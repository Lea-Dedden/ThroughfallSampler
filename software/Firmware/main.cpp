#include <SDI12.h>
#include <Wire.h>
#include "SparkFun_External_EEPROM.h" 

// Funktionen
void PULS_COUNT_1();
void PULS_COUNT_2();
void PULS_COUNT_3();
void PULS_COUNT_4();

void PULS_COUNT_5();
void PULS_COUNT_6();
void PULS_COUNT_7();
void PULS_COUNT_8();

void Delte_ARRAY ();
void SDI_Task();
void SET_ADRESS(String Str);
void Interface();
void SET_MULTI(String Str);
bool StrContains(char *str, char *sfind);
void clear_vcp();
void SEND_ALL_DATA_OUT();
void READ_EEPROM_MULTI();
void READ_EEPROM_ADRESS();
void PULS_TIMEOUT_TIMER();
void SET_TIMEOUT(String str);
void READ_EEPROM_TIMEOUT();


ExternalEEPROM myMem;

#define DATA_PIN  6   /*!< The pin of the SDI-12 data bus */
#define DIR       2
#define POWER_PIN -1 /*!< The sensor power pin (or -1 if not switching power) */

char sensorAddress = 'a';
int  state         = 0;

#define WAIT 0
#define INITIATE_CONCURRENT   1
#define INITIATE_MEASUREMENT  2

#define MAX_STRING_LENGHT 20

// PINS
#define KIPP_1 0
#define KIPP_2 7  
#define KIPP_3 4 
#define KIPP_4 1

#define KIPP_5 16
#define KIPP_6 17
#define KIPP_7 5
#define KIPP_8 9

#define KIPP_INPUTS 8

int PULS_TIMEOUT = 100;
bool TIMEOUT [KIPP_INPUTS] = {0};

//HX711 scale;

float C_KIPP[KIPP_INPUTS] = {0};  // 9 floats to hold simulated sensor data
float KIPP_Multi = 1;   // Multiplikator für Kippwaage

// Create object by which to communicate with the SDI-12 bus on SDIPIN
SDI12 slaveSDI12(DATA_PIN, DIR);

unsigned long previousMillis = 0; 

void parseSdi12Cmd(String command, String* dValues) {

  /* Ingests a command from an SDI-12 master, sends the applicable response, and
   * (when applicable) sets a flag to initiate a measurement
   */

  // First char of command is always either (a) the address of the device being
  // probed OR (b) a '?' for address query.
  // Do nothing if this command is addressed to a different device
  if (command.charAt(0) != sensorAddress && command.charAt(0) != '?') { return; }

  // If execution reaches this point, the slave should respond with something in
  // the form:   <address><responseStr><Carriage Return><Line Feed>
  // The following if-switch-case block determines what to put into <responseStr>,
  // and the full response will be constructed afterward. For '?!' (address query)
  // or 'a!' (acknowledge active) commands, responseStr is blank so section is skipped
  String responseStr = "";
  if (command.length() > 1) {
    switch (command.charAt(1)) {      
      case 'I':
        // Identify command
        // Slave should respond with ID message: 2-char SDI-12 version + 8-char
        // company name + 6-char sensor model + 3-char sensor version + 0-13 char S/N
        responseStr = "13WAGNERDE0000011.0001";  // Substitute proper ID String here
        break;
      case 'C':
        // Initiate concurrent measurement command
        // Slave should immediately respond with: "tttnn":
        //    3-digit (seconds until measurement is available) +
        //    2-digit (number of values that will be available)
        // Slave should also start a measurment and relinquish control of the data line
        responseStr =
          "00208";  // 4 values ready in 5 sec; Substitue sensor-specific values here
        // It is not preferred for the actual measurement to occur in this subfunction,
        // because doing to would hold the main program hostage until the measurement
        // is complete.  Instead, we'll just set a flag and handle the measurement
        // elsewhere.
        state = INITIATE_CONCURRENT;
        break;
        // NOTE: "aC1...9!" commands may be added by duplicating this case and adding
        //       additional states to the state flag
      case 'M':
        // Initiate measurement command
        // Slave should immediately respond with: "tttnn":
        //    3-digit (seconds until measurement is available) +
        //    1-digit (number of values that will be available)
        // Slave should also start a measurment but may keep control of the data line
        // until advertised time elapsed OR measurement is complete and service request
        // sent
        responseStr =
          "00208";  // 4 values ready in 2 sec; Substitue sensor-specific values here
        // It is not preferred for the actual measurement to occur in this subfunction,
        // because doing to would hold the main program hostage until the measurement is
        // complete.  Instead, we'll just set a flag and handle the measurement
        // elsewhere. It is preferred though not required that the slave send a service
        // request upon completion of the measurement.  This should be handled in the
        // main loop().
        state = INITIATE_MEASUREMENT;
        break;
        // NOTE: "aM1...9!" commands may be added by duplicating this case and adding
        //       additional states to the state flag

      case 'D':
        // Send data command
        // Slave should respond with a String of values
        // Values to be returned must be split into Strings of 35 characters or fewer
        // (75 or fewer for concurrent).  The number following "D" in the SDI-12 command
        // specifies which String to send    
        if((int)command.charAt(2) - 48 < 10)
        {
        responseStr = dValues[(int)command.charAt(2) - 48];
        //Serial.print("Send Data: ");     
        }    
        break;
      case 'A':
        // Change address command
        // Slave should respond with blank message (just the [new] address + <CR> +
        // <LF>)
        sensorAddress = command.charAt(2);
        break;
      default:
        // Mostly for debugging; send back UNKN if unexpected command received
        responseStr = "UNKN";
        break;
    }
  }

//Serial.print("Data Out:");
//Serial.println(String(sensorAddress) + responseStr);   
  // Issue the response speficied in the switch-case structure above.
  slaveSDI12.sendResponse(String(sensorAddress) + responseStr + "\r\n");
}

void formatOutputSDI(float* measurementValues, String* dValues, unsigned int maxChar) {
  /* Ingests an array of floats and produces Strings in SDI-12 output format */

  dValues[0] = "";
  int j      = 0;

  // upper limit on i should be number of elements in measurementValues
  for (int i = 0; i < 8; i++) {
    // Read float value "i" as a String with 6 deceimal digits
    // (NOTE: SDI-12 specifies max of 7 digits per value; we can only use 6
    //  decimal place precision if integer part is one digit)
    String valStr = String(measurementValues[i], 2);
    // Explictly add implied + sign if non-negative
    if (valStr.charAt(0) != '-') { valStr = '+' + valStr; }
    // Append dValues[j] if it will not exceed 35 (aM!) or 75 (aC!) characters
    if (dValues[j].length() + valStr.length() < maxChar) {
      dValues[j] += valStr;
    }
    // Start a new dValues "line" if appending would exceed 35/75 characters
    else {
      dValues[++j] = valStr;
    }
  }

  // Fill rest of dValues with blank strings
  while (j < 9) { dValues[++j] = ""; }
}

void setup() {
  pinMode(DIR, OUTPUT);
  pinMode(3, INPUT);
  digitalWrite(DIR, LOW);

  Wire.begin();

  slaveSDI12.begin();
  //pinMode(11, OUTPUT);
  pinMode(KIPP_1, INPUT);
  pinMode(KIPP_2, INPUT);
  pinMode(KIPP_3, INPUT);
  pinMode(KIPP_4, INPUT);

  pinMode(KIPP_5, INPUT);
  pinMode(KIPP_6, INPUT);
  pinMode(KIPP_7, INPUT);
  pinMode(KIPP_8, INPUT);  

//115200
  Serial.begin(9600);  // start serial for output

  //while (!Serial)  {}

  //Serial.println("Start");
  //delay(500);
  //Serial.println("Schreibe Daten");
  Wire.begin();

  // 200ms Serial Timeout -> Auf Zeilen abschlusswarten
  Serial.setTimeout(200);

  READ_EEPROM_MULTI();
  READ_EEPROM_ADRESS();
  READ_EEPROM_TIMEOUT();


  slaveSDI12.forceListen();  // sets SDIPIN as input to prepare for incoming message

  attachInterrupt(digitalPinToInterrupt(KIPP_1), PULS_COUNT_3, RISING);
  attachInterrupt(digitalPinToInterrupt(KIPP_2), PULS_COUNT_2, RISING);
  attachInterrupt(digitalPinToInterrupt(KIPP_3), PULS_COUNT_1, RISING);
  attachInterrupt(digitalPinToInterrupt(KIPP_4), PULS_COUNT_4, RISING);

  attachInterrupt(digitalPinToInterrupt(KIPP_5), PULS_COUNT_5, RISING);
  attachInterrupt(digitalPinToInterrupt(KIPP_6), PULS_COUNT_6, RISING);
  attachInterrupt(digitalPinToInterrupt(KIPP_7), PULS_COUNT_7, RISING);
  attachInterrupt(digitalPinToInterrupt(KIPP_8), PULS_COUNT_8, RISING); 
}

void PULS_COUNT_1()
{
  if (TIMEOUT[0] == false)
  C_KIPP[0] += KIPP_Multi;

  TIMEOUT[0] = true;
}

void PULS_COUNT_2()
{
  if (TIMEOUT[1] == false)
  C_KIPP[1] += KIPP_Multi;

  TIMEOUT[1] = true;   
}

void PULS_COUNT_3()
{
  if (TIMEOUT[2] == false)
  C_KIPP[2] += KIPP_Multi;

  TIMEOUT[2] = true;  
}

void PULS_COUNT_4()
{
  if (TIMEOUT[3] == false)
  C_KIPP[3] += KIPP_Multi;

  TIMEOUT[3] = true; 
}

void PULS_COUNT_5()
{
  if (TIMEOUT[4] == false)
  C_KIPP[4] += KIPP_Multi;

  TIMEOUT[4] = true; 
}

void PULS_COUNT_6()
{
  if (TIMEOUT[5] == false)
  C_KIPP[5] += KIPP_Multi;

  TIMEOUT[5] = true; 
}

void PULS_COUNT_7()
{
  if (TIMEOUT[6] == false)
  C_KIPP[6] += KIPP_Multi;

  TIMEOUT[6] = true; 
}

void PULS_COUNT_8()
{
  if (TIMEOUT[7] == false)
  C_KIPP[7] += KIPP_Multi;

  TIMEOUT[7] = true; 
}

void loop() {

  SDI_Task();
  Interface();
  PULS_TIMEOUT_TIMER();
}

void PULS_TIMEOUT_TIMER()
{
    unsigned long currentMillis = millis();

  if (currentMillis - previousMillis >= PULS_TIMEOUT) {
    previousMillis = currentMillis;

    for (int i = 0; i < KIPP_INPUTS; i++)
    {
      TIMEOUT[i] = false;
    }
  }
}

void Interface()
{
  
  char Data_Array [MAX_STRING_LENGHT];  
   if(Serial.available())
   {
      // Liest eine ganze Zeile ein und wandelt diese zu einem Char Array
      String data_serial = Serial.readString();
      data_serial.toCharArray(Data_Array, MAX_STRING_LENGHT);
      data_serial.trim();
      // Wenn Adresse gesendet wird
      if(StrContains(Data_Array,"Adr"))
      {
        SET_ADRESS(data_serial);       
      }
      else if (StrContains(Data_Array,"Mul"))
      {
        SET_MULTI(data_serial);
      }
      else if (StrContains(Data_Array,"Time"))
      {
        SET_TIMEOUT(data_serial);
      }
      else if (StrContains(Data_Array,"DATA"))
      {
        SEND_ALL_DATA_OUT();
      }
      else if (StrContains(Data_Array,"CLEAR"))
      {
        Delte_ARRAY ();
        myMem.erase();
      }
      else
      {
        clear_vcp();
      }
   }
}

void SEND_ALL_DATA_OUT()
{
  Serial.println("Adr;" + (String)sensorAddress);
  delay(1);
  Serial.println("Mul;" + (String)KIPP_Multi);
  delay(1);
  Serial.println("Val1;" + (String)C_KIPP[0]);
  delay(1);
  Serial.println("Val2;" + (String)C_KIPP[1]);
  delay(1);
  Serial.println("Val3;" + (String)C_KIPP[2]);
  delay(1);
  Serial.println("Val4;" + (String)C_KIPP[3]);
  delay(1);
  Serial.println("Val5;" + (String)C_KIPP[4]);
  delay(1);
  Serial.println("Val6;" + (String)C_KIPP[5]);
  delay(1);
  Serial.println("Val7;" + (String)C_KIPP[6]);
  delay(1);
  Serial.println("Val8;" + (String)C_KIPP[7]);
  delay(1);
    Serial.println("Time;" + (String)PULS_TIMEOUT);
  delay(1);
}

void SET_ADRESS(String Str)
{
  Serial.println(Str);
  char New_Adr = Str.charAt(4);

  // Schreiben der neuen SDI12 Adresse 
  if(isAlphaNumeric(New_Adr))
  {
      myMem.put(0, New_Adr);
      sensorAddress = New_Adr;      
  }
}

void SET_MULTI(String str)
{
  String TMP_MUL = str.substring(4, str.length());
  float New_Mul = TMP_MUL.toFloat();
  if(New_Mul > 0)
  {
    myMem.put(10, New_Mul);
    KIPP_Multi = New_Mul;
  }
}

void zerlegeInt32(int zahl, byte* bytes) {
    bytes[0] = (zahl >> 24) & 0xFF;
    bytes[1] = (zahl >> 16) & 0xFF;
    bytes[2] = (zahl >> 8) & 0xFF;
    bytes[3] = zahl & 0xFF;
}

void SET_TIMEOUT(String str)
{
  String TMP_MUL = str.substring(5, str.length());
  int New_Mul = TMP_MUL.toInt();

  if(New_Mul > 0)
  { 
    PULS_TIMEOUT = New_Mul;   
    byte bytes[4] = {0};
    zerlegeInt32(New_Mul, bytes);

    for (size_t i = 0; i < 4; i++)
    {
      myMem.put(20+i, bytes[i]);
    }    
    //myMem.put(20, New_Mul);     
  }
}

bool StrContains(char *str, char *sfind)
{
    char found = 0;
    char index = 0;
    char len;

    len = strlen(str);
    
    if (strlen(sfind) > len) {
        return 0;
    }
    while (index < len) {
        if (str[index] == sfind[found]) {
            found++;
            if (strlen(sfind) == found) {
                return 1;
            }
        }
        else {
            found = 0;
        }
        index++;
    }

    return 0;
}

void clear_vcp()
{
  while(Serial.available() > 0) {
  Serial.read();    
  }
}

void SDI_Task()
{     
  static String dValues[10];  // 10 String objects to hold the responses to aD0!-aD9! commands
  static String commandReceived = "";  // String object to hold the incoming command
  // If a byte is available, an SDI message is queued up. Read in the entire message
  // before proceding.  It may be more robust to add a single character per loop()
  // iteration to a static char buffer; however, the SDI-12 spec requires a precise
  // response time, and this method is invariant to the remaining loop() contents.
  int avail = slaveSDI12.available();
  if (avail < 0) {    
    //Serial.println("clear");
    slaveSDI12.clearBuffer();
  }  // Buffer is full; clear

  else if (avail > 0) {
    Serial.println("Data!!!!!");
    for (int a = 0; a < avail; a++) {
      char charReceived = slaveSDI12.read(); 
     // Serial.println(charReceived);
      //Serial.println(charReceived);     
      // Character '!' indicates the end of an SDI-12 command; if the current
      // character is '!', stop listening and respond to the command
      if (charReceived == '!') {
        //Serial.println("Command:" + commandReceived);
        // Command string is completed; do something with it
        parseSdi12Cmd(commandReceived, dValues);
        // '!' should be the last available character anyway, but exit the "for" loop
        // just in case there are any stray characters
        slaveSDI12.clearBuffer();
        // Clear command string to reset for next command
        commandReceived = "";
        break;
      }

      else if(!isAlphaNumeric(charReceived))
      {
          charReceived = 0;
      }
      else {
        // Append command string with new character
        commandReceived += String(charReceived);        
      }
    }
  }

  // For aM! and aC! commands, parseSdi12Cmd will modify "state" to indicate that
  // a measurement should be taken
  switch (state) {
    case WAIT: break;
    case INITIATE_CONCURRENT:
      // Do whatever the sensor is supposed to do here
      // For this example, we will just create arbitrary "simulated" sensor data
      // NOTE: Your application might have a different data type (e.g. int) and
      //       number of values to report!
      formatOutputSDI(C_KIPP, dValues, 75);
      state = WAIT;
      slaveSDI12.forceListen();  // sets SDI-12 pin as input to prepare for incoming
                                 // message AGAIN
      break;
    case INITIATE_MEASUREMENT:
      // Do whatever the sensor is supposed to do here
      // For this example, we will just create arbitrary "simulated" sensor data
      // NOTE: Your application might have a different data type (e.g. int) and
      //       number of values to report!

      // Populate the "dValues" String array with the values in SDI-12 format
      formatOutputSDI(C_KIPP, dValues, 35);
      Delte_ARRAY();
      // For aM!, Send "service request" (<address><CR><LF>) when data is ready
      slaveSDI12.sendResponse(String(sensorAddress) + "\r\n");
      state = WAIT;
      slaveSDI12.forceListen();  // sets SDI-12 pin as input to prepare for incoming
                                 // message AGAIN
      break;
  }
}

void Delte_ARRAY ()
{
  for (int i = 0; i < 8; i++)
  {
    C_KIPP[i] = 0;
  }  
}

void READ_EEPROM_ADRESS()
{
  char TMP = 0;
  myMem.get(0,TMP);

  // Prüfen ob Daten Korrekt sind
 if(isAlphaNumeric(TMP))
      {
          sensorAddress = TMP;
      }
}

void READ_EEPROM_MULTI()
{
  float TMP = 1;
  myMem.get(10,TMP);

  if(TMP > 0.0)
  {
    KIPP_Multi = TMP;
  }
}

int32_t bytesZuInt32(byte* bytes) {
    int32_t zahl = 0;
    zahl |= ((int32_t)bytes[0] << 24);
    zahl |= ((int32_t)bytes[1] << 16);
    zahl |= ((int32_t)bytes[2] << 8);
    zahl |= bytes[3];
    return zahl;
}

void READ_EEPROM_TIMEOUT()
{
    byte bytes[4] = {0};
    for (size_t i = 0; i < 4; i++)
    {
      myMem.get(20+i, bytes[i]);
    }

 // int8_t TMP = 10;
//  myMem.get(20,TMP);

  int32_t TMP = bytesZuInt32(bytes);

  if(TMP >= 20.0)
  {
    PULS_TIMEOUT = TMP;
  }
  else
    PULS_TIMEOUT = 100;

   // Serial.println(PULS_TIMEOUT);
}





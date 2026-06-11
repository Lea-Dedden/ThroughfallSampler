using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Text.RegularExpressions;

namespace SID_12_Interface
    // Zeit dif von log
{
    public partial class Form1 : Form
    {
        String TEXT_INFO = "Delon Wagner 10.2024 V2.1";


        public Form1()
        {
            InitializeComponent();
            label2.Text = TEXT_INFO;
            timer1.Interval = 1000;
            GB_Settings.Visible = false;
            GB_Readings.Visible = false;
            GET_SERIAL_PORTS();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                serialPort1.Close();
                GB_Settings.Visible = false;
                GB_Readings.Visible = false;
            }
        }

        private void GET_SERIAL_PORTS()
        {
            CB_PORTS.Items.Clear();

            string[] ports = SerialPort.GetPortNames();

            CB_PORTS.Items.Clear();
            ;

            foreach (string port in ports)
            {
                CB_PORTS.Items.Add(port);

            }

            if (ports.Length > 0)
            {
                CB_PORTS.SelectedIndex = 0;

            }
            else
            {
                CB_PORTS.Text = "No Port";

            }
        }

        private void B_Refresh_Click(object sender, EventArgs e)
        {
            GET_SERIAL_PORTS();
        }

        private void B_Connect_Click(object sender, EventArgs e)
        {
            if (CB_PORTS.SelectedIndex >= 0)
            {
                if (!serialPort1.IsOpen && serialPort2.PortName != CB_PORTS.Text)
                {
                    serialPort1.BaudRate = 115000;
                    serialPort1.PortName = CB_PORTS.Text;
                    serialPort1.Open();
                    GB_Settings.Visible = true;
                    GB_Readings.Visible = true;
                    timer1.Start();
                }
                else
                    MessageBox.Show("Port is busy");
            }
        }

        private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {

            if (this.InvokeRequired)
            {
                this.Invoke((MethodInvoker)delegate
                {
                    serialPort1_DataReceived(sender, e);
                });
                return;
            }

            string data_in_string;
            // Daten in den String Laden bis Abschlusskommt
            data_in_string = serialPort1.ReadTo("\r");

            // Daten in auswerte funktion weitergeben
            CHECK_INCOMMING_DATA(data_in_string);
            serialPort1.DiscardInBuffer();
        }
        // 1
        private void CHECK_INCOMMING_DATA(string data_in_string)
        {
            // COMMAND;WERT1#

            if (data_in_string.Contains("Adr"))
            {
                string [] Data = data_in_string.Split(';');
                L_Adr.Text = Data[1];     
            }

            else if (data_in_string.Contains("Mul"))
            {
                string[] Data = data_in_string.Split(';');
                L_Multi.Text = Data[1]; 
            }

            else if (data_in_string.Contains("Val1"))
            {
                string[] Data = data_in_string.Split(';');
                Value1.Text = Data[1];
            }

            else if (data_in_string.Contains("Val2"))
            {
                string[] Data = data_in_string.Split(';');
                Value2.Text = Data[1];
            }

            else if (data_in_string.Contains("Val3"))
            {
                string[] Data = data_in_string.Split(';');
                Value3.Text = Data[1];
            }

            else if (data_in_string.Contains("Val4"))
            {
                string[] Data = data_in_string.Split(';');
                Value4.Text = Data[1];
            }

            else if (data_in_string.Contains("Val5"))
            {
                string[] Data = data_in_string.Split(';');
                Value5.Text = Data[1];
            }

            else if (data_in_string.Contains("Val6"))
            {
                string[] Data = data_in_string.Split(';');
                Value6.Text = Data[1];
            }

            else if (data_in_string.Contains("Val7"))
            {
                string[] Data = data_in_string.Split(';');
                Value7.Text = Data[1];
            }

            else if (data_in_string.Contains("Val8"))
            {
                string[] Data = data_in_string.Split(';');
                Value8.Text = Data[1];
            }
            else if (data_in_string.Contains("Time"))
            {
                string[] Data = data_in_string.Split(';');
                L_Time.Text = Data[1];
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (TB_Adress.Text.Length == 1 && IsAlphaNumeric(TB_Adress.Text))
            {
                string tmp = "Adr;" + TB_Adress.Text;
                serialPort1.WriteLine(tmp);
            }
            else
                MessageBox.Show("Just one Charakter!\n a-z A-Z 0-9");
        }

        public static bool IsAlphaNumeric(string strToCheck)
        {
            return strToCheck.All(char.IsLetterOrDigit);
        }

        private void B_Set_Multi_Click(object sender, EventArgs e)
        {
            if (TB_Multi.Text.Length > 0)
            {
                float value = 0;
                float.TryParse(TB_Multi.Text, out value);

                if (value > 0 && value <= 100)
                {
                    string tmp = "Mul;" + value.ToString();
                    tmp = tmp.Replace(',','.');
                    serialPort1.WriteLine(tmp);
                }
                else
                    MessageBox.Show("Must be > 0 and < 100");
            }
            else
                MessageBox.Show("Wrong data");

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if(serialPort1.IsOpen)
            {
                string tmp = "DATA";
                serialPort1.WriteLine(tmp);
            }
        }

        private void B_CLEAR_Click(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                string tmp = "CLEAR";
                serialPort1.WriteLine(tmp);
            }
        }


        private void label2_MouseLeave(object sender, EventArgs e)
        {
            label2.Text = TEXT_INFO;
        }

        private void GB_Settings_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            int check = 0;
            if (TB_TIMEOUT.Text.Length > 0)
            {
                int.TryParse(TB_TIMEOUT.Text, out check);
                if (check >= 20 && check <= 5000)
                {
                    string tmp = "Time;" + TB_TIMEOUT.Text;
                    serialPort1.WriteLine(tmp);
                }
                else
                    MessageBox.Show("Error!\n 20-5000");
            }
            else
                MessageBox.Show("Error!\n 20-5000");
        }
    }
}

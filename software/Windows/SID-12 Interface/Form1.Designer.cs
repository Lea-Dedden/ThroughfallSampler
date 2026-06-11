namespace SID_12_Interface
{
    partial class Form1
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.Interface = new System.Windows.Forms.GroupBox();
            this.B_Disconnect = new System.Windows.Forms.Button();
            this.B_Refresh = new System.Windows.Forms.Button();
            this.B_Connect = new System.Windows.Forms.Button();
            this.CB_PORTS = new System.Windows.Forms.ComboBox();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.serialPort2 = new System.IO.Ports.SerialPort(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.TB_Adress = new System.Windows.Forms.TextBox();
            this.TB_Multi = new System.Windows.Forms.TextBox();
            this.B_Set_Adress = new System.Windows.Forms.Button();
            this.B_Set_Multi = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.L_IN1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.GB_Settings = new System.Windows.Forms.GroupBox();
            this.B_CLEAR = new System.Windows.Forms.Button();
            this.L_Multi = new System.Windows.Forms.Label();
            this.L_Adr = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.L_IN2 = new System.Windows.Forms.Label();
            this.L_IN3 = new System.Windows.Forms.Label();
            this.L_IN4 = new System.Windows.Forms.Label();
            this.Value1 = new System.Windows.Forms.Label();
            this.Value2 = new System.Windows.Forms.Label();
            this.Value3 = new System.Windows.Forms.Label();
            this.Value4 = new System.Windows.Forms.Label();
            this.GB_Readings = new System.Windows.Forms.GroupBox();
            this.Value8 = new System.Windows.Forms.Label();
            this.Value7 = new System.Windows.Forms.Label();
            this.Value6 = new System.Windows.Forms.Label();
            this.Value5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.L_Time = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.TB_TIMEOUT = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.Interface.SuspendLayout();
            this.GB_Settings.SuspendLayout();
            this.GB_Readings.SuspendLayout();
            this.SuspendLayout();
            // 
            // Interface
            // 
            this.Interface.Controls.Add(this.B_Disconnect);
            this.Interface.Controls.Add(this.B_Refresh);
            this.Interface.Controls.Add(this.B_Connect);
            this.Interface.Controls.Add(this.CB_PORTS);
            this.Interface.Location = new System.Drawing.Point(13, 12);
            this.Interface.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Interface.Name = "Interface";
            this.Interface.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Interface.Size = new System.Drawing.Size(136, 158);
            this.Interface.TabIndex = 0;
            this.Interface.TabStop = false;
            this.Interface.Text = "Connect";
            // 
            // B_Disconnect
            // 
            this.B_Disconnect.Location = new System.Drawing.Point(5, 110);
            this.B_Disconnect.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.B_Disconnect.Name = "B_Disconnect";
            this.B_Disconnect.Size = new System.Drawing.Size(121, 23);
            this.B_Disconnect.TabIndex = 2;
            this.B_Disconnect.Text = "Disconnect";
            this.B_Disconnect.UseVisualStyleBackColor = true;
            this.B_Disconnect.Click += new System.EventHandler(this.button1_Click);
            // 
            // B_Refresh
            // 
            this.B_Refresh.Location = new System.Drawing.Point(5, 50);
            this.B_Refresh.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.B_Refresh.Name = "B_Refresh";
            this.B_Refresh.Size = new System.Drawing.Size(121, 23);
            this.B_Refresh.TabIndex = 1;
            this.B_Refresh.Text = "Refresh";
            this.B_Refresh.UseVisualStyleBackColor = true;
            this.B_Refresh.Click += new System.EventHandler(this.B_Refresh_Click);
            // 
            // B_Connect
            // 
            this.B_Connect.Location = new System.Drawing.Point(5, 80);
            this.B_Connect.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.B_Connect.Name = "B_Connect";
            this.B_Connect.Size = new System.Drawing.Size(121, 23);
            this.B_Connect.TabIndex = 1;
            this.B_Connect.Text = "Connect";
            this.B_Connect.UseVisualStyleBackColor = true;
            this.B_Connect.Click += new System.EventHandler(this.B_Connect_Click);
            // 
            // CB_PORTS
            // 
            this.CB_PORTS.FormattingEnabled = true;
            this.CB_PORTS.Location = new System.Drawing.Point(5, 21);
            this.CB_PORTS.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.CB_PORTS.Name = "CB_PORTS";
            this.CB_PORTS.Size = new System.Drawing.Size(121, 24);
            this.CB_PORTS.TabIndex = 1;
            // 
            // serialPort1
            // 
            this.serialPort1.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort1_DataReceived);
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(10, 258);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 13);
            this.label2.TabIndex = 16;
            this.label2.MouseLeave += new System.EventHandler(this.label2_MouseLeave);
            // 
            // TB_Adress
            // 
            this.TB_Adress.Location = new System.Drawing.Point(68, 54);
            this.TB_Adress.Margin = new System.Windows.Forms.Padding(4);
            this.TB_Adress.Name = "TB_Adress";
            this.TB_Adress.Size = new System.Drawing.Size(69, 22);
            this.TB_Adress.TabIndex = 17;
            // 
            // TB_Multi
            // 
            this.TB_Multi.Location = new System.Drawing.Point(68, 84);
            this.TB_Multi.Margin = new System.Windows.Forms.Padding(4);
            this.TB_Multi.Name = "TB_Multi";
            this.TB_Multi.Size = new System.Drawing.Size(69, 22);
            this.TB_Multi.TabIndex = 18;
            // 
            // B_Set_Adress
            // 
            this.B_Set_Adress.Location = new System.Drawing.Point(147, 51);
            this.B_Set_Adress.Margin = new System.Windows.Forms.Padding(4);
            this.B_Set_Adress.Name = "B_Set_Adress";
            this.B_Set_Adress.Size = new System.Drawing.Size(61, 28);
            this.B_Set_Adress.TabIndex = 19;
            this.B_Set_Adress.Text = "Set";
            this.B_Set_Adress.UseVisualStyleBackColor = true;
            this.B_Set_Adress.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // B_Set_Multi
            // 
            this.B_Set_Multi.Location = new System.Drawing.Point(147, 86);
            this.B_Set_Multi.Margin = new System.Windows.Forms.Padding(4);
            this.B_Set_Multi.Name = "B_Set_Multi";
            this.B_Set_Multi.Size = new System.Drawing.Size(61, 28);
            this.B_Set_Multi.TabIndex = 20;
            this.B_Set_Multi.Text = "Set";
            this.B_Set_Multi.UseVisualStyleBackColor = true;
            this.B_Set_Multi.Click += new System.EventHandler(this.B_Set_Multi_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 58);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 16);
            this.label1.TabIndex = 21;
            this.label1.Text = "Adress:";
            // 
            // L_IN1
            // 
            this.L_IN1.AutoSize = true;
            this.L_IN1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.L_IN1.Location = new System.Drawing.Point(8, 25);
            this.L_IN1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.L_IN1.Name = "L_IN1";
            this.L_IN1.Size = new System.Drawing.Size(71, 24);
            this.L_IN1.TabIndex = 22;
            this.L_IN1.Text = "Input 1:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(23, 86);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 16);
            this.label4.TabIndex = 23;
            this.label4.Text = "Multi:";
            // 
            // GB_Settings
            // 
            this.GB_Settings.Controls.Add(this.button1);
            this.GB_Settings.Controls.Add(this.TB_TIMEOUT);
            this.GB_Settings.Controls.Add(this.label12);
            this.GB_Settings.Controls.Add(this.L_Time);
            this.GB_Settings.Controls.Add(this.label10);
            this.GB_Settings.Controls.Add(this.B_CLEAR);
            this.GB_Settings.Controls.Add(this.L_Multi);
            this.GB_Settings.Controls.Add(this.L_Adr);
            this.GB_Settings.Controls.Add(this.label5);
            this.GB_Settings.Controls.Add(this.label3);
            this.GB_Settings.Controls.Add(this.TB_Adress);
            this.GB_Settings.Controls.Add(this.label4);
            this.GB_Settings.Controls.Add(this.TB_Multi);
            this.GB_Settings.Controls.Add(this.B_Set_Adress);
            this.GB_Settings.Controls.Add(this.label1);
            this.GB_Settings.Controls.Add(this.B_Set_Multi);
            this.GB_Settings.Location = new System.Drawing.Point(156, 15);
            this.GB_Settings.Margin = new System.Windows.Forms.Padding(4);
            this.GB_Settings.Name = "GB_Settings";
            this.GB_Settings.Padding = new System.Windows.Forms.Padding(4);
            this.GB_Settings.Size = new System.Drawing.Size(216, 186);
            this.GB_Settings.TabIndex = 24;
            this.GB_Settings.TabStop = false;
            this.GB_Settings.Text = "Setting";
            this.GB_Settings.Enter += new System.EventHandler(this.GB_Settings_Enter);
            // 
            // B_CLEAR
            // 
            this.B_CLEAR.Location = new System.Drawing.Point(147, 122);
            this.B_CLEAR.Margin = new System.Windows.Forms.Padding(4);
            this.B_CLEAR.Name = "B_CLEAR";
            this.B_CLEAR.Size = new System.Drawing.Size(61, 54);
            this.B_CLEAR.TabIndex = 28;
            this.B_CLEAR.Text = "Clear";
            this.B_CLEAR.UseVisualStyleBackColor = true;
            this.B_CLEAR.Click += new System.EventHandler(this.B_CLEAR_Click);
            // 
            // L_Multi
            // 
            this.L_Multi.AutoSize = true;
            this.L_Multi.Location = new System.Drawing.Point(79, 160);
            this.L_Multi.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.L_Multi.Name = "L_Multi";
            this.L_Multi.Size = new System.Drawing.Size(34, 16);
            this.L_Multi.TabIndex = 27;
            this.L_Multi.Text = "Multi";
            // 
            // L_Adr
            // 
            this.L_Adr.AutoSize = true;
            this.L_Adr.Location = new System.Drawing.Point(82, 141);
            this.L_Adr.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.L_Adr.Name = "L_Adr";
            this.L_Adr.Size = new System.Drawing.Size(31, 16);
            this.L_Adr.TabIndex = 26;
            this.L_Adr.Text = "Adr.";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(29, 160);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 16);
            this.label5.TabIndex = 25;
            this.label5.Text = "Multi:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 141);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 16);
            this.label3.TabIndex = 24;
            this.label3.Text = "Adress:";
            // 
            // L_IN2
            // 
            this.L_IN2.AutoSize = true;
            this.L_IN2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.L_IN2.Location = new System.Drawing.Point(8, 54);
            this.L_IN2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.L_IN2.Name = "L_IN2";
            this.L_IN2.Size = new System.Drawing.Size(71, 24);
            this.L_IN2.TabIndex = 25;
            this.L_IN2.Text = "Input 2:";
            // 
            // L_IN3
            // 
            this.L_IN3.AutoSize = true;
            this.L_IN3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.L_IN3.Location = new System.Drawing.Point(8, 84);
            this.L_IN3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.L_IN3.Name = "L_IN3";
            this.L_IN3.Size = new System.Drawing.Size(71, 24);
            this.L_IN3.TabIndex = 26;
            this.L_IN3.Text = "Input 3:";
            // 
            // L_IN4
            // 
            this.L_IN4.AutoSize = true;
            this.L_IN4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.L_IN4.Location = new System.Drawing.Point(8, 113);
            this.L_IN4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.L_IN4.Name = "L_IN4";
            this.L_IN4.Size = new System.Drawing.Size(71, 24);
            this.L_IN4.TabIndex = 27;
            this.L_IN4.Text = "Input 4:";
            // 
            // Value1
            // 
            this.Value1.AutoSize = true;
            this.Value1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Value1.Location = new System.Drawing.Point(111, 25);
            this.Value1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Value1.Name = "Value1";
            this.Value1.Size = new System.Drawing.Size(59, 24);
            this.Value1.TabIndex = 28;
            this.Value1.Text = "Value";
            // 
            // Value2
            // 
            this.Value2.AutoSize = true;
            this.Value2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Value2.Location = new System.Drawing.Point(111, 54);
            this.Value2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Value2.Name = "Value2";
            this.Value2.Size = new System.Drawing.Size(59, 24);
            this.Value2.TabIndex = 29;
            this.Value2.Text = "Value";
            // 
            // Value3
            // 
            this.Value3.AutoSize = true;
            this.Value3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Value3.Location = new System.Drawing.Point(111, 84);
            this.Value3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Value3.Name = "Value3";
            this.Value3.Size = new System.Drawing.Size(59, 24);
            this.Value3.TabIndex = 30;
            this.Value3.Text = "Value";
            // 
            // Value4
            // 
            this.Value4.AutoSize = true;
            this.Value4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Value4.Location = new System.Drawing.Point(111, 113);
            this.Value4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Value4.Name = "Value4";
            this.Value4.Size = new System.Drawing.Size(59, 24);
            this.Value4.TabIndex = 31;
            this.Value4.Text = "Value";
            // 
            // GB_Readings
            // 
            this.GB_Readings.Controls.Add(this.Value8);
            this.GB_Readings.Controls.Add(this.Value7);
            this.GB_Readings.Controls.Add(this.Value6);
            this.GB_Readings.Controls.Add(this.Value5);
            this.GB_Readings.Controls.Add(this.label6);
            this.GB_Readings.Controls.Add(this.label7);
            this.GB_Readings.Controls.Add(this.label8);
            this.GB_Readings.Controls.Add(this.label9);
            this.GB_Readings.Controls.Add(this.L_IN1);
            this.GB_Readings.Controls.Add(this.Value4);
            this.GB_Readings.Controls.Add(this.L_IN2);
            this.GB_Readings.Controls.Add(this.Value3);
            this.GB_Readings.Controls.Add(this.L_IN3);
            this.GB_Readings.Controls.Add(this.Value2);
            this.GB_Readings.Controls.Add(this.L_IN4);
            this.GB_Readings.Controls.Add(this.Value1);
            this.GB_Readings.Location = new System.Drawing.Point(380, 15);
            this.GB_Readings.Margin = new System.Windows.Forms.Padding(4);
            this.GB_Readings.Name = "GB_Readings";
            this.GB_Readings.Padding = new System.Windows.Forms.Padding(4);
            this.GB_Readings.Size = new System.Drawing.Size(232, 267);
            this.GB_Readings.TabIndex = 32;
            this.GB_Readings.TabStop = false;
            this.GB_Readings.Text = "Readings";
            // 
            // Value8
            // 
            this.Value8.AutoSize = true;
            this.Value8.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Value8.Location = new System.Drawing.Point(111, 232);
            this.Value8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Value8.Name = "Value8";
            this.Value8.Size = new System.Drawing.Size(59, 24);
            this.Value8.TabIndex = 39;
            this.Value8.Text = "Value";
            // 
            // Value7
            // 
            this.Value7.AutoSize = true;
            this.Value7.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Value7.Location = new System.Drawing.Point(111, 203);
            this.Value7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Value7.Name = "Value7";
            this.Value7.Size = new System.Drawing.Size(59, 24);
            this.Value7.TabIndex = 38;
            this.Value7.Text = "Value";
            // 
            // Value6
            // 
            this.Value6.AutoSize = true;
            this.Value6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Value6.Location = new System.Drawing.Point(111, 173);
            this.Value6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Value6.Name = "Value6";
            this.Value6.Size = new System.Drawing.Size(59, 24);
            this.Value6.TabIndex = 37;
            this.Value6.Text = "Value";
            // 
            // Value5
            // 
            this.Value5.AutoSize = true;
            this.Value5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Value5.Location = new System.Drawing.Point(111, 144);
            this.Value5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Value5.Name = "Value5";
            this.Value5.Size = new System.Drawing.Size(59, 24);
            this.Value5.TabIndex = 36;
            this.Value5.Text = "Value";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(8, 144);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(71, 24);
            this.label6.TabIndex = 32;
            this.label6.Text = "Input 5:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(8, 173);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(71, 24);
            this.label7.TabIndex = 33;
            this.label7.Text = "Input 6:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(8, 203);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(71, 24);
            this.label8.TabIndex = 34;
            this.label8.Text = "Input 7:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(8, 232);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(71, 24);
            this.label9.TabIndex = 35;
            this.label9.Text = "Input 8:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(13, 122);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(59, 16);
            this.label10.TabIndex = 29;
            this.label10.Text = "Timeout:";
            // 
            // L_Time
            // 
            this.L_Time.AutoSize = true;
            this.L_Time.Location = new System.Drawing.Point(81, 122);
            this.L_Time.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.L_Time.Name = "L_Time";
            this.L_Time.Size = new System.Drawing.Size(56, 16);
            this.L_Time.TabIndex = 30;
            this.L_Time.Text = "Timeout";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(5, 28);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(59, 16);
            this.label12.TabIndex = 31;
            this.label12.Text = "Timeout:";
            // 
            // TB_TIMEOUT
            // 
            this.TB_TIMEOUT.Location = new System.Drawing.Point(68, 24);
            this.TB_TIMEOUT.Margin = new System.Windows.Forms.Padding(4);
            this.TB_TIMEOUT.Name = "TB_TIMEOUT";
            this.TB_TIMEOUT.Size = new System.Drawing.Size(69, 22);
            this.TB_TIMEOUT.TabIndex = 32;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(147, 18);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(61, 28);
            this.button1.TabIndex = 33;
            this.button1.Text = "Set";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_2);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(620, 286);
            this.Controls.Add(this.GB_Readings);
            this.Controls.Add(this.GB_Settings);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Interface);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.Text = "Interface";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Interface.ResumeLayout(false);
            this.GB_Settings.ResumeLayout(false);
            this.GB_Settings.PerformLayout();
            this.GB_Readings.ResumeLayout(false);
            this.GB_Readings.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox Interface;
        private System.Windows.Forms.Button B_Refresh;
        private System.Windows.Forms.Button B_Connect;
        private System.Windows.Forms.ComboBox CB_PORTS;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.Button B_Disconnect;
        private System.IO.Ports.SerialPort serialPort2;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TB_Adress;
        private System.Windows.Forms.TextBox TB_Multi;
        private System.Windows.Forms.Button B_Set_Adress;
        private System.Windows.Forms.Button B_Set_Multi;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label L_IN1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox GB_Settings;
        private System.Windows.Forms.Label L_IN2;
        private System.Windows.Forms.Label L_IN3;
        private System.Windows.Forms.Label L_IN4;
        private System.Windows.Forms.Label Value1;
        private System.Windows.Forms.Label Value2;
        private System.Windows.Forms.Label Value3;
        private System.Windows.Forms.Label Value4;
        private System.Windows.Forms.GroupBox GB_Readings;
        private System.Windows.Forms.Label L_Multi;
        private System.Windows.Forms.Label L_Adr;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button B_CLEAR;
        private System.Windows.Forms.Label Value8;
        private System.Windows.Forms.Label Value7;
        private System.Windows.Forms.Label Value6;
        private System.Windows.Forms.Label Value5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label L_Time;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox TB_TIMEOUT;
        private System.Windows.Forms.Label label12;
    }
}


namespace CanCOMApplication
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.button2 = new System.Windows.Forms.Button();
            this.dataGridViewDevices = new System.Windows.Forms.DataGridView();
            this.DeviceID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DeviceName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DeviceDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button3 = new System.Windows.Forms.Button();
            this.dataGridViewCanTraffic = new System.Windows.Forms.DataGridView();
            this.CanID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Data_Length = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Data = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Timestamp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Direction = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button1 = new System.Windows.Forms.Button();
            this.dataGridViewTestCases = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.test_case = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.send_frame_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataLen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.data_to_send = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.receive_frame_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.timeout = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.relatedDeviceID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.connectionStatusLabel = new System.Windows.Forms.Label();
            this.ElapsedTimeLabel = new System.Windows.Forms.Label();
            this.simulationStartBTN = new System.Windows.Forms.Button();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.availablePorts = new System.Windows.Forms.ComboBox();
            this.tabControl1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDevices)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCanTraffic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTestCases)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1235, 676);
            this.tabControl1.TabIndex = 2;
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(4, 24);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1227, 648);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Configuration";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.button2);
            this.tabPage2.Controls.Add(this.dataGridViewDevices);
            this.tabPage2.Controls.Add(this.button3);
            this.tabPage2.Controls.Add(this.dataGridViewCanTraffic);
            this.tabPage2.Controls.Add(this.button1);
            this.tabPage2.Controls.Add(this.dataGridViewTestCases);
            this.tabPage2.Controls.Add(this.groupBox3);
            this.tabPage2.Controls.Add(this.simulationStartBTN);
            this.tabPage2.Location = new System.Drawing.Point(4, 24);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1227, 648);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Run";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(1120, 76);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(99, 23);
            this.button2.TabIndex = 9;
            this.button2.Text = "Delete selected";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // dataGridViewDevices
            // 
            this.dataGridViewDevices.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewDevices.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DeviceID,
            this.DeviceName,
            this.DeviceDescription});
            this.dataGridViewDevices.Location = new System.Drawing.Point(8, 336);
            this.dataGridViewDevices.Name = "dataGridViewDevices";
            this.dataGridViewDevices.RowTemplate.Height = 25;
            this.dataGridViewDevices.Size = new System.Drawing.Size(1211, 127);
            this.dataGridViewDevices.TabIndex = 8;
            // 
            // DeviceID
            // 
            this.DeviceID.HeaderText = "Device ID";
            this.DeviceID.Name = "DeviceID";
            // 
            // DeviceName
            // 
            this.DeviceName.HeaderText = "Device name";
            this.DeviceName.Name = "DeviceName";
            this.DeviceName.Width = 200;
            // 
            // DeviceDescription
            // 
            this.DeviceDescription.HeaderText = "Device Description";
            this.DeviceDescription.Name = "DeviceDescription";
            this.DeviceDescription.Width = 500;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(829, 19);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(125, 51);
            this.button3.TabIndex = 7;
            this.button3.Text = "chart creator";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // dataGridViewCanTraffic
            // 
            this.dataGridViewCanTraffic.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewCanTraffic.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CanID,
            this.Data_Length,
            this.Data,
            this.Timestamp,
            this.Direction});
            this.dataGridViewCanTraffic.Location = new System.Drawing.Point(8, 105);
            this.dataGridViewCanTraffic.Name = "dataGridViewCanTraffic";
            this.dataGridViewCanTraffic.RowTemplate.Height = 25;
            this.dataGridViewCanTraffic.Size = new System.Drawing.Size(1211, 225);
            this.dataGridViewCanTraffic.TabIndex = 6;
            // 
            // CanID
            // 
            this.CanID.HeaderText = "Frame ID";
            this.CanID.Name = "CanID";
            // 
            // Data_Length
            // 
            this.Data_Length.HeaderText = "Data Length";
            this.Data_Length.Name = "Data_Length";
            // 
            // Data
            // 
            this.Data.HeaderText = "Data";
            this.Data.Name = "Data";
            this.Data.Width = 200;
            // 
            // Timestamp
            // 
            this.Timestamp.HeaderText = "Timestamp";
            this.Timestamp.Name = "Timestamp";
            // 
            // Direction
            // 
            this.Direction.HeaderText = "Direction";
            this.Direction.Name = "Direction";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1122, 6);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(99, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "Save to DB";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataGridViewTestCases
            // 
            this.dataGridViewTestCases.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewTestCases.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.test_case,
            this.send_frame_id,
            this.dataLen,
            this.data_to_send,
            this.receive_frame_id,
            this.timeout,
            this.description,
            this.relatedDeviceID});
            this.dataGridViewTestCases.Location = new System.Drawing.Point(8, 471);
            this.dataGridViewTestCases.Name = "dataGridViewTestCases";
            this.dataGridViewTestCases.RowTemplate.Height = 25;
            this.dataGridViewTestCases.Size = new System.Drawing.Size(1211, 171);
            this.dataGridViewTestCases.TabIndex = 4;
            // 
            // ID
            // 
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            // 
            // test_case
            // 
            this.test_case.HeaderText = "test case";
            this.test_case.Name = "test_case";
            // 
            // send_frame_id
            // 
            this.send_frame_id.HeaderText = "send frame id";
            this.send_frame_id.Name = "send_frame_id";
            // 
            // dataLen
            // 
            this.dataLen.HeaderText = "data length";
            this.dataLen.Name = "dataLen";
            // 
            // data_to_send
            // 
            this.data_to_send.HeaderText = "data to send";
            this.data_to_send.Name = "data_to_send";
            this.data_to_send.Width = 200;
            // 
            // receive_frame_id
            // 
            this.receive_frame_id.HeaderText = "receive frame id";
            this.receive_frame_id.Name = "receive_frame_id";
            // 
            // timeout
            // 
            this.timeout.HeaderText = "timeout";
            this.timeout.Name = "timeout";
            // 
            // description
            // 
            this.description.HeaderText = "description";
            this.description.Name = "description";
            this.description.Width = 200;
            // 
            // relatedDeviceID
            // 
            this.relatedDeviceID.HeaderText = "device id";
            this.relatedDeviceID.Name = "relatedDeviceID";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.connectionStatusLabel);
            this.groupBox3.Controls.Add(this.ElapsedTimeLabel);
            this.groupBox3.Location = new System.Drawing.Point(62, 6);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(151, 93);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Simulation data";
            // 
            // connectionStatusLabel
            // 
            this.connectionStatusLabel.AutoSize = true;
            this.connectionStatusLabel.Location = new System.Drawing.Point(6, 54);
            this.connectionStatusLabel.Name = "connectionStatusLabel";
            this.connectionStatusLabel.Size = new System.Drawing.Size(117, 15);
            this.connectionStatusLabel.TabIndex = 2;
            this.connectionStatusLabel.Text = "Status: Disconnected";
            // 
            // ElapsedTimeLabel
            // 
            this.ElapsedTimeLabel.AutoSize = true;
            this.ElapsedTimeLabel.Location = new System.Drawing.Point(6, 31);
            this.ElapsedTimeLabel.Name = "ElapsedTimeLabel";
            this.ElapsedTimeLabel.Size = new System.Drawing.Size(77, 15);
            this.ElapsedTimeLabel.TabIndex = 2;
            this.ElapsedTimeLabel.Text = "Elapsed time:";
            // 
            // simulationStartBTN
            // 
            this.simulationStartBTN.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("simulationStartBTN.BackgroundImage")));
            this.simulationStartBTN.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.simulationStartBTN.Location = new System.Drawing.Point(8, 25);
            this.simulationStartBTN.Name = "simulationStartBTN";
            this.simulationStartBTN.Size = new System.Drawing.Size(50, 50);
            this.simulationStartBTN.TabIndex = 0;
            this.simulationStartBTN.UseVisualStyleBackColor = true;
            this.simulationStartBTN.Click += new System.EventHandler(this.simulationStartBTN_Click);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.groupBox2);
            this.tabPage3.Controls.Add(this.groupBox1);
            this.tabPage3.Location = new System.Drawing.Point(4, 24);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(1227, 648);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Settings";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox2.Location = new System.Drawing.Point(3, 193);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(235, 221);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Database connection settings";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.comboBox2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.availablePorts);
            this.groupBox1.Location = new System.Drawing.Point(548, 193);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(244, 221);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "USB connection settings";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(69, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Port";
            // 
            // comboBox2
            // 
            this.comboBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "300",
            "600",
            "1200",
            "2400",
            "4800",
            "9600",
            "14400",
            "19200",
            "28800",
            "31250",
            "38400",
            "57600",
            "115200"});
            this.comboBox2.Location = new System.Drawing.Point(104, 51);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(132, 23);
            this.comboBox2.TabIndex = 2;
            this.comboBox2.SelectionChangeCommitted += new System.EventHandler(this.comboBox2_SelectionChangeCommitted);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(41, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Baud rate";
            // 
            // availablePorts
            // 
            this.availablePorts.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.availablePorts.FormattingEnabled = true;
            this.availablePorts.Location = new System.Drawing.Point(104, 22);
            this.availablePorts.Name = "availablePorts";
            this.availablePorts.Size = new System.Drawing.Size(132, 23);
            this.availablePorts.TabIndex = 0;
            this.availablePorts.SelectedIndexChanged += new System.EventHandler(this.availablePorts_SelectedIndexChanged);
            this.availablePorts.SelectionChangeCommitted += new System.EventHandler(this.availablePorts_SelectionChangeCommitted);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1235, 676);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.tabControl1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDevices)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCanTraffic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTestCases)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private TabPage tabPage3;
        private GroupBox groupBox2;
        private GroupBox groupBox1;
        private ComboBox availablePorts;
        private Label label1;
        private ComboBox comboBox2;
        private Label label2;
        private Button simulationStartBTN;
        private GroupBox groupBox3;
        private Label ElapsedTimeLabel;
        private Label connectionStatusLabel;
        private DataGridView dataGridViewTestCases;
        private Button button1;
        private DataGridView dataGridViewCanTraffic;
        private DataGridViewTextBoxColumn CanID;
        private DataGridViewTextBoxColumn Data_Length;
        private DataGridViewTextBoxColumn Data;
        private DataGridViewTextBoxColumn Timestamp;
        private DataGridViewTextBoxColumn Direction;
        private Button button3;
        private DataGridView dataGridViewDevices;
        private DataGridViewTextBoxColumn DeviceID;
        private DataGridViewTextBoxColumn DeviceName;
        private DataGridViewTextBoxColumn DeviceDescription;
        private Button button2;
        private DataGridViewTextBoxColumn ID;
        private DataGridViewTextBoxColumn test_case;
        private DataGridViewTextBoxColumn send_frame_id;
        private DataGridViewTextBoxColumn dataLen;
        private DataGridViewTextBoxColumn data_to_send;
        private DataGridViewTextBoxColumn receive_frame_id;
        private DataGridViewTextBoxColumn timeout;
        private DataGridViewTextBoxColumn description;
        private DataGridViewTextBoxColumn relatedDeviceID;
    }
}
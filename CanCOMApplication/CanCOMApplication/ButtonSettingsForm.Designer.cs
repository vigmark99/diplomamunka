namespace CanCOMApplication
{
    partial class ButtonSettingsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkBoxStartPressed = new System.Windows.Forms.CheckBox();
            this.textBoxSendingInterval = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.comboBoxMessageGenerationMethod = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxButtonText = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textBoxCanData8 = new System.Windows.Forms.TextBox();
            this.textBoxCanData7 = new System.Windows.Forms.TextBox();
            this.textBoxCanData6 = new System.Windows.Forms.TextBox();
            this.textBoxCanData5 = new System.Windows.Forms.TextBox();
            this.textBoxCanData4 = new System.Windows.Forms.TextBox();
            this.textBoxCanData3 = new System.Windows.Forms.TextBox();
            this.textBoxCanData2 = new System.Windows.Forms.TextBox();
            this.textBoxCanData1 = new System.Windows.Forms.TextBox();
            this.textBoxCanDataLen = new System.Windows.Forms.TextBox();
            this.textBoxCanID = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkBoxStartPressed);
            this.groupBox1.Controls.Add(this.textBoxSendingInterval);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.comboBoxMessageGenerationMethod);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.textBoxButtonText);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(345, 161);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "General Button Settings";
            // 
            // checkBoxStartPressed
            // 
            this.checkBoxStartPressed.AutoSize = true;
            this.checkBoxStartPressed.Location = new System.Drawing.Point(10, 120);
            this.checkBoxStartPressed.Name = "checkBoxStartPressed";
            this.checkBoxStartPressed.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.checkBoxStartPressed.Size = new System.Drawing.Size(134, 19);
            this.checkBoxStartPressed.TabIndex = 8;
            this.checkBoxStartPressed.Text = "Start in pressed state";
            this.checkBoxStartPressed.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.checkBoxStartPressed.UseVisualStyleBackColor = true;
            this.checkBoxStartPressed.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // textBoxSendingInterval
            // 
            this.textBoxSendingInterval.Location = new System.Drawing.Point(111, 91);
            this.textBoxSendingInterval.Name = "textBoxSendingInterval";
            this.textBoxSendingInterval.Size = new System.Drawing.Size(100, 23);
            this.textBoxSendingInterval.TabIndex = 6;
            this.textBoxSendingInterval.TextChanged += new System.EventHandler(this.textBoxSendingInterval_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(10, 94);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(95, 15);
            this.label6.TabIndex = 5;
            this.label6.Text = "Sending Interval:";
            // 
            // comboBoxMessageGenerationMethod
            // 
            this.comboBoxMessageGenerationMethod.FormattingEnabled = true;
            this.comboBoxMessageGenerationMethod.Location = new System.Drawing.Point(173, 53);
            this.comboBoxMessageGenerationMethod.Name = "comboBoxMessageGenerationMethod";
            this.comboBoxMessageGenerationMethod.Size = new System.Drawing.Size(159, 23);
            this.comboBoxMessageGenerationMethod.TabIndex = 4;
            this.comboBoxMessageGenerationMethod.SelectedIndexChanged += new System.EventHandler(this.comboBoxMessageGenerationMethod_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(161, 15);
            this.label2.TabIndex = 0;
            this.label2.Text = "Message generation method:";
            // 
            // textBoxButtonText
            // 
            this.textBoxButtonText.Location = new System.Drawing.Point(89, 20);
            this.textBoxButtonText.Name = "textBoxButtonText";
            this.textBoxButtonText.Size = new System.Drawing.Size(243, 23);
            this.textBoxButtonText.TabIndex = 3;
            this.textBoxButtonText.TextChanged += new System.EventHandler(this.textBoxButtonText_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Button name:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textBoxCanData8);
            this.groupBox2.Controls.Add(this.textBoxCanData7);
            this.groupBox2.Controls.Add(this.textBoxCanData6);
            this.groupBox2.Controls.Add(this.textBoxCanData5);
            this.groupBox2.Controls.Add(this.textBoxCanData4);
            this.groupBox2.Controls.Add(this.textBoxCanData3);
            this.groupBox2.Controls.Add(this.textBoxCanData2);
            this.groupBox2.Controls.Add(this.textBoxCanData1);
            this.groupBox2.Controls.Add(this.textBoxCanDataLen);
            this.groupBox2.Controls.Add(this.textBoxCanID);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Location = new System.Drawing.Point(12, 179);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(345, 164);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Can Data Generation Settings";
            // 
            // textBoxCanData8
            // 
            this.textBoxCanData8.Location = new System.Drawing.Point(282, 122);
            this.textBoxCanData8.Name = "textBoxCanData8";
            this.textBoxCanData8.Size = new System.Drawing.Size(50, 23);
            this.textBoxCanData8.TabIndex = 12;
            this.textBoxCanData8.TextChanged += new System.EventHandler(this.textBoxCanData8_TextChanged);
            // 
            // textBoxCanData7
            // 
            this.textBoxCanData7.Location = new System.Drawing.Point(226, 122);
            this.textBoxCanData7.Name = "textBoxCanData7";
            this.textBoxCanData7.Size = new System.Drawing.Size(50, 23);
            this.textBoxCanData7.TabIndex = 11;
            this.textBoxCanData7.TextChanged += new System.EventHandler(this.textBoxCanData7_TextChanged);
            // 
            // textBoxCanData6
            // 
            this.textBoxCanData6.Location = new System.Drawing.Point(170, 122);
            this.textBoxCanData6.Name = "textBoxCanData6";
            this.textBoxCanData6.Size = new System.Drawing.Size(50, 23);
            this.textBoxCanData6.TabIndex = 10;
            this.textBoxCanData6.TextChanged += new System.EventHandler(this.textBoxCanData6_TextChanged);
            // 
            // textBoxCanData5
            // 
            this.textBoxCanData5.Location = new System.Drawing.Point(114, 122);
            this.textBoxCanData5.Name = "textBoxCanData5";
            this.textBoxCanData5.Size = new System.Drawing.Size(50, 23);
            this.textBoxCanData5.TabIndex = 9;
            this.textBoxCanData5.TextChanged += new System.EventHandler(this.textBoxCanData5_TextChanged);
            // 
            // textBoxCanData4
            // 
            this.textBoxCanData4.Location = new System.Drawing.Point(282, 93);
            this.textBoxCanData4.Name = "textBoxCanData4";
            this.textBoxCanData4.Size = new System.Drawing.Size(50, 23);
            this.textBoxCanData4.TabIndex = 8;
            this.textBoxCanData4.TextChanged += new System.EventHandler(this.textBoxCanData4_TextChanged);
            // 
            // textBoxCanData3
            // 
            this.textBoxCanData3.Location = new System.Drawing.Point(226, 93);
            this.textBoxCanData3.Name = "textBoxCanData3";
            this.textBoxCanData3.Size = new System.Drawing.Size(50, 23);
            this.textBoxCanData3.TabIndex = 7;
            this.textBoxCanData3.TextChanged += new System.EventHandler(this.textBoxCanData3_TextChanged);
            // 
            // textBoxCanData2
            // 
            this.textBoxCanData2.Location = new System.Drawing.Point(170, 93);
            this.textBoxCanData2.Name = "textBoxCanData2";
            this.textBoxCanData2.Size = new System.Drawing.Size(50, 23);
            this.textBoxCanData2.TabIndex = 6;
            this.textBoxCanData2.TextChanged += new System.EventHandler(this.textBoxCanData2_TextChanged);
            // 
            // textBoxCanData1
            // 
            this.textBoxCanData1.Location = new System.Drawing.Point(114, 93);
            this.textBoxCanData1.Name = "textBoxCanData1";
            this.textBoxCanData1.Size = new System.Drawing.Size(50, 23);
            this.textBoxCanData1.TabIndex = 5;
            this.textBoxCanData1.TextChanged += new System.EventHandler(this.textBoxCanData1_TextChanged);
            // 
            // textBoxCanDataLen
            // 
            this.textBoxCanDataLen.Location = new System.Drawing.Point(114, 64);
            this.textBoxCanDataLen.Name = "textBoxCanDataLen";
            this.textBoxCanDataLen.Size = new System.Drawing.Size(57, 23);
            this.textBoxCanDataLen.TabIndex = 4;
            this.textBoxCanDataLen.TextChanged += new System.EventHandler(this.textBoxCanDataLen_TextChanged);
            // 
            // textBoxCanID
            // 
            this.textBoxCanID.Location = new System.Drawing.Point(114, 34);
            this.textBoxCanID.Name = "textBoxCanID";
            this.textBoxCanID.Size = new System.Drawing.Size(120, 23);
            this.textBoxCanID.TabIndex = 3;
            this.textBoxCanID.TextChanged += new System.EventHandler(this.textBoxCanID_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 67);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(98, 15);
            this.label5.TabIndex = 2;
            this.label5.Text = "Can Data Length:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 93);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 15);
            this.label4.TabIndex = 1;
            this.label4.Text = "Can Data:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 37);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 15);
            this.label3.TabIndex = 0;
            this.label3.Text = "Can ID:";
            // 
            // ButtonSettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(366, 355);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "ButtonSettingsForm";
            this.Text = "Button Settings";
            this.Load += new System.EventHandler(this.ButtonSettingsForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private Label label1;
        private ComboBox comboBoxMessageGenerationMethod;
        private Label label2;
        private TextBox textBoxButtonText;
        private Label label4;
        private Label label3;
        private TextBox textBoxCanID;
        private Label label5;
        private TextBox textBoxCanData1;
        private TextBox textBoxCanDataLen;
        private TextBox textBoxCanData2;
        private TextBox textBoxCanData8;
        private TextBox textBoxCanData7;
        private TextBox textBoxCanData6;
        private TextBox textBoxCanData5;
        private TextBox textBoxCanData4;
        private TextBox textBoxCanData3;
        private TextBox textBoxSendingInterval;
        private Label label6;
        private CheckBox checkBoxStartPressed;
    }
}
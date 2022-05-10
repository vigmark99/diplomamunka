namespace CanCOMApplication
{
    partial class Form2
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
            this.formsPlot1 = new ScottPlot.FormsPlot();
            this.applyFilterBT = new System.Windows.Forms.Button();
            this.IDfilterTB = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.AutoRefreshCB1 = new System.Windows.Forms.CheckBox();
            this.ValueTypesCB = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // formsPlot1
            // 
            this.formsPlot1.Location = new System.Drawing.Point(13, 12);
            this.formsPlot1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.formsPlot1.Name = "formsPlot1";
            this.formsPlot1.Size = new System.Drawing.Size(752, 375);
            this.formsPlot1.TabIndex = 0;
            // 
            // applyFilterBT
            // 
            this.applyFilterBT.Location = new System.Drawing.Point(1025, 115);
            this.applyFilterBT.Name = "applyFilterBT";
            this.applyFilterBT.Size = new System.Drawing.Size(75, 23);
            this.applyFilterBT.TabIndex = 1;
            this.applyFilterBT.Text = "Plot1";
            this.applyFilterBT.UseVisualStyleBackColor = true;
            this.applyFilterBT.Click += new System.EventHandler(this.applyFilterBT_Click);
            // 
            // IDfilterTB
            // 
            this.IDfilterTB.Location = new System.Drawing.Point(792, 115);
            this.IDfilterTB.Name = "IDfilterTB";
            this.IDfilterTB.Size = new System.Drawing.Size(100, 23);
            this.IDfilterTB.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(821, 97);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "Can ID";
            // 
            // AutoRefreshCB1
            // 
            this.AutoRefreshCB1.AutoSize = true;
            this.AutoRefreshCB1.Location = new System.Drawing.Point(1106, 117);
            this.AutoRefreshCB1.Name = "AutoRefreshCB1";
            this.AutoRefreshCB1.Size = new System.Drawing.Size(94, 19);
            this.AutoRefreshCB1.TabIndex = 4;
            this.AutoRefreshCB1.Text = "Auto Refresh";
            this.AutoRefreshCB1.UseVisualStyleBackColor = true;
            this.AutoRefreshCB1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // ValueTypesCB
            // 
            this.ValueTypesCB.FormattingEnabled = true;
            this.ValueTypesCB.Location = new System.Drawing.Point(898, 115);
            this.ValueTypesCB.Name = "ValueTypesCB";
            this.ValueTypesCB.Size = new System.Drawing.Size(121, 23);
            this.ValueTypesCB.TabIndex = 5;
            // 
            // Form2
            // 
            this.ClientSize = new System.Drawing.Size(1248, 399);
            this.Controls.Add(this.ValueTypesCB);
            this.Controls.Add(this.AutoRefreshCB1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.IDfilterTB);
            this.Controls.Add(this.applyFilterBT);
            this.Controls.Add(this.formsPlot1);
            this.Name = "Form2";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private TextBox IDfilterTB;
        private Label label1;
        private GroupBox groupBox1;
        private Button button1;
        private ScottPlot.FormsPlot Plot1;
        private ScottPlot.FormsPlot formsPlot1;
        private Button applyFilterBT;
        private TextBox filterIDTB;
        private CheckBox AutoRefreshCB1;
        private ComboBox ValueTypesCB;
    }
}
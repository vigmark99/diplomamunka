using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CanCOMApplication
{
    internal partial class ButtonSettingsForm : Form
    {
        ButtonData Data;

        Byte[] DataBytes=new byte[8];

        bool loaded=false;
        internal ButtonSettingsForm(ButtonData Data_)
        {
            InitializeComponent();
            Data = Data_;
        }
        public void RecheckData()
        {
            
        }

        public void FillDataFields()
        {
            textBoxButtonText.Text = Data.name;
            textBoxCanData1.Text = (DataBytes[0]=Data.cdf.DataB[0]).ToString();
            textBoxCanData2.Text = (DataBytes[1] = Data.cdf.DataB[1]).ToString();
            textBoxCanData3.Text = (DataBytes[2] = Data.cdf.DataB[2]).ToString();
            textBoxCanData4.Text = (DataBytes[3] = Data.cdf.DataB[3]).ToString();
            textBoxCanData5.Text = (DataBytes[4] = Data.cdf.DataB[4]).ToString();
            textBoxCanData6.Text = (DataBytes[5] = Data.cdf.DataB[5]).ToString();
            textBoxCanData7.Text = (DataBytes[6] = Data.cdf.DataB[6]).ToString();
            textBoxCanData8.Text = (DataBytes[7] = Data.cdf.DataB[7]).ToString();
            textBoxCanDataLen.Text = Data.cdf.DLEN.ToString();
            textBoxCanID.Text = Data.cdf.ID.ToString();
            textBoxSendingInterval.Text = Data.sendingInterval.ToString();
            checkBoxStartPressed.Checked = Data.startState;
            for(int i=0; i< comboBoxMessageGenerationMethod.Items.Count;i++)
            {
                if(comboBoxMessageGenerationMethod.Items[i].ToString()==Data.dataGenerationType.ToString())
                {
                    comboBoxMessageGenerationMethod.SelectedIndex = i;  
                }
            }
            if (Data.dataGenerationType == ButtonData.DataGenerationType.Continous)
            {
                textBoxSendingInterval.Enabled = true;
                checkBoxStartPressed.Enabled = true;
                label6.Enabled = true;
            }
            else
            {
                textBoxSendingInterval.Enabled = false;
                checkBoxStartPressed.Enabled = false;
                label6.Enabled = false;
            }
        }

        private void ButtonSettingsForm_Load(object sender, EventArgs e)
        {
            comboBoxMessageGenerationMethod.Items.Clear();
            comboBoxMessageGenerationMethod.DataSource = Enum.GetValues(typeof(ButtonData.DataGenerationType));
            FillDataFields();
            loaded = true;
        }

        private void textBoxButtonText_TextChanged(object sender, EventArgs e)
        {
            TextBox textBoxButtonText = sender as TextBox;
            Data.name= textBoxButtonText.Text;
        }

        private void comboBoxMessageGenerationMethod_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(loaded)
            {
                ComboBox temp = sender as ComboBox;
                if (temp.SelectedItem == null)
                {
                    return;
                }
                Data.dataGenerationType = (ButtonData.DataGenerationType)temp.SelectedItem;
                if (Data.dataGenerationType == ButtonData.DataGenerationType.Continous)
                {
                    textBoxSendingInterval.Enabled = true;
                    checkBoxStartPressed.Enabled = true;
                    label6.Enabled = true;
                }
                else
                {
                    textBoxSendingInterval.Enabled = false;
                    checkBoxStartPressed.Enabled = false;
                    label6.Enabled = false;
                }
            }
        }

        private void textBoxCanID_TextChanged(object sender, EventArgs e)
        {
            TextBox temp = sender as TextBox;
            string txt = temp.Text == "" ? "0" : temp.Text;
            string trueText = temp.Text;
            if (!uint.TryParse(txt, out Data.cdf.ID))
            {
                MessageBox.Show("Invalid Data");
                temp.Select();
                temp.BackColor = Color.Red;
            }
            else
            {
                textBoxCanID.TextChanged -= textBoxCanID_TextChanged;
                if (Data.cdf.ID==0)
                {
                    temp.Text = trueText;
                }
                temp.BackColor = Color.White;
                FillDataFields();
                textBoxCanID.TextChanged += textBoxCanID_TextChanged;
            }
        }

        private void textBoxCanDataLen_TextChanged(object sender, EventArgs e)
        {
            TextBox temp = sender as TextBox;
            string txt=temp.Text==""?"0":temp.Text;
            string trueText = temp.Text;
            if (!uint.TryParse(txt, out Data.cdf.DLEN))
            {
                MessageBox.Show("Invalid Data");
                //FillDataFields();
                temp.Select();
                temp.BackColor = Color.Red;
            }
            else
            {
                textBoxCanDataLen.TextChanged -= textBoxCanDataLen_TextChanged;
                FillDataFields();
                if (Data.cdf.DLEN == 0)
                {
                    temp.Text = trueText;
                }
                else if(Data.cdf.DLEN > 8)
                {
                    Data.cdf.DLEN = 8;
                }
                temp.BackColor = Color.White;
                textBoxCanDataLen.TextChanged += textBoxCanDataLen_TextChanged;
            }
        }

        private void refreshDataByte()
        {
            Data.cdf.DataB = DataBytes;
        }

        private void textBoxCanData1_TextChanged(object sender, EventArgs e)
        {
            TextBox temp = sender as TextBox;
            string txt = temp.Text == "" ? "0" : temp.Text;
            string trueText = temp.Text;
            if (!byte.TryParse(txt, out DataBytes[0]))
            {
                MessageBox.Show("Invalid Data");
                //FillDataFields();
                temp.Select();
                temp.BackColor = Color.Red;
            }
            else
            {
                temp.BackColor = Color.White;
                refreshDataByte();
                textBoxCanData1.TextChanged-= textBoxCanData1_TextChanged;
                FillDataFields();
                if (Data.cdf.DataB[0] == 0)
                {
                    temp.Text = trueText;
                }
                textBoxCanData1.TextChanged += textBoxCanData1_TextChanged;
            }
            
        }

        private void textBoxCanData2_TextChanged(object sender, EventArgs e)
        {
            TextBox temp = sender as TextBox;
            string txt = temp.Text == "" ? "0" : temp.Text;
            string trueText = temp.Text;
            if (!byte.TryParse(txt, out DataBytes[1]))
            {
                MessageBox.Show("Invalid Data");
                //FillDataFields();
                temp.Select();
                temp.BackColor = Color.Red;
            }
            else
            {
                temp.BackColor = Color.White;
                refreshDataByte();
                textBoxCanData2.TextChanged -= textBoxCanData2_TextChanged;
                FillDataFields();
                if (Data.cdf.DataB[1] == 0)
                {
                    temp.Text = trueText;
                }
                textBoxCanData2.TextChanged += textBoxCanData2_TextChanged;
            }
        }

        private void textBoxCanData3_TextChanged(object sender, EventArgs e)
        {
            TextBox temp = sender as TextBox;
            string txt = temp.Text == "" ? "0" : temp.Text;
            string trueText = temp.Text;
            if (!byte.TryParse(txt, out DataBytes[2]))
            {
                MessageBox.Show("Invalid Data");
                //FillDataFields();
                temp.Select();
                temp.BackColor = Color.Red;
            }
            else
            {
                temp.BackColor = Color.White;
                refreshDataByte();
                textBoxCanData3.TextChanged -= textBoxCanData3_TextChanged;
                FillDataFields();
                if (Data.cdf.DataB[2] == 0)
                {
                    temp.Text = trueText;
                }
                textBoxCanData3.TextChanged += textBoxCanData3_TextChanged;
            }
        }

        private void textBoxCanData4_TextChanged(object sender, EventArgs e)
        {
            TextBox temp = sender as TextBox;
            string txt = temp.Text == "" ? "0" : temp.Text;
            string trueText = temp.Text;
            if (!byte.TryParse(txt, out DataBytes[3]))
            {
                MessageBox.Show("Invalid Data");
                //FillDataFields();
                temp.Select();
                temp.BackColor = Color.Red;
            }
            else
            {
                temp.BackColor = Color.White;
                refreshDataByte();
                textBoxCanData4.TextChanged -= textBoxCanData4_TextChanged;
                FillDataFields();
                if (Data.cdf.DataB[3] == 0)
                {
                    temp.Text = trueText;
                }
                textBoxCanData4.TextChanged += textBoxCanData4_TextChanged;
            }
        }

        private void textBoxCanData5_TextChanged(object sender, EventArgs e)
        {
            TextBox temp = sender as TextBox;
            string txt = temp.Text == "" ? "0" : temp.Text;
            string trueText = temp.Text;
            if (!byte.TryParse(txt, out DataBytes[4]))
            {
                MessageBox.Show("Invalid Data");
                //FillDataFields();
                temp.Select();
                temp.BackColor = Color.Red;
            }
            else
            {
                temp.BackColor = Color.White;
                refreshDataByte();
                textBoxCanData5.TextChanged -= textBoxCanData5_TextChanged;
                FillDataFields();
                if (Data.cdf.DataB[4] == 0)
                {
                    temp.Text = trueText;
                }
                textBoxCanData5.TextChanged += textBoxCanData5_TextChanged;
            }
        }

        private void textBoxCanData6_TextChanged(object sender, EventArgs e)
        {
            TextBox temp = sender as TextBox;
            string txt = temp.Text == "" ? "0" : temp.Text;
            string trueText = temp.Text;
            if (!byte.TryParse(txt, out DataBytes[5]))
            {
                MessageBox.Show("Invalid Data");
                //FillDataFields();
                temp.Select();
                temp.BackColor = Color.Red;
            }
            else
            {
                temp.BackColor = Color.White;
                refreshDataByte();
                textBoxCanData6.TextChanged -= textBoxCanData6_TextChanged;
                FillDataFields();
                if (Data.cdf.DataB[5] == 0)
                {
                    temp.Text = trueText;
                }
                textBoxCanData6.TextChanged += textBoxCanData6_TextChanged;
            }
        }

        private void textBoxCanData7_TextChanged(object sender, EventArgs e)
        {
            TextBox temp = sender as TextBox;
            string txt = temp.Text == "" ? "0" : temp.Text;
            string trueText = temp.Text;
            if (!byte.TryParse(txt, out DataBytes[6]))
            {
                MessageBox.Show("Invalid Data");
                //FillDataFields();
                temp.Select();
                temp.BackColor = Color.Red;
            }
            else
            {
                temp.BackColor = Color.White;
                refreshDataByte();
                textBoxCanData7.TextChanged -= textBoxCanData7_TextChanged;
                FillDataFields();
                if (Data.cdf.DataB[6] == 0)
                {
                    temp.Text = trueText;
                }
                textBoxCanData7.TextChanged += textBoxCanData7_TextChanged;
            }
        }

        private void textBoxCanData8_TextChanged(object sender, EventArgs e)
        {
            TextBox temp = sender as TextBox;
            string txt = temp.Text == "" ? "0" : temp.Text;
            string trueText = temp.Text;
            if (!byte.TryParse(txt, out DataBytes[7]))
            {
                MessageBox.Show("Invalid Data");
                //FillDataFields();
                temp.Select();
                temp.BackColor = Color.Red;
            }
            else
            {
                temp.BackColor = Color.White;
                refreshDataByte();
                textBoxCanData8.TextChanged -= textBoxCanData8_TextChanged;
                FillDataFields();
                if (Data.cdf.DataB[7] == 0)
                {
                    temp.Text = trueText;
                }
                textBoxCanData8.TextChanged += textBoxCanData8_TextChanged;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void textBoxSendingInterval_TextChanged(object sender, EventArgs e)
        {
            TextBox temp = sender as TextBox;
            string txt = temp.Text == "" ? "0" : temp.Text;
            string trueText = temp.Text;
            double tempd;
            if (double.TryParse(txt, out tempd))
            {
                
                Data.sendingInterval = tempd;
                temp.BackColor = Color.White;
                textBoxSendingInterval.TextChanged -= textBoxSendingInterval_TextChanged;
                FillDataFields();
                if (Math.Abs(Data.sendingInterval-0.002) <= 0)
                {
                    temp.Text = trueText;
                }
                textBoxSendingInterval.TextChanged += textBoxSendingInterval_TextChanged;
            }
            else
            {
                MessageBox.Show("Invalid Data");
                //FillDataFields();
                temp.Select();
                temp.BackColor = Color.Red;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            Data.startState = ((CheckBox)sender).Checked;
        }
    }
}

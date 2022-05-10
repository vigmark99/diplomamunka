using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
using System.Diagnostics;

namespace CanCOMApplication
{

    public delegate void TimerEventHandler();
    public delegate void USBstatusChanged();

    
    public partial class Form1 : Form
    {
        private bool isClosing = false;
        USBCom usbcom = new USBCom();
        DBhandler dbhandler = new DBhandler();

        SimulationData simulationdata = new SimulationData();

        System.Timers.Timer dataRefresher=new System.Timers.Timer();
        System.Timers.Timer timeoutTimer = new System.Timers.Timer();

        List<Button> buttons = new List<Button>();

        List<Task> tasks = new List<Task>();

        private delegate void addCanFrameToDataGridCanTraffic(TrafficElementCanDataFrame TECDF);

        private List<TrafficElementCanDataFrame> canTraffic = new List<TrafficElementCanDataFrame>();

        private int lastSimpleButtonTag = 0;

        private int lastActiveTestcase = 0;

        bool testRunning = false;
        public Form1()
        {
            InitializeComponent();
            usbcom=new USBCom();
            usbcom.Refreshed += Usbcom_Refreshed;
            usbcom.StatusChanged += Usbcom_StatusChanged;
            usbcom.USBmessageArrived += Usbcom_USBmessageArrived;
            this.Load += Form1_Load;
        }

        private void Usbcom_USBmessageArrived(CanDataFrame cdf)
        {
            if(lastActiveTestcase<= dbhandler.TestSteps.Count-1)
            {
                if (dbhandler.TestSteps[lastActiveTestcase].status == TestStep.testState.processing && cdf.ID == dbhandler.TestSteps[lastActiveTestcase].frameIDReceived)
                {
                    timeoutTimer.Stop();
                    dbhandler.TestSteps[lastActiveTestcase].status = TestStep.testState.succeed;
                    for (int i = 0; i < dbhandler.canDevices.Count; i++)
                    {
                        if (dbhandler.canDevices[i].ID == dbhandler.TestSteps[lastActiveTestcase].relatedDeviceID)
                        {
                            if (dbhandler.canDevices[i].testResults == CanDevice.CanDeviceTestResults.Initial)
                            {
                                dbhandler.canDevices[i].testResults = CanDevice.CanDeviceTestResults.TestsOk;
                                dataGridViewDevices.Rows[i].DefaultCellStyle.BackColor = Color.Green;
                            }
                            else if (dbhandler.canDevices[i].testResults == CanDevice.CanDeviceTestResults.TestsFailed)
                            {
                                dbhandler.canDevices[i].testResults = CanDevice.CanDeviceTestResults.TestsPartiallyFailed;
                                dataGridViewDevices.Rows[i].DefaultCellStyle.BackColor = Color.Yellow;
                            }
                        }
                    }
                    dataGridViewTestCases.Rows[lastActiveTestcase].DefaultCellStyle.BackColor = Color.Green;
                    lastActiveTestcase++;
                }
            }
            TrafficElementCanDataFrame temp = new TrafficElementCanDataFrame(simulationdata.initialTime);
            temp.canDataFrame = cdf;
            temp.direction = TrafficElementCanDataFrame.DIRECTION.incoming;
            addCanFrameToDataGridView(temp);
            canTraffic.Add(temp);
            dbhandler.putFrameToDB(temp);
        }

        private void addCanFrameToDataGridView(TrafficElementCanDataFrame TECDF)
        {
            if (InvokeRequired)
            {
                Invoke(new addCanFrameToDataGridCanTraffic(addCanFrameToDataGridView), TECDF);
            }
            else
            {
                DataGridViewRow row = (DataGridViewRow)dataGridViewCanTraffic.Rows[0].Clone();
                row.Cells[0].Value = TECDF.canDataFrame.ID;
                row.Cells[1].Value = TECDF.canDataFrame.DLEN;
                string temp = "";
                for(int i=0; i<TECDF.canDataFrame.DLEN;i++)
                {
                    temp += TECDF.canDataFrame.DataB[i].ToString();
                    if (i != TECDF.canDataFrame.DLEN - 1)
                        temp += " ";
                }
                row.Cells[2].Value = temp;
                row.Cells[3].Value = TECDF.timeStampTimeSpan;
                row.Cells[4].Value = TECDF.direction == TrafficElementCanDataFrame.DIRECTION.outgoing ? "OUTGOING" : "INCOMING";
                dataGridViewCanTraffic.Rows.Add(row);
                
            }
        }

        private void Usbcom_StatusChanged()
        {
            if (InvokeRequired)
            {
                Invoke(new USBstatusChanged(Usbcom_StatusChanged));
            }
            else
            {
                if(usbcom.HWstatus==USBCom.HWstate.dataTransferLaunched)
                {
                    testRunning = true;
                    simulationdata.initialTime = DateTimeOffset.Now;
                    dataGridViewCanTraffic.Rows.Clear();
                }
            }
        }

        private void Form1_Load(object? sender, EventArgs e)
        {
            usbcom.Start();
            try
            {
                dbhandler.connect();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            dataRefresher.Interval = 100;
            dataRefresher.AutoReset=true;
            dataRefresher.Elapsed += DataRefresher_Elapsed;
            dataRefresher.Start();
            addNewSimpleButton();
            timeoutTimer.Elapsed += TimeoutTimer_Elapsed;
            try
            {
                refreshTestStepsIdDatagrid();
                refreshDevicesInDataGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void refreshDevicesInDataGrid()
        {
            dbhandler.readDevices();
            for(int i = 0; i < dbhandler.canDevices.Count; i++)
            {
                DataGridViewRow row = (DataGridViewRow)dataGridViewDevices.Rows[0].Clone();
                row.Cells[0].Value = dbhandler.canDevices[i].ID.ToString();
                row.Cells[1].Value = dbhandler.canDevices[i].name.ToString();
                row.Cells[2].Value = dbhandler.canDevices[i].description.ToString();
                dataGridViewDevices.Rows.Add(row);
            }
        }

        private void refreshTestStepsIdDatagrid()
        {
            dbhandler.readTestSteps();
            for (int i = 0; i < dbhandler.TestSteps.Count; i++)
            {
                DataGridViewRow row = (DataGridViewRow)dataGridViewTestCases.Rows[0].Clone();
                row.Cells[0].Value = dbhandler.TestSteps[i].ID.ToString();
                row.Cells[1].Value = dbhandler.TestSteps[i].name.ToString();
                row.Cells[2].Value = dbhandler.TestSteps[i].frameToSend.ID.ToString();
                row.Cells[3].Value = dbhandler.TestSteps[i].frameToSend.DLEN.ToString();
                row.Cells[4].Value = dbhandler.TestSteps[i].frameToSend.DataL.ToString();
                row.Cells[5].Value = dbhandler.TestSteps[i].frameIDReceived.ToString();
                row.Cells[6].Value = dbhandler.TestSteps[i].frameTimeout.ToString();
                row.Cells[7].Value = dbhandler.TestSteps[i].description.ToString();
                row.Cells[8].Value = dbhandler.TestSteps[i].relatedDeviceID.ToString();
                //row.Cells[9].Value = dbhandler.TestSteps[i].enabled.ToString();
                dataGridViewTestCases.Rows.Add(row);
            }
        }

        private void TimeoutTimer_Elapsed(object? sender, System.Timers.ElapsedEventArgs e)
        {
            dbhandler.TestSteps[lastActiveTestcase].status = TestStep.testState.failed;
            for (int i = 0; i < dbhandler.canDevices.Count; i++)
            {
                if (dbhandler.canDevices[i].ID == dbhandler.TestSteps[lastActiveTestcase].relatedDeviceID)
                {
                    if(dbhandler.canDevices[i].testResults==CanDevice.CanDeviceTestResults.Initial)
                    {
                        dbhandler.canDevices[i].testResults = CanDevice.CanDeviceTestResults.TestsFailed;
                        dataGridViewDevices.Rows[i].DefaultCellStyle.BackColor = Color.Red;
                    }
                    else if (dbhandler.canDevices[i].testResults == CanDevice.CanDeviceTestResults.TestsOk)
                    {
                        dbhandler.canDevices[i].testResults = CanDevice.CanDeviceTestResults.TestsPartiallyFailed;
                        dataGridViewDevices.Rows[i].DefaultCellStyle.BackColor = Color.Yellow;
                    }
                }
            }
            dataGridViewTestCases.Rows[lastActiveTestcase].DefaultCellStyle.BackColor = Color.Red;
            lastActiveTestcase++;
            
        }

        private void DataRefresher_Elapsed(object? sender, System.Timers.ElapsedEventArgs e)
        {
            try
            {
                if (!isClosing)
                {
                    if (InvokeRequired)
                    {
                        Invoke(new TimerEventHandler(DataRefresher_Elapsed_Handler));
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }
        private void DataRefresher_Elapsed_Handler()
        {
            if (simulationdata.simulationState==1)
            {
                TimeSpan elapsedTime = DateTimeOffset.Now.Subtract(simulationdata.initialTime);
                ElapsedTimeLabel.Text = "Elapsed time: " + elapsedTime.TotalSeconds.ToString();
            }
            if (usbcom.HWstatus == USBCom.HWstate.dataTransferLaunched)
            {
                connectionStatusLabel.Text = "Status: Connected";
            }
            else if(usbcom.HWstatus == USBCom.HWstate.disconnected)
            {
                connectionStatusLabel.Text = "Status: Disconnected";
            }
            else if (usbcom.HWstatus == USBCom.HWstate.defaultError)
            {
                connectionStatusLabel.Text = "Status: Error";
            }
            if(usbcom.HWstatus == USBCom.HWstate.dataTransferLaunched)
            {
                if(lastActiveTestcase!=dbhandler.TestSteps.Count)
                {
                    if(dbhandler.TestSteps[lastActiveTestcase].status==TestStep.testState.unprocessed)
                    {
                        Debug.WriteLine("outgoing:" + dbhandler.TestSteps[lastActiveTestcase].getDataAsString());
                        dataGridViewTestCases.Rows[lastActiveTestcase].DefaultCellStyle.BackColor = Color.Yellow;
                        dbhandler.TestSteps[lastActiveTestcase].status=TestStep.testState.processing;
                        sendOutCanMessage(dbhandler.TestSteps[lastActiveTestcase].frameToSend);
                        timeoutTimer.Interval = dbhandler.TestSteps[lastActiveTestcase].frameTimeout;
                        timeoutTimer.AutoReset = false;
                        timeoutTimer.Start();
                    }
                }
            }
        }

        private void sendOutCanMessage(CanDataFrame cdf)
        {
            TrafficElementCanDataFrame temp = new TrafficElementCanDataFrame(simulationdata.initialTime);
            temp.canDataFrame = cdf;
            usbcom.messages.Add(cdf.getDataAsString());
            temp.direction = TrafficElementCanDataFrame.DIRECTION.outgoing;
            addCanFrameToDataGridView(temp);
            canTraffic.Add(temp);
            dbhandler.putFrameToDB(temp);
        }

        private void Usbcom_Refreshed()
        {
            if (InvokeRequired)
            {
                Invoke(new AvailableComsRefreshedEventHandler(Usbcom_Refreshed));
            }
            else
            {
                foreach (String s1 in usbcom.availableComs)
                {
                    bool contains = false;
                    foreach (String s2 in availablePorts.Items)
                    {
                        if (s1.Equals(s2))
                            contains = true;
                    }
                    if (!contains)
                    {
                        availablePorts.Items.Add(s1);
                    }
                }

                foreach (String s1 in availablePorts.Items)
                {
                    bool contains = false;
                    foreach (String s2 in usbcom.availableComs)
                    {
                        if (s1.Equals(s2))
                            contains = true;
                    }
                    if (!contains)
                    {
                        if(availablePorts.SelectedItem!=null)
                        if(availablePorts.SelectedItem.Equals(s1))
                        {
                            availablePorts.SelectedItem = null;
                        }
                        availablePorts.Items.Remove(s1);
                    }
                }
            }
            
        }

        private void simulationStartBTN_Click(object sender, EventArgs e)
        {
            if(simulationdata.simulationState == 0)
            {
                foreach (DataGridViewRow row in dataGridViewTestCases.Rows)
                        row.DefaultCellStyle.BackColor = Color.White;
                foreach (DataGridViewRow row in dataGridViewDevices.Rows)
                    row.DefaultCellStyle.BackColor = Color.White;
                simulationdata.simulationState = 1;
                
                usbcom.OpenPort();

            }
            else if(simulationdata.simulationState == 1)
            {
                simulationdata.simulationState = 0;
                lastActiveTestcase = 0;
                usbcom.ClosePort();
                for(int i=0; i< dbhandler.TestSteps.Count; i++)
                {
                    dbhandler.TestSteps[i].status = TestStep.testState.unprocessed;
                }
                for(int i=0; i<dbhandler.canDevices.Count; i++)
                {
                    dbhandler.canDevices[i].testResults = CanDevice.CanDeviceTestResults.Initial;
                }
                
            }
            
        }

        private void button2_DragDrop(object sender, DragEventArgs e)
        {

        }

        private void addNewSimpleButton()
        {
            Button temp = new Button();
            temp.Left = 300; temp.Top = 200;
            temp.Size = new Size(100,60);
            ButtonData bd = new ButtonData();
            bd.id = lastSimpleButtonTag++;
            bd.newButtonNeededWhenMove = true;
            bd.name = temp.Text;
            temp.Tag = bd;
            temp.UseMnemonic = false;
            temp.Text = "drag&drop dummy button";
            temp.MouseDown+=button1_MouseDown;
            temp.MouseMove+=button1_MouseMove;
            temp.MouseUp+=button1_MouseUp;
            temp.MouseClick += button1_MouseClick;
            tabPage1.Controls.Add(temp);
            buttons.Add(temp);
        }

        private void button1_DragDrop(object sender, DragEventArgs e)
        {
            
        }

        private void button1_MouseClick(object sender, EventArgs e)
        {
            
            
        }

        bool isDragged = false;
        Point ptOffset;
        private void button1_MouseDown(object sender, MouseEventArgs e)
        {
            Button b = (Button)sender;
            if (e.Button == MouseButtons.Left && simulationdata.simulationState==0)
            {
                isDragged = true;
                Point ptStartPosition = b.PointToScreen(new Point(e.X, e.Y));

                ptOffset = new Point();
                ptOffset.X = b.Location.X - ptStartPosition.X;
                ptOffset.Y = b.Location.Y - ptStartPosition.Y;
            }
            else
            {
                isDragged = false;
            }
        }

        private void button1_MouseMove(object sender, MouseEventArgs e)
        {
            
            Button b = (Button)sender;
            
            if (isDragged)
            {
                Point newPoint = b.PointToScreen(new Point(e.X, e.Y));
                newPoint.Offset(ptOffset);
                b.Location = newPoint;
                if (((ButtonData)b.Tag).newButtonNeededWhenMove == true)
                {
                    addNewSimpleButton();
                    ((ButtonData)b.Tag).newButtonNeededWhenMove =  false;
                }
            }
        }

        private void button1_MouseUp(object sender, MouseEventArgs e)
        {
            isDragged = false;
            Button b = (Button)sender;
            MouseEventArgs me = (MouseEventArgs)e;
            //MessageBox.Show("that was a button " + me.Button.ToString());
            if (/*simulationdata.simulationState==0 &&*/ me.Button == MouseButtons.Right)
            {
                this.Enabled = false;
                Task task = Task.Factory.StartNew(() => Application.Run(new ButtonSettingsForm((ButtonData)b.Tag)));
                Task.WaitAll(task);
                b.Text = ((ButtonData)b.Tag).name;
                //MessageBox.Show("that was the right button " + ((ButtonData)b.Tag).id.ToString()); 
                this.BringToFront();
                this.Enabled = true;
            }
            else if (me.Button == MouseButtons.Left && simulationdata.simulationState==1)
            {
                if(((ButtonData)b.Tag).dataGenerationType==ButtonData.DataGenerationType.Once)
                {
                    //MessageBox.Show("that was the left button " + ((ButtonData)b.Tag).id.ToString());
                    if (usbcom.HWstatus == USBCom.HWstate.dataTransferLaunched)
                        sendOutCanMessage(((ButtonData)b.Tag).cdf);
                }else if (((ButtonData)b.Tag).dataGenerationType == ButtonData.DataGenerationType.Continous)
                {
                    //MessageBox.Show("that was the left button " + ((ButtonData)b.Tag).id.ToString());
                    if (usbcom.HWstatus == USBCom.HWstate.dataTransferLaunched)
                    {
                        if (!((ButtonData)b.Tag).state)
                        {
                            ((ButtonData)b.Tag).timerEventOccured += Form1_timerEventOccured;
                            ((ButtonData)b.Tag).t.Start();
                            ((ButtonData)b.Tag).state = true;
                        }
                        else
                        {
                            ((ButtonData)b.Tag).timerEventOccured -= Form1_timerEventOccured;
                            ((ButtonData)b.Tag).t.Stop();
                            ((ButtonData)b.Tag).state = false;
                        }
                    }
                }
            }
        }

        private void Form1_timerEventOccured(CanDataFrame cdf)
        {
            if (usbcom.HWstatus == USBCom.HWstate.dataTransferLaunched)
            {
                sendOutCanMessage(cdf);
            }
        }

        private void T_Elapsed(object? sender, System.Timers.ElapsedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void availablePorts_SelectionChangeCommitted(object sender, EventArgs e)
        {
            usbcom.requestedComPort = ((ComboBox)sender).SelectedItem.ToString();
        }

        private void comboBox2_SelectionChangeCommitted(object sender, EventArgs e)
        {
            //usbcom.requestedBaudRate = Int32.Parse(((ComboBox)sender).Text);
        }

        private void availablePorts_SelectedIndexChanged(object sender, EventArgs e)
        {
            //usbcom.requestedComPort = ((ComboBox)sender).SelectedItem.ToString();
        }

        private void dataGridViewTestCases_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < dataGridViewTestCases.Rows.Count-1; i++)
                {
                    DataGridViewRow row = (DataGridViewRow)dataGridViewTestCases.Rows[i];
                    if (dbhandler.TestSteps.Count <= i)
                    {
                        dbhandler.TestSteps.Add(new TestStep());
                    }
                    dbhandler.TestSteps[i].ID= uint.Parse((string)row.Cells[0].Value);
                    dbhandler.TestSteps[i].name=(string)row.Cells[1].Value;
                    dbhandler.TestSteps[i].frameToSend.ID= uint.Parse((string)row.Cells[2].Value);
                    dbhandler.TestSteps[i].frameToSend.DLEN= uint.Parse((string)row.Cells[3].Value);
                    dbhandler.TestSteps[i].frameToSend.DataL=ulong.Parse((string)row.Cells[4].Value);
                    dbhandler.TestSteps[i].frameIDReceived= uint.Parse((string)row.Cells[5].Value);
                    dbhandler.TestSteps[i].frameTimeout= uint.Parse((string)row.Cells[6].Value);
                    dbhandler.TestSteps[i].description=(string)row.Cells[7].Value;
                    dbhandler.TestSteps[i].relatedDeviceID = uint.Parse((string)row.Cells[8].Value);
                    dbhandler.TestSteps[i].enabled = true;


                }
                int cnt = dbhandler.TestSteps.Count- (dataGridViewTestCases.Rows.Count-1);
                if (cnt > 0)
                    dbhandler.TestSteps.RemoveRange(dataGridViewTestCases.Rows.Count - 1, cnt);
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            try
            {
                for (int i = 0; i < dataGridViewDevices.Rows.Count - 1; i++)
                {
                    DataGridViewRow row = (DataGridViewRow)dataGridViewDevices.Rows[i];
                    if(dbhandler.canDevices.Count<=i)
                    {
                        dbhandler.canDevices.Add(new CanDevice());
                    }
                    dbhandler.canDevices[i].ID = uint.Parse((string)row.Cells[0].Value);
                    dbhandler.canDevices[i].name = (string)row.Cells[1].Value;
                    dbhandler.canDevices[i].description = (string)row.Cells[2].Value;
                    
                }
                int cnt = dbhandler.canDevices.Count - (dataGridViewDevices.Rows.Count - 1);
                if (cnt > 0)
                    dbhandler.canDevices.RemoveRange(dataGridViewDevices.Rows.Count - 1, cnt);
                dbhandler.refreshCanDevices();
                dataGridViewDevices.Rows.Clear();
                refreshDevicesInDataGrid();
                dataGridViewTestCases.Rows.Clear();
                refreshTestStepsIdDatagrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            dataRefresher.Stop();
            dataRefresher.Dispose();
            isClosing = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            tasks.Add(Task.Run(() => Application.Run(new Form2(canTraffic))));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow item in dataGridViewTestCases.SelectedRows)
            {
                dataGridViewTestCases.Rows.RemoveAt(item.Index);
            }
            foreach (DataGridViewRow item in dataGridViewDevices.SelectedRows)
            {
                dataGridViewDevices.Rows.RemoveAt(item.Index);
            }
        }

        private void SimulationStateLabel_Click(object sender, EventArgs e)
        {

        }
    }
}
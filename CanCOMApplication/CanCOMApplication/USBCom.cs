using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
using System.Diagnostics;

namespace CanCOMApplication
{
	

	public delegate void AvailableComsRefreshedEventHandler();
	public delegate void HWStatusRefreshedEventHandler();
	internal class USBCom
    {
		public delegate void MessageReceived(CanDataFrame msg);

		private object syncObject=new object();
		public enum HWstate {

			initial=0, //no connection requested
			waitingForHandshake=1, //a device is connected, identification started
			dataTransferLaunched=2, //the device is correct, communication started
			disconnected=3,
			Reserved2=4,
			Reserved3=5,
			Reserved4=6,
			Reserved5=7,
			Reserved6=8,
			Reserved7=9,
			defaultError=10, //default error state
			handshakeTimeout=11, //error state: handshake response in timeout
			connectionValidCANerror=12 //the device is correct, communication cannot be started, it is in error state

		}

		public event HWStatusRefreshedEventHandler StatusChanged;

		private HWstate state;
		public HWstate HWstatus { get { return state; } private set { state = value; StatusChanged(); } }

		public int requestedBaudRate=115200;
		public int requestedParity=0;
		public int requestedStopBits=0;
		public bool requestedRead=false;
		public bool requestedWrite=false;
		public bool hndsk2SendRequested = false;
		public string requestedComPort = "";


		string Handshake0 = "";
		string Handshake1 = "";
		string Handshake2 = "";

		const int handshakeTimeoutms = 1000;

		int failedConnectionCounter = 0;
		

		SerialPort sp=new SerialPort();

		System.Timers.Timer tsender = new System.Timers.Timer();
		System.Timers.Timer comRefresher = new System.Timers.Timer();
		System.Timers.Timer handshakeTimeout = new System.Timers.Timer();

		public event AvailableComsRefreshedEventHandler Refreshed;
		
		public event MessageReceived USBmessageArrived;


		public List<String> messages=new List<string>();

		public List<String> availableComs= new List<String>();
		public USBCom()
		{
			tsender.Interval = Double.Parse(HWcomMessages.TimerSenderInterval);
			tsender.Elapsed += Tsender_Elapsed;
			tsender.AutoReset = true;
			

			comRefresher.Interval = Double.Parse(HWcomMessages.ComRefresherInterval);
			comRefresher.Elapsed += ComRefresher_Elapsed;
			comRefresher.AutoReset = true;
			handshakeTimeout.Interval = handshakeTimeoutms;
            handshakeTimeout.Elapsed += HandshakeTimeout_Elapsed;
			
            sp.DataReceived += Sp_DataReceived;
		}

        private void HandshakeTimeout_Elapsed(object? sender, System.Timers.ElapsedEventArgs e)
        {
            if(failedConnectionCounter<2)
            {
				failedConnectionCounter++;
				StartPerformHandshake();

			}
        }

        private void Sp_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
			try
            {
				
				if (HWstatus==HWstate.disconnected || HWstatus == HWstate.initial || HWstatus == HWstate.waitingForHandshake)
                {
					String s = sp.ReadLine();
					Debug.WriteLine("incoming:" + s);
					Debug.WriteLine("needed:" + Handshake1);
					s.Trim();
					if (s == Handshake1)
					{
						handshakeTimeout.Stop();

						hndsk2SendRequested = true;
						messages.Insert(0,Handshake2);
					}
					else
					{
						Debug.WriteLine("NE");

					}
				}
                else
                {
					
					CanDataFrame arrived = new CanDataFrame();

					String str = sp.ReadLine().Replace("\r","");
					Debug.WriteLine("incoming:" + str);
					if (str.Substring(0,7)=="<frame>" && str.Substring(str.Length-8, 8)== "</frame>")
                    {
						str=str.Remove(0, 7);
						str=str.Remove(str.Length - 8, 8);
						String[] temp = str.Split(" ");
						arrived.ID = UInt32.Parse(temp[0]);
						arrived.DLEN= UInt32.Parse(temp[1]);
						byte[] tempb=new byte[8];
						for(int i=0;  i<arrived.DLEN; i++)
                        {
							tempb[i] = Byte.Parse(temp[i+2]);
							
						}
						arrived.DataB = tempb;
					}
					USBmessageArrived(arrived);
				}
			}
			catch (Exception ex)
            {
				MessageBox.Show(ex.ToString());
            }
			
        }

        public void Start()
        {
			comRefresher.Start();
		}

		public void OpenPort()
        {
			failedConnectionCounter = 0;
			if (requestedComPort=="")
            {
				return;
            }
			tsender.Start();
			sp.BaudRate = requestedBaudRate;
			sp.PortName = requestedComPort;
            try { sp.Open(); }
			catch(Exception e) { MessageBox.Show(e.Message.ToString()); }
			
			if (sp.IsOpen)
			{
				HWstatus = HWstate.waitingForHandshake;
			}
            else
            {
				HWstatus = HWstate.defaultError;
            }
			StartPerformHandshake();
		}

		public void ClosePort()
        {
			try { sp.Close();  }
			catch (Exception e) { MessageBox.Show(e.Message.ToString()); }

			if (!sp.IsOpen)
			{
				tsender.Stop();
				HWstatus = HWstate.disconnected;
			}
			else
			{
				HWstatus = HWstate.defaultError;
			}
		}


		public void RefreshComPortConnection()
        {

        }

		public void StartPerformHandshake()
        {
			hndsk2SendRequested = false;
			Random rnd = new Random();
			int rand = rnd.Next(99);
			Handshake0 = "<drive><hndsk>" + rand + "</hndsk></drive>";
			Handshake1 = "<drive><hndsk>" + (rand + 1) + "</hndsk></drive>";
			Handshake2 = "<drive><hndsk>" + (rand + 2) + "</hndsk></drive>";
			messages.Add(Handshake0);
			handshakeTimeout.Start();
        }

        private void ComRefresher_Elapsed(object? sender, System.Timers.ElapsedEventArgs e)
        {
			availableComs = new List<String>(SerialPort.GetPortNames());
			Refreshed();
		}

        private void Tsender_Elapsed(object? sender, System.Timers.ElapsedEventArgs e)
		{
			lock(syncObject)
            {
				if (messages.Count > 0 && sp.IsOpen)
				{
					sp.Write(messages[0].ToString() + '\n');
					Debug.WriteLine("outgoing:" + messages[0].ToString());
					messages.RemoveAt(0);
					if(hndsk2SendRequested)
                    {
						HWstatus = HWstate.dataTransferLaunched;
						hndsk2SendRequested = false;
					}
				}
			}
		}
    }
}

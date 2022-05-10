using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Timers;

namespace CanCOMApplication
{
    delegate void TimerElapsed(CanDataFrame cdf);
    internal class ButtonData
    {
        public string name;
        public int id;
        public string frameID;
        public string frameData;
        public CanDataFrame cdf=new CanDataFrame();
        public bool newButtonNeededWhenMove;

        public bool state = false;

        public double sendingInterval { set { 
            if(t!=null)
                {
                    t.Interval = value;
                }
            }
            get
            {
                return t.Interval;
            }
        }
        public bool startState = false;

        public System.Timers.Timer t;
        public event TimerElapsed timerEventOccured;
        public ButtonData()
        {
            t = new System.Timers.Timer();
            t.AutoReset = true;
            t.Elapsed += T_Elapsed;
            t.Interval = sendingInterval;
        }

        private void T_Elapsed(object? sender, ElapsedEventArgs e)
        {
            timerEventOccured(cdf);
        }

        public enum DataGenerationType
        {
            Once=0,
            Continous=1
        }

        public DataGenerationType dataGenerationType;

        public string getDataAsString()
        {
            string message = "<frame>" + cdf.ID;
            byte[] temp = cdf.DataB;
            message += " " + cdf.DLEN;
            for (int i = 0; i < cdf.DLEN; i++)
            {
                message += " " + temp[i];
            }
            message += "</frame>";
            return message;
        }
    }
}

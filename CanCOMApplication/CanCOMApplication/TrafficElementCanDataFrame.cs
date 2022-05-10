using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanCOMApplication
{
    internal class TrafficElementCanDataFrame
    {
        public CanDataFrame canDataFrame { get; set; }

        public TrafficElementCanDataFrame(DateTimeOffset timeOfStart)
        {
            timeStampTimeSpan = DateTimeOffset.Now.Subtract(timeOfStart);
        }
        public enum DIRECTION
        {
            outgoing = 0,
            incoming = 1,
        }
        public DIRECTION direction;

        public static String GetTimestamp(DateTime value)
        {
            return value.ToString("yyyyMMddHHmmssffff");
        }

        public String timeStamp = GetTimestamp(DateTime.Now);
        public DateTime timeStampDateTime= DateTime.Now;
        public TimeSpan timeStampTimeSpan;

        public long unixTime = DateTimeOffset.Now.ToUnixTimeMilliseconds();
    }
}

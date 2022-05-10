using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanCOMApplication
{
    internal class CanDataFrame
    {
        public uint ID;
        public uint DLEN;
        private ulong data;
        public ulong DataL
        {
            get { return data; }
            set { data = value; }
        }
        public byte[] DataB 
        { 
            get { return BitConverter.GetBytes(data); }
            set { data=BitConverter.ToUInt64(value); }
        }

        public string getDataAsString()
        {
            string message = "<frame>" + ID;
            byte[] temp = DataB;
            message += " " + DLEN;
            for (int i = 0; i <DLEN; i++)
            {
                message += " " + temp[i];
            }
            message += "</frame>";
            return message;
        }
    }
}

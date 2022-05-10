using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanCOMApplication
{
    internal class TestStep
    {
        public uint ID;
        public uint  frameIDReceived;
        public CanDataFrame frameToSend=new CanDataFrame();
        public uint frameTimeout;
        public string name;
        public string description;
        public bool enabled = false;
        public uint relatedDeviceID;

        public enum testState
        {

            unprocessed = 0, //no connection requested
            processing = 1,
            succeed = 2, //a device is connected, identification started
            failed = 3, //the device is correct, communication started
        }
        public testState status=testState.unprocessed;

        public byte[] GetFrameData()
        {
            return frameToSend.DataB;
        }
        public string getDataAsString()
        {
            string message = "<frame>" + frameToSend.ID;
            byte[] temp = frameToSend.DataB;
            message += " " + frameToSend.DLEN;
            for (int i = 0; i < frameToSend.DLEN; i++)
            {
                message += " " + temp[i];
            }
            message += "</frame>";
            return message;
        }
    }
}

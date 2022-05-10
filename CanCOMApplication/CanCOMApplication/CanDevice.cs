using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanCOMApplication
{
    internal class CanDevice
    {
        public enum CanDeviceTestResults { Initial=0, TestsFailed=1, TestsPartiallyFailed = 2, TestsOk =3 };
        public CanDeviceTestResults testResults=CanDeviceTestResults.Initial;
        public string name;
        public uint ID;
        public string description;
    }
}

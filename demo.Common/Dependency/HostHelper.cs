using System;
using System.Collections.Generic;
using System.Text;

namespace demo.Common.Dependency
{
    public class HostHelper:ObjectInstance<HostHelper>
    {
        public HostHelper() {
            MachineName = GetMachineName();
        }

        public string MachineName { get; }
        public string MachineNameLowCase => MachineName.ToLower();

        private string GetMachineName()
        {
            var machineName = Environment.MachineName;
            return machineName.Replace("-","");
        }
    }
}

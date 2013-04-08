using System;
using Hik.NDist.Common;

namespace Hik.NDist.Management.Objects
{
    [Serializable]
    public class ServiceInfo
    {
        public string Name { get; set; }

        public RunningStatus RunningStatus { get; set; }
    }
}

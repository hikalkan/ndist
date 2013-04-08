using System;
using Hik.NDist.Management.Objects;

namespace Hik.NDist.Manager.MainTree.Events
{
    internal class ServiceRunningStatusChangedEventArgs : EventArgs
    {
        public ServiceInfo Service { get; set; }
    }
}
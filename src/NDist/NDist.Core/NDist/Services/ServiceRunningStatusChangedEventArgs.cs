using System;
using Hik.NDist.Common;

namespace Hik.NDist.Services
{
    /// <summary>
    /// Used on IRunnable.RunningStatusChanged event.
    /// </summary>
    [Serializable]
    public class ServiceRunningStatusChangedEventArgs : RunningStatusChangedEventArgs
    {
        /// <summary>
        /// Source object which's state is changed.
        /// </summary>
        public INDistServiceHost ServiceHost { get; private set; }

        /// <summary>
        /// Creates a new RunningStatusChangedEventArgs object.
        /// </summary>
        /// <param name="serviceHost"> </param>
        public ServiceRunningStatusChangedEventArgs(INDistServiceHost serviceHost)
        {
            ServiceHost = serviceHost;
        }
    }
}
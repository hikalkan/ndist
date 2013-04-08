using System;
using System.Collections.Generic;
using Hik.NDist.Common;

namespace Hik.NDist.Services.Controller
{
    public interface INDistServiceController : IRunnable
    {
        event EventHandler<ServiceRunningStatusChangedEventArgs> ServiceRunningStatusChanged;

        INDistServiceHost GetService(string name);

        INDistServiceHost GetServiceOrNull(string name);

        void StartService(string serviceName);

        void StopService(string serviceName);

        List<NDistServiceHost> GetServiceList();
    }
}
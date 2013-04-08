using System;
using Hik.Communication.Scs.Communication.EndPoints.Tcp;
using Hik.Communication.ScsServices.Service;
using Hik.NDist.Config;

namespace Hik.NDist.Management
{
    /// <summary>
    /// This class is used to start/stop the management service.
    /// </summary>
    internal class NDistManagementServicesRunner : INDistManagementServicesRunner
    {
        private readonly NDistConfig _config;

        private readonly INDistManagementService _managementService;

        private readonly IScsServiceApplication _scsServiceApplication;

        public NDistManagementServicesRunner(NDistConfig config, INDistManagementService managementService)
        {
            _config = config;
            _managementService = managementService;

            _scsServiceApplication = ScsServiceBuilder.CreateService(new ScsTcpEndPoint(Convert.ToInt32(_config.GetSetting("ServerPort").Value)));
            _scsServiceApplication.AddService<INDistManagementService, NDistManagementService>((NDistManagementService)_managementService);
        }

        public void Start()
        {
            _scsServiceApplication.Start();
        }

        public void Stop()
        {
            _scsServiceApplication.Stop();
        }
    }
}
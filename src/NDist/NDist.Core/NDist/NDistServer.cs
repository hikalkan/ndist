using Hik.NDist.Common;
using Hik.NDist.Management;
using Hik.NDist.Services;
using Hik.NDist.Services.Controller;

namespace Hik.NDist
{
    /// <summary>
    /// This is the main class that starts/stops modules of the NDist server.
    /// </summary>
    internal class NDistServer : IRunnable
    {
        private readonly INDistServiceController _serviceController;
        private readonly INDistManagementServicesRunner _managementServicesRunner;

        public NDistServer(INDistServiceController serviceController, INDistManagementServicesRunner managementServicesRunner)
        {
            _serviceController = serviceController;
            _managementServicesRunner = managementServicesRunner;
        }
        
        public void Start()
        {
            _serviceController.Start();
            _managementServicesRunner.Start();
        }

        public void Stop()
        {
            _managementServicesRunner.Stop();
            _serviceController.Stop();
        }
    }
}
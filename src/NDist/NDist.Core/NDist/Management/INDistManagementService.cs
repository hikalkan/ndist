using System.Collections.Generic;
using Hik.Communication.ScsServices.Service;
using Hik.NDist.Management.Objects;

namespace Hik.NDist.Management
{
    [ScsService]
    public interface INDistManagementService
    {
        void Register();

        List<ServiceInfo> GetAllServices();
        
        void StopService(string serviceName);

        void StartService(string serviceName);
    }
}
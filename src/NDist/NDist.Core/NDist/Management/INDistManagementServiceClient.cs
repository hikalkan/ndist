using Hik.NDist.Management.Objects;

namespace Hik.NDist.Management
{
    /// <summary>
    /// This interface must be implemented by clienct in order to manage NDist system.
    /// </summary>
    public interface INDistManagementServiceClient
    {
        void OnServiceInstalled(ServiceInfo service);

        void OnServiceUnInstalled(ServiceInfo service);

        void OnServiceRunningStatusChanged(ServiceInfo service);
    }
}
using System;
using System.Windows;
using Hik.NDist.Management;
using Hik.NDist.Management.Objects;
using Hik.NDist.Manager.MainTree.Events;
using Hik.NDist.Helpers;

namespace Hik.NDist.Manager.MainTree
{
    internal class NDistServerListener : INDistManagementServiceClient
    {
        public event EventHandler<ServiceRunningStatusChangedEventArgs> ServiceRunningStatusChanged;

        public void OnServiceInstalled(ServiceInfo service)
        {

        }

        public void OnServiceUnInstalled(ServiceInfo service)
        {

        }

        public void OnServiceRunningStatusChanged(ServiceInfo service)
        {
            Application.Current.Dispatcher.Invoke(
                new Action(() => EventHelper.Invoke(
                    ServiceRunningStatusChanged,
                    this,
                    new ServiceRunningStatusChangedEventArgs
                        {
                            Service = service
                        })));
        }
    }
}
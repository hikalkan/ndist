using System;
using System.Windows;
using System.Windows.Controls;
using Hik.Communication.ScsServices.Client;
using Hik.NDist.Common;
using Hik.NDist.Management;
using Hik.NDist.Management.Objects;

namespace Hik.NDist.Manager.MainTree
{
    internal class NDistServiceNode : IMainTreeItem
    {
        public ServiceInfo Service { get; set; }

        private readonly IScsServiceClient<INDistManagementService> _client;
        private readonly NDistServerListener _serverListener;

        public NDistServiceNode(IScsServiceClient<INDistManagementService> client, NDistServerListener serverListener, ServiceInfo service)
        {
            Service = service;
            _client = client;
            _serverListener = serverListener;
            _serverListener.ServiceRunningStatusChanged += ServerListener_ServiceRunningStatusChanged;
        }

        void ServerListener_ServiceRunningStatusChanged(object sender, Events.ServiceRunningStatusChangedEventArgs e)
        {
            if (e.Service.Name != Service.Name)
            {
                return;
            }

            Service = e.Service;
            RefreshHeader();
       }

        public void Dispose()
        {
            
        }

        public TreeView TreeView { get; set; }

        public TreeViewItem TreeViewItem { get; set; }

        public void Initialize()
        {
            RefreshHeader();
        }

        private void RefreshHeader()
        {
            if (Service.RunningStatus == RunningStatus.Started)
            {
                TreeViewItem.Header = TreeviewHelper.CreateHeader(Service.Name, "/Images/service_running.png");                                            
            }
            else
            {
                TreeViewItem.Header = TreeviewHelper.CreateHeader(Service.Name, "/Images/service.png");                            
            }
        }

        public void CreateContextMenu()
        {
            TreeView.ContextMenu.Items.Clear();

            var startMenuItem = new MenuItem
                                    {
                                        Header = "Start",
                                        IsEnabled = Service.RunningStatus == RunningStatus.Stopped
                                    };

            startMenuItem.Click += StartMenuItem_Click;
            TreeView.ContextMenu.Items.Add(startMenuItem);

            var stopMenuItem = new MenuItem
                                   {
                                       Header = "Stop",
                                       IsEnabled = Service.RunningStatus == RunningStatus.Started
                                   };

            stopMenuItem.Click += StopMenuItem_Click;
            TreeView.ContextMenu.Items.Add(stopMenuItem);
        }

        private void StartMenuItem_Click(object sender, RoutedEventArgs e)
        {
            _client.ServiceProxy.StartService(Service.Name);
        }

        private void StopMenuItem_Click(object sender, RoutedEventArgs e)
        {
            _client.ServiceProxy.StopService(Service.Name);
        }
    }
}
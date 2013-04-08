using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using Hik.Communication.ScsServices.Client;
using Hik.NDist.Management;

namespace Hik.NDist.Manager.MainTree
{
    internal class NDistServicesNode : IMainTreeItem
    {
        public TreeView TreeView { get; set; }

        public TreeViewItem TreeViewItem { get; set; }

        private readonly IScsServiceClient<INDistManagementService> _client;

        private readonly NDistServerListener _serverListener;

        public NDistServicesNode(IScsServiceClient<INDistManagementService> client, NDistServerListener serverListener)
        {
            _client = client;
            _serverListener = serverListener;
        }

        public void Dispose()
        {

        }

        public void Initialize()
        {
            var services = _client.ServiceProxy.GetAllServices();
            TreeViewItem.Items.Clear();
            foreach (var service in services)
            {
                var node = new NDistServiceNode(_client, _serverListener, service) { TreeView = TreeView };
                node.TreeViewItem = new TreeViewItem { Header = service.Name, Tag = node };
                TreeViewItem.Items.Add(node.TreeViewItem);
                node.Initialize();
            }
        }

        public void CreateContextMenu()
        {
            TreeView.ContextMenu.Items.Clear();
            var addServiceMenuItem =
                new MenuItem
                    {
                        Header = "Add service",
                        Icon = new Image
                                   {
                                       Source = new BitmapImage(new Uri("/Images/service_add.png", UriKind.Relative))
                                   }
                    };
            addServiceMenuItem.Click += AddServiceMenuItem_Click;
            TreeView.ContextMenu.Items.Add(addServiceMenuItem);

        }

        private void AddServiceMenuItem_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
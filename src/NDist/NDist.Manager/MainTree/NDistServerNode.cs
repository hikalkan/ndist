using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Hik.Communication.Scs.Communication.EndPoints;
using Hik.Communication.ScsServices.Client;
using Hik.NDist.Management;

namespace Hik.NDist.Manager.MainTree
{
    internal class NDistServerNode : IMainTreeItem
    {
        public TreeView TreeView { get; set; }

        public string Address { get; private set; }

        private IScsServiceClient<INDistManagementService> _client;

        private readonly NDistServerListener _serverListener;

        public NDistServerNode(string address)
        {
            Address = address;
            _serverListener = new NDistServerListener();
        }
        
        public void Connect()
        {
            _client = ScsServiceClientBuilder.CreateClient<INDistManagementService>(ScsEndPoint.CreateEndPoint(Address), _serverListener);
            _client.Connected += Client_Connected;
            _client.Disconnected += Client_Disconnected;
            _client.Connect();
        }

        protected virtual void Client_Disconnected(object sender, EventArgs e)
        {

        }

        protected virtual void Client_Connected(object sender, EventArgs e)
        {
            Task.Factory.StartNew(() => _client.ServiceProxy.Register());
        }

        public void Dispose()
        {
            _client.Dispose();
        }

        public TreeViewItem TreeViewItem { get; set; }

        public void Initialize()
        {
            var node = new NDistServicesNode(_client, _serverListener) { TreeView = TreeView };
            node.TreeViewItem = new TreeViewItem { Header = TreeviewHelper.CreateHeader("Services", "/Images/services.png"), Tag = node };
            TreeViewItem.Items.Add(node.TreeViewItem);
            node.Initialize();
        }

        public void CreateContextMenu()
        {
            TreeView.ContextMenu.Items.Clear();
        }
    }
}
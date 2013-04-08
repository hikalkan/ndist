using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace Hik.NDist.Manager.MainTree
{
    public class NDistServersNode : IMainTreeItem
    {
        public TreeView TreeView { get; set; }

        public TreeViewItem TreeViewItem { get; set; }

        public void Initialize()
        {
            var node = new NDistServerNode("127.0.0.1:30086") { TreeView = TreeView };
            node.Connect();
            AddServerNode(node);
        }

        public void CreateContextMenu()
        {
            TreeView.ContextMenu.Items.Clear();
            var addServerMenuItem =
                new MenuItem
                    {
                        Header = "Add server",
                        Icon = new Image
                                   {
                                       Source = new BitmapImage(new Uri("/Images/server_add.png", UriKind.Relative))
                                   }
                    };
            addServerMenuItem.Click += AddServerMenuItem_Click;
            TreeView.ContextMenu.Items.Add(addServerMenuItem);
        }

        private void AddServerMenuItem_Click(object sender, RoutedEventArgs e)
        {
        }

        private void AddServerNode(NDistServerNode node)
        {
            node.TreeViewItem = new TreeViewItem { Header = TreeviewHelper.CreateHeader(node.Address, "/Images/server.png"), Tag = node };
            TreeViewItem.Items.Add(node.TreeViewItem);
            TreeViewItem.IsExpanded = true;
            node.Initialize();
        }

        public void Dispose()
        {
            foreach (TreeViewItem item in TreeViewItem.Items)
            {
                var node = (NDistServerNode) item.Tag;
                node.Dispose();
            }
        }
    }
}
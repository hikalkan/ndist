using System.Windows;
using System.Windows.Controls;
using Hik.NDist.Manager.MainTree;

namespace Hik.NDist.Manager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            WpfHelper.Dispatcher = Dispatcher;
            InitializeMainTree();
        }

        private void InitializeMainTree()
        {
            var node = new NDistServersNode {TreeView = MainTree};
            node.TreeViewItem = new TreeViewItem { Header = TreeviewHelper.CreateHeader("Servers", "/Images/servers.png"), Tag = node };
            MainTree.Items.Add(node.TreeViewItem);
            node.Initialize();
        }

        private void MainTree_ContextMenuOpening(object sender, ContextMenuEventArgs e)
        {
            if (MainTree.SelectedItem == null)
            {
                e.Handled = true;
                return;
            }

            var item = (IMainTreeItem) ((TreeViewItem) MainTree.SelectedItem).Tag;
            item.CreateContextMenu();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            foreach (TreeViewItem item in MainTree.Items)
            {
                ((IMainTreeItem)item.Tag).Dispose();
            }
        }
    }
}

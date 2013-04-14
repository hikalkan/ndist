using System.Windows;
using System.Windows.Controls;
using Hik.NDist.Manager.MainTree;
using Hik.NDist.Manager.Pages;

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

        private void Menu_Services_InstallService(object sender, RoutedEventArgs e)
        {
            CreateNewTabPage(new InstallServicePage());
        }

        private void CreateNewTabPage(object control)
        {
            var tabItem = new TabItem {Header = "Install new service", Content = control};
            MainPages.Items.Add(tabItem);
            tabItem.IsSelected = true;
        }
    }
}

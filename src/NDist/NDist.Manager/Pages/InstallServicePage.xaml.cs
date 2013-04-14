using System.Windows.Controls;
using Hik.NDist.Manager.Pages.Controls;

namespace Hik.NDist.Manager.Pages
{
    /// <summary>
    /// Interaction logic for InstallServicePage.xaml
    /// </summary>
    public partial class InstallServicePage : UserControl
    {
        public InstallServicePage()
        {
            InitializeComponent();
            Initialize();
        }

        private void Initialize()
        {
            ServiceList.Items.Add(new ServiceInfoInList());
            ServiceList.Items.Add(new ServiceInfoInList());
            ServiceList.Items.Add(new ServiceInfoInList());
        }

        private void InstallServiceButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (ServiceList.SelectedItems.Count <= 0)
            {
                return;
            }

            var selectedServiceItem = ServiceList.SelectedItems[0] as ServiceInfoInList;

        }
    }
}

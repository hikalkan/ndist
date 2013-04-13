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
            ServiceList.Children.Add(new ServiceInfoInList());
            ServiceList.Children.Add(new ServiceInfoInList());
            ServiceList.Children.Add(new ServiceInfoInList());
            ServiceList.Children.Add(new ServiceInfoInList());
            ServiceList.Children.Add(new ServiceInfoInList());
        }
    }
}

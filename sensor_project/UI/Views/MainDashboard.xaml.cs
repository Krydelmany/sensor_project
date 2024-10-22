using System.Windows;

namespace sensor_project.UI.Views
{
    public partial class MainDashboard : Window
    {
        public MainDashboard()
        {
            InitializeComponent();
            DataContext = new sensor_project.Core.DashboardViewModel();
        }
    }
}

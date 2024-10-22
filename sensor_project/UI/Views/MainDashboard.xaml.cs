using System.Windows;
using System.Windows.Media;

namespace sensor_project.UI.Views
{
    public partial class MainDashboard : Window
    {
        public MainDashboard()
        {
            InitializeComponent();
            DataContext = new sensor_project.Core.DashboardViewModel();
        }

        private void Window_Activated(object sender, EventArgs e)
        {
            // Altera a cor da borda quando a janela é ativada
            InnerBorder.BorderBrush = new SolidColorBrush(Color.FromRgb(113, 96, 232)); // Cor personalizada (roxo)
        }

        private void Window_Deactivated(object sender, EventArgs e)
        {
            // Altera a cor da borda quando a janela é desativada
            InnerBorder.BorderBrush = new SolidColorBrush(Color.FromRgb(128, 128, 128)); // Cor personalizada (cinza)
        }

    }
}

using System.Windows;
using System.Windows.Input;
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
            // Altera a cor da borda quando a janela é focada
            InnerBorder.BorderBrush = new SolidColorBrush(Color.FromRgb(52, 52, 52)); // Cor personalizada (roxo)
        }

        private void Window_Deactivated(object sender, EventArgs e)
        {
            // Altera a cor da borda quando a janela sai do foco
            InnerBorder.BorderBrush = new SolidColorBrush(Color.FromRgb(61, 61, 61)); // Cor personalizada (cinza)
        }
        private void TitleBar_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ClickCount == 2)
            {
                if (WindowState == WindowState.Maximized)
                    WindowState = WindowState.Normal;
                else
                    WindowState = WindowState.Maximized;
            }
            else
            {
                DragMove();
            }
        }


        private void MinimizeButton_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void MaximizeButton_Click(object sender, RoutedEventArgs e)
        {
            if (WindowState == WindowState.Maximized)
                WindowState = WindowState.Normal;
            else
                WindowState = WindowState.Maximized;
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

    }
}

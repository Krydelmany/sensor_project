using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Controls; // Add this line to fix Border reference

namespace sensor_project.UI.Views
{
    public partial class MainDashboard : Window
    {
        public MainDashboard()
        {
            InitializeComponent();
            InitializeWidgetAnimations();
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

        private void Widget_MouseEnter(object sender, MouseEventArgs e)
        {
            if (sender is Border border)
            {
                DoubleAnimation scaleAnimation = new DoubleAnimation
                {
                    To = 1.05,
                    Duration = TimeSpan.FromMilliseconds(200)
                };

                border.RenderTransform = new ScaleTransform();
                border.RenderTransformOrigin = new Point(0.5, 0.5);
                border.RenderTransform.BeginAnimation(ScaleTransform.ScaleXProperty, scaleAnimation);
                border.RenderTransform.BeginAnimation(ScaleTransform.ScaleYProperty, scaleAnimation);
            }
        }

        private void Widget_MouseLeave(object sender, MouseEventArgs e)
        {
            if (sender is Border border)
            {
                DoubleAnimation scaleAnimation = new DoubleAnimation
                {
                    To = 1.0,
                    Duration = TimeSpan.FromMilliseconds(200)
                };

                border.RenderTransform.BeginAnimation(ScaleTransform.ScaleXProperty, scaleAnimation);
                border.RenderTransform.BeginAnimation(ScaleTransform.ScaleYProperty, scaleAnimation);
            }
        }

        private void InitializeWidgetAnimations()
        {
            TemperatureWidget.MouseEnter += Widget_MouseEnter;
            TemperatureWidget.MouseLeave += Widget_MouseLeave;
            HumidityWidget.MouseEnter += Widget_MouseEnter;
            HumidityWidget.MouseLeave += Widget_MouseLeave;
            MovementWidget.MouseEnter += Widget_MouseEnter;
            MovementWidget.MouseLeave += Widget_MouseLeave;
        }
    }
}

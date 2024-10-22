using sensor_project.Sensors.Temperature;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace sensor_project
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private TemperatureSensor temperatureSensor;

        public MainWindow()
        {
            InitializeComponent();

            temperatureSensor = new TemperatureSensor();

            // Atualiza o label com a temperatura simulada
            UpdateTemperatureLabel();
        }
        private void UpdateTemperatureLabel()
        {
            // Obtém a temperatura do sensor simulado
            double temperature = temperatureSensor.GetTemperature();

            // Atualiza o texto do Label com a temperatura obtida
            temperatureLabel.Content = $"Temperatura: {temperature}°C";
        }
    }
}
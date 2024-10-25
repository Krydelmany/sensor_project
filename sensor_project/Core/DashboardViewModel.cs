using System;
using System.ComponentModel;
using System.Windows.Input;
using System.Windows.Threading;
using sensor_project.MotionDetection;
using sensor_project.Sensors.Humidity;
using sensor_project.Sensors.Temperature;

namespace sensor_project.Core
{
    public class DashboardViewModel : INotifyPropertyChanged
    {
        private TemperatureSensor temperatureSensor;
        private HumiditySensor humiditySensor;
        private MovementSensor movementSensor;
        private DispatcherTimer simulationTimer;

        private RelayCommand startSimulationCommand;
        public ICommand StartSimulationCommand => startSimulationCommand;

        private RelayCommand stopSimulationCommand;
        public ICommand StopSimulationCommand => stopSimulationCommand;

        private bool isSimulationActive;

        public bool IsSimulationActive
        {
            get => isSimulationActive;
            set
            {
                if (isSimulationActive != value)
                {
                    isSimulationActive = value;
                    OnPropertyChanged(nameof(IsSimulationActive));
                    OnPropertyChanged(nameof(IsStartSimulationButtonEnabled));
                    OnPropertyChanged(nameof(IsStopSimulationButtonEnabled));
                }
            }
        }

        public bool IsStartSimulationButtonEnabled => !IsSimulationActive;
        public bool IsStopSimulationButtonEnabled => IsSimulationActive;


        private double temperature;
        public double Temperature
        {
            get => temperature;
            set
            {
                temperature = value;
                OnPropertyChanged(nameof(Temperature));
            }
        }

        private double humidity;
        public double Humidity
        {
            get => humidity;
            set
            {
                humidity = value;
                OnPropertyChanged(nameof(Humidity));
            }
        }

        private bool isMovementDetected;
        public bool IsMovementDetected
        {
            get => isMovementDetected;
            set
            {
                isMovementDetected = value;
                OnPropertyChanged(nameof(IsMovementDetected));
            }
        }

        public DashboardViewModel()
        {
            temperatureSensor = new TemperatureSensor();
            humiditySensor = new HumiditySensor();
            movementSensor = new MovementSensor();

            // Timer para simular leitura de sensores a cada 2 segundos
            simulationTimer = new DispatcherTimer();
            simulationTimer.Interval = TimeSpan.FromSeconds(2);
            simulationTimer.Tick += SimulateSensors;

            // Inicializa os comandos
            startSimulationCommand = new RelayCommand(StartSimulation);
            stopSimulationCommand = new RelayCommand(StopSimulation);
        }

        private void StartSimulation(object? parameter)
        {
            IsSimulationActive = true; 
            simulationTimer.Start();
        }

        private void StopSimulation(object? parameter)
        {
            IsSimulationActive = false; 
            simulationTimer.Stop();
        }

        private void SimulateSensors(object? sender, EventArgs e)
        {
            try
            {
                IsMovementDetected = movementSensor.IsMovementDetected();
                if (IsMovementDetected)
                {
                    Temperature = temperatureSensor.GetSimulatedTemperature();
                    Humidity = humiditySensor.GetSimulatedHumidity();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

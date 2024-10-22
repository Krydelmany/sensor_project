using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sensor_project.Sensors.Temperature
{
    public class TemperatureSensor
    {
        private Random random;

        public TemperatureSensor()
        {
            random = new Random();
        }

        // Simulação de valores de temperatura entre -10 e 40 graus Celsius
        public double GetSimulatedTemperature()
        {
            return Math.Round(random.NextDouble() * 50 - 10, 2); // entre -10°C e 40°C
        }
    }
}

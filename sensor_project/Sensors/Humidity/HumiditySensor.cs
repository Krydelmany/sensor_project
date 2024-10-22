using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sensor_project.Sensors.Humidity
{
    public class HumiditySensor
    {
        private Random random;

        public HumiditySensor()
        {
            random = new Random();
        }

        // Simulação de valores de umidade entre 0% e 100%
        public double GetSimulatedHumidity()
        {
            return Math.Round(random.NextDouble() * 100, 2); // entre 0% e 100%
        }
    }
}

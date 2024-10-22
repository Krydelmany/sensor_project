using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sensor_project.MotionDetection
{
    public class MovementSensor
    {
        private Random random;

        public MovementSensor()
        {
            random = new Random();
        }

        // Simulação do sensor de movimento ativado em intervalos aleatórios
        public bool IsMovementDetected()
        {
            return random.Next(0, 100) > 70; // 30% de chance de detectar movimento
        }
    }
}


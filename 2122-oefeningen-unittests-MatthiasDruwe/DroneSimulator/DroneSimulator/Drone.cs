using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DroneSimulator
{
    internal class Drone
    {
        public double Height { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public double Rotation { get; set; }
        public Boolean MotorOn { get; set; }

        public Drone()
        {
            Height = 0;
            Latitude = 0;
            Longitude = 0;
            Rotation = 0;
        }


        public override string ToString()
        {
            return $"h:{Height}, lat:{Latitude}, long:{Longitude}, r:{Rotation}";
        }
    }
}

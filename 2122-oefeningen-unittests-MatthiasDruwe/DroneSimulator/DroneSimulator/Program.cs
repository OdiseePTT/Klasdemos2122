using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DroneSimulator
{
    class Program
    {
        static void Main(string[] args)
        {
            Drone d = new Drone();
            Remote r = new Remote(d);
            
            r.TakeOff();
           
            r.MoveForward();
    
            Console.WriteLine(d);
            r.MoveDown();
            for (int i = 0; i < 500; i++)
            {
                r.MoveUp();
                Console.WriteLine(d);
            }
           
            Console.ReadLine();
        }
    }
}

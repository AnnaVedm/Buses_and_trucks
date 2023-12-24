using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buses_and_trucks
{
    internal class Program
    {
        public static void Main()
        {
            Console.Title = "Автобусы и грузовики";
            Random random = new Random();
            Console.WriteLine("Выберите машину\n1. Автобус    \n2. Грузовик");
            string input = Console.ReadLine();
            if (input == "1")
            {
                Console.Clear();
                Console.WriteLine("АВТОБУС");
                Bus bus = new Bus();
                bus.Start();
            }
            else if (input == "2")
            {
                Console.Clear();
                Console.WriteLine("ГРУЗОВИК");
                Truck truck = new Truck();
                truck.Start();
            }
            else
            {
                Console.WriteLine("ОШИБКА!!! Нажмите любую клавишу и попробуйте ещё раз");
                Console.ReadKey();
                Console.Clear();
                Main();
            }
        }
    }
}


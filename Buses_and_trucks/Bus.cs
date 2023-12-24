using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buses_and_trucks
{
    internal class Bus : Avto
    {
        int people;
        protected double weight;
        public void Start()
        {
            InfoInput();
            InfoOutput();
            Trip();
        }
        protected override void InfoInput()
        {
            base.InfoInput();
            int avgWeight = 62;
            Console.Write("\nИНСТРУКЦИЯ К РАСЧЁТАМ ВЕЛИЧИН В КОДЕ (СКОРОСТЬ) \n");
            Console.Write("\n=========================================");
            Console.Write($"\nВес >= 1000 кг  -  скорость / 1,5 \n\nВес >= 2000  -  скорость / 2\n");
            Console.Write("\n=========================================\n");
            Console.WriteLine($"\nСредний вес человека - {avgWeight} кг");
            Console.WriteLine("\nВведите кол-во пассажиров (не больше 40): ");
            people = Convert.ToInt32(Console.ReadLine());

            while (people > 40)
            {
                Console.WriteLine("ОШИБКА!!! Попробуйте ещё раз\nВведите кол-во пассажиров (не больше 40): ");
                people = Convert.ToInt32(Console.ReadLine());
            }
            Console.Clear();
            weight = people * avgWeight;
        }
        protected override void InfoOutput()
        {
            Console.Write($"\nВес: {weight} кг");
            base.InfoOutput();
            ostanovka();
        }
        protected override void Trip()
        {
            if (weight >= 2000)
            {
                speed = Math.Round(speed / 2, 2);
            }
            else if (weight >= 1000)
            {
                speed = Math.Round(speed / 1.5, 2);
            }
            base.Trip();
        }
        private void ostanovka()
        {
            //Console.WriteLine("\nВы на остановке и подбираете людей ");
            int cost = 40;

            cost *= people;

            Console.WriteLine($"В автобус вошло {people} человек");
            Console.WriteLine($"Выручка за поездку: {cost} руб");
        }
    }
}

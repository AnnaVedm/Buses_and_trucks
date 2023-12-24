using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buses_and_trucks
{
    internal class Truck : Avto
    {
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
            Console.Write("\nИНСТРУКЦИЯ К РАСЧЁТАМ ВЕЛИЧИН В КОДЕ (СКОРОСТЬ): \n");
            Console.Write("\n=========================================");
            Console.Write($"\n2500 кг  -  скорость / 1,5  \n\n4000 кг -  скорость / 2");
            Console.Write("\n=========================================\n");
            Console.WriteLine("\nВведите вес груза (не больше 5000): ");
            weight = Convert.ToDouble(Console.ReadLine());
            while (weight > 5000)
            {
                Console.Write("ОШИБКА!!! Попробуйте ещё раз\nВведите вес груза (не больше 5000): ");
                weight = Convert.ToDouble(Console.ReadLine());
            }
            if (weight >= 4000)
            {
                speed = Math.Round(speed / 2, 2);
            }
            else if (weight >= 2500)
            {
                speed = Math.Round(speed / 1.5, 2);
            }
        }
        protected override void InfoOutput()
        {
            Console.Write($"\nВес: {weight} кг");
            base.InfoOutput();
            pogruzka_razgruzka();
        }
        protected override void Trip()
        {
            if (weight >= 4000)
            {
                speed = Math.Round(speed / 2, 2);
            }
            else if (weight >= 2500)
            {
                speed = Math.Round(speed / 1.5, 2);
            }
            base.Trip();
        }
        private void pogruzka_razgruzka()
        {
            Console.WriteLine("\nВведите что хотите сделать с грузом:");
            Console.WriteLine("1. Оставить груз");
            Console.WriteLine("2. Взять груз");
            Console.WriteLine("3. Ничего не делать");
            int vybor = Convert.ToInt32(Console.ReadLine());
            switch (vybor)
            {
                case 1:
                    Console.WriteLine("Вы выбрали оставить груз");
                    Console.WriteLine("Сколько груза хотите оставить?");
                    int gruz = Convert.ToInt32(Console.ReadLine());

                    while (gruz > weight || gruz < 0)
                    {
                        Console.WriteLine("ОШИБКА!!!! Вы ввели некорректное значение, попробуйте снова");
                        gruz = Convert.ToInt32(Console.ReadLine());
                    }
                    weight -= gruz;
                    break;
                case 2:
                    Console.WriteLine("Вы выбрали взять груз");
                    Console.WriteLine("Сколько груза хотите взять?");

                    int gruz1 = Convert.ToInt32(Console.ReadLine());

                    while (gruz1 > weight || gruz1 < 0 || gruz1 > 5000 || (weight + gruz1 > 5000))
                    {
                        Console.WriteLine("ОШИБКА!!!! Вы ввели некорректное значение, попробуйте снова");
                        gruz1 = Convert.ToInt32(Console.ReadLine());
                    }
                    weight += gruz1;
                    break;
                case 3:
                    Console.WriteLine("Вы едете дальше");
                    break;
            }
        }
    }
}

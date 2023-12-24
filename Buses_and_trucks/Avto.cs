using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buses_and_trucks
{
    internal class Avto
    {
        protected int benzin_bak_max;
        protected double benzin_bak;
        protected double speed;
        protected double rashod;
        protected double km_max = 0;
        protected double km = 0;
        protected double probeg;
        protected Random random = new Random();

        protected virtual void InfoInput()
        {
            Console.Write("Введите объём бака (не более 30 литров): ");
            benzin_bak_max = Convert.ToInt32(Console.ReadLine());
            while (benzin_bak_max > 30 || benzin_bak_max <= 0)
            {
                Console.WriteLine("ОШИБКА!!! Попробуйте ещё раз");
            }

            benzin_bak = random.Next(0, benzin_bak_max + 1);
            Console.Write("Введите скорость (не более 110 км/ч): ");
            speed = Convert.ToDouble(Console.ReadLine());

            while (speed > 110 || speed <= 0)
            {
                Console.WriteLine("ОШИБКА!!! Попробуйте ещё раз");
            }

            Console.Write("Введите расход топлива на 100 км (от 5 до 15 литров): ");
            rashod = Convert.ToDouble(Console.ReadLine());
            while (rashod < 5 || rashod > 15)
            {
                Console.WriteLine("ОШИБКА!!! Попробуйте ещё раз");
            }
        }
        protected virtual void InfoOutput()
        {
            Console.WriteLine($"\nСкорость: {speed} км/ч\nРасход: {rashod} л/100км\nПройдено: {km} км\nОсталось: {km_max - km} км\nТопливо: {benzin_bak}/{benzin_bak_max} л\nПробег: {probeg} км");
        }
        protected virtual void Trip()
        {
            Program program = new Program();
            //Bus bus = new Bus();
            km = 0;
            km_max = random.Next(10, 751);
            Console.WriteLine($"\nВы собираетесь проехать:\n{km_max} км\n\n Нажмите Enter, чтобы продолжить");
            //bus.ostanovka();
            Console.ReadKey();
            do
            {
                km += benzin_bak / (rashod / 100);
                if (km < km_max)
                {
                    //probeg += km;
                    benzin_bak = 0;
                    InfoOutput();
                    Zapravka();
                    InfoOutput();
                    Console.WriteLine("\nНажмите Enter, чтобы продолжить");
                    Console.ReadKey();
                }
                else
                {
                    benzin_bak = (km - km_max) * (rashod / 100);
                    km = km_max;
                    //probeg += km;
                    probeg += km_max;
                    InfoOutput();

                    Console.WriteLine("\nЕдем дальше?\n1. Продолжить");
                    Console.WriteLine("2. Выйти");

                    string vybor = Console.ReadLine();
                    if (vybor == "1")
                    {
                        Console.WriteLine("\nХотите заправиться?\n1. Да    \n2. Нет");
                        vybor = Console.ReadLine();
                        if (vybor == "1")
                        {
                            Zapravka();
                        }
                        InfoOutput();
                        Trip();
                    }
                    else
                    {
                        Console.WriteLine("\nИГРА ОКОНЧЕНА");
                        Console.Clear();
                        Program.Main();
                        break;
                    }
                }
            } while (km < km_max);
        }
        protected void Zapravka()
        {
            Console.Write($"\nНа сколько литров хотите заправиться? (Не больше {benzin_bak_max - benzin_bak} л)\nВвод: ");
            double input = Convert.ToDouble(Console.ReadLine());
            if (input <= benzin_bak_max - benzin_bak)
            {
                benzin_bak += input;
            }
            else
            {
                Console.WriteLine("ОШИБКА!!! Попробуйте ещё раз");
                Zapravka();
            }
        }
    }
}

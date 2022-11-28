using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace UserExeption
{
    
    internal class Program
    {
        static void Main(string[] args)
        {

            // Task 1.
            var Misha = new Person_12Plus();
            Console.WriteLine($"Создан пользователь {Misha.Name} введите его имя:");
            Misha.Name = Console.ReadLine();
            //Console.WriteLine($"Задано имя пользователя {Misha.Name} введите возраст:");
            //Misha.Age = int.Parse(Console.ReadLine());
            //var Misha2 = new Person_12Plus(Misha.Name, Misha.Age);

            try
            {
                Console.WriteLine($"Задано имя пользователя {Misha.Name} введите возраст:");
                Misha.Age = int.Parse(Console.ReadLine());
                
            }
            catch (Exception e002)
            {
                Console.WriteLine("Пользовательские ошибки {0}", e002.Message);
            }

            // Task 2.

            //var triangle = new Triangle();
            Triangle myTriangle = new Triangle();

            Thread.CurrentThread.CurrentCulture = new CultureInfo("ru-RU");
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("ru-RU");

            Console.WriteLine($"Создан новый объект типа: {myTriangle.name} введите сторону А: ");
            try
            {

                string str = Console.ReadLine();
                myTriangle._sideA = float.Parse(str, CultureInfo.InvariantCulture);
                
                // myTriangle = myTriangle._sideA.Replace(",", ".");

                //myTriangle._sideA = 15.0f;

            }
            catch (Exception e003)
            {
                Console.WriteLine("Пользовательские ошибки {0}", e003.Message);
            }
            //Console.WriteLine(myTriangle._sideA);
            Console.WriteLine("Введите сторону B: ");
            try
            {
                myTriangle._sideB = (float)Convert.ToDouble(Console.ReadLine());
            }
            catch (Exception e004)
            {
                Console.WriteLine("Пользовательские ошибки {0}", e004.Message);
            }
            Console.WriteLine("Введите сторону C: ");
            try
            {
                myTriangle._sideC = (float)Convert.ToDouble(Console.ReadLine());
            }
            catch (Exception e005)
            {
                Console.WriteLine("Пользовательские ошибки {0}", e005.Message);
            }

            myTriangle.Square();
            myTriangle.Perimeter();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserExeption
{ 
    // Task 1. User Exception Class
    internal class Person_12Plus : Exception
    {
        public Person_12Plus() { }
        public Person_12Plus(string message) : base(message) { }
        public Person_12Plus(string message, Exception innerException) : base(message, innerException) { }
        public Person_12Plus(string name, int age)
        {
            Name = name;
            Age = age;
        }

        private int age;
        public string Name { get; set; } = "User" + DateTime.Now.ToString("yyyy.MM.dd-HH:mm:ss.fff");
        public int Age
        {
        get { return age; } // get => age;
        set
        {
            if (value < 0) // throw new Exception("Некорректный возраст");
            {
                throw new Person_12Plus("Incorrect Age");
                //throw new Exception("Некорректный возраст");
            }
            else
            {
                if (value < 12)
                {
                    throw new Person_12Plus("The age cannot be above 12 years old");
                    //throw new Exception("Возрастное ограничение 12+");
                }
                else age = value;
            }
        }
        }
    }
}

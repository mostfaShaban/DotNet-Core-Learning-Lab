using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASS_02_OOP
{
    internal struct Person
    {
        #region Attributes

        public string Name;
        public int Age;

        #endregion

        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }

        #region methods

        public void ReadData()
        {
            do
            {
                Console.Write("Name: ");
                Name = Console.ReadLine() ?? string.Empty;

                if (!IsNameValid(Name))
                    Console.WriteLine("Invalid name! Use letters only.");

            } while (!IsNameValid(Name));

            while (true)
            {
                Console.Write("Age: ");
                string input = Console.ReadLine() ?? string.Empty;

                if (int.TryParse(input, out int age) && age > 0 && age <= 120)
                {
                    Age = age;
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid age! Enter a number between 1 and 120.");
                }
            }
        }

        public void Display()
        {
            Console.WriteLine($"Name: {Name}, Age: {Age}");
        }


        private static bool IsNameValid(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                return false;

            foreach (char c in name)
            {
                if (!char.IsLetter(c) && c != ' ')
                    return false;
            }
            return true;
        }


        public static Person GetOldest(Person[] people)
        {
            Person oldest = people[0];

            for (int i = 1; i < people.Length; i++)
            {
                if (people[i].Age > oldest.Age)
                {
                    oldest = people[i];
                }
            }

            return oldest;
        }

        #endregion

    }
}

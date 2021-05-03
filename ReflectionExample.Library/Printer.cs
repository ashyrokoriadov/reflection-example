using System;

namespace ReflectionExample.Library
{
    class Printer
    {
        public void Print()
        {
            Console.WriteLine("Вызван метод Print.");
        }

        public void PrintWithParameter(string valueToPrint)
        {
            Console.WriteLine($"Вызван метод Print с параметром {valueToPrint}");
            object test = new object();
        }

        private void PrintPrivate()
        {
            Console.WriteLine($"Вызван метод Private Print.");
        }

        public string StringProperty { get; set; } = "Свойство типа string.";

        private string _privateFiled = "Привет! Я приватное поле.";
    }
}

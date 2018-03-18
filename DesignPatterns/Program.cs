using DesignPatterns.RecursiveGenericsForFluentInheritance;
using DesignPatterns.SimpleBuilder;
using System;

namespace DesignPatterns
{
    class Program
    {
        static void Main(string[] args)
        {
            ShowMenu();
        }

        private static void ShowMenu()
        {
            Console.Clear();
            Console.WriteLine("Please select Design Pattern:");
            Console.WriteLine("1. Builder");

            var response = Console.ReadLine();

            if(!int.TryParse(response, out int menuItem))
            {
                Console.WriteLine("Please select Design Pattern:");
                ShowMenu();
            }

            switch (menuItem)
            {
                case 1:
                    BuilderDemo();
                    break;
                default:
                    Console.WriteLine("Please select the existing menu item.");
                    Console.Read();
                    break;
            }
        }

        private static void ExitToMenu()
        {
            Console.WriteLine();
            Console.WriteLine("Press any button to return to menu...");
            var pressedKey = Console.ReadKey();

            if (pressedKey != null)
            {
                ShowMenu();
            }
        }

        private static void BuilderDemo()
        {
            Console.WriteLine();
            Console.WriteLine("Classic Builder:");
            Console.WriteLine();

            var builder = new HtmlBuilder("ul");
            builder.AddChild("li", "Hello");
            builder.AddChild("li", "World");
            Console.WriteLine(builder.ToString());
            Console.WriteLine();

            Console.WriteLine("Fluent Builder with Recursive Generics:");
            Console.WriteLine();

            var person = Person.New
                .Called("Peter Johnson")
                .WorksAs("Journalist")
                .Build();
            Console.WriteLine(person);

            ExitToMenu();
        }

    }
}

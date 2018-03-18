using DesignPatterns.RecursiveGenericsForFluentInheritance;
using DesignPatterns.SimpleBuilder;
using System;

namespace DesignPatterns
{
    class Program
    {
        static void Main(string[] args)
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

            Console.ReadKey();
        }

    }
}

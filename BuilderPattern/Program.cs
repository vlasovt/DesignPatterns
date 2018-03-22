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

            var person = RecursiveGenericsForFluentInheritance.Person.New
                .Called("Peter Johnson")
                .WorksAs("Journalist")
                .Build();
            Console.WriteLine(person);

            Console.WriteLine();
            Console.WriteLine("Faceted Builder:");
            Console.WriteLine();

            var pb = new FacetedBuilder.PersonBuilder();
            FacetedBuilder.Person facetedPerson = pb.Works
                .At("Toyota")
                .AsA("Engineer")
                .Earning(123000)
                .Lives
                .At("123 london Road")
                .In("London")
                .WithPostcode("ERD DFR");

            Console.WriteLine(facetedPerson);

            Console.ReadKey();
        }

    }
}

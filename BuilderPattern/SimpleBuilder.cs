using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.SimpleBuilder
{
    public class HtmlElement
    {
        private const int identSize = 2;
        public string Name, Text;
        public List<HtmlElement> Elements = new List<HtmlElement>();

        public HtmlElement()
        {

        }

        public HtmlElement(string name, string text)
        {
            Name = name ?? throw new ArgumentNullException(paramName: nameof(name));
            Text = text ?? throw new ArgumentNullException(paramName: nameof(text));
        }

        private string ToStringImpl(int indent)
        {
            var sb = new StringBuilder();
            var i = new string(' ', identSize * indent);
            sb.AppendLine($"{i}<{Name}>");

            if (!string.IsNullOrWhiteSpace(Text))
            {
                sb.Append(new string(' ', identSize * indent + 1));
                

            }

            foreach (var e in Elements)
            {
                sb.Append(e.ToStringImpl(indent + 1));
            }

            sb.AppendLine($"{i}</{Name}>");

            return sb.ToString();
        }

        public override string ToString()
        {
            return ToStringImpl(0);
        }

    }

    public class HtmlBuilder
    {
        private readonly string rootName;
        HtmlElement root = new HtmlElement();

        public HtmlBuilder(string rootName)
        {
            this.rootName = rootName;
            root.Name = rootName;
        }

        // Fluent pattern; it returns the reference to the builder, thus allowing the method chaining : AddChild().AddChild()
        public HtmlBuilder AddChild(string childName, string childText)
        {
            var e = new HtmlElement(childName, childText);
            root.Elements.Add(e);

            return this;
        }

        public override string ToString()
        {
            return root.ToString();
        }

        public void Clear()
        {
            root = new HtmlElement { Name = rootName };
        }
    }
}
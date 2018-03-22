using System.Collections.Generic;
using System.Text;

namespace Coding.Exercise
{
    public class CodeBuilder
    {
        StringBuilder sb = new StringBuilder();
        string className = string.Empty;
        List<string> properties = new List<string>();

        public CodeBuilder(string nameOfClass)
        {
            className = nameOfClass;
        }

        public CodeBuilder AddField(string propertyName, string propertyType)
        {
            properties.Add("  public " + propertyType + " " + propertyName + ";");
            return this;
        }

        public override string ToString()
        {
            sb.AppendLine("public class " + className);
            sb.AppendLine("{");
            foreach (var property in properties)
            {
                sb.AppendLine(property);
            }
            sb.AppendLine("}");

            return sb.ToString();
        }
    }
}

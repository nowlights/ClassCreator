using System.Collections.Generic;

namespace Project.Mapping
{
    public static class CSharpMapper
    {
        public static class Class
        {
            public static string Build(string NameDataBase, string UsingStyleConnection, string NameTable, List<Entities.Props> Props)
            {
                string code = "public class " + NameTable + " \r\n{";
                foreach (var i in Props)
                {
                    code += "\r\n\tpublic " + i.Type + " " + i.Name + " { get; set; }";
                }
                code += "\r\n}";
                return code;
            }
        }

        
    }
}
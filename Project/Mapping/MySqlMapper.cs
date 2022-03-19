using System.Collections.Generic;
using System.Linq;

namespace Project.Mapping
{
    public static class MySqlMapper
    {
        private static class TypeToMySql
        {
            public static string Convert(string type)
            {
                var t = type.ToLower();
                if (t == "string") return "VARCHAR(45)";
                else if (t == "decimal" || t == "double") return "DECIMAL";
                else return t.ToUpper(); // variaves ambiguas int, datetime...
            }
        }


        // os nomes da classes aninhadas Create, Insert... deve conter na lista de LanguageTypes

        public static class Create
        {
            public static string Build(string NameDataBase, string UsingStyleConnection, string NameTable, List<Entities.Props> Props)
            {
                string code = $"CREATE TABLE `{NameDataBase}`.`{NameTable}` (\r\n";

                for (var i = 0; i < Props.Count; i++)
                {
                    if (i == 0 && Props[i].Name.ToLower().Contains("id"))
                        code += $"`{Props[i].Name}` INT {(Props[i].NotNull ? "NOT NULL" : "NULL")} AUTO_INCREMENT, \r\n";
                    else
                        code += $"`{Props[i].Name}` {TypeToMySql.Convert(Props[i].Type)} {(Props[i].NotNull ? "NOT NULL" : "NULL")}, \r\n";

                    if (i == Props.Count - 1 && Props[0].Name.ToLower().Contains("id"))
                        code += $"PRIMARY KEY (`{Props[0].Name}`));";
                }
                return code;
            }


        }

        public static class Insert
        {
            public static string Build(string NameDataBase, string UsingStyleConnection, string NameTable, List<Entities.Props> Props)
            {
                string code = $"INSERT INTO `{NameDataBase}`.`{NameTable}` (";
                string codeParam = "";
                foreach (var i in Props)
                {
                    code += $"{i.Name}, ";
                    codeParam += $"@{i.Name}, ";
                }
                code = code.Remove(code.Length - 2, 2);
                codeParam = codeParam.Remove(codeParam.Length - 2, 2);
                code += $") VALUES ({codeParam})";
                return code;
            }
        }

        public static class Select
        {
            public static string Build(string NameDataBase, string UsingStyleConnection, string NameTable, List<Entities.Props> Props)
            {
                string code = $"SELECT * FROM `{NameDataBase}`.`{NameTable}` WHERE ...";
                return code;
            }
        }

        public static class Update
        {
            public static string Build(string NameDataBase, string UsingStyleConnection, string NameTable, List<Entities.Props> Props)
            {
                string code = $"UPDATE `{NameDataBase}`.`{NameTable}` SET ";
                foreach (var i in Props)
                    code += $"{i.Name}=@{i.Name}, ";

                code = code.Remove(code.Length - 2, 2);

                if (Props[0].Name.ToLower().Contains("id"))
                {
                    code += $" WHERE {Props[0].Name}=@{Props[0].Name}";
                }
                return code;
            }
        }

        public static class Delete
        {
            public static string Build(string NameDataBase, string UsingStyleConnection, string NameTable, List<Entities.Props> Props)
            {
                string code = $"DELETE FROM `{NameDataBase}`.`{NameTable}` WHERE ";
                if (Props[0].Name.ToLower().Contains("id")) code += $"{Props[0].Name}=@{Props[0].Name}";
                else code += "...";
                return code;
            }
        }

    }
}
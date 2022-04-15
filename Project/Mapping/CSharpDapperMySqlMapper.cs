using System.Collections.Generic;
using Project.Extension;

namespace Project.Mapping
{
    public class CSharpDapperMySqlMapper
    {
        public static class Create_Async
        {
            public static string Build(string NomeDataBase, string UsingStyleConnection, string NameTable, List<Entities.Props> Props)
            {
                string code = $"public async Task<int> Create({NameTable} x)";
                code += "\r\n{";
                code += "\r\n\tTry";
                code += "\r\n\t{";
                code += $"\r\n\t\tvar sql = $\"INSERT INTO {NameTable} (";
                for (int i = 0; i < Props.Count; i++)
                {
                    if (i == 0 && Props[i].Name.ToLower().Contains("id")) { }
                    else
                        code += Props[i].Name + ",";
                }
                code = code.RemoveLast(); code += ") VALUES (";
                for (int i = 0; i < Props.Count; i++)
                {
                    if (i == 0 && Props[i].Name.ToLower().Contains("id")) { }
                    else
                        code += "@" + Props[i].Name + ",";
                }
                code = code.RemoveLast(); code += ")\";";
                code += $"\r\n\t\t{UsingStyleConnection}";
                code += "\r\n\t\t{";
                code += "\r\n\t\t\tvar res = await cn.ExecuteAsync(sql, x);";
                code += "\r\n\t\t\treturn res;";
                code += "\r\n\t\t}";
                code += "\r\n\t}";
                code += "\r\n\tcatch (System.Exception) { throw; }";
                code += "\r\n}";

                return code;
            }
        }
        public static class Get_Async
        {
            public static string Build(string NameDataBase, string UsingStyleConnection, string NameTable, List<Entities.Props> Props)
            {
                string code = $"public async Task<{NameTable}> GetAsync(";
                code += Props[0].Name.ToLower().Contains("id") ? $"int {Props[0].Name})" : ")";
                code += "\r\n{";
                code += "\r\n\tTry";
                code += "\r\n\t{";

                code += "\r\n\t\tvar param = new {";
                code += Props[0].Name.ToLower().Contains("id") ? $" {Props[0].Name} " : "";
                code += "};";

                code += $"\r\n\t\tvar sql = \"SELECT * FROM {NameTable} WHERE ";
                code += Props[0].Name.ToLower().Contains("id") ? $"{Props[0].Name}=@{Props[0].Name}\";" : "...\";";


                code += $"\r\n\t\t{UsingStyleConnection}";
                code += "\r\n\t\t{";
                code += $"\r\n\t\t\tvar res = await cn.QueryAsync<{NameTable}>(sql, param);";
                code += $"\r\n\t\t\treturn res.FirstOrDefault();";
                code += "\r\n\t\t}";
                code += "\r\n\t}";
                code += "\r\n\tcatch(System.Exception) { throw; }";
                code += "\r\n}";

                return code;
            }
        }

        public static class Get_List_Async
        {
            public static string Build(string NameDataBase, string UsingStyleConnection, string NameTable, List<Entities.Props> Props)
            {
                string code = $"public async Task<List<{NameTable}>> GetListAsync(";
                code += Props[0].Name.ToLower().Contains("id") ? $"int {Props[0].Name})" : ")";
                code += "\r\n{";
                code += "\r\n\tTry";
                code += "\r\n\t{";

                code += "\r\n\t\tvar param = new {";
                code += Props[0].Name.ToLower().Contains("id") ? $" {Props[0].Name} " : "";
                code += "};";

                code += $"\r\n\t\tvar sql = \"SELECT * FROM {NameTable} WHERE ";
                code += Props[0].Name.ToLower().Contains("id") ? $"{Props[0].Name}=@{Props[0].Name}\";" : "...\";";


                code += $"\r\n\t\t{UsingStyleConnection}";
                code += "\r\n\t\t{";
                code += $"\r\n\t\t\tvar res = await cn.QueryAsync<{NameTable}>(sql, param);";
                code += $"\r\n\t\t\treturn res.ToList();";
                code += "\r\n\t\t}";
                code += "\r\n\t}";
                code += "\r\n\tcatch(System.Exception) { throw; }";
                code += "\r\n}";

                return code;
            }
        }

        public static class Update_Async
        {
            public static string Build(string NameDataBase, string UsingStyleConnection, string NameTable, List<Entities.Props> Props)
            {
                string code = $"public async Task<int> UpdateAsync(";
                code += Props[0].Name.ToLower().Contains("id") ? $"int {Props[0].Name})" : ")";
                code += "\r\n{";
                code += "\r\n\tTry";
                code += "\r\n\t{";

                code += "\r\n\t\tvar param = new {";
                code += Props[0].Name.ToLower().Contains("id") ? $" {Props[0].Name} " : "";
                code += "};";

                code += $"\r\n\t\tvar sql = \"UPDATE {NameTable} SET ";
                foreach (var i in Props)
                {
                    if (Props[0].Name.ToLower().Contains("id") && Props[0].Name.ToLower() == i.Name.ToLower()) { }
                    else
                        code += $"{i.Name}=@{i.Name}, ";
                }
                code = code.Remove(code.Length - 2, 2);
                code += " WHERE ";

                code += Props[0].Name.ToLower().Contains("id") ? $"{Props[0].Name}=@{Props[0].Name}\";" : "...\";";


                code += $"\r\n\t\t{UsingStyleConnection}";
                code += "\r\n\t\t{";
                code += $"\r\n\t\t\tvar res = await cn.ExecuteAsync(sql, param);";
                code += $"\r\n\t\t\treturn res; // return rows affected";
                code += "\r\n\t\t}";
                code += "\r\n\t}";
                code += "\r\n\tcatch(System.Exception) { throw; }";
                code += "\r\n}";

                return code;
            }
        }

        public static class Delete_Async
        {
            public static string Build(string NameDataBase, string UsingStyleConnection, string NameTable, List<Entities.Props> Props)
            {
                string code = $"public async Task<int> DeleteAsync(";
                code += Props[0].Name.ToLower().Contains("id") ? $"int {Props[0].Name})" : ")";
                code += "\r\n{";
                code += "\r\n\tTry";
                code += "\r\n\t{";

                code += "\r\n\t\tvar param = new {";
                code += Props[0].Name.ToLower().Contains("id") ? $" {Props[0].Name} " : "";
                code += "};";

                code += $"\r\n\t\tvar sql = \"DELETE FROM {NameTable} WHERE ";
                code += Props[0].Name.ToLower().Contains("id") ? $"{Props[0].Name}=@{Props[0].Name}\";" : "...\";";


                code += $"\r\n\t\t{UsingStyleConnection}";
                code += "\r\n\t\t{";
                code += $"\r\n\t\t\tvar res = await cn.ExecuteAsync(sql, param);";
                code += $"\r\n\t\t\treturn res; // return rows affected";
                code += "\r\n\t\t}";
                code += "\r\n\t}";
                code += "\r\n\tcatch(System.Exception) { throw; }";
                code += "\r\n}";

                return code;
            }
        }

        public static class Complete_Crud
        {
            public static string Build(string NameDataBase, string UsingStyleConnection, string NameTable, List<Entities.Props> Props)
            {
                string code = "";
                code += Create_Async.Build(NameDataBase, UsingStyleConnection, NameTable, Props);
                code += "\r\n\r\n";
                code += Get_Async.Build(NameDataBase, UsingStyleConnection, NameTable, Props);
                code += "\r\n\r\n";
                code += Get_List_Async.Build(NameDataBase, UsingStyleConnection, NameTable, Props);
                code += "\r\n\r\n";
                code += Update_Async.Build(NameDataBase, UsingStyleConnection, NameTable, Props);
                code += "\r\n\r\n";
                code += Delete_Async.Build(NameDataBase, UsingStyleConnection, NameTable, Props);
                return code;
            }
        }


    }
}
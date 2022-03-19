using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Project.Mapping
{
    public class MappingCall
    {
        public class LanguagesTypes
        {
            public string Lang { get; set; }
            public string[] Statament { get; set; }

            public static List<LanguagesTypes> Langs()
            {
                var lt = new List<LanguagesTypes>();
                lt.Add(new LanguagesTypes { Lang = "MySql", Statament = new string[] { "create", "insert", "select", "update", "delete" } });
                lt.Add(new LanguagesTypes { Lang = "CSharp", Statament = new string[] { "class" } });
                lt.Add(new LanguagesTypes { Lang = "CSharp + Dapper + MySql", Statament = new string[] { "Get_Async", "Get_List_Async", "Update_Async", "Delete_Async", "Complete_Crud" } });
                return lt;
            }

        }

        private static string MappingLangToClass(string LANG)
        {
            switch (LANG.ToLower())
            {
                case "mysql": return "Project.Mapping.MySqlMapper";
                case "csharp": return "Project.Mapping.CSharpMapper";
                case "csharp + dapper + mysql": return "Project.Mapping.CSharpDapperMySqlMapper";
            }
            throw new ArgumentNullException("LANG is null");
        }
        public static string Mapper(string LANG, string CRUD, string NameDataBase, string UsingStyleConnection, string NameTable, List<Entities.Props> Props)
        {
            object[] param = { NameDataBase, UsingStyleConnection, NameTable, Props };

            if (Props != null)
                if (Props.Count() >= 1)
                    if (LanguagesTypes.Langs().Count(x => x.Lang.ToLower() == LANG) >= 1)
                    {

                        var classes = Assembly.GetExecutingAssembly().GetTypes().Where(x => x.FullName.Contains(MappingLangToClass(LANG)));

                        foreach (var i in classes)
                        {
                            if (i.Name.ToLower().Contains(CRUD.ToLower()))
                            {
                                var x = Convert.ToString(i.GetMethod("Build").Invoke(null, param));
                                return x;
                            }
                        }

                    }

            return "";
        }
    }
}
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
            public List<string> Statament { get; set; }
            public string ClassName { get; set; }

            public static List<LanguagesTypes> Langs()
            {
                var lt = new List<LanguagesTypes>();
                lt.Add(new LanguagesTypes { Lang = "MySql", ClassName = "Project.Mapping.MySqlMapper" });
                lt.Add(new LanguagesTypes { Lang = "CSharp", ClassName = "Project.Mapping.CSharpMapper" });
                lt.Add(new LanguagesTypes { Lang = "CSharp + Dapper + MySql", ClassName = "Project.Mapping.CSharpDapperMySqlMapper" });
                foreach (var i in lt)
                {
                    var classes = Assembly.GetExecutingAssembly().GetTypes().Where(x => x.FullName.Contains(i.ClassName));
                    foreach (var c in classes)
                    {
                        if (i.Statament == null)
                            i.Statament = new List<string>();

                        if (!c.Name.Contains("Mapper"))
                            if (!c.Name.Contains(i.Lang))
                                i.Statament.Add(c.Name.ToUpper());
                    }
                }
                return lt;
            }
        }

        private static string MappingLangToClass(string LANG)
        {
            var langs = LanguagesTypes.Langs();
            var langFind = langs.Where(x => x.Lang.ToLower() == LANG.ToLower()).FirstOrDefault();
            if (langFind != null)
                return langFind.ClassName;
            else throw new ArgumentNullException("Not found this lang");
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
using System.Threading.Tasks;
using Project.Entities;
using Newtonsoft.Json;
using System.IO;
using System.Collections.Generic;
using System;
using System.Linq;

namespace Project.Data
{
    public class iProjetoService
    {
        private string NameFile { get; } = "projetos.json";

        private string NewGuid()
        {
            return Guid.NewGuid().ToString().Substring(0, 6);
        }

        private async Task<List<Projeto>> Deserialize()
        {
            using (var r = new StreamReader(NameFile))
            {
                string json = await r.ReadToEndAsync();
                return JsonConvert.DeserializeObject<List<Projeto>>(json);
            }
        }

        private async Task Serialize(List<Projeto> data)
        {
            await File.WriteAllTextAsync(NameFile, JsonConvert.SerializeObject(data));
        }

        #region PROJETO


        public async Task SaveProjeto(Projeto x)
        {
            if (File.Exists(NameFile))
            {
                var projetos = await Deserialize();
                x.Guid = NewGuid();
                projetos.Add(x);
                await Serialize(projetos);
            }
            else
            {
                x.Guid = NewGuid();
                var projetos = new List<Projeto>();
                projetos.Add(x);
                await Serialize(projetos);
            }
        }

        public async Task<List<Projeto>> GetListProjeto()
        {
            if (File.Exists(NameFile))
            {
                return await Deserialize();
            }
            else return new List<Projeto>();
        }

        public async Task<Projeto> GetProjeto(string Guid)
        {
            if (File.Exists(NameFile))
            {
                var projetos = await Deserialize();
                if (projetos != null) return projetos.Where(x => x.Guid == Guid).FirstOrDefault();
                else return null;
            }
            else return null;
        }

        public async Task DeleteProjeto(string GuidProjeto)
        {
            if (File.Exists(NameFile))
            {
                var projetos = await Deserialize();
                var indexProjeto = projetos.FindIndex(x => x.Guid == GuidProjeto);
                projetos.RemoveAt(indexProjeto);
                await Serialize(projetos);
            }
        }


        public async Task UpdateProjeto(string GuidProjeto, Projeto x)
        {
            if (File.Exists(NameFile))
            {
                var projetos = await Deserialize();
                var projeto = projetos.Where(x => x.Guid == GuidProjeto).FirstOrDefault();
                var indexProjeto = projetos.FindIndex(x => x.Guid == GuidProjeto);

                var newProjeto = new Projeto();
                newProjeto = x;
                x.Tables = projeto.Tables;

                projetos[indexProjeto] = newProjeto;

                await Serialize(projetos);

            }
        }

        #endregion




        #region TABLE

        public async Task AddTable(string GuidProjeto, string Name)
        {
            if (File.Exists(NameFile))
            {
                Table tb = new Table();
                tb.Guid = NewGuid();
                tb.Name = Name;
                tb.Date = DateTime.Now;

                var projetos = await Deserialize();
                var index = projetos.FindIndex(x => x.Guid == GuidProjeto);
                if (projetos[index].Tables == null)
                    projetos[index].Tables = new List<Table>();
                projetos[index].Tables.Add(tb);

                await Serialize(projetos);

            }
        }

        public async Task DeleteTable(string GuidProjeto, string GuidTable)
        {
            if (File.Exists(NameFile))
            {
                var projetos = await Deserialize();
                var projeto = projetos.Where(x => x.Guid == GuidProjeto).FirstOrDefault();

                int indexProjeto = projetos.FindIndex(x => x.Guid == GuidProjeto);
                int indexTable = projeto.Tables.FindIndex(x => x.Guid == GuidTable);
                projetos[indexProjeto].Tables.RemoveAt(indexTable);
                await Serialize(projetos);
            }
        }

        public async Task<Table> GetTable(string GuidProjeto, string GuidTable)
        {
            if (File.Exists(NameFile))
            {
                var projetos = await Deserialize();
                var projeto = projetos.Where(x => x.Guid == GuidProjeto).FirstOrDefault();
                return projeto.Tables.Where(x => x.Guid == GuidTable).FirstOrDefault();
            }
            return null;
        }

        public async Task UpdateTable(string GuidProjeto, string GuidTable, Table table)
        {
            if (File.Exists(NameFile))
            {
                var projetos = await Deserialize();
                var projeto = projetos.Where(x => x.Guid == GuidProjeto).FirstOrDefault();
                var indexProjeto = projetos.FindIndex(x => x.Guid == GuidProjeto);

                var Table = projeto.Tables.Where(x => x.Guid == GuidTable).FirstOrDefault();
                var indexTable = projeto.Tables.FindIndex(x => x.Guid == GuidTable);

                var newTable = new Table();
                newTable = table;
                newTable.Entities = Table.Entities;

                projeto.Tables[indexTable] = newTable;
                projetos[indexProjeto] = projeto;

                await Serialize(projetos);
            }
        }

        #endregion



        #region PROPS

        public async Task AddProps(string GuidProjeto, string GuidTable, string Tipo, string Nome)
        {
            if (File.Exists(NameFile))
            {
                var projetos = await Deserialize();
                var projeto = projetos.Where(x => x.Guid == GuidProjeto).FirstOrDefault();
                var indexProjeto = projetos.FindIndex(x => x.Guid == GuidProjeto);
                var indexTable = projeto.Tables.FindIndex(x => x.Guid == GuidTable);
                if (projeto.Tables[indexTable].Entities != null && projeto.Tables[indexTable].Entities.Count(x => x.Name == Nome) >= 1)
                    return;
                Props p = new Props();
                p.Guid = NewGuid();
                p.Name = Nome;
                p.Type = Tipo;
                p.Date = DateTime.Now;
                if (projeto.Tables[indexTable].Entities == null)
                    projeto.Tables[indexTable].Entities = new List<Props>();
                projeto.Tables[indexTable].Entities.Add(p);
                projetos[indexProjeto] = projeto;
                await Serialize(projetos);
            }
        }

        public async Task RemoveProps(string GuidProjeto, string GuidTable, string GuidProperty)
        {
            if (File.Exists(NameFile))
            {
                var projetos = await Deserialize();
                var projeto = projetos.Where(x => x.Guid == GuidProjeto).FirstOrDefault();
                var table = projeto.Tables.Where(x => x.Guid == GuidTable).FirstOrDefault();

                var indexProjeto = projetos.FindIndex(x => x.Guid == GuidProjeto);
                var indexTable = projeto.Tables.FindIndex(x => x.Guid == GuidTable);
                var indexProp = table.Entities.FindIndex(x => x.Guid == GuidProperty);

                table.Entities.RemoveAt(indexProp);
                projeto.Tables[indexTable] = table;
                projetos[indexProjeto] = projeto;
                await Serialize(projetos);
            }
        }

        public async Task SetNotNullProps(string GuidProjeto, string GuidTable, string GuidProperty)
        {
            if (File.Exists(NameFile))
            {
                var projetos = await Deserialize();
                var projeto = projetos.Where(x => x.Guid == GuidProjeto).FirstOrDefault();
                var table = projeto.Tables.Where(x => x.Guid == GuidTable).FirstOrDefault();

                var indexProjeto = projetos.FindIndex(x => x.Guid == GuidProjeto);
                var indexTable = projeto.Tables.FindIndex(x => x.Guid == GuidTable);
                var indexProp = table.Entities.FindIndex(x => x.Guid == GuidProperty);

                projeto.Tables[indexTable].Entities[indexProp].NotNull = projeto.Tables[indexTable].Entities[indexProp].NotNull ? false : true;

                projetos[indexProjeto] = projeto;
                await Serialize(projetos);
            }
        }

        #endregion
    }
}
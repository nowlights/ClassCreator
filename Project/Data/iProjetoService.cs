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
        public async Task Save(Projeto x)
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

        public async Task<List<Projeto>> GetList()
        {
            if (File.Exists(NameFile))
            {
                return await Deserialize();
            }
            else return new List<Projeto>();
        }

        public async Task<Projeto> Get(string Guid)
        {
            if (File.Exists(NameFile))
            {
                var projetos = await Deserialize();
                if (projetos != null) return projetos.Where(x => x.Guid == Guid).FirstOrDefault();
                else return null;
            }
            else return null;
        }


        public async Task AddTable(string Guid, string Name)
        {
            if (File.Exists(NameFile))
            {
                Table tb = new Table();
                tb.Name = Name;

                var projetos = await Deserialize();
                var index = projetos.FindIndex(x => x.Guid == Guid);
                if(projetos[index].Tables == null)
                    projetos[index].Tables = new List<Table>();
                projetos[index].Tables.Add(tb);

                await Serialize(projetos);

            }
        }
    }
}
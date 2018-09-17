using AppeltjeEitje.Data.Entities;
using Microsoft.AspNetCore.Hosting;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AppeltjeEitje.Data
{
    public class AppelEiSeed
    {
        private readonly AppelEiContext _ctx;
        private readonly IHostingEnvironment _hosting;

        public AppelEiSeed(AppelEiContext ctx, IHostingEnvironment hosting)
        {
            _ctx = ctx;
            _hosting = hosting;
        }

        public void Seed()
        {
            _ctx.Database.EnsureCreated();

            if (_ctx.Personen.Count() < 2)
            {
                var filepath = Path.Combine(_hosting.ContentRootPath, "Data/persoon.json");
                var json = File.ReadAllText(filepath);
                var personen = JsonConvert.DeserializeObject<IEnumerable<Persoon>>(json);
                _ctx.Personen.AddRange(personen);
            }

            if(_ctx.Groepen.Count() < 1)
            {
                var filepath = Path.Combine(_hosting.ContentRootPath, "Data/groep.json");
                var json = File.ReadAllText(filepath);
                var groepen = JsonConvert.DeserializeObject<IEnumerable<Groep>>(json);
                _ctx.Groepen.AddRange(groepen);
            }
            _ctx.SaveChanges();
        }
    }
}

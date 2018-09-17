using AppeltjeEitje.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppeltjeEitje.Data
{
    public class AppelEiContext : DbContext
    {
        public AppelEiContext(DbContextOptions<AppelEiContext> options): base(options)
        {

        }

        public DbSet<Persoon> Personen { get; set; }
        public DbSet<Groep> Groepen { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}

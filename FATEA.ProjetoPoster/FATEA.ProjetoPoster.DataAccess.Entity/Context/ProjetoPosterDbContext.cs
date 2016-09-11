using FATEA.ProjetoPoster.DataAccess.Entity.Configurations;
using FATEA.ProjetoPoster.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FATEA.ProjetoPoster.DataAccess.Entity.Context
{
    public class ProjetoPosterDbContext : DbContext
    {
        public DbSet<Evento> Eventos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new EventoTypeConfiguration());
        }
    }
}

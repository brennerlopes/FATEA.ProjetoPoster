using FATEA.ProjetoPoster.DataAccess.Entity.Configurations;
using FATEA.ProjetoPoster.Domain;
using Microsoft.AspNet.Identity.EntityFramework;
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
        public DbSet<Curso> Cursos { get; set; }
        public DbSet<Instituicao> Instituicoes { get; set; }
        public DbSet<Poster> Posters { get; set; }
        public DbSet<Avaliacao> Avaliacoes { get; set; }

        public ProjetoPosterDbContext()
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new PosterTypeConfiguration());
            modelBuilder.Configurations.Add(new CursoTypeConfiguration());
            modelBuilder.Configurations.Add(new EventoTypeConfiguration());
            modelBuilder.Configurations.Add(new AvaliacaoTypeConfiguration());
            modelBuilder.Entity<IdentityUserLogin>().HasKey<string>(l => l.UserId);
            modelBuilder.Entity<IdentityRole>().HasKey<string>(r => r.Id);
            modelBuilder.Entity<IdentityUserRole>().HasKey(r => new { r.RoleId, r.UserId });
        }
        
    }
}

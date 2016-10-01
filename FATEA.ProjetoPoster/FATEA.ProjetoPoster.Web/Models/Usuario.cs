using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using System.Data.Entity;

namespace FATEA.ProjetoPoster.Web.Models
{
    public class Usuario : IdentityUser
    {
        public string NomeUsuario { get; set; }

        public string RgUsuario { get; set; }
        public string CpfUsuario { get; set; }
        public string EmailUsuario { get; set; }     



        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<Usuario> manager)
        {

            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            return userIdentity;
        }

        public class ApplicationDbContext : IdentityDbContext<Usuario>
        {
            public ApplicationDbContext()
                : base("ProjetoPosterDbContext")
            {
            }
            protected override void OnModelCreating(DbModelBuilder modelBuilder)
            {
                base.OnModelCreating(modelBuilder);

                modelBuilder.Entity<Usuario>()                 
                   .Property(p => p.NomeUsuario)
                   .HasColumnName("NomeUsuario");

                modelBuilder.Entity<Usuario>()
                
                   .Property(p => p.RgUsuario)
                   .HasColumnName("RgUsuario");

                modelBuilder.Entity<Usuario>()
                  
                  .Property(p => p.EmailUsuario)
                  .HasColumnName("EmailUsuario");

                modelBuilder.Entity<Usuario>()
                 
                    .Property(p => p.CpfUsuario)
                    .HasColumnName("CpfUsuario");



            }

            public static ApplicationDbContext Create()
            {
                return new ApplicationDbContext();
            }

            //public System.Data.Entity.DbSet<FATEA.ProjetoPoster.Domain.Poster> Posters { get; set; }
        }
    }
}
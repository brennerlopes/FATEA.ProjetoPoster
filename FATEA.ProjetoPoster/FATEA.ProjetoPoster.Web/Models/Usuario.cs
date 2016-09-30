using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;

namespace FATEA.ProjetoPoster.Web.Models
{
    public class Usuario : IdentityUser
    {
        public string NomeUsuario { get; set; }
        public int RgUsuario { get; set; }
        public int CpfUsuario { get; set; }
        public string EmailUsuario { get; set; }
        public string Senha { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<Usuario> manager)
        {
            
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            return userIdentity;
        }

        public class ApplicationDbContext : IdentityDbContext<Usuario>
        {
            public ApplicationDbContext()
                : base("DefaultConnection", throwIfV1Schema: false)
            {
            }

            public static ApplicationDbContext Create()
            {
                return new ApplicationDbContext();
            }

            //public System.Data.Entity.DbSet<FATEA.ProjetoPoster.Domain.Poster> Posters { get; set; }
        }
    }
}
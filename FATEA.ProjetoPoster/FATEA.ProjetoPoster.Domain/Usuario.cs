using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using System.Data.Entity;

namespace FATEA.ProjetoPoster.Domain
{
    public class Usuario : IdentityUser
    {
        public string NomeUsuario { get; set; }

        public string RgUsuario { get; set; }
        public string CpfUsuario { get; set; }

        public virtual List<Poster> Posters { get; set; }


        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<Usuario> manager)
        {

            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            return userIdentity;
        }

        }

    }

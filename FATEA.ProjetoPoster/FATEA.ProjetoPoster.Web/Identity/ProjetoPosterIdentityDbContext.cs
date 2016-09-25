using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FATEA.ProjetoPoster.Web.Identity
{
    public class ProjetoPosterIdentityDbContext : IdentityDbContext <IdentityUser>
    {
        public ProjetoPosterIdentityDbContext()
            : base("ProjetoPosterDbContext")
        {

        }
    }
}
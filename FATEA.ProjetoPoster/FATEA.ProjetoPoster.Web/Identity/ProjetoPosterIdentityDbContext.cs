using FATEA.ProjetoPoster.Web.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FATEA.ProjetoPoster.Web.Identity
{
    public class ProjetoPosterIdentityDbContext : IdentityDbContext<Usuario>
    {
        public ProjetoPosterIdentityDbContext()
            : base("ProjetoPosterDbContext")
        {

        }
    }
}
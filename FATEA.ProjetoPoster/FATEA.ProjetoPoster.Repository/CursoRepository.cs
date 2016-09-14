using FATEA.ProjetoPoster.DataAccess.Entity.Context;
using FATEA.ProjetoPoster.Domain;
using FATEA.ProjetoPoster.Repository.Common.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FATEA.ProjetoPoster.Repository
{
    public class CursoRepository : EntityCrudRepository<Curso, long>
    {
        public CursoRepository(ProjetoPosterDbContext contexto)
            : base(contexto)
        {

        }
    }
}

using FATEA.ProjetoPoster.DataAccess.Entity.Context;
using FATEA.ProjetoPoster.Domain;
using FATEA.ProjetoPoster.Repository.Common.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FATEA.ProjetoPoster.Repository
{
    public class AvaliacaoRepository : EntityCrudRepository<Avaliacao, long>
    {
        public AvaliacaoRepository(ProjetoPosterDbContext contexto)
            : base(contexto)
        {

        }

        public override List<Avaliacao> Select(Func<Avaliacao, bool> where = null)
        {
            IEnumerable<Avaliacao> avaliacoes = _contexto.Set<Avaliacao>().Include(p => p.Poster);
            if (where != null)
            {
                avaliacoes = avaliacoes.Where(where);
            }
            return avaliacoes.ToList();
        }

        public override Avaliacao ById(long id)
        {
            return _contexto.Set<Avaliacao>().Include(p => p.Poster)
                .Where(w => w.Id == id).SingleOrDefault();
        }
    }
}

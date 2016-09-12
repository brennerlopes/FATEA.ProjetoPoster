using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FATEA.ProjetoPoster.Repository.Common
{
    public interface ICrudRepositorio<TEntity, TKey>
        where TEntity : class
    {
        List<TEntity> Select(Func<TEntity, bool> where = null);
        TEntity ById(TKey id);
        void Insert(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        void DeleteById(TKey id);
    }
}


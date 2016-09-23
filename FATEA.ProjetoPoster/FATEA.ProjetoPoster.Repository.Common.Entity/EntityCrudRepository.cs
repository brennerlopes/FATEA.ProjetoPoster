using FATEA.ProjetoPoster.Repository.Common;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FATEA.ProjetoPoster.Repository.Common.Entity
{
    public abstract class EntityCrudRepository<TEntity, TKey> : ICrudRepositorio<TEntity, TKey>
        where TEntity : class
    {
        protected DbContext _contexto;

        public EntityCrudRepository(DbContext contexto)
        {
            _contexto = contexto;
        }

        public virtual List<TEntity> Select(Func<TEntity, bool> where = null)
        {
            IEnumerable<TEntity> result = _contexto.Set<TEntity>();
            if (where != null)
            {
                result = result.Where(where);
            }
            return result.ToList();
        }

        public virtual TEntity ById(TKey id)
        {
            return _contexto.Set<TEntity>().Find(id);
        }

        public virtual void Delete(TEntity entity)
        {
            _contexto.Set<TEntity>().Attach(entity);
            _contexto.Entry(entity).State = EntityState.Deleted;
            _contexto.SaveChanges();
        }

        public virtual void DeleteById(TKey id)
        {
            TEntity entity = ById(id);
            Delete(entity);
        }

        public virtual void Insert(TEntity entity)
        {
            _contexto.Set<TEntity>().Add(entity);
            _contexto.SaveChanges();
        }

        public virtual void Update(TEntity entity)
        {
            _contexto.Set<TEntity>().Attach(entity);
            _contexto.Entry(entity).State = EntityState.Modified;
            _contexto.SaveChanges();
        }
    }
}

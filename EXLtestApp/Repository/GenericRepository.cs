using EXLtestApp.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace EXLtestApp.Repository
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        public readonly DbContext Context;


        public GenericRepository(DbContext _dbContext)
        {
            Context = _dbContext;
        }
        public void Add(TEntity model)
        {
             Context.Set<TEntity>().Add(model);
        }

        public void AddRange(IEnumerable<TEntity> models)
        {
            Context.Set<TEntity>().AddRange(models);
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
          return  Context.Set<TEntity>().Where(predicate);
        }

        public TEntity Get(int Id)
        {
            return Context.Set<TEntity>().Find(Id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return Context.Set<TEntity>().ToList();
        }

        public void Remove(TEntity model)
        {
            Context.Set<TEntity>().Remove(model);
        }

        public void RemoveRange(IEnumerable<TEntity> models)
        {
            Context.Set<TEntity>().RemoveRange(models);
        }
    }
}

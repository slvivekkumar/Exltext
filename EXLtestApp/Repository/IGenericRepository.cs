using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace EXLtestApp.IRepository
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        TEntity Get(int Id);
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);

        void Add(TEntity model);
        void AddRange(IEnumerable<TEntity> models);

        void Remove(TEntity model);
        void RemoveRange(IEnumerable<TEntity> models);
    }

}

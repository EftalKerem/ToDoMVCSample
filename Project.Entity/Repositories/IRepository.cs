using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Project.Entity.Repositories
{
    public interface IRepository<T> where T : class
    {
        T Insert(T entity);
        T Update(T entity);
        IQueryable<T> GetAll();
        T Find(Expression<Func<T, bool>> match);
        T Delete(T entity);

    }
}

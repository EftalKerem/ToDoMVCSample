using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Project.Entity.Entity;
using Project.Entity.Models;

namespace Project.Entity.Repositories
{
    public class Repository<T>:IRepository<T> where T : class
    {
        private readonly EntityDbContext _entityDbContext;

        public Repository(EntityDbContext entityDbContext)
        {
            _entityDbContext = entityDbContext;
        }
        public T Insert(T entity)
        {
            _entityDbContext.Set<T>().Add(entity);
            _entityDbContext.SaveChanges();
            return entity;
        }

        public T Update(T entity)
        {
            _entityDbContext.Set<T>().Update(entity);
            _entityDbContext.SaveChanges();
            return entity;
        }

        public IQueryable<T> GetAll()
        {
            return _entityDbContext.Set<T>();
        }

        public T Find(Expression<Func<T, bool>> match)
        {
            return _entityDbContext.Set<T>().SingleOrDefault(match);
        }

        public T Delete(T entity)
        {
            _entityDbContext.Set<T>().Remove(entity);
            _entityDbContext.SaveChanges();
            return entity;
        }
    }
}

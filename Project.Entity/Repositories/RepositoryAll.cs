using System;
using System.Collections.Generic;
using System.Text;
using Project.Entity.Entity;
using Project.Entity.Models;

namespace Project.Entity.Repositories
{
    public class RepositoryAll : IRepositoryAll
    {
        private readonly EntityDbContext _entityDbContext;
        public RepositoryAll(EntityDbContext entityDbContext)
        {
            _entityDbContext = entityDbContext;
        }
        private IRepository<ToDoData> _toDoData; 

        public IRepository<ToDoData> ToDoData
        {
            get => _toDoData ?? (_toDoData = new Repository<ToDoData>(_entityDbContext));
            set => throw new NotImplementedException();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using Project.Entity.Models;

namespace Project.Entity.Repositories
{
    public interface IRepositoryAll
    {
        IRepository<ToDoData> ToDoData { get; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Project.Entity.Models;
using Project.Entity.Repositories;

namespace Project.Service.ToDoDataServices
{
    public class ToDoDataService:IToDoDataService
    {
        private IRepositoryAll _repositoryAll;
        public ToDoDataService(IRepositoryAll repositoryAll)
        {
            _repositoryAll = repositoryAll;
        }
        public ToDoData Insert(ToDoData toDoData)
        {
            return _repositoryAll.ToDoData.Insert(toDoData);
        }

        public ToDoData Update(ToDoData toDoData)
        {
            return _repositoryAll.ToDoData.Update(toDoData); 
        }

        public bool Delete(int id)
        {
            var toDoData = _repositoryAll.ToDoData.Find(p => p.Id == id);
            try
            {
                _repositoryAll.ToDoData.Delete(toDoData);
                return true;
            }
            catch (Exception e)
            {
                return false; 
            } 
        }

        public List<ToDoData> GetAll()
        {
            return _repositoryAll.ToDoData.GetAll().ToList();
        }

        public ToDoData Find(int id)
        {
            return _repositoryAll.ToDoData.Find(p => p.Id==id);
        }
    }
}

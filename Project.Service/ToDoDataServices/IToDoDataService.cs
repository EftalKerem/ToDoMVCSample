using System;
using System.Collections.Generic;
using System.Text;
using Project.Entity.Models;

namespace Project.Service.ToDoDataServices
{
    public interface IToDoDataService
    {
        ToDoData Insert(ToDoData toDoData);
        ToDoData Update(ToDoData toDoData);
        bool Delete(int id);
        List<ToDoData> GetAll();
        ToDoData Find(int id);

    }
}

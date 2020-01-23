using System;
using System.Diagnostics;
using Hangfire;
using Microsoft.AspNetCore.Mvc;
using Project.Entity.Models;
using Project.Service.ToDoDataServices;
using Project.Web.Helper;
using Project.Web.Models;

namespace Project.Web.Controllers
{
    public class HomeController : Controller
    {

        private readonly IToDoDataService _toDoDataService;
        public HomeController(IToDoDataService toDoDataService)
        {
            _toDoDataService = toDoDataService;
        }

        public IActionResult Index()
        {
            var model = _toDoDataService.GetAll(); 
            return View(model);
        }

        #region Create
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(ToDoData toDoData)
        {
            try
            {
                toDoData.CreateDateTime = DateTime.Now;
                toDoData.IsRead = false;
                _toDoDataService.Insert(toDoData); 
            }
            catch (Exception e)
            {  
                TempData.Put("Notification", new UiMessage(NotyType.error, "Create failed.")); 
                return RedirectToAction("Index");
            } 
            TempData.Put("Notification", new UiMessage(NotyType.success, "Created."));  
            return RedirectToAction("Index");
        }
        #endregion

        #region Edit 
        public IActionResult Edit(int id)
        {
            var model = _toDoDataService.Find(id);
            return View(model);
        }
        [HttpPost]
        public IActionResult Edit(ToDoData toDoData)
        {
            try
            {
                var _toDoData = _toDoDataService.Find(toDoData.Id);
                _toDoData.Title = toDoData.Title;
                _toDoData.Description = toDoData.Description;
                _toDoData.InsertDateTime = toDoData.InsertDateTime;
                _toDoDataService.Update(_toDoData);
            }
            catch (Exception e)
            {
                TempData.Put("Notification", new UiMessage(NotyType.error, "Updated Failed."));
                return RedirectToAction("Index"); 
            }
            TempData.Put("Notification", new UiMessage(NotyType.success, "Uptated."));
            return RedirectToAction("Index");
        }
        #endregion

        #region Delete

        [HttpPost]
        public JsonResult Delete(int id)
        {
            var delete = _toDoDataService.Delete(id);
            if (delete)
            { 
                return Json(new { isSuccess = true, message = "İtem cannot be deleted!"});
            }
            return Json(new { isSuccess = false, message = "İtem deleted!" }); 
        }

        #endregion

        
    }
}

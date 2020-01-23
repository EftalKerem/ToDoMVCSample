using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hangfire;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Project.Service.RestSharpServices;
using Project.Service.ToDoDataServices;
using Project.Web.Helper;
using RestSharp;
using RestSharp.Authenticators;

namespace Project.Web.Controllers
{
    public class HangfireController : Controller
    {
        private readonly IRestSharpService _restSharpService;
        private readonly IConfiguration _configuration;
        private readonly IToDoDataService _toDoDataService;
        public HangfireController(IRestSharpService restSharpService, IConfiguration configuration, IToDoDataService toDoDataService)
        {
            _restSharpService = restSharpService;
            _configuration = configuration;
            _toDoDataService = toDoDataService;
        }
        public void HangfireAction()
        {
           var list = _toDoDataService.GetAll().Where(p=>p.InsertDateTime.ToString("dd.MM.yyyy")==DateTime.Now.ToString("dd.MM.yyyy") && !p.IsRead);
            if (list.Count()>0)
            {
                foreach (var item in list)
                {
                    _restSharpService.PushWebNotification(new OneSignalModel(item.Title,item.Title, _configuration));
                    item.IsRead = true;
                    _toDoDataService.Update(item);
                }
            }

        }
       
    }
}
using System;
using System.Collections.Generic;
using System.Text;
using Project.Web.Helper;


namespace Project.Service.RestSharpServices
{
    public interface IRestSharpService
    {
        bool PushWebNotification( OneSignalModel oneSignalModel );
    }
}

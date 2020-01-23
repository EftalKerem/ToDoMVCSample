 
using Newtonsoft.Json;
using Project.Web.Helper;
using RestSharp; 
namespace Project.Service.RestSharpServices
{
    public class RestSharpService: IRestSharpService
    {
        public bool PushWebNotification(OneSignalModel oneSignalModel)
        {
            var client = new RestClient("https://onesignal.com/api/v1/notifications");
            var request = new RestRequest();
            var body = JsonConvert.SerializeObject(oneSignalModel);
            request.Method = Method.POST;
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Authorization", "basic ODA0MDFmMzktODA1My00MzY0LWI5ZTUtNTk3Nzc4YWIzMDZh"); 
            request.AddParameter("application/json", body, ParameterType.RequestBody);
           var result= client.Execute(request);
            return true;
        }
    }
}

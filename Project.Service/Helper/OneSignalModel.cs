using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace Project.Web.Helper
{
    public class OneSignalModel
    {
        [JsonProperty("app_id")]
        public string AppId { get;}
        [JsonProperty("included_segments")] 
        public string[] IncludedSegments { get; }
        [JsonProperty("contents")] 
        public OneSignalContentModel Contents { get; set; }

        public OneSignalModel(string enContent,string trContent,IConfiguration configuration )
        {
            AppId = configuration.GetSection("OnaSignalString").GetSection("AppId").Value;
            IncludedSegments = new[] { "Active Users", "Inactive Users" };
            Contents = new OneSignalContentModel(){En = enContent ,Tr = trContent };
        }
    }

    public class OneSignalContentModel
    {
        [JsonProperty("en")]
        public string En { get; set; }
        [JsonProperty("tr")]
        public string Tr { get; set; }
    }
}

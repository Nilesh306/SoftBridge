using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace SoftBridgeApp
{
    public class GlobalVariable
    {
        public static HttpClient Webapiclient = new HttpClient();

        static GlobalVariable()
        {
            Webapiclient.BaseAddress = new Uri("https://localhost:44339/api/");
            Webapiclient.DefaultRequestHeaders.Clear();
            Webapiclient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        }
    }
}
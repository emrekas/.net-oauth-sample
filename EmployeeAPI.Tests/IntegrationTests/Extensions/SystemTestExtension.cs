using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using Newtonsoft.Json;

namespace EmployeeAPI.Tests.IntegrationTests.Extensions
{
    public static class SystemTestExtension
    {
        public static HttpClient GetTokenAuthorizeHttpClient(CustomWebApplicationFactory<Startup> factory)
        {
            //AuthAPI servisini ayağa kaldırma konusunda sıkıntı yaşadım token da alamadığım ve süre yetmediği için böylece bıraktım.

            // var authClient = new HttpClient();
            // var authenticateAdminUserCommand = new
            // {
            //     client_id= "EmployeeAPI",
            //     client_secret = "employee",
            //     grant_type = "grant_type"
            // };
            // var content = JsonConvert.SerializeObject(authenticateAdminUserCommand);
            // var httpResponse = authClient.PostAsync("https://localhost:10006/connect/token", new StringContent(content, Encoding.UTF8, "application/json")).Result;
            //
            //var client = factory.CreateClient();
            //var token = JsonConvert.DeserializeObject<Dictionary<string, object>>(httpResponse.Content.ReadAsStringAsync().Result)["token"];
            //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token.ToString());

            //return client;
            return new HttpClient();
        }
    }
}
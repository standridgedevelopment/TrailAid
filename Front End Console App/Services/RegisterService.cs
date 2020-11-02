using Front_End_Console_App.Models.Register;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace FrontEndConsoleApp.Services
{
    public class RegisterService
    {
        

        private readonly HttpClient _httpClient = new HttpClient();
        

        public async Task<IHttpActionResult> Register(RegisterBindingModel model)
        {
            string strModel = JsonConvert.SerializeObject(model);
            HttpContent content = new StringContent(strModel, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await _httpClient.PostAsync("https://localhost:44375/api/Account/Register", content);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsAsync<IHttpActionResult>();
            }
            return null;
        }
        public async Task<string> GetToken(TokenCreate model)
        {
            string strModel = JsonConvert.SerializeObject(model);
            HttpContent content = new StringContent(strModel, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await _httpClient.PostAsync("https://localhost:44375/Token", content);
            if (response.IsSuccessStatusCode)
            {
                var tokenObject = await response.Content.ReadAsAsync<Token>();
                return tokenObject.access_token;
            }
            return null;
        }
    }
}

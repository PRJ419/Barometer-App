using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Barometer_App.DTO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Barometer_App
{
    public class IdentityService
    {
        private const string Baseaddress = "https://192.168.43.170:45456/api/";

        public async Task<bool> RegisterAsync(RegisterDTO model)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri(Baseaddress);

            var json = JsonConvert.SerializeObject(model);

            HttpContent content = new StringContent(json);

            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            try
            {
                var response = await client.PostAsync("register", content);
                return response.IsSuccessStatusCode;
            }
            catch (Exception e)
            {
                return false;
            }

        }

        public async Task<string> LoginAsync(LoginDTO model)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri(Baseaddress);

            var json = JsonConvert.SerializeObject(model);
            HttpContent content = new StringContent(json);

            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            try
            {
                var response = await client.PostAsync("login", content);
                var jwt = await response.Content.ReadAsStringAsync();

                //JObject jwtDyn = JsonConvert.DeserializeObject<JObject>(jwt);
                //var accessToken = jwtDyn.Value<string>("access_token");

                return jwt;
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}

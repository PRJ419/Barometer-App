using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Barometer_App.Models;
using Newtonsoft.Json;

namespace RESTClient
{
    public class RestClient : IRestClient
    {
       // private const string Baseaddress = "https://localhost:44310/";
        private const string Baseaddress = "https://10.192.137.119:45457/";

        //GET api/bars/
        public async Task<List<BarSimple>> GetBestBarList() //Virker
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseaddress);

                try
                {
                    var response = await client.GetAsync("api/bars/");
                    if (response.IsSuccessStatusCode)
                    {
                        var msg = await response.Content.ReadAsStringAsync();
                        var bars = JsonConvert.DeserializeObject<List<BarSimple>>(msg);

                        return bars;
                    }

                    //GetAsync failed, returning empty list of bars
                    return new List<BarSimple>();
                }
                catch (Exception)
                {
                    Console.WriteLine("Der var ingen barer at hente");
                    //There were no bars to get, returning empty list of bars
                    return new List<BarSimple>();
                }
            }
        }

        //PUT api/bars/
        public async Task<bool> EditBar(Bar editedBar) //Virker
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseaddress);

                var jsonString = JsonConvert.SerializeObject(editedBar);
                Console.WriteLine(jsonString); //Test

                var content = new StringContent(jsonString, Encoding.UTF8, "application/json");

                var response = await client.PutAsync("api/bars/", content);

                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("Bar has been updated!"); //Test
                    return true;
                }

                Console.WriteLine($"Something went wrong: {response.StatusCode}"); // Test
                return false;
            }
        }

        //POST api/bars/
        public async Task<bool> CreateBar(Bar newBar) //Virker
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseaddress);

                var jsonString = JsonConvert.SerializeObject(newBar);

                Console.WriteLine($"json : \n{jsonString}"); //Test
                var content = new StringContent(jsonString, Encoding.UTF8, "application/json");

                var response = await client.PostAsync("api/bars/", content);

                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("Bar has been created!"); //Test
                    return true;
                }

                Console.WriteLine($"Something went wrong {response.StatusCode}"); //Test
                return false;
            }
        }

        //GET api/bars/{id}
        public async Task<Bar> GetDetailedBar(string id) //Virker
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseaddress);

                try
                {
                    var response = await client.GetAsync($"api/bars/{id}");

                    if (response.IsSuccessStatusCode)
                    {
                        var msg = await response.Content.ReadAsStringAsync();
                        var bar = JsonConvert.DeserializeObject<Bar>(msg);
                        return bar;
                    }

                    //GetAsync failed, returning empty bar
                    return new Bar();
                }
                catch (Exception)
                {
                    Console.WriteLine($"Der eksisterer ingen bar ved navn {id}");
                    //There were no bar to get, returning empty bar
                    return new Bar();
                }
            }
        }

        //DELETE api/bars/{id}
        public async Task<bool> DeleteBar(string id) // Virker
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseaddress);

                var response = await client.DeleteAsync($"api/bars/{id}/");

                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("Bar has been deleted!"); //Test
                    return true;
                }

                Console.WriteLine($"Something went wrong {response.StatusCode}"); //Test
                return false;
            }
        }

        //GET api/bars/worst
        public async Task<List<BarSimple>> GetWorstBarList() //Virker
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseaddress);

                try
                {
                    var response = await client.GetAsync("api/bars/worst");
                    if (response.IsSuccessStatusCode)
                    {
                        var msg = await response.Content.ReadAsStringAsync();
                        var bars = JsonConvert.DeserializeObject<List<BarSimple>>(msg);

                        return bars;
                    }

                    //GetAsync failed, returning empty list of bars
                    return new List<BarSimple>();
                }
                catch (Exception)
                {
                    Console.WriteLine("Der var ingen barer at hente");
                    //There were no bars to get, returning empty list of bars
                    return new List<BarSimple>();
                }
            }
        }

        //GET api/bars/{from}/{to}
        public async Task<List<BarSimple>> GetSpecificBarList(int startIndex, int pageSize) //Virker men i alfabetisk orden
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseaddress);

                try
                {
                    var response = await client.GetAsync($"api/bars/{startIndex}/{pageSize}");
                    if (response.IsSuccessStatusCode)
                    {
                        var msg = await response.Content.ReadAsStringAsync();
                        var bars = JsonConvert.DeserializeObject<List<BarSimple>>(msg);

                        return bars;
                    }

                    //GetAsync failed, returning empty list of bars
                    return new List<BarSimple>();
                }
                catch (Exception)
                {
                    Console.WriteLine("Der var ingen barer at hente");
                    //There were no bars to get, returning empty list of bars
                    return new List<BarSimple>();
                }
            }
        }


    }
}

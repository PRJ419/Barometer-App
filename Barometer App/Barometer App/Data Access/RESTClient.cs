using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Barometer_App.Models;
using Newtonsoft.Json;
using RESTClient.DTOs;

namespace RESTClient
{
    public class RestClient : IRestClient
    {
        private const string Baseaddress = "https://localhost:44310/";

        //BAR

        //GET api/bars/
        public async Task<List<BarSimpleDto>> GetBarList()
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
                        var bars = JsonConvert.DeserializeObject<List<BarSimpleDto>>(msg);

                        return bars;
                    }

                    //GetAsync failed, returning empty list of bars
                    return new List<BarSimpleDto>();
                }
                catch (Exception e)
                {
                    Console.WriteLine("Der var ingen barer at hente");
                    //There were no bars to get, returning empty list of bars
                    return new List<BarSimpleDto>();
                }
            }
        }

        //PUT api/bars/
        public async Task<bool> EditBar(BarDto editedBar) //Virker ikke
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
        public async Task<bool> CreateBar(BarDto newBar)
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
        public async Task<BarDto> GetDetailedBar(string id)
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
                        var bar = JsonConvert.DeserializeObject<BarDto>(msg);

                        return bar;
                    }

                    //GetAsync failed, returning empty bar
                    return new BarDto();
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Der eksisterer ingen bar ved navn {id}");
                    //There were no bar to get, returning empty bar
                    return new BarDto();
                }
            }
        }

        //DELETE api/bars/{id}
        public async Task<bool> DeleteBar(string id)
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
        public async Task<List<BarSimpleDto>> GetWorstBarList()
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
                        var bars = JsonConvert.DeserializeObject<List<BarSimpleDto>>(msg);

                        return bars;
                    }

                    //GetAsync failed, returning empty list of bars
                    return new List<BarSimpleDto>();
                }
                catch (Exception e)
                {
                    Console.WriteLine("Der var ingen barer at hente");
                    //There were no bars to get, returning empty list of bars
                    return new List<BarSimpleDto>();
                }
            }
        }

        //GET api/bars/{from}/{to}
        public async Task<List<BarSimpleDto>> GetSpecificBarList(int index1, int index2) //Virker men weird, skal lige snakke med tobi
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseaddress);

                try
                {
                    var response = await client.GetAsync($"api/bars/{index1}/{index2}");
                    if (response.IsSuccessStatusCode)
                    {
                        var msg = await response.Content.ReadAsStringAsync();
                        var bars = JsonConvert.DeserializeObject<List<BarSimpleDto>>(msg);

                        return bars;
                    }

                    //GetAsync failed, returning empty list of bars
                    return new List<BarSimpleDto>();
                }
                catch (Exception e)
                {
                    Console.WriteLine("Der var ingen barer at hente");
                    //There were no bars to get, returning empty list of bars
                    return new List<BarSimpleDto>();
                }
            }
        }

        //GET api/bars/{barname}/drinks
        public async Task<List<DrinkDto>> GetBarDrinkList(string id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseaddress);

                try
                {
                    var response = await client.GetAsync($"api/bars/{id}/drinks/");
                    if (response.IsSuccessStatusCode)
                    {
                        var msg = await response.Content.ReadAsStringAsync();
                        var drinks = JsonConvert.DeserializeObject<List<DrinkDto>>(msg);

                        return drinks;
                    }

                    //GetAsync failed, returning empty list of bars
                    return new List<DrinkDto>();
                }
                catch (Exception e)
                {
                    Console.WriteLine("Der var ingen drinks at hente");
                    //There were no drinks to get, returning empty list of drinks
                    return new List<DrinkDto>();
                }
            }
        }

        
    }
}

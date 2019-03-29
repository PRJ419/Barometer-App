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
    class RestClient
    {
        private const string Baseaddress = "https://192.168.43.96:45456/"; 

        //Creating new bar
        public async Task<bool> CreateBar(BarSimpleDto newBar) //Skal opdateres til full bar DTO
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

                Console.WriteLine($"Something went wrong"); //Test
                return false;
            }
        }

        //Editing existing bar
        public async Task<bool> EditBar(BarSimpleDto editedBar) //Not done
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

        //Getting a list of bars with simple info
        public async Task<List<BarSimpleDto>> GetBarList()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseaddress);

                var response = await client.GetAsync("api/bars/");

                if (response.IsSuccessStatusCode)
                {
                    var msg = await response.Content.ReadAsStringAsync();
                    var bars = JsonConvert.DeserializeObject<List<BarSimpleDto>>(msg);

                    return bars;
                }

                return null;
            }
        }

        //Getting a bar with detailed info
        public async Task<BarSimpleDto> GetDetailedBar(string id) //Skal opdateres til full bar DTO
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseaddress);

                var response = await client.GetAsync($"api/bars/{id}");

                if (response.IsSuccessStatusCode)
                {
                    var msg = await response.Content.ReadAsStringAsync();
                    BarSimpleDto bar = JsonConvert.DeserializeObject<BarSimpleDto>(msg);

                    return bar;
                }
                return null;
            }
        }

        //Unused methods
        //public async Task<double> GetSpecificBarRating(string id)
        //{
        //    using (var client = new HttpClient())
        //    {
        //        client.BaseAddress = new Uri(Baseaddress);

        //        var response = await client.GetAsync($"api/bars/{id}");

        //        if (response.IsSuccessStatusCode)
        //        {
        //            var msg = await response.Content.ReadAsStringAsync();
        //            BarSimpleDto bar = JsonConvert.DeserializeObject<BarSimpleDto>(msg);

        //            return bar.AvgRating;
        //        }

        //        return -1;
        //    }
        //}

        //public async Task<string> GetSpecificBarName(string id)
        //{
        //    using (var client = new HttpClient())
        //    {
        //        client.BaseAddress = new Uri(Baseaddress);

        //        var response = await client.GetAsync($"api/bars/{id}");

        //        if (response.IsSuccessStatusCode)
        //        {
        //            var msg = await response.Content.ReadAsStringAsync();
        //            BarSimpleDto bar = JsonConvert.DeserializeObject<BarSimpleDto>(msg);

        //            return bar.BarName;
        //        }

        //        return null;
        //    }
        //}
    }
}

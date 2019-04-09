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

        //GET /api/bars/
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

        //PUT /api/bars/
        public async Task<bool> EditBar(BarDto editedBar)
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

        //POST /api/bars/
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

        //GET /api/bars/{id}
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

        //DELETE /api/bars/{id}
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

        //GET /api/bars/worst
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

        //GET /api/bars/{from}/{to}
        public async Task<List<BarSimpleDto>> GetSpecificBarList(int startIndex, int pageSize) //Virker, og det er alfabetisk orden
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


        //DRINK

        //GET /api/bars/{barname}/drinks
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

                    //GetAsync failed, returning empty list of drinks
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

        //PUT /api/bars/{barname}/drinks
        public async Task<bool> EditDrink(DrinkDto editedDrink, string id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseaddress);

                var jsonString = JsonConvert.SerializeObject(editedDrink);
                Console.WriteLine(jsonString); //Test

                var content = new StringContent(jsonString, Encoding.UTF8, "application/json");

                var response = await client.PutAsync($"api/bars/{id}/drinks", content);

                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("Drink has been updated!"); //Test
                    return true;
                }

                Console.WriteLine($"Something went wrong: {response.StatusCode}"); // Test
                return false;
            }
        }

        //POST /api/bars/{barname}/drinks
        public async Task<bool> CreateDrink(DrinkDto newDrink, string id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseaddress);

                var jsonString = JsonConvert.SerializeObject(newDrink);

                Console.WriteLine($"json : \n{jsonString}"); //Test
                var content = new StringContent(jsonString, Encoding.UTF8, "application/json");

                var response = await client.PostAsync($"api/bars/{id}/drinks", content);

                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("Drink has been created!"); //Test
                    return true;
                }

                Console.WriteLine($"Something went wrong {response.StatusCode}"); //Test
                return false;
            }
        }

        //DELETE /api/bars/{barname}/drinks TODO: HVORDAN FINDER VI DEN SPECIFIKKE DRINK?
        /*public async Task<bool> DeleteDrink(string barId)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseaddress);

                var response = await client.DeleteAsync($"api/bars/{barId}/???????");

                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("Drink has been deleted!"); //Test
                    return true;
                }

                Console.WriteLine($"Something went wrong {response.StatusCode}"); //Test
                return false;
            }
        }*/


        //EVENT

        //GET /api/bars/{barname}/events
        public async Task<List<BarEventDto>> GetBarEventList(string id) //TODO: Skal testes
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseaddress);

                try
                {
                    var response = await client.GetAsync($"api/bars/{id}/events/");
                    if (response.IsSuccessStatusCode)
                    {
                        var msg = await response.Content.ReadAsStringAsync();
                        var events = JsonConvert.DeserializeObject<List<BarEventDto>>(msg);

                        return events;
                    }

                    //GetAsync failed, returning empty list of events
                    return new List<BarEventDto>();
                }
                catch (Exception e)
                {
                    Console.WriteLine("Der var ingen events at hente");
                    //There were no events to get, returning empty list of events
                    return new List<BarEventDto>();
                }
            }
        }

        //PUT /api/bars/{barname}/events
        public async Task<bool> EditEvent(BarEventDto editedEvent, string id) //TODO: Skal testes
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseaddress);

                var jsonString = JsonConvert.SerializeObject(editedEvent);
                Console.WriteLine(jsonString); //Test

                var content = new StringContent(jsonString, Encoding.UTF8, "application/json");

                var response = await client.PutAsync($"api/bars/{id}/events", content);

                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("Event has been updated!"); //Test
                    return true;
                }

                Console.WriteLine($"Something went wrong: {response.StatusCode}"); // Test
                return false;
            }
        }

        //POST /api/bars/{barname}/events
        public async Task<bool> CreateEvent(BarEventDto newEvent, string id) //TODO: Skal testes
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseaddress);

                var jsonString = JsonConvert.SerializeObject(newEvent);

                Console.WriteLine($"json : \n{jsonString}"); //Test
                var content = new StringContent(jsonString, Encoding.UTF8, "application/json");

                var response = await client.PostAsync($"api/bars/{id}/events", content);

                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("Event has been created!"); //Test
                    return true;
                }

                Console.WriteLine($"Something went wrong {response.StatusCode}"); //Test
                return false;
            }
        }

        //DELETE /eventname
        public async Task<bool> DeleteEvent(string id) //TODO: Skal testes
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseaddress);

                var response = await client.DeleteAsync($"{id}/");

                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("Event has been deleted!"); //Test
                    return true;
                }

                Console.WriteLine($"Something went wrong {response.StatusCode}"); //Test
                return false;
            }
        }


        //REVIEW

        //GET /api/bars/{barname}/reviews
        public async Task<List<ReviewDto>> GetBarReviewList(string id) //TODO: Skal testes
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseaddress);

                try
                {
                    var response = await client.GetAsync($"api/bars/{id}/reviews/");
                    if (response.IsSuccessStatusCode)
                    {
                        var msg = await response.Content.ReadAsStringAsync();
                        var events = JsonConvert.DeserializeObject<List<ReviewDto>>(msg);

                        return events;
                    }

                    //GetAsync failed, returning empty list of reviews
                    return new List<ReviewDto>();
                }
                catch (Exception e)
                {
                    Console.WriteLine("Der var ingen reviews at hente");
                    //There were no events to get, returning empty list of reviews
                    return new List<ReviewDto>();
                }
            }
        }

        //PUT /api/bars/{barname}/reviews
        public async Task<bool> EditReview(ReviewDto editedReview, string id) //TODO: Skal testes
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseaddress);

                var jsonString = JsonConvert.SerializeObject(editedReview);
                Console.WriteLine(jsonString); //Test

                var content = new StringContent(jsonString, Encoding.UTF8, "application/json");

                var response = await client.PutAsync($"api/bars/{id}/reviews", content);

                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("Review has been updated!"); //Test
                    return true;
                }

                Console.WriteLine($"Something went wrong: {response.StatusCode}"); // Test
                return false;
            }
        }

        //POST /api/bars/{barname}/reviews
        public async Task<bool> CreateReview(ReviewDto newReview, string id) //TODO: Skal testes
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseaddress);

                var jsonString = JsonConvert.SerializeObject(newReview);

                Console.WriteLine($"json : \n{jsonString}"); //Test
                var content = new StringContent(jsonString, Encoding.UTF8, "application/json");

                var response = await client.PostAsync($"api/bars/{id}/reviews", content);

                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("Review has been created!"); //Test
                    return true;
                }

                Console.WriteLine($"Something went wrong {response.StatusCode}"); //Test
                return false;
            }
        }

        //DELETE /api/bars/{barname}/reviews
        //TODO: SKAL VI SLETTE LISTEN AF REVIEWS ELLER SPECIFIK?

        //GET /api/bars/{barname}/reviews/{username}
        //TODO: GETTER VI KUN EN SPECIFIK PERSONS REVIEW FOR EN BESTEMT BAR ELLER FOR ALLE BARER?
    }
}

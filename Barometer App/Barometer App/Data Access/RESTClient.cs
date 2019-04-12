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

        //BAR

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

        //DRINK

        //GET api/bars/{barname}/drinks
        public async Task<List<Drink>> GetBarDrinkList(string id) //Virker
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
                        var drinks = JsonConvert.DeserializeObject<List<Drink>>(msg);

                        return drinks;
                    }

                    //GetAsync failed, returning empty list of bars
                    return new List<Drink>();
                }
                catch (Exception e)
                {
                    Console.WriteLine("Der var ingen drinks at hente");
                    //There were no drinks to get, returning empty list of drinks
                    return new List<Drink>();
                }
            }
        }

        //PUT /api/bars/{barname}/drinks
        public async Task<bool> EditDrink(Drink editedDrink, string id) //Virker
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
        public async Task<bool> CreateDrink(Drink newDrink, string id) //Virker
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

        //DELETE /api/bars/{barname}/drinks
        public async Task<bool> DeleteDrink(string barId, string drinkId) //Virker
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseaddress);

                var response = await client.DeleteAsync($"api/bars/{barId}/drinks/{drinkId}");

                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("Drink has been deleted!"); //Test
                    return true;
                }

                Console.WriteLine($"Something went wrong {response.StatusCode}"); //Test
                return false;
            }
        }


        //EVENT

        //GET /api/bars/{barname}/events
        public async Task<List<BarEvent>> GetBarEventList(string id) //Virker
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
                        var events = JsonConvert.DeserializeObject<List<BarEvent>>(msg);

                        return events;
                    }

                    //GetAsync failed, returning empty list of events
                    return new List<BarEvent>();
                }
                catch (Exception e)
                {
                    Console.WriteLine("Der var ingen events at hente");
                    //There were no events to get, returning empty list of events
                    return new List<BarEvent>();
                }
            }
        }

        //PUT /api/bars/{barname}/events
        public async Task<bool> EditEvent(BarEvent editedEvent, string id) //Virker
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
        public async Task<bool> CreateEvent(BarEvent newEvent, string id) //Virker
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

        //DELETE /api/bars/{barname}/events{eventname}
        public async Task<bool> DeleteEvent(string barId, string eventId) //Virker
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseaddress);

                var response = await client.DeleteAsync($"api/bars/{barId}/events/{eventId}/");

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
        public async Task<List<Review>> GetBarReviewList(string id) //Virker
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
                        var events = JsonConvert.DeserializeObject<List<Review>>(msg);

                        return events;
                    }

                    //GetAsync failed
                    return new List<Review>();
                }
                catch (Exception e)
                {
                    Console.WriteLine("Der var ingen reviews at hente");
                    //There were no reviews to get
                    return new List<Review>();
                }
            }
        }

        //PUT /api/bars/{barname}/reviews
        public async Task<bool> EditReview(Review editedReview, string id) //Virker
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
        public async Task<bool> CreateReview(Review newReview, string id) //Virker
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

        //GET /api/bars/{barname}/reviews/{username}
        public async Task<Review> GetSpecificBarReview(string barId, string username) //Virker
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseaddress);

                try
                {
                    var response = await client.GetAsync($"api/bars/{barId}/reviews/{username}");

                    if (response.IsSuccessStatusCode)
                    {
                        var msg = await response.Content.ReadAsStringAsync();
                        var review = JsonConvert.DeserializeObject<Review>(msg);

                        return review;
                    }
                    //GetAsync failed, returning empty review
                    return new Review();
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Der eksisterer ingen review fra {username} for {barId}");
                    //There were no review to get, returning empty review
                    return new Review();
                }
            }
        }

        //DELETE /api/bars/{barname}/reviews/{username}
        public async Task<bool> DeleteReview(string barId, string username) //Virker
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseaddress);

                var response = await client.DeleteAsync($"api/bars/{barId}/reviews/{username}");

                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("Review has been deleted!"); //Test
                    return true;
                }

                Console.WriteLine($"Something went wrong {response.StatusCode}"); //Test
                return false;
            }
        }
    }
}

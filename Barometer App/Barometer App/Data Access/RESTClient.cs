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
        /// <summary>
        /// Gets a list of simple bars to be shown on list view in the order of best first.
        /// </summary>
        /// <returns>
        /// A list of BarSimple
        /// </returns>
        public async Task<List<BarSimple>> GetBestBarList()
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
                    //There were no bars to get, returning empty list of bars
                    return new List<BarSimple>();
                }
            }
        }

        //PUT api/bars/
        /// <summary>
        /// Allows editing of a bar in the database
        /// </summary>
        /// <param name="editedBar">
        /// An instance of the Bar model
        /// </param>
        /// <returns>
        /// True if it went well. False if it went wrong.
        /// </returns>
        public async Task<bool> EditBar(Bar editedBar)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseaddress);

                var jsonString = JsonConvert.SerializeObject(editedBar);

                var content = new StringContent(jsonString, Encoding.UTF8, "application/json");

                var response = await client.PutAsync("api/bars/", content);

                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                return false;
            }
        }

        //POST api/bars/
        /// <summary>
        /// Allows creation of a new bar into the database.
        /// </summary>
        /// <param name="newBar">
        /// An instance of the Bar model.
        /// </param>
        /// <returns>
        /// True if it went well. False if it went wrong.
        /// </returns>
        public async Task<bool> CreateBar(Bar newBar)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseaddress);

                var jsonString = JsonConvert.SerializeObject(newBar);

                var content = new StringContent(jsonString, Encoding.UTF8, "application/json");

                var response = await client.PostAsync("api/bars/", content);

                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                return false;
            }
        }

        //GET api/bars/{id}
        /// <summary>
        /// Gets information about a specific bar for a detailed view of this particular bar.
        /// </summary>
        /// <param name="id">
        /// The name of the bar which is to be fetched.
        /// </param>
        /// <returns>
        /// An instance of the Bar model.
        /// </returns>
        public async Task<Bar> GetDetailedBar(string id)
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
                    //There were no bar to get, returning empty bar
                    return new Bar();
                }
            }
        }

        //DELETE api/bars/{id}
        /// <summary>
        /// Deletes an existing bar in the database.
        /// </summary>
        /// <param name="id">
        /// The name of the bar which is to be deleted.
        /// </param>
        /// <returns>
        /// True if it went well. False if it went wrong.
        /// </returns>
        public async Task<bool> DeleteBar(string id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseaddress);

                var response = await client.DeleteAsync($"api/bars/{id}/");

                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                return false;
            }
        }

        //GET api/bars/worst
        /// <summary>
        /// Gets a list of simple bars to be shown on the list view in the order of worst first.
        /// </summary>
        /// <returns>
        /// A list of BarSimple
        /// </returns>
        public async Task<List<BarSimple>> GetWorstBarList()
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
                    //There were no bars to get, returning empty list of bars
                    return new List<BarSimple>();
                }
            }
        }

        //GET api/bars/{from}/{to}
        /// <summary>
        /// Gets a specific list of simple bars to avoid getting all at the same time. It does so in alphabetical order.
        /// </summary>
        /// <param name="startIndex">
        /// The index of the full list of bars in which the specific list shall start from.
        /// </param>
        /// <param name="pageSize">
        /// The amount of bars which is to be shown on the list.
        /// </param>
        /// <returns>
        /// A list of BarSimple.
        /// </returns>
        public async Task<List<BarSimple>> GetSpecificBarList(int startIndex, int pageSize)
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
                    //There were no bars to get, returning empty list of bars
                    return new List<BarSimple>();
                }
            }
        }

        //DRINK

        //GET api/bars/{barname}/drinks
        public async Task<List<Drink>> GetBarDrinkList(string id)
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
                    //There were no drinks to get, returning empty list of drinks
                    return new List<Drink>();
                }
            }
        }

        //PUT /api/bars/{barname}/drinks
        public async Task<bool> EditDrink(Drink editedDrink, string id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseaddress);

                var jsonString = JsonConvert.SerializeObject(editedDrink);

                var content = new StringContent(jsonString, Encoding.UTF8, "application/json");

                var response = await client.PutAsync($"api/bars/{id}/drinks", content);

                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                return false;
            }
        }

        //POST /api/bars/{barname}/drinks
        public async Task<bool> CreateDrink(Drink newDrink, string id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseaddress);

                var jsonString = JsonConvert.SerializeObject(newDrink);

                var content = new StringContent(jsonString, Encoding.UTF8, "application/json");

                var response = await client.PostAsync($"api/bars/{id}/drinks", content);

                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                return false;
            }
        }

        //DELETE /api/bars/{barname}/drinks
        public async Task<bool> DeleteDrink(string barId, string drinkId)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseaddress);

                var response = await client.DeleteAsync($"api/bars/{barId}/drinks/{drinkId}");

                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                return false;
            }
        }


        //EVENT

        //GET /api/bars/{barname}/events
        public async Task<List<BarEvent>> GetBarEventList(string id)
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
                    //There were no events to get, returning empty list of events
                    return new List<BarEvent>();
                }
            }
        }

        //PUT /api/bars/{barname}/events
        public async Task<bool> EditEvent(BarEvent editedEvent, string id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseaddress);

                var jsonString = JsonConvert.SerializeObject(editedEvent);

                var content = new StringContent(jsonString, Encoding.UTF8, "application/json");

                var response = await client.PutAsync($"api/bars/{id}/events", content);

                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                return false;
            }
        }

        //POST /api/bars/{barname}/events
        public async Task<bool> CreateEvent(BarEvent newEvent, string id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseaddress);

                var jsonString = JsonConvert.SerializeObject(newEvent);

                var content = new StringContent(jsonString, Encoding.UTF8, "application/json");

                var response = await client.PostAsync($"api/bars/{id}/events", content);

                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                return false;
            }
        }

        //DELETE /api/bars/{barname}/events{eventname}
        public async Task<bool> DeleteEvent(string barId, string eventId)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseaddress);

                var response = await client.DeleteAsync($"api/bars/{barId}/events/{eventId}/");

                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                return false;
            }
        }


        //REVIEW

        //GET /api/bars/{barname}/reviews
        public async Task<List<Review>> GetBarReviewList(string id)
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
                    //There were no reviews to get
                    return new List<Review>();
                }
            }
        }

        //PUT /api/bars/{barname}/reviews
        public async Task<bool> EditReview(Review editedReview, string id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseaddress);

                var jsonString = JsonConvert.SerializeObject(editedReview);

                var content = new StringContent(jsonString, Encoding.UTF8, "application/json");

                var response = await client.PutAsync($"api/bars/{id}/reviews", content);

                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                return false;
            }
        }

        //POST /api/bars/{barname}/reviews
        public async Task<bool> CreateReview(Review newReview, string id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseaddress);

                var jsonString = JsonConvert.SerializeObject(newReview);

                var content = new StringContent(jsonString, Encoding.UTF8, "application/json");

                var response = await client.PostAsync($"api/bars/{id}/reviews", content);

                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                return false;
            }
        }

        //GET /api/bars/{barname}/reviews/{username}
        public async Task<Review> GetSpecificBarReview(string barId, string username)
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
                    //There were no review to get, returning empty review
                    return new Review();
                }
            }
        }

        //DELETE /api/bars/{barname}/reviews/{username}
        public async Task<bool> DeleteReview(string barId, string username)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseaddress);

                var response = await client.DeleteAsync($"api/bars/{barId}/reviews/{username}");

                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                return false;
            }
        }
    }
}

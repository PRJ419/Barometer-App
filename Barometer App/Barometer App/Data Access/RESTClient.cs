using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using Barometer_App;
using Barometer_App.DTO;
using Barometer_App.Models;
using Newtonsoft.Json;

namespace RESTClient
{
    public class RestClient : IRestClient
    {
       // private const string Baseaddress = "https://localhost:44310/";
        private const string Baseaddress = "https://10.192.71.109:45459";
        private Customer customer = Customer.GetCustomer();

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

                try
                {
                    var jsonString = JsonConvert.SerializeObject(editedBar);

                    var content = new StringContent(jsonString, Encoding.UTF8, "application/json");

                    var response = await client.PutAsync("api/bars/", content);

                    if (response.IsSuccessStatusCode)
                    {
                        return true;
                    }

                    //GetAsync failed
                    return false;
                }
                catch (Exception)
                {
                    return false;
                }

                
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

                try
                {
                    var jsonString = JsonConvert.SerializeObject(newBar);

                    var content = new StringContent(jsonString, Encoding.UTF8, "application/json");

                    var response = await client.PostAsync("api/bars/", content);

                    if (response.IsSuccessStatusCode)
                    {
                        return true;
                    }
                    //PostAsync failed
                    return false;
                }
                catch (Exception)
                {
                    return false;
                }
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
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", customer.UserToken);

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

                try
                {
                    var response = await client.DeleteAsync($"api/bars/{id}/");

                    if (response.IsSuccessStatusCode)
                    {
                        return true;
                    }
                    //DeleteAsync failed
                    return false;
                }
                catch (Exception)
                {
                    return false;
                }
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
        /// <summary>
        /// Gets a list of a specific bars drinks.
        /// </summary>
        /// <param name="id">
        /// The name of the bar which drinks one wish to see.
        /// </param>
        /// <returns>
        /// The list of the bars drinks.
        /// </returns>
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
                catch (Exception)
                {
                    //There were no drinks to get, returning empty list of drinks
                    return new List<Drink>();
                }
            }
        }

        //PUT /api/bars/{barname}/drinks
        /// <summary>
        /// Allows editing of a bars drink.
        /// </summary>
        /// <param name="editedDrink">
        /// The edited version of the drink.
        /// </param>
        /// <param name="id">
        /// The name of the bar which the drink belongs to.
        /// </param>
        /// <returns>
        /// True if it went well. False if it went wrong.
        /// </returns>
        public async Task<bool> EditDrink(Drink editedDrink, string id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseaddress);

                try
                {
                    var jsonString = JsonConvert.SerializeObject(editedDrink);

                    var content = new StringContent(jsonString, Encoding.UTF8, "application/json");

                    var response = await client.PutAsync($"api/bars/{id}/drinks", content);

                    if (response.IsSuccessStatusCode)
                    {
                        return true;
                    }
                    //PutAsync failed
                    return false;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        //POST /api/bars/{barname}/drinks
        /// <summary>
        /// Allows creation of a new drink to the specific bars menu.
        /// </summary>
        /// <param name="newDrink">
        /// A new instance of the Drink model, which will be added.
        /// </param>
        /// <param name="id">
        /// The name of the bar which the newly created drink belongs to.
        /// </param>
        /// <returns>
        /// True if it went well. False if it went wrong.
        /// </returns>
        public async Task<bool> CreateDrink(Drink newDrink, string id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseaddress);

                try
                {
                    var jsonString = JsonConvert.SerializeObject(newDrink);

                    var content = new StringContent(jsonString, Encoding.UTF8, "application/json");

                    var response = await client.PostAsync($"api/bars/{id}/drinks", content);

                    if (response.IsSuccessStatusCode)
                    {
                        return true;
                    }
                    return false;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        //DELETE /api/bars/{barname}/drinks
        /// <summary>
        /// Deletes a specific drink from a bars menu.
        /// </summary>
        /// <param name="barId">
        /// The name of bar which the drink belongs to.
        /// </param>
        /// <param name="drinkId">
        /// The name of the drink which is to be deleted.
        /// </param>
        /// <returns>
        /// True if it went well. False if it went wrong.
        /// </returns>
        public async Task<bool> DeleteDrink(string barId, string drinkId)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseaddress);

                try
                {
                    var response = await client.DeleteAsync($"api/bars/{barId}/drinks/{drinkId}");

                    if (response.IsSuccessStatusCode)
                    {
                        return true;
                    }
                    return false;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }


        //EVENT

        //GET /api/bars/{barname}/events
        /// <summary>
        /// Gets a list of all of a bars events.
        /// </summary>
        /// <param name="id">
        /// The name of the bar which events one wants to get.
        /// </param>
        /// <returns>
        /// The list of BarEvents.
        /// </returns>
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
                catch (Exception)
                {
                    //There were no events to get, returning empty list of events
                    return new List<BarEvent>();
                }
            }
        }

        //PUT /api/bars/{barname}/events
        /// <summary>
        /// Allows editing of an event of a bar.
        /// </summary>
        /// <param name="editedEvent">
        /// The edited version of the bar event.
        /// </param>
        /// <param name="id">
        /// The name of the bar which the event belongs to.
        /// </param>
        /// <returns>
        /// True if it went well. False if it went wrong.
        /// </returns>
        public async Task<bool> EditEvent(BarEvent editedEvent, string id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseaddress);

                try
                {
                    var jsonString = JsonConvert.SerializeObject(editedEvent);

                    var content = new StringContent(jsonString, Encoding.UTF8, "application/json");

                    var response = await client.PutAsync($"api/bars/{id}/events", content);

                    if (response.IsSuccessStatusCode)
                    {
                        return true;
                    }
                    return false;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        //POST /api/bars/{barname}/events
        /// <summary>
        /// Allows creation of an event of a bar.
        /// </summary>
        /// <param name="newEvent">
        /// The event which is wished to be created.
        /// </param>
        /// <param name="id">
        /// The name of the bar which the event belongs to.
        /// </param>
        /// <returns>
        /// True if it went well. False if it went wrong.
        /// </returns>
        public async Task<bool> CreateEvent(BarEvent newEvent, string id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseaddress);

                try
                {
                    var jsonString = JsonConvert.SerializeObject(newEvent);

                    var content = new StringContent(jsonString, Encoding.UTF8, "application/json");

                    var response = await client.PostAsync($"api/bars/{id}/events", content);

                    if (response.IsSuccessStatusCode)
                    {
                        return true;
                    }
                    return false;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        //DELETE /api/bars/{barname}/events{eventname}
        /// <summary>
        /// Deletes a specific event of a bar.
        /// </summary>
        /// <param name="barId">
        /// The name of the bar which the event belongs to.
        /// </param>
        /// <param name="eventId">
        /// The name of the event which is to be deleted.
        /// </param>
        /// <returns>
        /// True if it went well. False if it went wrong.
        /// </returns>
        public async Task<bool> DeleteEvent(string barId, string eventId)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseaddress);

                try
                {
                    var response = await client.DeleteAsync($"api/bars/{barId}/events/{eventId}/");

                    if (response.IsSuccessStatusCode)
                    {
                        return true;
                    }
                    return false;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }


        //REVIEW

        //GET /api/bars/{barname}/reviews
        /// <summary>
        /// Gets a list of reviews for a specific bar.
        /// </summary>
        /// <param name="id">
        /// The name of the bar which reviews which one wants to get.
        /// </param>
        /// <returns>
        /// The list of reviews.
        /// </returns>
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
                catch (Exception)
                {
                    //There were no reviews to get
                    return new List<Review>();
                }
            }
        }

        //PUT /api/bars/{barname}/reviews
        /// <summary>
        /// Allows editing of a review for a specific bar.
        /// </summary>
        /// <param name="editedReview">
        /// The edited version of the review.
        /// </param>
        /// <param name="id">
        /// The name of the bar which the review belongs to.
        /// </param>
        /// <returns>
        /// True if it went well. False if it went wrong.
        /// </returns>
        public async Task<bool> EditReview(Review editedReview)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseaddress);

                try
                {
                    var jsonString = JsonConvert.SerializeObject(editedReview);

                    var content = new StringContent(jsonString, Encoding.UTF8, "application/json");

                    var response = await client.PutAsync($"api/bars/{editedReview.BarName}/reviews", content);

                    if (response.IsSuccessStatusCode)
                    {
                        return true;
                    }
                    return false;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        //POST /api/bars/{barname}/reviews
        /// <summary>
        /// Allows creation of a review for a specific bar.
        /// </summary>
        /// <param name="newReview">
        /// The review which is to be created.
        /// </param>
        /// <param name="id">
        /// The name of the bar which the review belongs to.
        /// </param>
        /// <returns>
        /// True if it went well. False if it went wrong.
        /// </returns>
        public async Task<bool> CreateReview(Review newReview)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseaddress);

                try
                {
                    var jsonString = JsonConvert.SerializeObject(newReview);

                    var content = new StringContent(jsonString, Encoding.UTF8, "application/json");

                    var response = await client.PostAsync($"api/bars/{newReview.BarName}/reviews", content);

                    if (response.IsSuccessStatusCode)
                    {
                        return true;
                    }
                    return false;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        //GET /api/bars/{barname}/reviews/{username}
        /// <summary>
        /// Gets a specific users reviews for a bar.
        /// </summary>
        /// <param name="barId">
        /// The name of the bar which review is wanted.
        /// </param>
        /// <param name="username">
        /// The name of the user which review is wanted.
        /// </param>
        /// <returns>
        /// The specific review of a bar.
        /// </returns>
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
                catch (Exception)
                {
                    //There were no review to get, returning empty review
                    return new Review();
                }
            }
        }

        //DELETE /api/bars/{barname}/reviews/{username}
        /// <summary>
        /// Deletes a review from a specific user for a specific bar.
        /// </summary>
        /// <param name="barId">
        /// The name of the bar which the review belongs to.
        /// </param>
        /// <param name="username">
        /// The name of the user which the review belongs to.
        /// </param>
        /// <returns>
        /// True if it went well. False if it went wrong.
        /// </returns>
        public async Task<bool> DeleteReview(string barId, string username)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseaddress);

                try
                {
                    var response = await client.DeleteAsync($"api/bars/{barId}/reviews/{username}");

                    if (response.IsSuccessStatusCode)
                    {
                        return true;
                    }
                    return false;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        /*
         * ####################
         * # IDENTITY SERVICE #
         * ####################
         */
        #region Identity

        /// <summary>
        /// Attempts to register a user on the Identity Service
        /// </summary>
        /// <param name="model"> The RegisterDTO used for registering </param>
        /// <example> Example: bool result = await RestClient.RegisterAsync(dto) </example>
        /// <returns> Task&lt;bool&gt; with value true if request is successful otherwise false </returns>
        public async Task<bool> RegisterAsync(RegisterDTO model)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri(Baseaddress);

            var json = JsonConvert.SerializeObject(model);

            HttpContent content = new StringContent(json);

            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            try
            {
                var response = await client.PostAsync("api/register", content);
                return response.IsSuccessStatusCode;
            }
            catch (Exception e)
            {
                return false;
            }

        }

        /// <summary>
        /// Attempts to login a user on the Identity Service
        /// </summary>
        /// <param name="model"> The LoginDTO used for login in </param>
        /// <example> Example: string token = await RestClient.LoginAsync(dto) </example>
        /// <returns> Task&lt;string&gt; with the token for later use in autherization </returns>
        public async Task<string> LoginAsync(LoginDTO model)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri(Baseaddress);

            var json = JsonConvert.SerializeObject(model);
            HttpContent content = new StringContent(json);

            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            try
            {
                var response = await client.PostAsync("api/login", content);

                if (response.IsSuccessStatusCode)
                {
                    var jwt = await response.Content.ReadAsStringAsync();

                    return jwt;
                }
                return null;
            }
            catch (Exception e)
            {
                return null;
            }
        }
        #endregion
    }
}

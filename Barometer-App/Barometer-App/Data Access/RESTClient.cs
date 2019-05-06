using System;
using System.Collections.Generic;
using System.Data;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using Barometer_App.DTO;
using Barometer_App.Models;
using Newtonsoft.Json;

namespace RESTClient
{
    public class RestClient : IRestClient
    {
        //private const string Baseaddress = "https://localhost:44310/";
        private const string Baseaddress = "https://192.168.43.96:45457";
        private User customer = User.GetCustomer();
        private IHttpClientFactory clientFactory;

        /// <summary>
        /// Normal use of Restclient uses normal HttpClient for communication
        /// </summary>
        public RestClient()
        {
            clientFactory = new HttpClientFactory();
        }

        /// <summary>
        /// RestClient ctor used for injection a mock version of HttpClient
        /// </summary>
        /// <param name="mockFactory"></param>
        public RestClient(HttpClientHandler mockHandler)
        {
            clientFactory = new MockHttpClientFactory(mockHandler);
        }
        

        //BAR
        //GET api/bars/
        /// <summary>
        /// Gets a list of simple bars to be shown on list view in the order of best first.
        /// </summary>
        /// <returns>
        /// A list of BarSimple
        /// </returns>
        ///
        public async Task<List<BarSimple>> GetBestBarList()
        {
            //using (var client = new HttpClient())
            using (var client = clientFactory.CreateHttpClient(Baseaddress,
                new AuthenticationHeaderValue("Bearer", customer.UserToken)))
            {
                //client.BaseAddress = new Uri(Baseaddress);
                //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", customer.UserToken);

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
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", customer.UserToken);

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
        public async Task<bool> CreateBar(RegisterBarDTO newBar)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseaddress);
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", customer.UserToken);

                try
                {
                    var jsonString = JsonConvert.SerializeObject(newBar);

                    var content = new StringContent(jsonString, Encoding.UTF8, "application/json");

                    var response = await client.PostAsync("api/register/barrep/", content);

                    if (response.StatusCode == HttpStatusCode.BadRequest)
                    {
                        if (response.ReasonPhrase.ToLower().Contains("duplicate"))
                            throw new DuplicateNameException("Bar or BarRep already exists");
                    }

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
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", customer.UserToken);

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
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", customer.UserToken);

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
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", customer.UserToken);

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

        //BARREPRESENTATIVE

        //GET api/barrepresentatives
        /// <summary>
        /// Gets a list of BarRepresentatives.
        /// </summary>
        /// <returns>
        /// A list of BarRepresentative.
        /// </returns>
        public async Task<List<BarRepresentative>> GetAllBarRepresentatives()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseaddress);
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", customer.UserToken);

                try
                {
                    var response = await client.GetAsync($"api/barrepresentatives");
                    if (response.IsSuccessStatusCode)
                    {
                        var msg = await response.Content.ReadAsStringAsync();
                        var representatives = JsonConvert.DeserializeObject<List<BarRepresentative>>(msg);

                        return representatives;
                    }
                    //GetAsync failed, returning empty list of representatives
                    return new List<BarRepresentative>();
                }
                catch (Exception)
                {
                    //There were no representatives to get, returning empty list of representatives
                    return new List<BarRepresentative>();
                }
            }
        }

        //PUT api/barrepresentatives
        /// <summary>
        /// Allows editing of a BarRepresentative.
        /// </summary>
        /// <param name="editedBarRepresentative">
        /// The edited version of the specific BarRepresentative.
        /// </param>
        /// <returns>
        /// True if it went well. False if it went wrong.
        /// </returns>
        public async Task<bool> EditBarRepresentative(BarRepresentative editedBarRepresentative)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseaddress);
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", customer.UserToken);

                try
                {
                    var jsonString = JsonConvert.SerializeObject(editedBarRepresentative);

                    var content = new StringContent(jsonString, Encoding.UTF8, "application/json");

                    var response = await client.PutAsync($"api/barrepresentatives", content);

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

        //POST api/barrepresentatives
        /// <summary>
        /// Allows creation of a BarRepresentative.
        /// </summary>
        /// <param name="newBarRepresentative">
        /// The new instance of BarRepresentative.
        /// </param>
        /// <returns>
        /// True if it went well. False if it went wrong.
        /// </returns>
        public async Task<bool> CreateBarRepresentative(BarRepresentative newBarRepresentative)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseaddress);
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", customer.UserToken);

                try
                {
                    var jsonString = JsonConvert.SerializeObject(newBarRepresentative);

                    var content = new StringContent(jsonString, Encoding.UTF8, "application/json");

                    var response = await client.PostAsync($"api/barrepresentatives", content);

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

        //GET api/barrepresentatives/{username}
        /// <summary>
        /// Gets a specific BarRepresentative.
        /// </summary>
        /// <param name="username">
        /// The name of the BarRepresentative which is to be fetched.
        /// </param>
        /// <returns>
        /// The BarRepresentative with username matching the request.
        /// </returns>
        public async Task<BarRepresentative> GetSpecificBarRepresentative(string username)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseaddress);
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", customer.UserToken);

                try
                {
                    var response = await client.GetAsync($"api/barrepresentatives/{username}");
                    if (response.IsSuccessStatusCode)
                    {
                        var msg = await response.Content.ReadAsStringAsync();
                        var representative = JsonConvert.DeserializeObject<BarRepresentative>(msg);

                        return representative;
                    }
                    //GetAsync failed, returning empty representative
                    return new BarRepresentative();
                }
                catch (Exception)
                {
                    //There were no representative to get, returning empty representative
                    return new BarRepresentative();
                }
            }
        }

        //DELETE api/barrepresentatives/{username}
        /// <summary>
        /// Deletes a specific BarRepresentative.
        /// </summary>
        /// <param name="username">
        /// The name of the BarRepresentative which is to be deleted.
        /// </param>
        /// <returns>
        /// True if it went well. False if it went wrong.
        /// </returns>
        public async Task<bool> DeleteBarRepresentative(string username)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseaddress);
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", customer.UserToken);

                try
                {
                    var response = await client.DeleteAsync($"api/barrepresentatives/{username}");

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



        //COUPON

        //GET api/bars/{barName}/coupons
        /// <summary>
        /// Gets a list of coupons for the requested bar.
        /// </summary>
        /// <param name="barName">
        /// The name ofthe bar which coupons is to be fetched.
        /// </param>
        /// <returns>
        /// A list of coupons.
        /// </returns>
        public async Task<List<Coupon>> GetAllCoupons(string barName)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseaddress);
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", customer.UserToken);

                try
                {
                    var response = await client.GetAsync($"api/bars/{barName}/coupons");
                    if (response.IsSuccessStatusCode)
                    {
                        var msg = await response.Content.ReadAsStringAsync();
                        var coupons = JsonConvert.DeserializeObject<List<Coupon>>(msg);

                        return coupons;
                    }
                    //GetAsync failed, returning empty list of coupons
                    return new List<Coupon>();
                }
                catch (Exception)
                {
                    //There were no coupons to get, returning empty list of coupons
                    return new List<Coupon>();
                }
            }
        }

        //PUT api/bars/{barName}/coupons
        /// <summary>
        /// Allows editing of a coupon.
        /// </summary>
        /// <param name="editedCoupon">
        /// The edited version of the coupon.
        /// </param>
        /// <param name="barName">
        /// The name of the bar which the coupon belongs to.
        /// </param>
        /// <returns>
        /// True if it went well. False if it went wrong.
        /// </returns>
        public async Task<bool> EditCoupon(Coupon editedCoupon, string barName)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseaddress);
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", customer.UserToken);

                try
                {
                    var jsonString = JsonConvert.SerializeObject(editedCoupon);

                    var content = new StringContent(jsonString, Encoding.UTF8, "application/json");

                    var response = await client.PutAsync($"api/bars/{barName}/coupons", content);

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

        //POST api/bars/{barName}/coupons
        /// <summary>
        /// Allows creation of a coupon.
        /// </summary>
        /// <param name="newCoupon">
        /// The new instance of Coupon.
        /// </param>
        /// <param name="barName">
        /// The name of the bar which the coupon belongs to.
        /// </param>
        /// <returns>
        /// True if it went well. False if it went wrong.
        /// </returns>
        public async Task<bool> CreateCoupon(Coupon newCoupon, string barName)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseaddress);
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", customer.UserToken);

                try
                {
                    var jsonString = JsonConvert.SerializeObject(newCoupon);

                    var content = new StringContent(jsonString, Encoding.UTF8, "application/json");

                    var response = await client.PostAsync($"api/bars/{barName}/coupons", content);

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

        //GET api/bars/{barName}/coupons/{couponID}
        /// <summary>
        /// Gets a specific coupon for a bar.
        /// </summary>
        /// <param name="barName">
        /// The name of the bar which the coupon belongs to.
        /// </param>
        /// <param name="couponID">
        /// The ID of the coupon which is to be fetched.
        /// </param>
        /// <returns>
        /// The coupon with ID matching the request.
        /// </returns>
        public async Task<Coupon> GetSpecificCoupon(string barName, string couponID)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseaddress);
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", customer.UserToken);

                try
                {
                    var response = await client.GetAsync($"api/bars/{barName}/coupons/{couponID}");
                    if (response.IsSuccessStatusCode)
                    {
                        var msg = await response.Content.ReadAsStringAsync();
                        var coupon = JsonConvert.DeserializeObject<Coupon>(msg);

                        return coupon;
                    }
                    //GetAsync failed, returning empty coupon
                    return new Coupon();
                }
                catch (Exception)
                {
                    //There were no coupon to get, returning empty coupon
                    return new Coupon();
                }
            }
        }

        //DELETE api/bars/{barName}/coupons/{couponID}
        /// <summary>
        /// Deletes a specific coupon of a bar.
        /// </summary>
        /// <param name="barName">
        /// The name of the bar which the coupon belongs to.
        /// </param>
        /// <param name="couponID">
        /// The ID of the coupon which is to be deleted.
        /// </param>
        /// <returns>
        /// True if it went well. False if it went wrong.
        /// </returns>
        public async Task<bool> DeleteCoupon(string barName, string couponID)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseaddress);
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", customer.UserToken);

                try
                {
                    var response = await client.DeleteAsync($"api/bars/{barName}/coupons/{couponID}");

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


        //CUSTOMER

        //GET api/customers
        /// <summary>
        /// Gets a list of all customers.
        /// </summary>
        /// <returns>
        /// A list of customers.
        /// </returns>
        public async Task<List<User>> GetAllCustomers()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseaddress);
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", customer.UserToken);

                try
                {
                    var response = await client.GetAsync($"api/customers");
                    if (response.IsSuccessStatusCode)
                    {
                        var msg = await response.Content.ReadAsStringAsync();
                        var customers = JsonConvert.DeserializeObject<List<User>>(msg);

                        return customers;
                    }
                    //GetAsync failed, returning empty list of customers
                    return new List<User>();
                }
                catch (Exception)
                {
                    //There were no drinks to get, returning empty list of customers
                    return new List<User>();
                }
            }
        }

        //PUT api/customers
        /// <summary>
        /// Allows editing of a customer.
        /// </summary>
        /// <param name="editedCustomer">
        /// The edited instance of a customer.
        /// </param>
        /// <returns>
        /// True if it went well. False if it went wrong.
        /// </returns>
        public async Task<bool> EditCustomer(User editedCustomer)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseaddress);
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", customer.UserToken);

                try
                {
                    var jsonString = JsonConvert.SerializeObject(editedCustomer);

                    var content = new StringContent(jsonString, Encoding.UTF8, "application/json");

                    var response = await client.PutAsync($"api/customers", content);

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

        //POST api/customers
        /// <summary>
        /// Creates a new Customer.
        /// </summary>
        /// <param name="newCustomer">
        /// The new instance of a Customer.
        /// </param>
        /// <returns>
        /// True if it went well. False if it went wrong.
        /// </returns>
        public async Task<bool> CreateCustomer(User newCustomer)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseaddress);
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", customer.UserToken);

                try
                {
                    var jsonString = JsonConvert.SerializeObject(newCustomer);

                    var content = new StringContent(jsonString, Encoding.UTF8, "application/json");

                    var response = await client.PostAsync($"api/customers", content);

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

        //GET api/customers/{username}
        /// <summary>
        /// Gets a specific Customer.
        /// </summary>
        /// <param name="username">
        /// The username of the Customer which is to be fetched.
        /// </param>
        /// <returns>
        /// The Customer with username matching the request.
        /// </returns>
        public async Task<User> GetSpecificCustomer(string username)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseaddress);
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", customer.UserToken);

                try
                {
                    var response = await client.GetAsync($"api/customers/{username}");
                    if (response.IsSuccessStatusCode)
                    {
                        var msg = await response.Content.ReadAsStringAsync();
                        var customers = JsonConvert.DeserializeObject<User>(msg);

                        return customers;
                    }
                    //GetAsync failed, returning null
                    return null;
                }
                catch (Exception)
                {
                    //There were no customer to get, returning null
                    return null;
                }
            }
        }

        //DELETE api/customers/{username}
        /// <summary>
        /// Deletes a specific Customer.
        /// </summary>
        /// <param name="username">
        /// The name of the Customer which is to be deleted.
        /// </param>
        /// <returns>
        /// True if it went well. False if it went wrong.
        /// </returns>
        public async Task<bool> DeleteCustomer(string username)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseaddress);
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", customer.UserToken);

                try
                {
                    var response = await client.DeleteAsync($"api/customers/{username}");

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
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", customer.UserToken);

                try
                {
                    var response = await client.GetAsync($"api/bars/{id}/drinks/");
                    if (response.IsSuccessStatusCode)
                    {
                        var msg = await response.Content.ReadAsStringAsync();
                        var drinks = JsonConvert.DeserializeObject<List<Drink>>(msg);

                        return drinks;
                    }
                    //GetAsync failed, returning empty list of drinks
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
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", customer.UserToken);

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
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", customer.UserToken);

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
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", customer.UserToken);

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
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", customer.UserToken);

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
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", customer.UserToken);

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
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", customer.UserToken);

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
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", customer.UserToken);

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
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", customer.UserToken);

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
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", customer.UserToken);

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
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", customer.UserToken);

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
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", customer.UserToken);
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
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", customer.UserToken);

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

                if (response.StatusCode == HttpStatusCode.BadRequest)
                {
                    if (response.ReasonPhrase.ToLower().Contains("duplicate"))
                        throw new DuplicateNameException("Username already exists");

                    if(response.ReasonPhrase.ToLower().Contains("password"))
                        throw new Exception("Password must contain at least one uppercase letter, one lowercase letter and a number");
                }

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

                if (response.StatusCode == HttpStatusCode.BadRequest)
                {
                    if(response.ReasonPhrase.ToLower().Contains("password"))
                        throw new Exception("Wrong username and/or password");
                }

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

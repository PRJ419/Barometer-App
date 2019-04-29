using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Barometer_App.DTO;
using Barometer_App.Models;
using Barometer_App.Views;
using Newtonsoft.Json;


namespace RESTClient
{
    public class StubRestClient : IRestClient
    {
        //BAR

        //GET api/bars/
        public async Task<List<BarSimple>> GetBestBarList()
        {
            var stubList = new List<BarSimple>();

            var bar1 = new BarSimple { BarName = "Barname", AvgRating = 5, ShortDescription = "This is Bar1", Image = "https://www.bigskyfishing.com/wordpress/wp-content/uploads/2018/03/two-med-lake-reflections-lead.jpg" };
            stubList.Add(bar1);

            var bar2 = new BarSimple { BarName = "Bar2", AvgRating = 4, ShortDescription = "This is Bar2", Image = "https://www.xamarin.com/content/images/pages/forms/example-app.png" };
            stubList.Add(bar2);

            return stubList;

        }

        //PUT api/bars/
        public async Task<bool> EditBar(Bar editedBar)
        {
            return true;
        }

        //POST api/bars/
        public async Task<bool> CreateBar(Bar newBar)
        {
            return true;
        }

        //GET api/bars/{id}
        public async Task<Bar> GetDetailedBar(string id) //Brug id == "Barname"
        {
            var detailedBar = new Bar()
            {
                BarName = "Barname",
                Address = "Finlandsgade 22",
                AgeLimit = 18,
                AvgRating = 4.2,
                LongDescription = "Looooooong description",
                Image = "katrine",
                Educations = "Engineers"
            };

            if (id == "Barname")
            {
                return detailedBar;
            }
            return new Bar();
        }

        //DELETE api/bars/{id}
        public async Task<bool> DeleteBar(string id)
        {
            return true;
        }

        //GET api/bars/worst
        public async Task<List<BarSimple>> GetWorstBarList()
        {
            var stubList = new List<BarSimple>();

            var bar2 = new BarSimple { BarName = "Bar2", AvgRating = 4, ShortDescription = "This is Bar2", Image = "katrine.png" };
            stubList.Add(bar2);

            var bar1 = new BarSimple { BarName = "Bar1", AvgRating = 5, ShortDescription = "This is Bar1", Image = "katrine.png" };
            stubList.Add(bar1);

            return stubList;
        }

        //GET api/bars/{from}/{to}
        public async Task<List<BarSimple>> GetSpecificBarList(int startIndex, int pageSize) //Der er 5 barer
        {
            var stubList = new List<BarSimple>();

            var bar1 = new BarSimple { BarName = "Bar1", AvgRating = 5, ShortDescription = "This is Bar1", Image = "katrine.png" };
            stubList.Add(bar1);

            var bar2 = new BarSimple { BarName = "Bar2", AvgRating = 4, ShortDescription = "This is Bar2", Image = "katrine.png" };
            stubList.Add(bar2);

            var bar3 = new BarSimple { BarName = "Bar3", AvgRating = 3, ShortDescription = "This is Bar3", Image = "katrine.png" };
            stubList.Add(bar3);

            var bar4 = new BarSimple { BarName = "Bar4", AvgRating = 2, ShortDescription = "This is Bar4", Image = "katrine.png" };
            stubList.Add(bar4);

            var bar5 = new BarSimple { BarName = "Bar5", AvgRating = 1, ShortDescription = "This is Bar5", Image = "katrine.png" };
            stubList.Add(bar5);

            return stubList.GetRange(startIndex, pageSize);
        }


        //BARREPRESENTATIVE

        //GET api/barrepresentatives
        public async Task<List<BarRepresentative>> GetAllBarRepresentatives()
        {
            throw new NotImplementedException();
        }

        //PUT api/barrepresentatives
        public async Task<bool> EditBarRepresentative(BarRepresentative editedBarRepresentative)
        {
            throw new NotImplementedException();
        }

        //POST api/barrepresentatives
        public async Task<bool> CreateBarRepresentative(BarRepresentative newBarRepresentative)
        {
            throw new NotImplementedException();
        }

        //GET api/barrepresentatives/{username}
        public async Task<BarRepresentative> GetSpecificBarRepresentative(string username)
        {
            throw new NotImplementedException();
        }

        //DELETE api/barrepresentatives/{username}
        public async Task<bool> DeleteBarRepresentative(string username)
        {
            throw new NotImplementedException();
        }


        //COUPON

        //GET api/bars/{barName}/coupons
        public async Task<List<Coupon>> GetAllCoupons(string barName)
        {
            throw new NotImplementedException();
        }

        //PUT api/bars/{barName}/coupons
        public async Task<bool> EditCoupon(Coupon editedCoupon, string barName)
        {
            throw new NotImplementedException();
        }

        //POST api/bars/{barName}/coupons
        public async Task<bool> CreateCoupon(Coupon newCoupon, string barName)
        {
            throw new NotImplementedException();
        }

        //GET api/bars/{barName}/coupons/{couponID
        public async Task<Coupon> GetSpecificCoupon(string barName, string couponID)
        {
            throw new NotImplementedException();
        }

        //DELETE api/bars/{barName}/coupons/{couponID
        public async Task<bool> DeleteCoupon(string barName, string couponID)
        {
            throw new NotImplementedException();
        }


        //CUSTOMER

        //GET api/customers
        public async Task<List<Customer>> GetAllCustomers()
        {
            throw new NotImplementedException();
        }

        //PUT api/customers
        public async Task<bool> EditCustomer(Customer editedCustomer)
        {
            throw new NotImplementedException();
        }

        //POST api/customers
        public async Task<bool> CreateCustomer(Customer newCustomer)
        {
            throw new NotImplementedException();
        }

        //GET api/customers/{username}
        public async Task<Customer> GetSpecificCustomer(string username)
        {
            throw new NotImplementedException();
        }

        //DELETE api/customers/{username}
        public async Task<bool> DeleteCustomer(string username)
        {
            throw new NotImplementedException();
        }


        //DRINK

        //GET api/bars/{barname}/drinks
        public async Task<List<Drink>> GetBarDrinkList(string id) //Brug id == "Cbar"
        {
            var list = new List<Drink>
            {
                new Drink()
                {
                    DrinksName = "Martini",
                    BarName = "Barname",
                    Image = "martini.jpg",
                    Price = 20.00
                },
                new Drink()
                {
                    DrinksName = "Bloody mary",
                    BarName = "Barname",
                    Image = "martini.jpg",
                    Price = 30.00
                },
                new Drink()
                {
                    DrinksName = "Vodka",
                    BarName = "Barname",
                    Image = "martini.jpg",
                    Price = 40.00
                }
            };

            if (id == "Barname")
            {
                return list;
            }
            return new List<Drink>();
        }

        //PUT /api/bars/{barname}/drinks
        public async Task<bool> EditDrink(Drink editedDrink, string id)
        {
            return true;
        }

        //POST /api/bars/{barname}/drinks
        public async Task<bool> CreateDrink(Drink newDrink, string id)
        {
            return true;
        }

        //DELETE /api/bars/{barname}/drinks
        public async Task<bool> DeleteDrink(string barId, string drinkId)
        {
            return true;
        }


        //EVENT

        //GET /api/bars/{barname}/events
        public async Task<List<BarEvent>> GetBarEventList(string id)
        {
            var events = new List<BarEvent>();

            for (int i = 0; i < 3; i++)
            {
                events.Add(new BarEvent()
                {
                    BarName = "Barname",
                    Image = "katrine.png",
                    Date = DateTime.Now,
                    EventName = "Harry Pot bar"
                });
            }

            if (id == "Barname")
            {
                return events;
            }
            return new List<BarEvent>();
        }

        //PUT /api/bars/{barname}/events
        public async Task<bool> EditEvent(BarEvent editedEvent, string id)
        {
            return true;
        }

        //POST /api/bars/{barname}/events
        public async Task<bool> CreateEvent(BarEvent newEvent, string id)
        {
            return true;
        }

        //DELETE /api/bars/{barname}/events{eventname}
        public async Task<bool> DeleteEvent(string barId, string eventId)
        {
            return true;
        }


        //REVIEW

        //GET /api/bars/{barname}/reviews
        public async Task<List<Review>> GetBarReviewList(string id) //Brug id == "testbar"
        {
            var reviews = new List<Review>();

            var rev1 = new Review { BarPressure = 5, BarName = "Barname", Username = "user1"};
            reviews.Add(rev1);

            var rev2 = new Review { BarPressure = 4, BarName = "Barname", Username = "user2" };
            reviews.Add(rev2);

            var rev3 = new Review { BarPressure = 3, BarName = "Barname", Username = "user3" };
            reviews.Add(rev3);

            if (id == "Barname")
            {
                return reviews;
            }
            return new List<Review>();
        }

        //PUT /api/bars/{barname}/reviews
        public async Task<bool> EditReview(Review editedReview)
        {
            return true;
        }

        //POST /api/bars/{barname}/reviews
        public async Task<bool> CreateReview(Review newReview)
        {
            return true;
        }

        //GET /api/bars/{barname}/reviews/{username}
        public async Task<Review> GetSpecificBarReview(string barId, string username) // Brug barId == "testbar" og username == simon
        {
            var review = new Review { BarPressure = 5, BarName = "Barname", Username = "simon" };

            if (barId == "Barname" && username == "simon")
            {
                return review;
            }
            return new Review();
        }

        //DELETE /api/bars/{barname}/reviews/{username}
        public async Task<bool> DeleteReview(string barId, string username)
        {
            return true;
        }

        public async Task<bool> RegisterAsync(RegisterDTO model)
        {
            return true;
        }

        public async Task<string> LoginAsync(LoginDTO model)
        {
            return "UserToken";
        }
    }
}

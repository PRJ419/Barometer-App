using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
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

            var bar1 = new BarSimple {BarName = "Bar1", AvgRating = 5, ShortDescription = "This is Bar1", Image = "katrine.png"};
            stubList.Add(bar1);

            var bar2 = new BarSimple {BarName = "Bar2", AvgRating = 4, ShortDescription = "This is Bar2", Image = "katrine.png"};
            stubList.Add(bar2);

            return stubList;

        }

        //PUT api/bars/
        public async Task<bool> EditBar(Bar editedBar)
        {
            throw new NotImplementedException();
        }

        //POST api/bars/
        public async Task<bool> CreateBar(Bar newBar)
        {
            throw new NotImplementedException();
        }

        //GET api/bars/{id}
        public async Task<Bar> GetDetailedBar(string id)
        {
            var detailedBar = new Bar()
            {
                BarName = "Barname",
                Address = "Bar address",
                AgeLimit = 18,
                AvgRating = 4.2,
                LongDescription = "Looooooong description",
                Image = "katrine.png"
            };

            return detailedBar;
        }

        //DELETE api/bars/{id}
        public async Task<bool> DeleteBar(string id)
        {
            throw new NotImplementedException();
        }

        //GET api/bars/worst
        public async Task<List<BarSimple>> GetWorstBarList()
        {
            throw new NotImplementedException();
        }

        //GET api/bars/{from}/{to}
        public async Task<List<BarSimple>> GetSpecificBarList(int startIndex, int pageSize)
        {
            throw new NotImplementedException();
        }

        //DRINK

        //GET api/bars/{barname}/drinks
        public async Task<List<Drink>> GetBarDrinkList(string id)
        {
            throw new NotImplementedException();
        }

        //PUT /api/bars/{barname}/drinks
        public async Task<bool> EditDrink(Drink editedDrink, string id)
        {
            throw new NotImplementedException();
        }

        //POST /api/bars/{barname}/drinks
        public async Task<bool> CreateDrink(Drink newDrink, string id)
        {
            throw new NotImplementedException();
        }

        //DELETE /api/bars/{barname}/drinks
        public async Task<bool> DeleteDrink(string barId, string drinkId)
        {
            throw new NotImplementedException();
        }


        //EVENT

        //GET /api/bars/{barname}/events
        public async Task<List<BarEvent>> GetBarEventList(string id)
        {
            throw new NotImplementedException();
        }

        //PUT /api/bars/{barname}/events
        public async Task<bool> EditEvent(BarEvent editedEvent, string id)
        {
            throw new NotImplementedException();
        }

        //POST /api/bars/{barname}/events
        public async Task<bool> CreateEvent(BarEvent newEvent, string id)
        {
            throw new NotImplementedException();
        }

        //DELETE /api/bars/{barname}/events{eventname}
        public async Task<bool> DeleteEvent(string barId, string eventId)
        {
            throw new NotImplementedException();
        }


        //REVIEW

        //GET /api/bars/{barname}/reviews
        public async Task<List<Review>> GetBarReviewList(string id)
        {
            throw new NotImplementedException();
        }

        //PUT /api/bars/{barname}/reviews
        public async Task<bool> EditReview(Review editedReview, string id)
        {
            throw new NotImplementedException();
        }

        //POST /api/bars/{barname}/reviews
        public async Task<bool> CreateReview(Review newReview, string id)
        {
            throw new NotImplementedException();
        }

        //GET /api/bars/{barname}/reviews/{username}
        public async Task<Review> GetSpecificBarReview(string barId, string username)
        {
            throw new NotImplementedException();
        }

        //DELETE /api/bars/{barname}/reviews/{username}
        public async Task<bool> DeleteReview(string barId, string username)
        {
            throw new NotImplementedException();
        }
    }
}

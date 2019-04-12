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

        //GET api/bars/{barname}/drinks
        //public async Task<List<DrinkDto>> GetBarDrinkList(string id)
        //{
        //    throw new NotImplementedException();
        //}
    }
}

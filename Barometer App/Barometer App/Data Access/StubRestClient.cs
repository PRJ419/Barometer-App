using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Barometer_App.Models;
using Barometer_App.Views;
using Newtonsoft.Json;
using RESTClient.DTOs;

namespace RESTClient
{
    public class StubRestClient : IRestClient
    {
        
        //GET api/bars/
        public async Task<List<BarSimple>> GetBestBarList()
        {
            //var StubList = new List<BarListViewDto>();

            //BarListViewDto bar1 = new BarListViewDto();
            //bar1.BarName = "Bar1";
            //bar1.AvgRating = 5;
            //bar1.ShortDescription = "This is Bar1";
            //bar1.PostalCode = "8600";
            //StubList.Add(bar1);

            //BarListViewDto bar2 = new BarListViewDto();
            //bar2.BarName = "Bar2";
            //bar2.AvgRating = 4;
            //bar2.ShortDescription = "This is Bar2";
            //bar2.PostalCode = "8000";
            //StubList.Add(bar2);

            //return StubList;
            throw new NotImplementedException();
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
            //var detailedBar = new DetailedBarViewDTO()
            //{
            //    BarName = "Barname",
            //    Address = "Bar address",
            //    AgeRestriction = 18,
            //    AvgRating = 4.2,
            //    LongDescription = "Looooooong description",
            //};

            //return detailedBar;
            throw new NotImplementedException();
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

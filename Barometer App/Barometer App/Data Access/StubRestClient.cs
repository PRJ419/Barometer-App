using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Barometer_App.Views;
using Newtonsoft.Json;
using RESTClient.DTOs;

namespace RESTClient
{
    public class StubRestClient : IRestClient
    {
        
        //GET api/bars/
        public async Task<List<BarSimpleDto>> GetBarList()
        {
            List<BarSimpleDto> StubList = new List<BarSimpleDto>();

            BarSimpleDto bar1 = new BarSimpleDto();
            bar1.BarName = "Bar1";
            bar1.AvgRating = 5;
            bar1.ShortDescription = "This is Bar1";
            StubList.Add(bar1);

            BarSimpleDto bar2 = new BarSimpleDto();
            bar1.BarName = "Bar2";
            bar1.AvgRating = 4;
            bar1.ShortDescription = "This is Bar2";
            StubList.Add(bar2);

            return StubList;
        }

        //PUT api/bars/
        public async Task<bool> EditBar(BarDto editedBar) //Virker ikke
        {
            throw new NotImplementedException();
        }

        //POST api/bars/
        public async Task<bool> CreateBar(BarDto newBar)
        {
            throw new NotImplementedException();
        }

        //GET api/bars/{id}
        public async Task<BarDto> GetDetailedBar(string id)
        {
            BarDto DetailedBar = new BarDto();
            DetailedBar.BarName = "Barname";
            DetailedBar.Address = "Bar address";
            DetailedBar.AgeLimit = 18;
            DetailedBar.AvgRating = 4.2;
            DetailedBar.CVR = 12345678;
            DetailedBar.Educations = "School of engineering";
            DetailedBar.Email = "Bar email";
            DetailedBar.LongDescription = "Looooooong description";
            DetailedBar.PhoneNumber = 87654321;
            DetailedBar.ShortDescription = "Short description";

            return DetailedBar;
        }

        //DELETE api/bars/{id}
        public async Task<bool> DeleteBar(string id)
        {
            throw new NotImplementedException();
        }

        //GET api/bars/worst
        public async Task<List<BarSimpleDto>> GetWorstBarList()
        {
            throw new NotImplementedException();
        }

        //GET api/bars/{from}/{to}
        public async Task<List<BarSimpleDto>> GetSpecificBarList(int index1, int index2)
        {
            throw new NotImplementedException();
        }

        //GET api/bars/{barname}/drinks
        public async Task<List<DrinkDto>> GetBarDrinkList(string id)
        {
            throw new NotImplementedException();
        }
    }
}

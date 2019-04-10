using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Barometer_App.Models;
using RESTClient.DTOs;


namespace RESTClient
{
    public interface IRestClient
    {
        //BARS
        Task<List<BarSimple>> GetBestBarList();
        Task<bool> EditBar(Bar editedBar);
        Task<bool> CreateBar(Bar newBar);
        Task<Bar> GetDetailedBar(string id);
        Task<bool> DeleteBar(string id);
        Task<List<BarSimple>> GetWorstBarList();
        Task<List<BarSimple>> GetSpecificBarList(int startIndex, int pageSize);

        
    }
}

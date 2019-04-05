using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using RESTClient.DTOs;

namespace RESTClient
{
    public interface IRestClient
    {
        //List<BarSimpleDto> GetBestBarsList(); WAT IS DIS
        Task<List<BarListViewDto>> GetBarList();
        Task<bool> EditBar(BarDto editedBar);
        Task<bool> CreateBar(BarDto newBar);
        Task<DetailedBarViewDTO> GetDetailedBar(string id);
        Task<bool> DeleteBar(string id);
        Task<List<BarListViewDto>> GetWorstBarList();
        Task<List<BarListViewDto>> GetSpecificBarList(string id1, string id2);
        Task<List<DrinkDto>> GetBarDrinkList(string id);
    }
}

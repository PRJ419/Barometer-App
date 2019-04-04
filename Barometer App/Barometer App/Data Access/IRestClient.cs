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
        Task<List<BarSimpleDto>> GetBarList();
        Task<bool> EditBar(BarDto editedBar);
        Task<bool> CreateBar(BarDto newBar);
        Task<BarDto> GetDetailedBar(string id);
        Task<bool> DeleteBar(string id);
        Task<List<BarSimpleDto>> GetWorstBarList();
        Task<List<BarSimpleDto>> GetSpecificBarList(int index1, int index2);
        Task<List<DrinkDto>> GetBarDrinkList(string id);
    }
}

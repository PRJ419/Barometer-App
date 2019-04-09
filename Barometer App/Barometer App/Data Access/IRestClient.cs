using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using RESTClient.DTOs;

namespace RESTClient
{
    public interface IRestClient
    {
        //BARS
        Task<List<BarSimpleDto>> GetBarList();
        Task<bool> EditBar(BarDto editedBar);
        Task<bool> CreateBar(BarDto newBar);
        Task<BarDto> GetDetailedBar(string id);
        Task<bool> DeleteBar(string id);
        Task<List<BarSimpleDto>> GetWorstBarList();
        Task<List<BarSimpleDto>> GetSpecificBarList(int startIndex, int pageSize);

        //DRINKS
        Task<List<DrinkDto>> GetBarDrinkList(string id);
        Task<bool> EditDrink(DrinkDto editedDrink, string id);
        Task<bool> CreateDrink(DrinkDto newDrink, string id);
        //Task<bool> DeleteDrink(string barId); Ikke klar

        //EVENTS
        Task<List<BarEventDto>> GetBarEventList(string id);
        Task<bool> EditEvent(BarEventDto editedEvent, string id);
        Task<bool> CreateEvent(BarEventDto newEvent, string id);
        Task<bool> DeleteEvent(string id);

        //REVIEWS
        Task<List<ReviewDto>> GetBarReviewList(string id);
        Task<bool> EditReview(ReviewDto editedReview, string id);
        Task<bool> CreateReview(ReviewDto newReview, string id);
        //Kommer en DELETE her
        //Kommer en GET på specifik review her
    }
}

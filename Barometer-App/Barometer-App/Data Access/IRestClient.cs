using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Barometer_App.DTO;
using Barometer_App.Models;


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

        //BARREPRESENTATIVE
        Task<List<BarRepresentative>> GetAllBarRepresentatives();
        Task<bool> EditBarRepresentative(BarRepresentative editedBarRepresentative);
        Task<bool> CreateBarRepresentative(BarRepresentative newBarRepresentative);
        Task<BarRepresentative> GetSpecificBarRepresentative(string username);
        Task<bool> DeleteBarRepresentative(string username);
        

        //COUPON
        Task<List<Coupon>> GetAllCoupons(string barName);
        Task<bool> EditCoupon(Coupon editedCoupon, string barName);
        Task<bool> CreateCoupon(Coupon newCoupon, string barName);
        Task<Coupon> GetSpecificCoupon(string barName, string couponID);
        Task<bool> DeleteCoupon(string barName, string couponID);

        //CUSTOMER
        Task<List<Customer>> GetAllCustomers();
        Task<bool> EditCustomer(Customer editedCustomer);
        Task<bool> CreateCustomer(Customer newCustomer);
        Task<Customer> GetSpecificCustomer(string username);
        Task<bool> DeleteCustomer(string username);

        //DRINKS
        Task<List<Drink>> GetBarDrinkList(string id);
        Task<bool> EditDrink(Drink editedDrink, string id);
        Task<bool> CreateDrink(Drink newDrink, string id);
        Task<bool> DeleteDrink(string barId, string drinkId);

        //EVENTS
        Task<List<BarEvent>> GetBarEventList(string id);
        Task<bool> EditEvent(BarEvent editedEvent, string id);
        Task<bool> CreateEvent(BarEvent newEvent, string id);
        Task<bool> DeleteEvent(string barId, string eventId);

        //REVIEWS
        Task<List<Review>> GetBarReviewList(string id);
        Task<bool> EditReview(Review editedReview);
        Task<bool> CreateReview(Review newReview);
        Task<Review> GetSpecificBarReview(string barId, string username);
        Task<bool> DeleteReview(string barId, string username);

        //IDENTITY
        Task<bool> RegisterAsync(RegisterDTO model);
        Task<string> LoginAsync(LoginDTO model);
    }
}

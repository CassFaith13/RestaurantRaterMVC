using RestaurantRaterMVC.Models.RatingModels;

namespace RestaurantRaterMVC.Services.RatingServices
{
    public interface IRatingService
    {
        Task<List<RatingListItem>> GetAllRatings();
        Task<List<RatingListItem>> GetRestaurantRating(int id);
        public Task<bool> CreateRating(RatingCreate model);
    }
}
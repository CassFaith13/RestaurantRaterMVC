using Microsoft.EntityFrameworkCore;
using RestaurantRaterMVC.Data;
using RestaurantRaterMVC.Models.RatingModels;

namespace RestaurantRaterMVC.Services.RatingServices
{
    public class RatingService : IRatingService
    {
        private RestaurantDbContext _context;
        public RatingService(RestaurantDbContext context)
        {
            _context = context;
        }
        public async Task<List<RatingListItem>> GetAllRatings()
        {
            List<RatingListItem> ratings = await _context.Ratings
            .Select(r => new RatingListItem()
            {
                Id = r.Id,
                RestaurantName = r.Restaurant.Name,
                Score = r.Score,
                FoodScore = r.FoodScore,
                AtmosphereScore = r.AtmosphereScore,
                CleanlinessScore = r.CleanlinessScore,                        
            }).ToListAsync();

            return ratings;
        }
        public async Task<List<RatingListItem>> GetRestaurantRating(int id)
        {
            List<RatingListItem> ratings = await _context.Ratings
            .Where(r => r.RestaurantId == id)
            .Select(r => new RatingListItem()
            {
                Id = r.Id,
                RestaurantName = r.Restaurant.Name,
                FoodScore = r.FoodScore,
                CleanlinessScore = r.CleanlinessScore,
                AtmosphereScore = r.AtmosphereScore,
                Score = r.Score,                               
            }).ToListAsync();

            return ratings;
        }
        public async Task<bool> CreateRating(RatingCreate model)
        {
            Rating rating = new Rating()
            {
                RestaurantId = model.RestaurantId,
                FoodScore = model.FoodScore,
                CleanlinessScore = model.CleanlinessScore,
                AtmosphereScore = model.AtmosphereScore,
            };

            _context.Ratings.Add(rating);

            return await _context.SaveChangesAsync() == 1;
        }
    }
}
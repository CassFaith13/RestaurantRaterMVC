using System.ComponentModel.DataAnnotations;

namespace RestaurantRaterMVC.Models.RatingModels
{
    public class RatingListItem
    {
        [Display(Name = "Restaurant ID")]
        public int Id { get; set; }
        [Display(Name = "Restaurant")]
        public string? RestaurantName { get; set; }
        [Display(Name = "Food Score")]
        public double FoodScore { get; set; }
        [Display(Name = "Cleanliness Score")]
        public double CleanlinessScore { get; set; }
        [Display(Name = "Atmosphere Score")]
        public double AtmosphereScore { get; set; }
        [Display(Name = "Rating")]
        public double Score { get; set; }
    }
}
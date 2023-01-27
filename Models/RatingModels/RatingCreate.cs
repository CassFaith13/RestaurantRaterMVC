using System.ComponentModel.DataAnnotations;

namespace RestaurantRaterMVC.Models.RatingModels
{
    public class RatingCreate
    {
        [Required]
        [Display(Name = "Restaurant")]
        public int RestaurantId { get; set; }
        [Required]
        [Range(1,5)]
        public double FoodScore { get; set; }
        [Required]
        [Range(1,5)]
        public double CleanlinessScore { get; set; }
        [Required]
        [Range(1,5)]
        public double AtmosphereScore { get; set; }
    }
}
namespace RestaurantRaterMVC.Data
{
    public class Rating
    {
        public int Id { get; set; }
        public int RestaurantId { get; set; }
        public int Score { get; set; }
        public double FoodScore { get; set; }
        public double CleanlinessScore { get; set; }
        public double AtmosphereScore { get; set; }
        public virtual Restaurant? Restaurant { get; set; }
    }
}
using Microsoft.AspNetCore.Mvc;
using RestaurantRaterMVC.Data;
using RestaurantRaterMVC.Models.RatingModels;
using RestaurantRaterMVC.Services.RatingServices;

namespace RestaurantRaterMVC.Controllers
{
    public class RatingController : Controller
    {
        private IRatingService _service;
        public RatingController(IRatingService service)
        {
            _service = service;
        }
        public async Task<IActionResult> Create(RatingCreate model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            bool isRated = await _service.CreateRating(model);

            if (!isRated)
            {
                return View(model);
            }
            return RedirectToAction(nameof(Restaurant), new {id = model.RestaurantId});
        }
        public async Task<IActionResult> Index()
        {
            var ratings = await _service.GetAllRatings();

            return View(ratings);
        }
        public async Task<IActionResult> Restaurant(int id)
        {
            var ratings = await _service.GetRestaurantRating(id);

            return View(ratings);
        }
    }
}
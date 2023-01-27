using Microsoft.AspNetCore.Mvc;
using RestaurantRaterMVC.Data;
using RestaurantRaterMVC.Models.RestaurantModels;
using RestaurantRaterMVC.Services.RestaurantServices;

    public class RestaurantController : Controller
    {
        private IRestaurantService _service;
        public RestaurantController(IRestaurantService service)
        {
            _service = service;
        }
        // Create
        [HttpPost]
        public async Task<IActionResult> Create(RestaurantCreate model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            await _service.CreateRestaurant(model);

            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public async Task<IActionResult> Index() 
        {
            List<RestaurantListItem> restaurants = await _service.GetAllRestaurants();

            return View(restaurants);
        }
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [ActionName("Details")]
        public async Task<IActionResult> Restaurant(int id)
        {
            var restaurant = await _service.GetRestaurantsById(id);

            if (restaurant == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(restaurant);
        }
        public async Task<IActionResult> Edit(int id, RestaurantEdit model)
        {
            if (!ModelState.IsValid)
            {
                return View(ModelState);
            }

            bool hasUpdated = await _service.UpdateRestaurant(model);

            if (!hasUpdated)
            {
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction("Details", new { id = model.Id });
        }
        public async Task<IActionResult> Delete(int id, RestaurantDetail model)
        {
            bool wasDeleted = await _service.DeleteRestaurant(id);

            if (!wasDeleted)
            {
                return View(model);
            }
            return RedirectToAction(nameof(Index));
        }
    }
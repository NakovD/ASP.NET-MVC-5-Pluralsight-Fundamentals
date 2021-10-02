using OdeToFood.Data.Models;
using OdeToFood.Data.Services;
using System;
using System.Web.Mvc;

namespace OddToFood.Web.Controllers
{
    public class RestaurantsController : Controller
    {
        private readonly IRestaurantData db;
        public RestaurantsController(IRestaurantData db)
        {
            this.db = db;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var model = db.GetAll();
            return View(model);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var model = db.GetRestaurantById(id);

            if (model == null)
            {
                return View("NotFound");
            }

            return View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Create(Restaurant restaurant)
        {
            if (ModelState.IsValid)
            {
                db.AddRestaurant(restaurant);
                return RedirectToAction("Details", new { id = restaurant.Id });
            }

            return View();

        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var viewModel = db.GetRestaurantById(id);

            if (viewModel == null)
            {
                return View("NotFound");
            }

            return View(viewModel);
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Edit(Restaurant restaurant)
        {
            if (ModelState.IsValid)
            {
                db.ChangeRestaurantData(restaurant);
                return RedirectToAction("Details", new { Id = restaurant.Id });
            }

            return View(restaurant);
        }

        public ActionResult Delete(int id)
        {
            var isRestaurantDeleted = db.DeleteRestaurant(id);
            if (isRestaurantDeleted)
            {
                return RedirectToAction("Index");
            }
            return View("NotFound");
        }
    }
}
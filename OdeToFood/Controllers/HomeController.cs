using AspNetCore.Unobtrusive.Ajax;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OdeToFood.Data;
using OdeToFood.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace OdeToFood.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _db;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext dbContext)
        {
            _logger = logger;
            _db = dbContext;
        }

        public ActionResult Autocomplete(string term)
        {
            var model = _db.Restaurants.Where(r => r.Name.StartsWith(term)).Take(10).Select(r => new
            {
                label = r.Name
            });
            return Json(model);
        }

        public IActionResult Index(string searchTerm = null, int page = 1)
        {
            var model = _db.Restaurants.OrderByDescending(r => r.Review.Average(review => review.Rating))
            .Where(r => searchTerm == null || r.Name.Contains(searchTerm))
            .Select(r => new RestaurantListViewModel
            {
            Id = r.Id,
            Name = r.Name,
            City = r.City,
            Country = r.Country,
            CountOfReviews = r.Review.Count
            }).ToPagedList(page, 10);

            if (Request.IsAjaxRequest())
            {
                return PartialView("_Restaurants", model);
            }

            return View(model);
        }

        public IActionResult About()
        {
            var model = new AboutModel()
            {
                Name = "Sten Christjan Uesson",
                Location = "Tallinn"
            };
            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}

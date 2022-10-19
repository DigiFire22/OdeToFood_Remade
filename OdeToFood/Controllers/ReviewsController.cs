using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OdeToFood.Data;
using OdeToFood.Models;
using OdeToFood.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OdeToFood.Controllers
{
    public class ReviewsController : Controller
    {
        private readonly ApplicationDbContext _context;
       public ReviewsController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: ReviewsController
        public async Task<IActionResult> Index([Bind(Prefix = "id")] int restaurantId)
        {
            var restaurant = await _context.Restaurants
                .Include(r => r.Review)
                .FirstOrDefaultAsync(m => m.Id == restaurantId);
            if (restaurant == null)
            {
                return NotFound();
            }

            return View(restaurant);
        }
        [HttpGet]
        public ActionResult Create(int restaurantId)
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(RestarauntReview review)
        {
            if (ModelState.IsValid)
            {
                _context.Reviews.Add(review);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index), new { Id = review.RestaurantId });
            }
            return View(review);
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var model = _context.Reviews.Find(id);
            return View(model);
        }

		public async Task<IActionResult> Edit(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var review = await _context.RestarauntReview.FindAsync(id);
			if (review == null)
			{
				return NotFound();
			}
			return View(review);
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(int id, ReviewViewModel review)
		{
			if (id != review.Id)
			{
				return NotFound();
			}

			if (ModelState.IsValid)
			{
				try
				{
					var currentReview = await _context.RestarauntReview.FindAsync(id);
					currentReview.Body = review.Body;
					currentReview.Rating = review.Rating;
					_context.Entry(currentReview).State = EntityState.Modified;
					//_context.Update(review);
					await _context.SaveChangesAsync();
				}
				catch (DbUpdateConcurrencyException)
				{
					if (!_context.RestarauntReview.Any(r => r.Id == id))
					{
						return NotFound();
					}
					else
					{
						throw;
					}
				}
				return RedirectToAction(nameof(Index), new { id = review.RestaurantId });
			}
			return View(review);
		}
	}
}

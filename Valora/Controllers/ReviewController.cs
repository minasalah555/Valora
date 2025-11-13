using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Valora.Services;
using Valora.ViewModels;

namespace Valora.Controllers
{
    public class ReviewController : Controller
    {
        private readonly ReviewService _reviewService;

        public ReviewController(ReviewService reviewService)
        {
            _reviewService = reviewService;
        }

        // GET: Review/ProductReviews/5
        public async Task<IActionResult> ProductReviews(int id)
        {
            try
            {
                var reviews = await _reviewService.GetProductReviews(id);
                var averageRating = await _reviewService.GetProductAverageRating(id);
                var reviewCount = await _reviewService.GetProductReviewCount(id);

                ViewBag.ProductId = id;
                ViewBag.AverageRating = averageRating;
                ViewBag.ReviewCount = reviewCount;

                return View(reviews);
            }
            catch (Exception ex)
            {
                TempData["Error"] = $"Error loading reviews: {ex.Message}";
                return View(new List<DTOs.ReviewDTO>());
            }
        }

        // GET: Review/MyReviews
        [Authorize]
        public async Task<IActionResult> MyReviews()
        {
            try
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                if (string.IsNullOrEmpty(userId))
                {
                    return RedirectToAction("Login", "Account");
                }

                var reviews = await _reviewService.GetUserReviews(userId);
                return View(reviews);
            }
            catch (Exception ex)
            {
                TempData["Error"] = $"Error loading your reviews: {ex.Message}";
                return View(new List<DTOs.ReviewDTO>());
            }
        }

        // GET: Review/Create
        [Authorize]
        public IActionResult Create(int productId)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrEmpty(userId))
            {
                return RedirectToAction("Login", "Account");
            }

            var model = new CreateReviewViewModel
            {
                ProductId = productId,
                UserId = userId
            };

            return View(model);
        }

        // POST: Review/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Create(CreateReviewViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }

                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                if (string.IsNullOrEmpty(userId))
                {
                    return RedirectToAction("Login", "Account");
                }

                model.UserId = userId;
                var review = await _reviewService.CreateReview(model);

                TempData["Success"] = "Review submitted successfully!";
                return RedirectToAction(nameof(ProductReviews), new { id = model.ProductId });
            }
            catch (Exception ex)
            {
                TempData["Error"] = $"Error creating review: {ex.Message}";
                return View(model);
            }
        }

        // GET: Review/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                var review = await _reviewService.GetReviewDetails(id);
                if (review == null)
                {
                    TempData["Error"] = "Review not found";
                    return RedirectToAction(nameof(MyReviews));
                }

                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                if (review.UserId != userId && !User.IsInRole("Admin"))
                {
                    TempData["Error"] = "You don't have permission to edit this review";
                    return RedirectToAction(nameof(MyReviews));
                }

                var model = new UpdateReviewViewModel
                {
                    ReviewId = review.ReviewId,
                    Rating = review.Rating,
                    Title = review.Title,
                    Comment = review.Comment
                };

                return View(model);
            }
            catch (Exception ex)
            {
                TempData["Error"] = $"Error loading review: {ex.Message}";
                return RedirectToAction(nameof(MyReviews));
            }
        }

        // POST: Review/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Edit(UpdateReviewViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }

                var result = await _reviewService.UpdateReview(model);
                if (result)
                {
                    TempData["Success"] = "Review updated successfully";
                    return RedirectToAction(nameof(MyReviews));
                }
                else
                {
                    TempData["Error"] = "Failed to update review";
                    return View(model);
                }
            }
            catch (Exception ex)
            {
                TempData["Error"] = $"Error updating review: {ex.Message}";
                return View(model);
            }
        }

        // GET: Review/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var review = await _reviewService.GetReviewDetails(id);
                if (review == null)
                {
                    TempData["Error"] = "Review not found";
                    return RedirectToAction(nameof(MyReviews));
                }

                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                if (review.UserId != userId && !User.IsInRole("Admin"))
                {
                    TempData["Error"] = "You don't have permission to delete this review";
                    return RedirectToAction(nameof(MyReviews));
                }

                return View(review);
            }
            catch (Exception ex)
            {
                TempData["Error"] = $"Error loading review: {ex.Message}";
                return RedirectToAction(nameof(MyReviews));
            }
        }

        // POST: Review/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                var result = await _reviewService.DeleteReview(id);
                if (result)
                {
                    TempData["Success"] = "Review deleted successfully";
                }
                else
                {
                    TempData["Error"] = "Failed to delete review";
                }

                return RedirectToAction(nameof(MyReviews));
            }
            catch (Exception ex)
            {
                TempData["Error"] = $"Error deleting review: {ex.Message}";
                return RedirectToAction(nameof(MyReviews));
            }
        }
    }
}

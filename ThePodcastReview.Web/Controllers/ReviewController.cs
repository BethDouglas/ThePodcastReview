using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using ThePodcastReview.Contracts;
using ThePodcastReview.Models;
using ThePodcastReview.Services;

namespace ThePodcastReview.Web.Controllers
{
    public class ReviewController : Controller
    {
        private readonly Lazy<IReviewService> _reviewService;

        private readonly ReviewService _reviewServiceNoGuid;

        public ReviewController()
        {
            _reviewService = new Lazy<IReviewService>(() =>
                new ReviewService(Guid.Parse(User.Identity.GetUserId())));
            _reviewServiceNoGuid = new ReviewService();
        }

        public ReviewController(Lazy<IReviewService> reviewService)
        {
            _reviewService = reviewService;
        }

        // GET: Review
        public ActionResult Index()
        {
            var model = _reviewService.Value.GetReviews();

            return View(model);
        }

        public ActionResult ViewAll()
        {
            var model = _reviewServiceNoGuid.GetAllReviews();

            return View(model);
        }

        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ReviewCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            if (_reviewService.Value.CreateReview(model))
            {
                TempData["SaveResult"] = "Your review was created, thank you.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Review could not be created.");

            return View(model);

        }

        public ActionResult Details(int id)
        {
            var model = _reviewServiceNoGuid.GetReviewById(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var detail = _reviewService.Value.GetReviewById(id);
            var model =
                new ReviewEdit
                {
                    ReviewId = detail.ReviewId,
                    PodcastTitle = detail.PodcastTitle,
                    //Episode = detail.Episode,
                    Rating = detail.Rating,
                    Content = detail.Content,
                    FavEpisodes = detail.FavEpisodes,

                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ReviewEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if(model.ReviewId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            if(_reviewService.Value.UpdateReview(model))
            {
                TempData["SaveResult"] = "Your review was updated";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your review could not be updated.");
            return View(model);
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var model = _reviewService.Value.GetReviewById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {

            _reviewService.Value.DeleteReview(id);

            TempData["SaveResult"] = "Your review was deleted";

            return RedirectToAction("Index");
        }
    }
}
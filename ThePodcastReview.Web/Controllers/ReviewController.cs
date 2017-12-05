using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ThePodcastReview.Models;

namespace ThePodcastReview.Web.Controllers
{
    public class ReviewController : Controller
    {
        // GET: Review
        public ActionResult Index()
        {
            var model = new ReviewListItem[0];
            return View(model);
        }
    }
}
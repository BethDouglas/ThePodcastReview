using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ThePodcastReview.Models;
using ThePodcastReview.Services;

namespace ThePodcastReview.Web.Tests.Controllers.ReviewControllerTests
{
    [TestClass]
    public class CreatePost : ReviewControllerTestsBase
    {
        private ReviewCreate _model;

        private ActionResult Act()
        {
            return Controller.Create(_model);
        }

        [TestMethod]
        public void ShouldReturnRedirctToRouteResult()
        {
            var result = Controller.Create(new ReviewCreate());

            Assert.IsInstanceOfType(result, typeof(RedirectToRouteResult));
        }

        [TestMethod]
        public void ShouldCallCreateOnce()
        {
            var result = Controller.Create(new ReviewCreate());

            Assert.AreEqual(1, Service.CreateReviewCallCount);

        }
    }
}

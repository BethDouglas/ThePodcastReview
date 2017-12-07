using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ThePodcastReview.Contracts;
using ThePodcastReview.Web.Controllers;

namespace ThePodcastReview.Web.Tests.Controllers.ReviewControllerTests
{
    [TestClass]
    public abstract class ReviewControllerTestsBase
    {
        protected ReviewController Controller;

        protected FakeReviewService Service;

        [TestInitialize]
        public virtual void Arrange()
        {
            Service = new FakeReviewService();

            Controller = new ReviewController(
                new Lazy<IReviewService>(() => Service));
        }

    }
}

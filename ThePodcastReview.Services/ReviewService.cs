using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThePodcastReview.Data;
using ThePodcastReview.Models;

namespace ThePodcastReview.Services
{
    public class ReviewService
    {

        private readonly Guid _userId;

        //This makes the user Id available to us in all methods.
        //When we create a new instance of the ReviewService, we need to give it a userId.
        public ReviewService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateReview(ReviewCreate model)
        {
            var entity =
                new Review()
                {
                    OwnerId = _userId,
                    PodcastTitle = model.PodcastTitle,
                    Episode = model.Episode,
                    Rating = model.Rating,
                    Content = model.Content,
                    FavEpisodes = model.FavEpisodes,
                    CreatedUtc = DateTimeOffset.Now
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Reviews.Add(entity);
                return ctx.SaveChanges() == 1;
            }

        }

        public IEnumerable<ReviewListItem> GetReviews()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Reviews
                        .Where(e => e.OwnerId == _userId)
                        .Select(
                            e =>
                                new ReviewListItem
                                {
                                    ReviewId = e.ReviewId,
                                    PodcastTitle = e.PodcastTitle,
                                    Rating = e.Rating,
                                    CreatedUtc = e.CreatedUtc
                                }
                        );
                return query.ToArray();
            }
        }
    }
}

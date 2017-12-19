using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThePodcastReview.Contracts;
using ThePodcastReview.Data;
using ThePodcastReview.Models;

namespace ThePodcastReview.Services
{
    public class ReviewService : IReviewService
    {

        private readonly Guid _userId;

        public ReviewService()
        {
                
        }

        public ReviewService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateReview(ReviewCreate model)
        {
            var entity =
                new Review
                {
                    OwnerId = _userId,
                    PodcastTitle = model.PodcastTitle,
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
                                    Content= e.Content,
                                    Rating = e.Rating,
                                    CreatedUtc = e.CreatedUtc
                                }
                        );
                return query.ToArray();
            }
        }

        public IEnumerable<ReviewListAllItem> GetAllReviews()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Reviews
                        .Select(
                            e =>
                                new ReviewListAllItem
                                {
                                    ReviewId = e.ReviewId,
                                    UserId = e.OwnerId,
                                    PodcastTitle = e.PodcastTitle,
                                    Content = e.Content,
                                    Rating = e.Rating,
                                    CreatedUtc = e.CreatedUtc
                                }
                        );
                return query.ToArray();
            }
        }

        public ReviewDetail GetReviewById(int reviewId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Reviews
                        .Single(e => e.ReviewId == reviewId);
                return
                    new ReviewDetail
                    {
                        ReviewId = entity.ReviewId,
                        UserId = entity.OwnerId,
                        PodcastTitle = entity.PodcastTitle,
                        Rating = entity.Rating,
                        Content = entity.Content,
                        FavEpisodes = entity.FavEpisodes,
                        CreatedUtc = entity.CreatedUtc,
                        ModifiedUtc = entity.ModifiedUtc

                    };
            }
        }

        public bool UpdateReview(ReviewEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Reviews
                        .Single(e => e.ReviewId == model.ReviewId && e.OwnerId == _userId);

                entity.PodcastTitle = model.PodcastTitle;  
                entity.Rating = model.Rating;
                entity.Content = model.Content;
                entity.FavEpisodes = model.FavEpisodes;
                entity.ModifiedUtc = DateTimeOffset.UtcNow;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteReview(int reviewId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Reviews
                        .Single(e => e.ReviewId == reviewId && e.OwnerId == _userId);

                ctx.Reviews.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}

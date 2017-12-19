using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThePodcastReview.Models;

namespace ThePodcastReview.Contracts
{
    public interface IReviewService
    {
        bool CreateReview(ReviewCreate model);
        ICollection<ReviewListItem> GetReviews(int reviewId);
        IEnumerable<ReviewListAllItem> GetAllReviews();
        ReviewDetail GetReviewById(int reviewId);
        bool UpdateReview(ReviewEdit model);
        bool DeleteReview(int reviewId);
    }
}

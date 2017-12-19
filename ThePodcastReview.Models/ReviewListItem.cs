using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThePodcastReview.Models
{
    public class ReviewListItem
    {
        public int ReviewId { get; set; }

        public Guid UserId { get; set; }

        public string UserName { get; set; }

        [Display(Name = "Podcast")]
        public string PodcastTitle { get; set; }

        public int Rating { get; set; }

        //[DisplayLength?
        //public string Content { get; set; }

        [Display(Name = "Created")]
        public DateTimeOffset CreatedUtc { get; set; }

        public override string ToString() => PodcastTitle;
    }
}

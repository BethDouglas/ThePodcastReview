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

        [Display(Name = "Podcast")]
        public string PodcastTitle { get; set; }


        [MaxLength(5)]
        [Display(Name = "Review")]
        public string Content { get; set; }

        public int Rating { get; set; }

        [Display(Name = "Created")]
        public DateTimeOffset CreatedUtc { get; set; }

        public override string ToString() => PodcastTitle;
    }
}

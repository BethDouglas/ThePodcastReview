using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThePodcastReview.Models
{
    public class ReviewListAllItem
    {
        public int ReviewId { get; set; }

        [Display(Name = "Podcast")]
        public string PodcastTitle { get; set; }

        [Display(Name = "Review")]
        public string Content { get; set; }

        private int ContentLimit = 100;

        public string ContentTrimmed
        {
            get
            {
                if (this.Content.Length > this.ContentLimit)
                    return this.Content.Substring(0, this.ContentLimit) + "...";
                else
                    return this.Content;
            }

        }

        public int Rating { get; set; }

        //[DisplayLength?
        //public string Content { get; set; }

        //public string Reviewer { get; set; }

        [Display(Name = "Created")]
        public DateTimeOffset CreatedUtc { get; set; }
        public Guid UserId { get; set; }

        public override string ToString() => PodcastTitle;
    }
}

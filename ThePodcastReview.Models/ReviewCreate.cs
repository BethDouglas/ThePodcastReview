using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThePodcastReview.Models
{
    public class ReviewCreate
    {
        [Required]
        [Display(Name = "Podcast")]
        public string PodcastTitle { get; set; }

        [Display(Name = "Episode")]
        public string Episode { get; set; }

        [Required]
        public int Rating { get; set; }

        [Display(Name = "Review")]
        public string Content { get; set; }

        [Display(Name = "Favorite Episodes")]
        public string FavEpisodes { get; set; }

        public override string ToString() => PodcastTitle;
    }
}

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
        public string PodcastTitle { get; set; }

        public string Episode { get; set; }

        [Required]
        public int Rating { get; set; }

        public string Content { get; set; }

        public string FavEpisodes { get; set; }

        public override string ToString() => PodcastTitle;
    }
}

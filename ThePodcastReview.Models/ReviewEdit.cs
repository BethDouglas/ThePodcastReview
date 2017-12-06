using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThePodcastReview.Models
{
    public class ReviewEdit
    {
        public int ReviewId { get; set; }
        public string PodcastTitle { get; set; }
        public string Episode { get; set; }
        public int Rating { get; set; }
        public string Content { get; set; }
        public string FavEpisodes { get; set; }
    }
}

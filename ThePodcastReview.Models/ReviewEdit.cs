using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThePodcastReview.Models
{
    public class ReviewEdit
    {
        public int ReviewId { get; set; }

        [Required]
        [Display(Name = "Podcast*")]
        public string PodcastTitle { get; set; }

        [Required]
        [Display(Name = "Rating*")]
        [Range(1, 5, ErrorMessage = "Rating must be between 1 and 5")]
        public int Rating { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Review*")]
        public string Content { get; set; }

        [Display(Name = "Favorite Episodes")]
        [DataType(DataType.MultilineText)]
        public string FavEpisodes { get; set; }
    }
}

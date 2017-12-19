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
        [Display(Name = "Podcast*")]
        public string PodcastTitle { get; set; }

        //[Display(Name = "Episode")]
        //public string Episode { get; set; }

        [Required]
        [Display(Name = "Rating*")]        
        [Range(1, 5, ErrorMessage = "Rating must be between 1 and 5")]
        public int Rating { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Review*")]
        public string Content { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(Name = "Favorite Episodes")]
        public string FavEpisodes { get; set; }

        public override string ToString() => PodcastTitle;
    }
}

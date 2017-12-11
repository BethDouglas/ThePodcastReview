using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThePodcastReview.Data
{

    public class Review
    {
        [Key]
        public int ReviewId { get; set; }

        [Required]
        public Guid OwnerId { get; set; }

        [Required]
        [MaxLength(200)]
        public string PodcastTitle { get; set; }

        [MaxLength(200)]
        public string Episode { get; set; }

        [Range(1,5, ErrorMessage ="Rating must be between 1 and 5")]
        public int Rating { get; set; }

        [Required]
        [MaxLength(2000)]
        public string Content { get; set; }

        //public string Reviewer { get; set; }

        public string FavEpisodes { get; set; }

        [Required]
        public DateTimeOffset CreatedUtc { get; set; }

        public DateTimeOffset? ModifiedUtc { get; set; }
    }
}

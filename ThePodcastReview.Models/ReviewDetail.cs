﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThePodcastReview.Models
{
    public class ReviewDetail
    {
        public int ReviewId { get; set; }
        [Display(Name = "Podcast")]
        public string PodcastTitle { get; set; }

        public string Episode { get; set; }
        public int Rating { get; set; }
        public string Content { get; set; }

        [Display(Name ="Favorite Episodes")]
        public string FavEpisodes { get; set; }

        [Display(Name ="Created")]
        public DateTimeOffset CreatedUtc { get; set; }
        public DateTimeOffset? ModifiedUtc { get; set; }
        public override string ToString() => $"[{ReviewId}] {PodcastTitle}";
    }
}
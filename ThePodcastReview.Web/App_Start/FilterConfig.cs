﻿using System.Web;
using System.Web.Mvc;

namespace ThePodcastReview.Web
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
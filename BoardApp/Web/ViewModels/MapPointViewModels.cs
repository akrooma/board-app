﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain;

namespace Web.ViewModels
{
    public class MapPointCreateViewModel
    {
        public MapPoint MapPoint { get; set; }
        public SelectList RouteSelectList { get; set; }
    }

    public class MapPointEditViewModel : MapPointCreateViewModel
    {
    }
}
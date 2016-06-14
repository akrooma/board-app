using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain;

namespace Web.ViewModels
{
    public class RouteCommentCreateViewModel
    {
        public RouteComment RouteComment { get; set; }
        public SelectList RouteSelectList { get; set; }
    }

    public class RouteCommentEditViewModel : RouteCommentCreateViewModel
    {
        
    }
}
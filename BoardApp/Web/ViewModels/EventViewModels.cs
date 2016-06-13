using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain;

namespace Web.ViewModels
{
    public class EventCreateViewModel
    {
        public Event Event { get; set; }
        public List<int> PlannedRouteIds { get; set; }
        public MultiSelectList RouteSelectList { get; set; }
    }
}
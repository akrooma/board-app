using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain;

namespace Web.ViewModels
{
    public class RouteCreateViewModel
    {
        public Route Route { get; set; }
        public int[] CharacteristicIds { get; set; }
        public MultiSelectList RouteCharacteristicSelectList { get; set; }
    }

    public class RouteDetailsViewModel
    {
        public Route Route { get; set; }
        public List<RouteAndCharacteristic> Characteristics { get; set; }
        public List<RouteComment> Comments { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain;

namespace Web.ViewModels
{
    public class RouteAndCharacteristicCreateViewModel
    {
        public RouteAndCharacteristic RouteAndCharacteristic { get; set; }
        public SelectList RouteSelectList { get; set; }
        public SelectList RouteCharacteristicSelectList { get; set; }
    }

    public class RouteAndCharacteristicEditViewModel : RouteAndCharacteristicCreateViewModel
    {
        
    }
}
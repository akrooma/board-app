using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain;

namespace Web.ViewModels
{
	public class TransportItemCreateViewModel
	{
		public TransportItem TransportItem { get; set; }
		public SelectList TransportItemTypeSelectList { get; set; }
	}

	public class TransportItemEditViewModel : TransportItemCreateViewModel
	{
		
	}
}
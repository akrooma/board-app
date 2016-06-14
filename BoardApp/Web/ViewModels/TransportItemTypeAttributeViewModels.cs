using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain;

namespace Web.ViewModels
{
	public class TransportItemTypeAttributeCreateViewModel
	{
		public TransportItemTypeAttribute TransportItemTypeAttribute { get; set; }
		public SelectList TransportItemTypeSelectList { get; set; }
	}

	public class TransportItemTypeAttributeEditViewModel : TransportItemTypeAttributeCreateViewModel
	{
		
	}
}
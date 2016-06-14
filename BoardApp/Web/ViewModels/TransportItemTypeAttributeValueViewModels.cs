using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain;

namespace Web.ViewModels
{
	public class TransportItemTypeAttributeValueCreateViewModel
	{
		public TransportItemTypeAttributeValue TransportItemTypeAttributeValue { get; set; }
		public SelectList TransportItemTypeAttributeSelectList { get; set; }
	}

	public class TransportItemTypeAttributeValueEditViewModel : TransportItemTypeAttributeValueCreateViewModel
	{
		
	}
}
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
		public MultiSelectList TransportItemTypeAttributes { get; set; }
		public MultiSelectList TransportItemTypeAttributeValues { get; set; }
		public List<int> SelectedAttributeValueIds { get; set; }
		public List<TransportItemAndAttributeValue> AttributeValues { get; set; }
	}

	public class TransportItemDetailsViewModel
	{
		public TransportItem TransportItem { get; set; }
		public List<TransportItemAndAttributeValue> AttributeValues { get; set; }
	}
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
	public class TransportItemAndAttributeValue
	{
		public int TransportItemAndAttributeValueId { get; set; }

		public int TransportItemId { get; set; }
		public virtual TransportItem TransportItem { get; set; }
		
		public int TransportItemTypeAttributeValueId { get; set; }
		public virtual TransportItemTypeAttributeValue TransportItemTypeAttributeValue { get; set; }
	}
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Event
    {
        public int EventId { get; set; }

        [Required(ErrorMessageResourceName = "FieldIsRequired", ErrorMessageResourceType = typeof(Resources.Common))]
        [MinLength(1, ErrorMessageResourceName = "FieldMinLength", ErrorMessageResourceType = typeof(Resources.Common))]
        [MaxLength(128, ErrorMessageResourceName = "FieldMaxLength", ErrorMessageResourceType = typeof(Resources.Common))]
        [Display(Name = nameof(Resources.Domain.FirstName), ResourceType = typeof(Resources.Domain))]
        public string EventName { get; set; }

        [DataType(DataType.Date)]
        public DateTime EventCreationDate { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime EventStartDate { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime EventEndDate { get; set; }

        [MaxLength(1000)]
        public string EventDescription { get; set; }

        public virtual List<RouteInEvent> RoutesInEvent { get; set; } = new List<RouteInEvent>(); 

        // Picture?

        //public int UserAccountId { get; set; }
        //public UserAccount EventCreator { get; set; }
        //Invite list
    }
}

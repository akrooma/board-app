using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class RouteComment
    {
        public int RouteCommentId { get; set; }

        [MinLength(1)]
        [MaxLength(400)]
        public string Content { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime? UpdateTime { get; set; }

        [DataType(DataType.Date)]
        public DateTime PostingDate { get; set; }

        [DataType(DataType.Time)]
        public DateTime PostingTime { get; set; }

        /*
        [Display(Name = nameof(Resources.Domain.Person_DateTime2), ResourceType = typeof(Resources.Domain))]
        [DataType(DataType.DateTime, ErrorMessageResourceName = "FieldMustBeDataTypeDateTime", ErrorMessageResourceType = typeof(Resources.Common))]
        [Required(ErrorMessageResourceName = "FieldIsRequired", ErrorMessageResourceType = typeof(Resources.Common))]
        public DateTime DateTime2 { get; set; }

        [Display(Name = nameof(Resources.Domain.Person_Date2), ResourceType = typeof(Resources.Domain))]
        [DataType(DataType.Date, ErrorMessageResourceName = "FieldMustBeDataTypeDate", ErrorMessageResourceType = typeof(Resources.Common))]
        [Required(ErrorMessageResourceName = "FieldIsRequired", ErrorMessageResourceType = typeof(Resources.Common))]
        public DateTime Date2 { get; set; }

        [Display(Name = nameof(Resources.Domain.Person_Time2), ResourceType = typeof(Resources.Domain))]
        [DataType(DataType.Time, ErrorMessageResourceName = "FieldMustBeDataTypeTime", ErrorMessageResourceType = typeof(Resources.Common), ErrorMessage = null)]
        [Required(ErrorMessageResourceName = "FieldIsRequired", ErrorMessageResourceType = typeof(Resources.Common))]
        public DateTime Time2 { get; set; }
        */

        public int RouteId { get; set; }
        public virtual Route Route { get; set; }

        /*
        public int OwnerId { get; set; }
        public UserAccount Owner { get; set; }
        */
    }
}

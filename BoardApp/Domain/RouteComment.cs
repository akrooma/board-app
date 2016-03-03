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

        [MaxLength(300)]
        public string RouteCommentContent { get; set; }
        public DateTime PostDate { get; set; }
        public DateTime? UpdateDate { get; set; }

        public int OwnerId { get; set; }
        public UserAccount Owner { get; set; }

        public int RouteId { get; set; }
        public virtual Route Route { get; set; }
    }
}

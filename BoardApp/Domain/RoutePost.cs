using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class RoutePost
    {
        public int RoutePostId { get; set; }
        public string RoutePostContent { get; set; }

        public int PosterId { get; set; }
        public virtual UserAccount Poster { get; set; }

        public virtual List<RoutePost> ChildRoutePosts { get; set; } = new List<RoutePost>();
    }
}

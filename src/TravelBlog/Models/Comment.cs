using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TravelBlog.Models
{
    [Table("Comments")]
    public class Comment
    {
        [Key]
        public int CommentId { get; set; }
        public string Body { get; set; }
        public int LocationId { get; set; }
        public virtual Location Location {get; set;}
        public virtual ApplicationUser User { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TravelBlog.Models
{
    [Table("Suggestions")]
    public class Suggestion
    {
        [Key]
        public int SuggestionId { get; set; }
        public string Body { get; set; }
        public int LocationId { get; set; }
        public virtual Location Location { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}

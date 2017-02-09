using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TravelBlog.Models
{   [Table("People")]
    public class Person
    {   [Key]
        public int PersonId { get; set; }
        public string PersonName { get; set; }
        public string PersonDescription { get; set; }
        public string PersonImage { get; set; }
        public int LocationId { get; set; }
        public int ExperienceId { get; set; }
        public virtual Location Location { get; set; }
        public virtual Experience Experience { get; set; }
    }
}

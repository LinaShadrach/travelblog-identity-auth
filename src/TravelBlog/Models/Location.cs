using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TravelBlog.Models
{   [Table("Locations")]
    public class Location
    {
        public Location()
        {
            this.People = new HashSet<Person>();
        }
        [Key]
        public int LocationId { get; set; }
        public string LocationName { get; set; }
        public string LocationDescription { get; set; }
        public int ExperienceId { get; set; }
        public int PersonId { get; set; }
        public string LocationImage { get; set; }
        public virtual ICollection<Person> People { get; set; }
        public virtual ICollection<Experience> Experiences { get; set; }
    }
}

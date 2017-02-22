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
        public virtual ICollection<Encounter> Encounters { get; set; }
        public virtual ApplicationUser User { get; set; }

    }
}

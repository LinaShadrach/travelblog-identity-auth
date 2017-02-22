using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TravelBlog.Models
{
    [Table("Encounters")]
    public class Encounter
    {
        [Key]
        public int EncounterId { get; set; }
        public int ExperienceId { get; set; }
        public int PersonId { get; set; }
        public virtual Person Person { get; set; }
        public virtual Experience Experience { get; set; }

        public Encounter() { }
        public Encounter(int experienceId, int personId)
        {
            ExperienceId = experienceId;
            PersonId = personId;
        }
       
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace outer_space.Data.Tables
{
    public class Astronaut
    {
        public int AstronautID { get; set; }
        [Display(Name = "First Name")]
        public string AstronautNameFirst { get; set; }
        [Display(Name = "Last Name")]
        public string AstronautNameLast { get; set; }
        public string AstronautNameFull 
        { 
            get { return $"{AstronautNameFirst} {AstronautNameLast}"; } 
        }
        [Display(Name = "Birth Date")]
        public DateTime? AstronautBirthDate { get; set; }
        [Display(Name = "Death Date")]
        public DateTime? AstornautDeathDate { get; set; }

        //Joins
        public List<MissionAstronaut> MissionAstronauts { get; } = new List<MissionAstronaut>();
        //public List<Mission> Missions { get; }
    }
}

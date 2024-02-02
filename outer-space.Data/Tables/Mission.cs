using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace outer_space.Data.Tables
{
    public class Mission
    {
        public int MissionID { get; set; }
        [Display(Name = "Name")]
        public string MissionName { get; set; }
        [Display(Name = "Start Date")]
        public DateTime? MissionDateStart { get; set; }
        [Display(Name = "End Date")]
        public DateTime? MissionDateEnd { get; set; }

        //Joins
        public List<MissionAstronaut> MissionAstronauts { get; } = new List<MissionAstronaut>();
        //public List<Astronaut> Astronauts { get; }
    }
}

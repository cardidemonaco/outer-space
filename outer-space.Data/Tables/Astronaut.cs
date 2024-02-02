using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace outer_space.Data.Tables
{
    public class Astronaut
    {
        public int AstronautID { get; set; }
        public string AstronautNameFirst { get; set; }
        public string AstronautNameLast { get; set; }
        public DateTime? AstronautBirthDate { get; set; }
        public DateTime? AstornautDeathDate { get; set; }

        //Joins
        public List<MissionAstronaut> MissionAstronauts { get; }
        //public List<Mission> Missions { get; }
    }
}

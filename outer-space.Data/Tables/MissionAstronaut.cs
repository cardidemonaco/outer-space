using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace outer_space.Data.Tables
{
    public class MissionAstronaut
    {
        public int MissionID { get; set; }
        public int AstronautID { get; set; }
        public string MissionAstronautRole { get; set; } //What was the astronaut's role on this mission?

        //Joins
        public Mission Mission { get; set; }
        public Astronaut Astronaut { get; set; }
    }
}

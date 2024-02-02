using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace outer_space.Data.Tables
{
    public class Mission
    {
        public int MissionID { get; set; }
        public string MissionName { get; set; }
        public DateTime? MissionDateStart { get; set; }
        public DateTime? MissionDateEnd { get; set; }

        //Joins
        public List<MissionAstronaut> MissionAstronauts { get; }
        //public List<Astronaut> Astronauts { get; }
    }
}

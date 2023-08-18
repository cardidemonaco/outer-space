using System.ComponentModel.DataAnnotations;

namespace outer_space.Data.Tables
{
    public class Galaxy
    {
        public int GalaxyID { get; set; }
        [Display(Name = "Name")]
        public string GalaxyName { get; set; }
        [Display(Name = "Description")]
        public string GalaxyDescription { get; set;}
        [Display(Name = "Diameter in Parsecs")]
        public int GalaxyDiameterInParsecs { get; set; }
    }
}
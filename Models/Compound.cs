using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Balaie_Cristian_Vlad_PROJECT.Models
{
    public class Compound
    {
        public int ID { get; set; }

        public string Name { get; set; }
        public int? MetalID { get; set; }
        public Metal? Metal { get; set; }
        [Display(Name = "Quantity")]

        public int MetalQuantity { get; set; }
        public int? MetalloidID { get; set; }
        public Metalloid? Metalloid { get; set; }
        [Display(Name = "Quantity")]

        public int MetalloidQuantity { get; set; }
        public int? NonMetalID { get; set; }
        public NonMetal? NonMetal { get; set; }
        [Display(Name = "Quantity")]

        public int NonMetalQuantity { get; set; }


    }
}

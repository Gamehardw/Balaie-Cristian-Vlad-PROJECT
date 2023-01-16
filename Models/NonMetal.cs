using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Balaie_Cristian_Vlad_PROJECT.Models
{
    public class NonMetal
    {
        public int ID { get; set; }
        public string NonMetalName { get; set; }
        public int Position { get; set; }
        [Display(Name = "Atomic Mass")]
        public int Valency { get; set; }
        public ICollection<Compound> Compounds { get; set; }
    }
}

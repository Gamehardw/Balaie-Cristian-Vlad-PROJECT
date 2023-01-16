using System.ComponentModel.DataAnnotations;

namespace Balaie_Cristian_Vlad_PROJECT.Models
{
    public class Metalloid
    {
        public int ID { get; set; }
        public string MetalloidName { get; set; }
        public int Position { get; set; }
        [Display(Name ="Atomic Mass")]
        public int Valency { get; set; }

        public ICollection<Compound> Compounds { get; set; }
    }
}

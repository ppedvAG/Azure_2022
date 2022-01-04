using System.ComponentModel.DataAnnotations;

namespace HalloEF.Data.Model
{
    public class Kunde : Person
    {
        [MaxLength(64)]
        public string KdNummer { get; set; }
        public virtual Mitarbeiter Mitarbeiter { get; set; }
    }
}
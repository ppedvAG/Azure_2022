namespace HalloEF.Data.Model
{
    public class Mitarbeiter : Person
    {
        public string Beruf { get; set; }
        public virtual ICollection<Kunde> Kunden { get; set; } = new HashSet<Kunde>();
        public virtual ICollection<Abteilungen> Abteilungen { get; set; } = new HashSet<Abteilungen>();
    }
}
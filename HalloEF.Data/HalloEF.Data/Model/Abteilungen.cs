namespace HalloEF.Data.Model
{
    public class Abteilungen
    {
        public int Id { get; set; }
        public string Bezeichnung { get; set; }
        public virtual ICollection<Mitarbeiter> Mitarbeiter { get; set; } = new HashSet<Mitarbeiter>();

    }
}
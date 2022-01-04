namespace HalloEF.Data.Model
{
    public abstract class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime GebDatum { get; set; }
    }
}
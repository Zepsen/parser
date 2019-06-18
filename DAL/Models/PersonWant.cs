namespace DAL.Models
{
    public class PersonWant
    {
        public string PersonId { get; set; }
        public Person Person { get; set; }
        public int WantId { get; set; }
        public Want Want { get; set; }
    }
}
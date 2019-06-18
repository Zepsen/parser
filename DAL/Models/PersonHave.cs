namespace DAL.Models
{
    public class PersonHave
    {
        public string PersonId { get; set; }
        public Person Person { get; set; }
        public int HaveId { get; set; }
        public Have Have { get; set; }
    }
}
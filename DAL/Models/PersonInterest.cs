namespace DAL.Models
{
    public class PersonInterest
    {
        public string PersonId { get; set; }
        public Person Person { get; set; }
        public int InterestId { get; set; }
        public Interest Interest { get; set; }
    }
}
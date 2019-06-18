namespace DAL.Models
{
    public class Job
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Status { get; set; }
        
        public string PersonId { get; set; }
        public Person Person { get; set; }
    }
}
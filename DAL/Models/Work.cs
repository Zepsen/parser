namespace DAL.Models
{
    public class Work
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Date { get; set; }


        public string PersonId { get; set; }
        public Person Person { get; set; }
    }
}
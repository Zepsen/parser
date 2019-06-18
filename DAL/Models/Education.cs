namespace DAL.Models
{
    public class Education
    {
        public int  Id { get; set; }
        public string School { get; set; }
        public string Date { get; set; }
        public string Notes { get; set; }

        public string PersonId { get; set; }
        public Person Person { get; set; }
    }
}
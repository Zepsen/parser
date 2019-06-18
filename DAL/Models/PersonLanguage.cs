namespace DAL.Models
{
    public class PersonLanguage
    {
        public string PersonId { get; set; }
        public Person Person { get; set; }
        public int LanguageId { get; set; }
        public Language Language { get; set; }
    }
}
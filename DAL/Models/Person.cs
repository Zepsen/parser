using System.Collections.Generic;

namespace DAL.Models
{
    public class Person
    {
        public string Id { get; set; }
        public string Link { get; set; }
        public string Name { get; set; }
        public string Photo { get; set; }

        public ICollection<PersonLanguage> PersonLanguages { get; set; }
        public ICollection<PersonHave> PersonHaves { get; set; }
        public ICollection<PersonInterest> PersonInterests { get; set; }
        public ICollection<PersonWant> PersonWants { get; set; }
    }
}
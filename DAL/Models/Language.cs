using System.Collections.Generic;

namespace DAL.Models
{
    public class Language
    {
        public int  Id { get; set; }
        public string Title { get; set; }

        public ICollection<PersonLanguage> PersonLanguages { get; set; }
    }
}
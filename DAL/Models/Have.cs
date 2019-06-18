using System.Collections.Generic;

namespace DAL.Models
{
    public class Have
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public ICollection<PersonHave> PersonHaves { get; set; }
    }
}
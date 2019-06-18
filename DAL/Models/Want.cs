using System.Collections.Generic;

namespace DAL.Models
{
    public class Want
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public ICollection<PersonWant> PersonWants { get; set; }
    }
}
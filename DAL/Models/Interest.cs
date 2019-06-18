using System.Collections.Generic;

namespace DAL.Models
{
    public class Interest
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public ICollection<PersonInterest> PersonInterests { get; set; }
    }
}
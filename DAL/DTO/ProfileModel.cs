using System.Collections.Generic;
using System.Text;

namespace DAL.DTO
{
    public class ProfileModel
    {
        public string Id { get; set; }
        public string Link { get; set; }
        public string Name { get; set; }
        public string Photo { get; set; }
        
        public List<string> Languages { get; set; }
        public List<string> Interests { get; set; }
        public List<string> Wants { get; set; }
        public List<string> Haves { get; set; }


        public List<Education> Educations { get; set; }
        public JobModel CurrentJob { get; set; }
        public List<Work> Works { get; set; }
        


        public override string ToString()
        {
            var builder = new StringBuilder();

            builder.AppendLine($"Id is: {Id} \n");
            builder.AppendLine($"Name is: {Name} \n");
            builder.AppendLine($"Photo is: {Photo} \n");
            builder.AppendLine($"Link is: {Link} \n");
            builder.AppendLine($"Langs is: {string.Join(", ", Languages)} \n");
            builder.AppendLine($"Intrests is: {string.Join(", ", Interests)} \n");
            builder.AppendLine($"Wants is: {string.Join(", ", Wants)} \n");
            builder.AppendLine($"Haves is: {string.Join(", ", Haves)} \n");
            builder.AppendLine($"Job is: {CurrentJob.ToString()}");


            foreach (var education in Educations)
            {
                builder.AppendLine(education.ToString());
            }

            foreach (var work in Works)
            {
                builder.AppendLine(work.ToString());
            }

            return builder.ToString();
        }
    }

    public class Education
    {
        public string School { get; set; }
        public string Date { get; set; }
        public string Notes { get; set; }

        public override string ToString()
        {
            return $"School is: {School} \n" +
                   $"Date is: {Date} \n" +
                   $"Notes is: {Notes} \n";
        }
    }

    public class Work
    {
        public string Title { get; set; }
        public string Date { get; set; }

        public override string ToString()
        {
            return $"Title work exp: {Title} \n" +
                   $"Date work exp: {Date} \n";
        }
    }

    public class JobModel
    {
        public string Title { get; set; }
        public string Status { get; set; }

        public override string ToString()
        {
            return $"Title job: {Title} \n" +
                   $"Status job: {Status} \n";
        }
    }
}
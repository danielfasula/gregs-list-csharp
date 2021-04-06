using System;

namespace gregs_list_csharp.Models
{
    public class Job
    {

        public Job(string company, string jobTitle, int hours, int rate, string description)
        {
            this.Company = company;
            this.JobTitle = jobTitle;
            this.Hours = hours;
            this.Rate = rate;
            this.Description = description;
        }

        public string Company { get; set; }
        public string JobTitle { get; set; }
        public int Hours { get; set; }
        public int Rate { get; set; }
        public string Description { get; set; }
        public string Id { get; set; } = Guid.NewGuid().ToString();
    }
}
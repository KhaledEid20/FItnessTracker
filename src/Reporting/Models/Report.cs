using Reporting.Models;

namespace FitnessTracker.Reporting.Models
{
    public class Report
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string UserId { get; set; }
        public string Title { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public User user { get; set; }
        public Stats Stats { get; set; }

    }
}

// Table definition for dbdiagram.io
Table Report {
    Id varchar [pk, unique, default: `uuid_generate_v4()`]
    UserId varchar
    Title varchar
    CreatedDate timestamp [default: `now()`]
}

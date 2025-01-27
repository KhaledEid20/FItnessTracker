using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Workout.DTOs
{
    public class WorkoutDto
    {
        public string old_Title { get; set; }
        public string Title { get; set; }
        public DateTime CreationDate { get; set; }
        public bool Finished { get; set; }
        public string Notes { get; set; }
    }
}

/*

Example JSON for Postman:
{
    "old_Title" : "First khaled's Workout"
    "Title": "Morning Workout",
    "CreationDate": "2023-10-01T08:30:00Z",
    "Finished": false,
    "Notes": "Focus on cardio and strength training"
}
*/
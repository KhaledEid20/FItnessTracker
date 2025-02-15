using System;

namespace Workout.DTOs;

public class GetWorkoutDTO
{
        public string Id { get; set; }
        public string name { get; set; }
        public string Title { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool Finished { get; set; } = false;
        public string Notes { get; set; }
        public List<string> ExerciseIds { get; set; }
        
}

using System;

namespace Workout.DTOs;

public class GetWorkoutDTO
{
        public Guid Id { get; set; }
        public string name { get; set; }
        public string Title { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool Finished { get; set; } = false;
        public string Notes { get; set; }
        public List<Guid> ExerciseIds { get; set; }
        
}

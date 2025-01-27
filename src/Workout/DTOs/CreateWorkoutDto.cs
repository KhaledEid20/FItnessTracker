using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Workout.DTOs
{
    public class CreateWorkoutDto
    {
        public string Title { get; set; }
        public DateTime EndDate { get; set; } = DateTime.UtcNow.AddMinutes(5);
        public string Notes { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Workout.DTOs
{
    public class ResultDto
    {
        public string Message { get; set; }
        public bool Success { get; set; } = false;
    }
}
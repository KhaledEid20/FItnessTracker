using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Workout.DTOs
{
    public class ResultDto<T>
    {
        public string Message { get; set; }
        public bool Success { get; set; } = false;
        public T Data { get; set; }
    }
}
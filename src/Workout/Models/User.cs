using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Workout.Models
{
    public class User
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public ICollection<WorkOut> workOut { get; set; }
        public ICollection<Comment> Comments { get; set; }
    }
}
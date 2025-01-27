using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Workout.Models;

namespace Workout.Repositories.Base
{
    public interface IBase<T> where T : class
    {
        public Task<User> ValidateUser();
        public Task<IEnumerable<Exercise>> GetAllExercises();
    }
}
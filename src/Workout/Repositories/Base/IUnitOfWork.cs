using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Workout.Repositories.Base
{
    public interface IUnitOfWork
    {
        public IWorkout _workout { get; set; }
        public IExcersise _excersise { get; set; }
        public IComments _comments { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Workout.Repositories.Base;

namespace Workout.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        public IWorkout _workout { get; set; }
        public UnitOfWork(IWorkout workout)
        {
            _workout = workout;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Workout.Data;
using Workout.Models;
using Workout.Repositories.Base;

namespace Workout.Repositories
{
    public class Base<T> : IBase<T> where T : class
    {
        public readonly AppDbContext _context;
        public Base(AppDbContext context)
        {
            this._context = context;
        }

        public async Task<bool> ValidateUser(string id)
        {
            try
            {
                var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == id);
                if (user != null)
                {
                    return await Task.FromResult(true);
                }
                return await Task.FromResult(false);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public Task<IEnumerable<Exercise>> GetAllExercises()
        {
            try
            {
                var exercises = _context.Exercises.ToList();
                return Task.FromResult(exercises.AsEnumerable());
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }

}
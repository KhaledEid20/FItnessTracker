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
        private readonly IHttpContextAccessor _httpContextAccessor;

        public Base(AppDbContext context , IHttpContextAccessor httpContextAccessor)
        {
            this._context = context;
            _httpContextAccessor = httpContextAccessor;

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

        public async Task<User> ValidateUser()
        {
            try
            {
                var HttpContext = _httpContextAccessor.HttpContext;
                if (HttpContext.Items.TryGetValue("email", out var email))
                {

                    var user = await _context.Users.FirstOrDefaultAsync(x => x.Email == email.ToString());
                    if (user != null)
                    {
                        return user;
                    }
                }
                return null;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }

}
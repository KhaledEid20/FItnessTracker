using System;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Reporting.Data;
using Reporting.Models;
using Reporting.Repositories.Base;


namespace Reporting.Repositories;

public class Base<T> : IBase<T> where T : class
{
    public AppDbContext _context { get; set; }
    private readonly IHttpContextAccessor _httpContextAccessor;
    public Base(AppDbContext context , IHttpContextAccessor httpContextAccessor)
    {
        _context = context;
        _httpContextAccessor = httpContextAccessor;
    }

    public Base(AppDbContext context)
    {
        _context = context;
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

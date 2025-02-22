using System;
using Reporting.Models;
using Reporting.Repositories.Base;


namespace Reporting.Repositories;

public class Base<T> : IBase<T> where T : class
{
    public Task<User> ValidateUser()
    {
        throw new NotImplementedException();
    }
}

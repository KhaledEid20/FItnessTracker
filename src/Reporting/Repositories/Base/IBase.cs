using System;
using Reporting.Models;

namespace Reporting.Repositories.Base;

public interface IBase<T> where T : class
{
    public Task<User> ValidateUser();
}

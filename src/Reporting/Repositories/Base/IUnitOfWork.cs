using System;

namespace Reporting.Repositories.Base;

public interface IUnitOfWork
{
    public IReporting _report { get; set; }
}

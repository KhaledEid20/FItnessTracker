using System;
using Reporting.Repositories.Base;

namespace Reporting.Repositories;

public class UnitOfWork : IUnitOfWork
{
    public IReporting _report { get ; set; }
    public UnitOfWork(IReporting report)
    {
        _report = report;
    }
}

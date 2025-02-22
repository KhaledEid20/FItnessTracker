using System;
using FitnessTracker.Reporting.Models;
using Reporting.DTOs;
using Reporting.Repositories.Base;

namespace Reporting.Repositories;

public class ReportingService : Base<Report>, IReporting
{
    public Task<ResultDTO<string>> CreateReport(DateTime start, DateTime end)
    {
        throw new NotImplementedException();
    }

    public Task<ResultDTO<List<Report>>> GetAllSavedReports()
    {
        throw new NotImplementedException();
    }

    public Task<ResultDTO<List<Report>>> GetByPeriodOfTime(DateTime start, DateTime end)
    {
        throw new NotImplementedException();
    }
}

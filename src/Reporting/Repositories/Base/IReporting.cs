using System;
using FitnessTracker.Reporting.Models;
using Reporting.DTOs;

namespace Reporting.Repositories.Base;

public interface IReporting
{
    Task<ResultDTO<string>> CreateReport(DateTime start , DateTime end);
    Task<ResultDTO<List<ReportDTO>>> GetAllSavedReports();
    Task<ResultDTO<List<ReportDTO>>> GetByPeriodOfTime(DateTime start , DateTime end);
}

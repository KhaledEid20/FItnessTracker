using System;
using FitnessTracker.Reporting.Models;

namespace Reporting.Models;

public class Stats
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string ReportId { get; set; }
    public DateTime EndOfPeriod { get; set; }
    public DateTime StartPeriod { get; set; }
    public string NofWorkout { get; set; }
    public string Pending { get; set; }
    public string Completed { get; set; }
    public string TimeOut { get; set; }
    public Report reports { get; set; }
}


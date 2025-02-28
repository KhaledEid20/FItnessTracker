using System;
using FitnessTracker.Reporting.Models;

namespace Reporting.Models;

public class Stats
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string ReportId { get; set; }
    public DateTime EndOfPeriod { get; set; }
    public DateTime StartPeriod { get; set; }
    public int NofWorkout { get; set; }
    public int Pending { get; set; }
    public int Completed { get; set; }
    public int TimeOut { get; set; }
    public decimal DonePercentage { get; set; }
    public Report reports { get; set; }
}
using System;

namespace Reporting.DTOs;

public class ReportDTO
{
        public string Id { get; set; }
        public string Title { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime EndOfPeriod { get; set; }
        public DateTime StartPeriod { get; set; }
        public int NofWorkout { get; set; }
        public int Pending { get; set; }
        public int Completed { get; set; }
        public int TimeOut { get; set; }
        public decimal DonePercentage { get; set; }
}

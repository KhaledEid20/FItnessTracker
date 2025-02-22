using System;
using FitnessTracker.Reporting.Models;

namespace Reporting.Models;

public class User
{
    public string Id { get; set; }
    public string UserName { get; set; }
    public ICollection<Report> reports { get; set; }

}

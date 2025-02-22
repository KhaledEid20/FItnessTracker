using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FitnessTracker.Reporting.Models;
using Microsoft.SqlServer.Server;

namespace Reporting.Models
{
    public class WorkOut
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public string Title { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool Finished { get; set; }
        public int Status { get; set; }
        public string Notes { get; set; }

    }
}
using System;
using AutoMapper;
using FitnessTracker.Reporting.Models;
using Microsoft.EntityFrameworkCore;
using Reporting.Data;
using Reporting.DTOs;
using Reporting.Models;
using Reporting.Repositories.Base;

namespace Reporting.Repositories;

public class ReportingService : Base<Report>, IReporting
{
    public User _user { get; set; }
    public IMapper _mapper { get; set; }
    public ReportingService(AppDbContext context, IHttpContextAccessor httpContextAccessor , IMapper mapper) : base(context, httpContextAccessor)
    { 
        _mapper = mapper;
    }
    public async Task<ResultDTO<string>> CreateReport(DateTime start, DateTime end)
    {
        _user = await ValidateUser();
        if (_user == null)
        {
            return new ResultDTO<string>
            {
                Success = false,
                Message = "User not found"
            };
        }
    
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    var report = new Report
                    {
                        UserId = _user.Id,
                        Title = $"Report from {start} to {end}",
                    };
                    await _context.Reports.AddAsync(report);
                    await _context.SaveChangesAsync();
                    var stats = await CalculateStatistics(start, end);
                    stats.ReportId = report.Id;
                    await _context.Stats.AddAsync(stats);
                    await _context.SaveChangesAsync();
                    transaction.Commit();
                    return new ResultDTO<string>
                    {
                        Success = true,
                        Message = "Report created successfully"
                    };
                }
                catch (Exception e)
                {
                    transaction.Rollback();
                    return new ResultDTO<string>
                    {
                        Success = false,
                        Message = e.Message
                    };
                }
            }
    }
    public async Task<ResultDTO<List<ReportDTO>>> GetAllSavedReports()
    {
        _user = await ValidateUser();
        if (_user == null)
        {
            return new ResultDTO<List<ReportDTO>>
            {
                Success = false,
                Message = "User not found"
            };
        }
        var reports = await _context.Reports.Include(x => x.Stats).Where(x => x.UserId == _user.Id).ToListAsync();
        if(reports.Count() == 0)
        {
            return new ResultDTO<List<ReportDTO>>
            {
                Success = false,
                Message = "No reports found"
            };
        }
        var reportList = _mapper.Map<List<ReportDTO>>(reports);
        return new ResultDTO<List<ReportDTO>>
        {
            Success = true,
            Data = reportList
        };
    }
    public async Task<ResultDTO<List<ReportDTO>>> GetByPeriodOfTime(DateTime start, DateTime end)
    {
        _user = await ValidateUser();
        if (_user == null)
        {
            return new ResultDTO<List<ReportDTO>>
            {
                Success = false,
                Message = "User not found"
            };
        }
        var reports = await _context.Reports.Include(x => x.Stats).Where(x => x.UserId == _user.Id && x.Stats.StartPeriod >= start && x.Stats.EndOfPeriod <= end).ToListAsync();
        if(reports.Count() == 0)
        {
            return new ResultDTO<List<ReportDTO>>
            {
                Success = false,
                Message = "No reports found"
            };
        }
        var reportList = _mapper.Map<List<ReportDTO>>(reports);
        return new ResultDTO<List<ReportDTO>>
        {
            Success = true,
            Data = reportList
        };
        
    }
    
    private async Task<Stats> CalculateStatistics(DateTime start, DateTime end)
    {
        var Workout = await _context.WorkOuts.Where(x => x.CreationDate >= start && x.CreationDate <= end).ToListAsync();
        var nWorkout = Workout.Count();
        var Pending = Workout.Where(x => x.Status == 1).Count();
        var Completed = Workout.Where(x => x.Status == 2).Count();
        var TimeOut = Workout.Where(x => x.Status == 3).Count();
        var DonePercentage = (Completed / nWorkout) * 100;

        var stats = new Stats
        {
            StartPeriod = start,
            EndOfPeriod = end,
            NofWorkout = nWorkout,
            Pending = Pending,
            Completed = Completed,
            TimeOut = TimeOut,
            DonePercentage = DonePercentage
        };
        return stats;
    }
}

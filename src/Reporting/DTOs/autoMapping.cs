using System;
using AutoMapper;
using Reporting.DTOs;
using FitnessTracker.Reporting.Models;
using Reporting.Models;

namespace Reporting.DTOs; 

public class autoMapping: Profile
{
    public autoMapping()
    {
        CreateMap<Report, ReportDTO>()
            .ForMember(dest => dest.StartPeriod, opt => opt.MapFrom(src => src.Stats.StartPeriod))
            .ForMember(dest => dest.EndOfPeriod, opt => opt.MapFrom(src => src.Stats.EndOfPeriod))
            .ForMember(dest => dest.DonePercentage, opt => opt.MapFrom(src => src.Stats.DonePercentage))
            .ForMember(dest => dest.NofWorkout, opt => opt.MapFrom(src => src.Stats.NofWorkout))
            .ForMember(dest => dest.Pending, opt => opt.MapFrom(src => src.Stats.Pending))
            .ForMember(dest => dest.TimeOut, opt => opt.MapFrom(src => src.Stats.TimeOut))
            .ForMember(dest => dest.Completed, opt => opt.MapFrom(src => src.Stats.Completed));
    }
}
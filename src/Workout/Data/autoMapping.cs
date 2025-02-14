using System;
using AutoMapper;
using Workout.DTOs;
using Workout.Models;

namespace Workout.Data;

public class autoMapping : Profile
{
    public autoMapping()
    {
        CreateMap<WorkOut, GetWorkoutDTO>()
            .ForMember(dest => dest.name , opt => opt.MapFrom(src=>src.user.UserName));
    }
}

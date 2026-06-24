using AutoMapper;
using WebApplication1.DTOs;
using WebApplication1.Models;

namespace WebApplication1.Mappings;

public class CleanerProfile :  Profile
{
    public CleanerProfile()
    {
        CreateMap<CreateCleanerDto, Cleaner>();
        CreateMap<UpdateCleanerDto, Cleaner>();
    }
}
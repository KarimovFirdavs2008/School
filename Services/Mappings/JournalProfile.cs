using AutoMapper;
using WebApplication1.DTOs;
using WebApplication1.Models;

namespace WebApplication1.Mappings;

public class JournalProfile : Profile
{
    public JournalProfile()
    {
        CreateMap<CreateJournalDto, Journal>();
        CreateMap<UpdateJournalDto, Journal>();
    }
}
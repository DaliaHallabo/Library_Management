using AutoMapper;
using BookManagement.Dtos;
using BookManagement.Models;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<BorrowingDto, Borrowing>()
            .ForMember(dest => dest.BorrowDate, opt => opt.MapFrom(src => DateTime.Now))
            // Additional mappings as needed
            .ReverseMap(); // Optionally, configure reverse mapping
    }
}

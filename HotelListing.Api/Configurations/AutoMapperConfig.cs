using AutoMapper;
using HotelListing.Api.Data;
using HotelListing.Api.Models.Country;
using HotelListing.Api.Models.Hotel;

namespace HotelListing.Api.Configurations;

public class AutoMapperConfig : Profile
{
    public AutoMapperConfig()
    {
        CreateMap<Country, CreateCountryDto>().ReverseMap();
        CreateMap<Country, GetCountryDto>().ReverseMap();
        CreateMap<Country, CountryDto>().ReverseMap();
        CreateMap<Country, UpdateCountryDto>().ReverseMap();
        
        CreateMap<Hotel, HotelDto>().ReverseMap();
        CreateMap<Hotel, CreateHotelDto>().ReverseMap();
        
    }
}
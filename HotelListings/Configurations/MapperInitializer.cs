using AutoMapper;
using HotelListings.Data;
using HotelListings.Dtos;

namespace HotelListings.Configurations
{
    public class MapperInitializer : Profile
    {
        public MapperInitializer(  ) 
        {
            CreateMap<Country, CountryDTO>().ReverseMap();
            CreateMap<Country, CreateCountryDTO>().ReverseMap();
            CreateMap<Hotel, HotelDTO>().ReverseMap();
            CreateMap<Hotel, CreateHotelDTO>().ReverseMap();
        }
    }
}

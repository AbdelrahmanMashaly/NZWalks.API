using AutoMapper;

namespace NZWalks.API.Models.Dto.MappingProfile
{
    public class MappingProfile : Profile 
    {
        public MappingProfile() {
        CreateMap<Region,CreateRegionDto>().ReverseMap();


        }
    }
}

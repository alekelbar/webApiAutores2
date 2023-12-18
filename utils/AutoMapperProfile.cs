
using AutoMapper;
using webApi.DTO;
using webApi.Entities;

namespace webApi.DTOMapps
{

    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            // Create a new mapping configuration
            CreateMap<CreateAuthorDTO, Author>();
            CreateMap<Author, AuthorDTO>();
            CreateMap<UpdateAuthorDTO, Author>();
        }
    }

}
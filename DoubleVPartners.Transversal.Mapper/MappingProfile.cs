using AutoMapper;
using DoubleVPartners.Application.DTO;
using DoubleVPartners.Domain.Entity;

namespace DoubleVPartners.Transversal.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Persona, PersonaDTO>().ReverseMap();
            CreateMap<Usuario, UsuarioDTO>().ReverseMap();
        }
    }
}

using API.Domain;
using API.Models.Usuario;
using AutoMapper;

namespace API.Mapper
{
    public class MapperModel2Domain : Profile
    {
        public MapperModel2Domain()
        {
            CreateMap<UsuarioModelAdicionar, Usuario>()
                .ForMember(to => to.Cpf, map => map.MapFrom(from => from.Cpf))
                .ForMember(to => to.Nome, map => map.MapFrom(from => from.Nome))
                .ForMember(to => to.Email, map => map.MapFrom(from => from.Email))
                .ForMember(to => to.Senha, map => map.MapFrom(from => from.Senha))
                .ForMember(to => to.DataNascimento, map => map.MapFrom(from => from.DataNascimento));

            CreateMap<UsuarioModelAtualizar, Usuario>()
                .ForMember(to => to.Cpf, map => map.MapFrom(from => from.Cpf))
                .ForMember(to => to.Nome, map => map.MapFrom(from => from.Nome))
                .ForMember(to => to.Email, map => map.MapFrom(from => from.Email));
        }
    }
}

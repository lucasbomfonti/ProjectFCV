using API.Domain;
using API.Models.Usuario;
using AutoMapper;

namespace API.Mapper
{
    public class MapperDomain2Model : Profile
    {
        public MapperDomain2Model()
        {
            CreateMap<Usuario, UsuarioModel>()
                .ForMember(to => to.Senha, map => map.Ignore())
                .ForMember(to => to.ConfirmacaoSenha, map => map.Ignore());
           
        }
    }
}

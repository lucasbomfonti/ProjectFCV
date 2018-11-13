using System;
using System.Collections.Generic;
using API.Data.Repositorio.Interface.Base;
using Data.Serviço.Interface.Base;

namespace Data.Serviço.Base
{
    public class ServicoBase<T> : IServicoBase<T> where T : class
    {
        protected readonly IBaseRepositorio<T> Repositorio;

        public ServicoBase(IBaseRepositorio<T> repositorio)
        {
            Repositorio = repositorio;
        }

        public virtual Guid Adicionar(T entidade)
        {
            return Repositorio.Adicionar(entidade);
        }

       public virtual T Atualizar(T entidade)
       {
           return Repositorio.Atualizar(entidade);
       }

       public virtual void Remover(Guid id)
       {
           Repositorio.Remover(id);
       }

       public T Buscar(Guid id)
       {
           return Repositorio.Buscar(id);
       }

       public List<T> Todos()
       {
           return Repositorio.Todos();
       }
   }
}

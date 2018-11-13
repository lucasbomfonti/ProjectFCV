using System;
using System.Collections.Generic;
using System.Linq;
using API.Data.Repositorio.Context;
using API.Data.Repositorio.Interface.Base;
using API.Domain;

namespace API.Data.Repositorio.Base
{
    public class BaseRepositorio<T> : IBaseRepositorio<T> where T : EntidadeBase
    {
        protected readonly DataContexto Contexto;

        public BaseRepositorio(DataContexto contexto)
        {
            Contexto = contexto;
        }

        public Guid Adicionar(T entidade)
        {
            Contexto.Set<T>().Add(entidade);
            Contexto.SaveChanges();
            return entidade.Id;
        }

        public T Atualizar(T entidade)
        {
            var usuario = Buscar(entidade.Id);
            ValorDefinido(usuario, entidade);
            Contexto.SaveChanges();
            return usuario;
        }

        public void Remover(Guid id)
        {
           if(Buscar(id) == null)
               throw new Exception("Id não encontrado");
            Contexto.Remove(Buscar(id));
            Contexto.SaveChanges();
        }

        public T Buscar(Guid id)
        {
            return Contexto.Set<T>().Find(id);
        }

        public List<T> Todos()
        {
            return Contexto.Set<T>().ToList();
        }

        protected virtual void ValorDefinido(T ent, T novoValor)
        {
            Contexto.Entry(ent).CurrentValues.SetValues(novoValor);
            ValorDefinidoInterno(ent, novoValor);
        }

        protected virtual void ValorDefinidoInterno(object ent, object novoValor)
        {

        }
    }
}

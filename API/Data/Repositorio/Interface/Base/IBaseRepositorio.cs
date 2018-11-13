using System;
using System.Collections.Generic;

namespace API.Data.Repositorio.Interface.Base
{
    public interface IBaseRepositorio<T> where T : class
    {
        Guid Adicionar(T entidade);
        T Atualizar(T entidade);
        void Remover(Guid id);
        T Buscar(Guid id);
        List<T> Todos();
    }
}

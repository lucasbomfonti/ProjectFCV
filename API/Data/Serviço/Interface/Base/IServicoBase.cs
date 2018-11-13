using System;
using System.Collections.Generic;

namespace Data.Serviço.Interface.Base
{
    public interface IServicoBase<T> where T : class
    {
        Guid Adicionar(T entidade);
        T Atualizar(T entidade);
        void Remover(Guid id);
        T Buscar(Guid id);
        List<T> Todos();
    }
}

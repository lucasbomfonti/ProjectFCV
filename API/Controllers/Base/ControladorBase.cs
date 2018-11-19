using Microsoft.AspNetCore.Mvc;
using System;
using API.Data.Serviço.Interface.Base;
using API.Helper;
using API.Models.Base;

namespace API.Controllers.Base
{
    public class ControladorBase<T, TM, TIm, TUm> : ControllerBase where T : class where TM : class where TIm : class where TUm : ModeloBaseAtualizacao
    {
        protected readonly IServicoBase<T> Servico;
        public ControladorBase(IServicoBase<T> servico)
        {
            Servico = servico;
        }

        protected ActionResult Adicionar(TIm modelo)
        {
            if(!ModelState.IsValid)
                throw new Exception("Valores Inválidos");
            var entidade = MapperHelper.Map<TIm, T>(modelo);
            var resposta = Servico.Adicionar(entidade);
            return Ok(resposta);
        }

        protected ActionResult Atualizar(Guid id, TUm modelo)
        {
            if(!ModelState.IsValid)
                throw new Exception("Valores Inválidos");
            modelo.Id = id;
            var entidade = MapperHelper.Map<TUm, T>(modelo);
            var resposta = Servico.Atualizar(entidade);
            return Ok(resposta);
        }

        protected ActionResult Deletar(Guid id)
        {
            Servico.Remover(id);
            return Ok();
        }

        protected ActionResult BuscarPorId(Guid id)
        {
            var resposta = Servico.Buscar(id);
            if (resposta == null)
                return NotFound();
            return Ok(MapperHelper.Map<T, TM>(resposta));
        }

        protected ActionResult BuscarTodos()
        {
            var resposta = Servico.Todos();
            return Ok(MapperHelper.CopyList<T, TM>(resposta));
        }
    }
}

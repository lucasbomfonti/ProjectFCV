using API.Controllers.Base;
using API.Data.Serviço.Interface;
using API.Domain;
using API.Models.Usuario;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using API.Data.Serviço;

namespace API.Controllers
{
    public class UsuarioController : ControladorBase<Usuario, UsuarioModel, UsuarioModelAdicionar, UsuarioModelAtualizar>
    {

        public UsuarioController(IUsuarioServico servico) : base(servico)
        {
        }

        [HttpPost("add")]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public new ActionResult Adicionar([FromBody] UsuarioModelAdicionar modelo)
        {
            return base.Adicionar(modelo);
        }

        [HttpPut("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public new ActionResult Atualizar([FromRoute] Guid id, [FromBody] UsuarioModelAtualizar modelo)
        {
            return base.Atualizar(id, modelo);
        }

        [HttpGet("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public ActionResult BuscaPorId(Guid id)
        {
            return BuscarPorId(id);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public new ActionResult Deletar(Guid id)
        {
            return base.Deletar(id);
        }

        [HttpGet("all")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public new ActionResult BuscarTodos()
        {
            return base.BuscarTodos();
        }

        [HttpPatch("ForgetPassword")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public ActionResult ForgetPassword(string email)
        {
            ((UsuarioServico) Servico).SolicitacaoMudancaSenha(email);
            return NoContent();
        }

        [HttpPatch("ChangePassword")]
        [ProducesResponseType((int) HttpStatusCode.NoContent)]
        [ProducesResponseType((int) HttpStatusCode.BadRequest)]
        [ProducesResponseType((int) HttpStatusCode.InternalServerError)]
        public ActionResult MudarSenha(AtualizacaoSenhaModel model)
        {
            ((UsuarioServico) Servico).MudarSenha(model.Codigo, model.Senha, model.ConfirmacaoSenha);
            return NoContent();
        }
    }
}

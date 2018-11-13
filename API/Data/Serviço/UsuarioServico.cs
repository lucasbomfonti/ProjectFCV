using System;
using API.Data.Repositorio;
using API.Data.Repositorio.Interface;
using API.Data.Serviço.Interface;
using API.Domain;
using API.Helper;
using Data.Serviço.Base;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace API.Data.Serviço
{
    public class UsuarioServico : ServicoBase<Usuario>, IUsuarioServico
    {
        public UsuarioServico(IUsuarioRepositorio repositorio) : base(repositorio)
        {
            
        }

        public override Guid Adicionar(Usuario entidade)
        {
            entidade.Senha = EncryptHelper.EncryptPassword(entidade.Senha);
            return base.Adicionar(entidade);
        }

        public void SolicitacaoMudancaSenha(string email)
        {
            var usuario = ((UsuarioRepositorio) Repositorio).BuscarUsuarioPorEmail(email);

            if(usuario == null)
                throw new Exception("O Email não existe no Banco de dados");
            usuario.CodigoRecuperacao = CodigoVerificacao();
            Atualizar(usuario);

            var bodyEmail = $"Codigo de acesso: {usuario.CodigoRecuperacao}";
            SendEmail(email, bodyEmail, "Senha de Recuperação");
        }
        private void SendEmail(string email, string corpoEmail, string subject)
        {
            EmailHelper.SendMail(email, corpoEmail, subject);
        }

        private string CodigoVerificacao()
        {
            var limit = string.Empty;
            while (limit.Length < 10)
                limit += EnvironmentProperties.CharactersAllowed[new Random().Next(0, EnvironmentProperties.CharactersAllowed.Length)];
            return limit;
        }

        public void MudarSenha(string codigo, string senha, string confirmacaoSenha)
        {
            ValidacaoCodigoSenha(codigo);

            var usuario = (Usuario)((UsuarioRepositorio)Repositorio).ObtenhaUsuarioPorCodigo(codigo);
            var novaSenha = EncryptHelper.EncryptPassword(senha);
            if (usuario.Senha == novaSenha)
                throw new Exception("A nova senha não pode ser igual a senha atual");
            usuario.Senha = novaSenha;
            usuario.CodigoRecuperacao = null;
            
        }

        private void ValidacaoCodigoSenha(string codigo)
        {
            var temp = (Usuario) ((UsuarioRepositorio) Repositorio).ObtenhaUsuarioPorCodigo(codigo);
            if(temp.CodigoRecuperacao == null)
                throw new Exception("O código informado ja foi utilizado, solicite outro");
        }


    }
}

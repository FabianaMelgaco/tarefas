
using Dapper;
using System;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using Tarefas.DTO;
using System.Collections.Generic;



namespace Tarefas.DAO

{
    public class UsuarioDAO : BaseDAO, IUsuarioDAO
    {

        public void CriarUsuario(UsuarioDTO Usuario)
        {
            using (var con = Connection)
            {
                con.Open();
                con.Execute(
                    @"INSERT INTO Usuario
                    (Email, Nome, Senha, Ativo) VALUES
                    (@Email, @Nome, @Senha, @Ativo);", Usuario
                );
            }
        }

        public void EditarUsuario(UsuarioDTO Usuario)
        {
            using (var con = Connection)
            {
                con.Open();
                con.Execute(
                    @"UPDATE Usuario SET 
                    Nome = @Nome, Email = @Email, Senha = @Senha, Ativo = @Ativo
                    WHERE Id = @Id;", Usuario
                );
            }
        }
        public void ExcluirUsuario(int idusur)
        {
            using (var con = Connection)
            {
                con.Open();
                con.Execute($"DELETE FROM Usuario WHERE Id = {idusur};");
            }
        }
        public List<UsuarioDTO> ConsultarUsuario()
        {
            using (var con = Connection)
            {
                con.Open();
                var result = con.Query<UsuarioDTO>(
                @"SELECT * FROM Usuario"
                ).ToList();
                return result;
            }
        }
        public UsuarioDTO ConsultarUsuario(int idusur)
        {
            using (var con = Connection)

            {
                con.Open();
                UsuarioDTO result = Connection.Query<UsuarioDTO>
                (
                    $@"SELECT Id, Nome, Email, Senha, Ativo FROM Usuario WHERE Id = {idusur}"
                ).FirstOrDefault();
                return result;
            }
        }
        public UsuarioDTO ValidarUsuario(string email, string senha)
        {
            using (var con = Connection)
            {
                con.Open();
                UsuarioDTO result = Connection.Query<UsuarioDTO>
                (
                    @"SELECT Id, Nome, Email, Senha, Ativo FROM Usuario WHERE 
                    Email = @Email and Senha = @Senha and
                    Ativo = True", new { email,senha }
                ).FirstOrDefault();
                return result;
            }
        }
    }
}
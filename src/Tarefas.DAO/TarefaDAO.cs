
using Dapper;
using System;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using Tarefas.DTO;
using System.Collections.Generic;

namespace Tarefas.DAO
{
    public class TarefaDAO
    {
        private string DataSourceFile => Environment.CurrentDirectory + @"\TarefasDB.SQLite";


        public SQLiteConnection Connection => new SQLiteConnection("DataSource=" + DataSourceFile);
        
        public TarefaDAO()
        {
            if(!File.Exists(DataSourceFile))
            {
                CreateDatabase();
            }
        }

        private void CreateDatabase()
        {
            using(var con = Connection)
            {
                con.Open();
                con.Execute(
                    @"CREATE TABLE Tarefa
                    (
                    Id          integer primary key autoincrement,
                    Titulo      varchar(100) not null,
                    Descricao   varchar(100) not null,
                    Status      string not null
                    )"
                );
            }

        }
        public void Criar(TarefaDTO tarefa)
        {
            using (var con = Connection)
            {
                con.Open();
                con.Execute(
                    @"INSERT INTO Tarefa
                    (Titulo, Descricao, Status) VALUES
                    (@Titulo, @Descricao, @Status);", tarefa
                );
            }
        }

        public void Editar(TarefaDTO tarefa)
            {
            using (var con = Connection)
            {
                con.Open();
                con.Execute(
                    @"UPDATE Tarefa SET Titulo = 
                    @Titulo, Descricao = @Descricao, Status = @Status 
                    WHERE Id = @Id;", tarefa
                );
            }
        }

        public void Excluir(int id)
        {
  
            using (var con = Connection)
            {
                con.Open();
                //con.Execute("DELETE FROM Tarefa WHERE Id = @id");
                con.Execute($"DELETE FROM Tarefa WHERE Id = {id};");
                //con.Execute(@"DELETE FROM Tarefa WHERE Id = @Id;", id);

            }
        }        
        
        public List<TarefaDTO> Consultar()
        {
        using(var con = Connection)
            {
                con.Open();
                var result = con.Query<TarefaDTO>(
                @"SELECT Id, Titulo, Descricao, Status FROM Tarefa"
                ).ToList();
                return result;
            }
        }

        public TarefaDTO Consultar(int id)
        {
            using (var con = Connection)

            {
                con.Open();
                TarefaDTO result  = Connection.Query<TarefaDTO>
                (
                    @"SELECT Id, Titulo, Descricao, Status FROM Tarefa WHERE Id = @Id", new { id } 
                ).FirstOrDefault();
                return result;
            }
        }

    }
}
using Dapper;
using System;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using Tarefas.DTO;
using System.Collections.Generic;

namespace Tarefas.DAO
{
    public class DataBaseBootstrap : BaseDAO, IDataBaseBootstrap
    {
        public void Setup()
        {
            if (!File.Exists(DataSourceFile))
            {
                using (var con = Connection)
                {
                    con.Open();
                    con.Execute(
                        @"CREATE TABLE Tarefa
                    (
                    Id integer primary key autoincrement,
                    Titulo varchar(100) not null,
                    Descricao varchar(100) not null,
                    Status string not null
                    )"
                    );
                    con.Execute(
                         @"CREATE TABLE Usuario
                    (
                    Id integer primary key autoincrement,
                    Email varchar(100) not null,
                    Nome varchar(100) not null,
                    Senha varchar (50) not null,
                    Ativo bool not null
                    )"
                    );

                    InsertDefaultData(con);
                }
            }

        }

        public void InsertDefaultData(SQLiteConnection con)
        {
            var conta = new UsuarioDTO()
            {
                Email = "fabiana.melgaco@gmail.com",
                Senha = "123456",
                Nome = "Fabiana",
                Ativo = true
            };
            con.Execute(
                @"INSERT INTO Usuario
                (Email, Senha, Nome, Ativo) VALUES
                (@Email, @Senha, @Nome, @Ativo);", conta
            );
        }
    }

}

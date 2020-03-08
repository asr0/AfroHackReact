using AfroHackReact.Model;
using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace AfroHackReact.Data
{
    public class Repository : IRepository
    {
        private readonly string connectionString;

        public Repository(IConfiguration config)
        {
            connectionString = config.GetConnectionString("DefaultConnection");
        }

        public void CriarUsuario(Usuario usuario)
        {
            using SqlConnection conexao = new SqlConnection(connectionString);

            conexao.Open();

            usuario.Ativo = true;
            usuario.DataCriacao = DateTime.Now;

            var id = conexao.Query<int>(Sql.CriarUsuario, usuario).Single();

            foreach (var item in usuario.ListaHorarios)
            {
                conexao.Execute(Sql.CriarUsuarioHorario, new { Id = id, item.CodigoHorarioDisponivel });
            }

            conexao.Close();
        }

        public Usuario Login(string Email, string Senha)
        {
            using SqlConnection conexao = new SqlConnection(connectionString);

            conexao.Open();

            var retorno = conexao.Query<Usuario>(Sql.LoginUsuario, new { Email, Senha }).FirstOrDefault();

            if (retorno != null)
            {
                retorno.ListaHorarios = conexao.Query<HorarioUsuarioMentor>(Sql.LoginHorarios, new { retorno.CodigoUsuario }).ToList();
            }

            conexao.Close();
            return retorno;
        }

        public List<Usuario> ListarMentores(int CodigoUsuario)
        {
            using SqlConnection conexao = new SqlConnection(connectionString);
            conexao.Open();

            var retorno = conexao.Query<Usuario>(Sql.ListaMentores, new { CodigoUsuario }).ToList();

            conexao.Close();

            return retorno;
        }

        public List<AreaInteresse> AreasInteresse()
        {
            using SqlConnection conexao = new SqlConnection(connectionString);

            conexao.Open();

            var retorno = conexao.Query<AreaInteresse>(Sql.AreasInteresse).ToList();

            conexao.Close();

            return retorno;
        }

        public List<HorarioUsuarioMentor> HorariosDisponiveis()
        {
            using SqlConnection conexao = new SqlConnection(connectionString);

            conexao.Open();

            var retorno = conexao.Query<HorarioUsuarioMentor>(Sql.HorariosDisponiveis).ToList();

            conexao.Close();
            return retorno;
        }
    }
}
using AfroHackReact.Model;
using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

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

            var sql = @" INSERT INTO USUARIO(
                            [NomeUsuario]
                           ,[CodigoTipoUsuario]
                           ,[Email]
                           ,[NumeroCelular]
                           ,[Senha]
                           ,[Ativo]
                           ,[DataNascimento]
                           ,[NumeroDocumento]
                           ,[ExperienciaVida]
                           ,[CodigoAreaInteresse]
                           ,[DataCriacao])
                            VALUES(
                                @NomeUsuario,
                                @CodigoTipoUsuario,
                                @Email,
                                @NumeroCelular,
                                @Senha,
                                @Ativo,
                                @DataNascimento,
                                @NumeroDocumento,
                                @ExperienciaVida,
                                @CodigoAreaInteresse,
                                @DataCriacao)
                            SELECT CAST(SCOPE_IDENTITY() as int)";

            var id = conexao.Query<int>(sql, usuario).Single();

            foreach (var item in usuario.ListaHorarios)
            {
                string sql2 = "INSERT INTO HorarioUsuarioMentor (CodigoUsuarioMentor, CodigoHorarioDisponivel, Ativo) VALUES (@Id, @CodigoHorarioDisponivel,1)";
                conexao.Execute(sql2, new { Id = id, item.CodigoHorarioDisponivel });
            }

            conexao.Close();
        }

        public Usuario Login(string Email, string Senha)
        {
            using SqlConnection conexao = new SqlConnection(connectionString);
            conexao.Open();

            var sql = @"SELECT
                       [CodigoUsuario]
                      ,[NomeUsuario]
                      ,[CodigoTipoUsuario]
                      ,[Email]
                      ,[NumeroCelular]
                      ,[Senha]
                      ,[Ativo]
                      ,[DataNascimento]
                      ,[NumeroDocumento]
                      ,[DataCriacao]
                      ,[DataAlteracao]
                        FROM USUARIO WHERE EMAIL = @Email AND SENHA = @Senha";

            var retorno = conexao.Query<Usuario>(sql, new { Email, Senha }).FirstOrDefault();

            var sql2 = @"SELECT * FROM HorarioUsuarioMentor
                        JOIN HorarioDisponivel ON HorarioDisponivel.CodigoHorarioDisponivel = HorarioUsuarioMentor.CodigoHorarioDisponivel WHERE CodigoUsuarioMentor = @CodigoUsuario";

            if (retorno != null)
            {
                retorno.ListaHorarios = conexao.Query<HorarioUsuarioMentor>(sql2, new { retorno.CodigoUsuario }).ToList();
            }

            conexao.Close();

            return retorno;
        }

        public List<Usuario> ListarMentores(int CodigoUsuario)
        {
            using SqlConnection conexao = new SqlConnection(connectionString);
            conexao.Open();

            var sql = @"(
                        SELECT * FROM USUARIO
                        JOIN HorarioUsuarioMentor ON HorarioUsuarioMentor.CodigoUsuarioMentor = USUARIO.CodigoUsuario
                        WHERE
                        CodigoTipoUsuario = 1
                        AND HorarioUsuarioMentor.CodigoHorarioDisponivel IN
                        (
	                        SELECT CodigoHorarioDisponivel FROM HorarioUsuarioMentor WHERE CodigoUsuarioMentor = @CodigoUsuario
                        )

                        AND USUARIO.codigoareainteresse IN
                        (
	                        SELECT codigoareainteresse FROM USUARIO WHERE CodigoUsuario = @CodigoUsuario
                        ))";

            var retorno = conexao.Query<Usuario>(sql, new { CodigoUsuario }).ToList();

            conexao.Close();

            return retorno;
        }

        public List<HorarioUsuarioMentor> HorariosDisponiveis()
        {
            using SqlConnection conexao = new SqlConnection(connectionString);
            conexao.Open();

            var sql = @"SELECT [CodigoHorarioDisponivel]
                      ,[DescricaoPeriodo]
                      ,[DescricaoHorario]
                      ,[DataInclusao]
                  FROM [dbo].[HorarioDisponivel]";

            var retorno = conexao.Query<HorarioUsuarioMentor>(sql).ToList();

            return retorno;
        }
    }
}
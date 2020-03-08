using System;
using System.Collections.Generic;

namespace AfroHackReact.Model
{
    public class Usuario
    {
        public string NomeUsuario { get; set; }
        public int CodigoTipoUsuario { get; set; }
        public string NumeroDocumento { get; set; }
        public string Email { get; set; }
        public string NumeroCelular { get; set; }
        public string Senha { get; set; }
        public bool Ativo { get; set; }
        public DateTime DataNascimento { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime? DataAlteracao { get; set; }
        public int CodigoUsuario { get; set; }
        public string ExperienciaVida { get; set; }
        public int CodigoAreaInteresse { get; set; }
        public List<HorarioUsuarioMentor> ListaHorarios { get; set; }
    }
}
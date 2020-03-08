using AfroHackReact.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AfroHackReact
{
    public interface IRepository
    {
        void CriarUsuario(Usuario usuario);
        List<HorarioUsuarioMentor> HorariosDisponiveis();
        List<Usuario> ListarMentores(int CodigoUsuario);
        Usuario Login(string Email, string Senha);
    }
}
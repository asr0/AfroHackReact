using System;

namespace AfroHackReact.Model
{
    public class HorarioUsuarioMentor
    {
        public int CodigoHorarioDisponivel { get; set; }
        public string DescricaoPeriodo { get; set; }
        public string DescricaoHorario { get; set; }
        public DateTime DataInclusao { get; set; }
    }
}
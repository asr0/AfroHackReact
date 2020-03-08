using System.Collections.Generic;

namespace AfroHackReact.Model
{
    public class Dia
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public List<Horario> Horarios { get; set; }
    }
}
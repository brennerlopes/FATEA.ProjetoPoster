using System;

namespace FATEA.ProjetoPoster.Domain
{
    public class Evento
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Tema { get; set; }
        public string Descricao { get; set; }
        public int NumMaximoAutores { get; set; }
        public int NumAvaliadores { get; set; }
        public bool Status { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public string Informacoes { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FATEA.ProjetoPoster.Domain
{
    public class Poster
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Autores { get; set; }
        public string PalavraChave { get; set; }
        public string Resumo { get; set; }
        public string Modalidade { get; set; }
        public virtual Curso Curso { get; set; }
        public int IdCurso { get; set; }
        public virtual Evento Evento { get; set; }
        public int IdEvento { get; set; }
        public double Nota { get; set; }
        public string AvaliadoPor { get; set; }
        public string NomeArquivo { get; set; }
        public virtual List<Avaliacao> Avaliacoes { get; set; }
    }
}

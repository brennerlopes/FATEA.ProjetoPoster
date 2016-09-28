using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FATEA.ProjetoPoster.Domain
{
    public class Avaliacao
    {
        public long Id { get; set; }
        public int NotaTema { get; set; }
        public int NotaIntroducao { get; set; }
        public int NotaDesenvolvimento { get; set; }
        public int NotaResultados { get; set; }
        public int NotaConclusao { get; set; }
        public decimal NotaFinal { get; set; }
        public virtual Poster Poster { get; set; }
        public int PosterId { get; set; }
        public string AvaliadorId { get; set; }
    }
}

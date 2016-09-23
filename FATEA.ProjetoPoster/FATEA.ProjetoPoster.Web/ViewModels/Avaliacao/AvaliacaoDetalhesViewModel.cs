using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FATEA.ProjetoPoster.Web.ViewModels.Avaliacao
{
    public class AvaliacaoDetalhesViewModel
    {
        public long Id { get; set; }

        [DisplayName("Título do pôster")]
        public string TituloPoster { get; set; }

        [DisplayName("Nota do tema")]
        public int NotaTema { get; set; }

        [DisplayName("Nota da introdução")]
        public int NotaIntroducao { get; set; }

        [DisplayName("Nota do desenvolvimento")]
        public int NotaDesenvolvimento { get; set; }

        [DisplayName("Nota de resultados")]
        public int NotaResultados { get; set; }

        [DisplayName("Nota da conclusão")]
        public int NotaConclusao { get; set; }

        [DisplayName("Nota final")]
        public int NotaFinal { get; set; }
    }
}
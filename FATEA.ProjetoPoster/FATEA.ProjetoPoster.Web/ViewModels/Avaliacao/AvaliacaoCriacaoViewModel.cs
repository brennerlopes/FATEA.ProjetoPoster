using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FATEA.ProjetoPoster.Web.ViewModels.Avaliacao
{
    public class AvaliacaoCriacaoViewModel
    {
        [Required(ErrorMessage = "O ID é obrigatório")]
        public long Id { get; set; }

        [Required(ErrorMessage = "O pôster é obrigatório")]
        [DisplayName("Pôster")]
        public long PosterId { get; set; }

        [DisplayName("Nota do tema")]
        [Required(ErrorMessage = "A nota para o tema é obrigatória")]
        public int NotaTema { get; set; }

        [DisplayName("Nota da introdução")]
        [Required(ErrorMessage = "A nota para a introdução é obrigatória")]
        public int NotaIntroducao { get; set; }

        [DisplayName("Nota do desenvolvimento")]
        [Required(ErrorMessage = "A nota para o desenvolvimento é obrigatória")]
        public int NotaDesenvolvimento { get; set; }

        [DisplayName("Nota de resultados")]
        [Required(ErrorMessage = "A nota para os resultados é obrigatória")]
        public int NotaResultados { get; set; }

        [DisplayName("Nota da conclusão")]
        [Required(ErrorMessage = "A nota para a conclusão é obrigatória")]
        public int NotaConclusao { get; set; }

    }
}
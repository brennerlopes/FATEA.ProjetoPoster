using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace FATEA.ProjetoPoster.Web.ViewModels.Avaliacao
{
    public class AvaliacaoIndexViewModel
    {
        public long Id { get; set; }

        [DisplayName("Titulo do pôster")]
        public string TituloPoster { get; set; }

        [DisplayName("Nota final")]
        public decimal NotaFinal { get; set; }
    }
}

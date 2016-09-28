using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FATEA.ProjetoPoster.Web.ViewModels.Poster
{
    public class AtribuirPosterViewModel
    {

        [DisplayName("Avaliador")]
        [Required(ErrorMessage = "É obrigatório selecionar o avaliador")]
        public string AvaliadorId { get; set; }
               
        [DisplayName("Pôster")]
        [Required(ErrorMessage = "É obrigatório selecionar um pôster")]
        public long PosterId { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FATEA.ProjetoPoster.Web.ViewModels.Curso
{
    public  class CursoIndexViewModel
    {
        public int Id { get; set; }

        [DisplayName("Nome do curso")]
        public string Nome { get; set; }

        [DisplayName("Área do Curso")]
        public string Area { get; set; }
        
    }
}
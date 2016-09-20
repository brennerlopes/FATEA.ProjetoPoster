using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FATEA.ProjetoPoster.Web.ViewModels.Curso
{
    public class CursoEdicaoViewModel
    {
        [Required(ErrorMessage = "O ID do curso é obrigatório")]
        public int Id { get; set; }

        [DisplayName("Nome")]
        [Required(ErrorMessage = "O nome do curso é obrigatório")]
        [MaxLength(150, ErrorMessage = "O nome deve ter no máximo 150 caracteres.")]
        public string Nome { get; set; }

        [DisplayName("Área")]
        [Required(ErrorMessage = "A área do curso deve ser obrigatório")]
        [MaxLength(100, ErrorMessage = "O tema deve ter no máximo 100 caracteres.")]

        public string Area { get; set; }
    }
}
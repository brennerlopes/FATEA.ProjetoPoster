using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FATEA.ProjetoPoster.Web.ViewModels.Poster
{

    
    public  class PosterEdicaoViewModel

    {
        [Required(ErrorMessage = "O ID do Poster é obrigatório")]
        public long Id { get; set; }


        [DisplayName("Evento")]
        [Required(ErrorMessage = "Insira o Evento")]
        public int IdEvento { get; set; }

        [DisplayName("Curso")]
        [Required(ErrorMessage = "Insira Curso")]
        public long IdCurso { get; set; }

        [DisplayName("Título")]
        [Required(ErrorMessage = "O Título é obrigatório")]
        [MaxLength(100, ErrorMessage = "O Título deve ter no máximo 100 caracteres.")]
        public string Titulo { get; set; }

        [DisplayName("Autor(es)")]
        [Required(ErrorMessage = "O Autor(es) é(são) obrigatório(s)")]
        [MaxLength(100, ErrorMessage = "Os autores devem ter no máximo 100 caracteres.")]
        public string Autores { get; set; }

        [DisplayName("Palavra Chave")]
        [Required(ErrorMessage = "Por favor, insira as Palavras chave.")]
        [MaxLength(150, ErrorMessage = "A palavra chave deve ter no máximo 150 caracteres.")]
        public string PalavraChave { get; set; }

        [DisplayName("Resumo")]
        [Required(ErrorMessage = "Por favor, descreva um resumo do poster.")]
        [MaxLength(450, ErrorMessage = "O resumo deve ter no máximo 450 caracteres.")]
        public string Resumo { get; set; }

        [DisplayName("Modalidade")]
        [Required(ErrorMessage = "Preencha")]
        public string Modalidade { get; set; }

        [DisplayName("Nota")]

        public double Nota { get; set; }

        [DisplayName("Avaliador")]

        public string AvaliadoPor { get; set; }
        public string NomeArquivo { get; set; }


    }
}

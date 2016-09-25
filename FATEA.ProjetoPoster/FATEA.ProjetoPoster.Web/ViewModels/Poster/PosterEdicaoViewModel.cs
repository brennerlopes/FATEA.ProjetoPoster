using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FATEA.ProjetoPoster.Web.ViewModels.Poster
{

    public class PosterEdicaoViewModel

    public  class PosterEdicaoViewModel

    {
        [Required(ErrorMessage = "O ID do Poster é obrigatório")]
        public int Id { get; set; }

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
        [MaxLength(400, ErrorMessage = "A palavra chave deve ter no máximo 400 caracteres.")]
        public string Resumo { get; set; }

        [DisplayName("Modalidade")]
        [Required(ErrorMessage = "Modalidade do poster é obrigatório.")]
        public string Modalidade { get; set; }

        [DisplayName("Nota")]
        //[Required(ErrorMessage = "Insira área do Poster.")]
        public double Nota { get; set; }

        [DisplayName("Avaliador")]
        //[Required(ErrorMessage = "Nome do avaliador")]
        public string AvaliadoPor { get; set; }

        
        [DisplayName("Arquivo")]
        [Required(ErrorMessage = "Insira um arquivo.")]
        public string NomeArquivo { get; set; }

        [DisplayName("Area")]
        [Required(ErrorMessage = "Por favor, insira a Area")]
        [MaxLength(100, ErrorMessage = "O Título deve ter no máximo 100 caracteres.")]
        public string Area { get; set; }

       
      
    

}
}

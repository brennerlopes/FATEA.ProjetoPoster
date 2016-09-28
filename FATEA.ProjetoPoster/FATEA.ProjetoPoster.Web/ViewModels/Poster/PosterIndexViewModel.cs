using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace FATEA.ProjetoPoster.Web.ViewModels.Poster
{

   
    public  class PosterIndexViewModel

    {
        public int Id { get; set; }

        [DisplayName("Evento")]
        public string NomeEvento { get; set; }

        public string Titulo { get; set; }

        [DisplayName("Autores")]
        public string Autores { get; set; }

        [DisplayName("Palavras Chave")]
        public string PalavraChave { get; set; }

        [DisplayName("Resumo")]
        public string Resumo { get; set; }

        [DisplayName("Modalidade")]
        public string Modalidade { get; set; }

        [DisplayName("Curso")]
        public string NomeCurso { get; set; }

        [DisplayName("Nota")]
        public double Nota { get; set; }

        [DisplayName("Avaliador")]
        public string AvaliadoPor { get; set; }

        [DisplayName("Nome do Arquivo")]
        public string NomeArquivo { get; set; }



    }
}
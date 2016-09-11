using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FATEA.ProjetoPoster.Web.ViewModels.Evento
{
    public class EventoIndexViewModel
    {
        public long Id { get; set; }

        [DisplayName("Nome do evento")]
        public string Nome { get; set; }

        [DisplayName("Tema")]
        public string Tema { get; set; }

        [DisplayName("Descrição")]
        public string Descricao { get; set; }

        [DisplayName("Nº máximo de autores")]
        public string NumMaximoAutores { get; set; }

        [DisplayName("Nº de avaliadores")]
        public string NumAvaliadores { get; set; }

        [DisplayName("É ativo?")]
        public bool Status { get; set; }

        [DisplayName("Data inicial")]
        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime DataInicio { get; set; }

        [DisplayName("Data final")]
        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime DataFim { get; set; }

        [DisplayName("Informações")]
        public string Informacoes { get; set; }
    }
}
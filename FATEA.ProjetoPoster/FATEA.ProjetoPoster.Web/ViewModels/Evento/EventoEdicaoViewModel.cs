using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FATEA.ProjetoPoster.Web.ViewModels.Evento
{
    public class EventoEdicaoViewModel
    {
        [Required(ErrorMessage = "O ID do evento é obrigatório")]
        public long Id { get; set; }

        [DisplayName("Nome")]
        [Required(ErrorMessage = "O nome do evento é obrigatório")]
        [MaxLength(100, ErrorMessage = "O nome deve ter no máximo 100 caracteres.")]
        public string Nome { get; set; }

        [DisplayName("Tema")]
        [Required(ErrorMessage = "O tema é obrigatório")]
        [MaxLength(100, ErrorMessage = "O tema deve ter no máximo 100 caracteres.")]
        public string Tema { get; set; }

        [DisplayName("Descrição")]
        [Required(ErrorMessage = "A descrição é obrigatória")]
        [MaxLength(150, ErrorMessage = "A descrição deve ter no máximo 150 caracteres.")]
        public string Descricao { get; set; }

        [DisplayName("Nº máximo de autores por evento")]
        [Required(ErrorMessage = "O número máximo de autores é obrigatório")]
        public int NumMaximoAutores { get; set; }

        [DisplayName("Nº de avaliadores")]
        [Required(ErrorMessage = "O número de avaliadores é obrigatório")]
        public int NumAvaliadores { get; set; }

        [DisplayName("É ativo?")]
        [Required(ErrorMessage = "O status do evento é obrigatório")]
        public bool Status { get; set; }

        [DisplayName("Data inicial")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "A data inicial do evento é obrigatória")]
        [DataType(DataType.Date)]
        public DateTime DataInicio { get; set; }

        [DisplayName("Data final")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "A data final do evento é obrigatória")]
        [DataType(DataType.Date)]
        public DateTime DataFim { get; set; }

        [DisplayName("Informações")]
        [Required(ErrorMessage = "As informações são obrigatórias")]
        [MaxLength(200, ErrorMessage = "A descrição deve ter no máximo 200 caracteres.")]
        public string Informacoes { get; set; }
    }

}
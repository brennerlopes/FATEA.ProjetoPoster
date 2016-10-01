using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FATEA.ProjetoPoster.Web.ViewModels.Usuario
{
    public class UsuarioEditViewModel 
    {

        [DisplayName("Nome Completo")]
        [Required(ErrorMessage ="O nome é obrigatório")]
        [MaxLength(100, ErrorMessage = "O nome completo deve conter até 100 caracteres")]
        [MinLength(5, ErrorMessage = "O nome completo deve conter no mínimo 5 caracteres ")]
        public string NomeUsuario { get; set; }

        [DisplayName("RG")]
        //[MaxLength(11, ErrorMessage = "O RG deve conter no máximo 12 números")]
        //[MinLength(8, ErrorMessage = "O nome completo deve conter no mínimo 5 caracteres ")]
        public string RgUsuario { get; set; }
        

        [DisplayName("CPF")]
        [Required(ErrorMessage = "O CPF é obrigatório")]
        [MaxLength(14, ErrorMessage = "O CPF deve conter no máximo 14 dígitos")]

        //[MinLength(11, ErrorMessage = "O nome completo deve conter no mínimo 5 caracteres ")]

        public string CpfUsuario { get; set; }

        [DisplayName("Email")]
        [Required(ErrorMessage = "O email do usuário é obrigatório")]
        [MaxLength(30, ErrorMessage = "O email deve conter até 30 caracteres")]
        [MinLength(10, ErrorMessage = "O email deve conter no mínimo 5 caracteres")]

        public string EmailUsuario { get; set; }

        [DisplayName("Senha")]
        [Required(ErrorMessage = "A senha é obrigatória")]
        [DataType(DataType.Password)]
        [MinLength(6, ErrorMessage = "A senha deve conter no mínimo 6 caracteres")]
        [MaxLength(14, ErrorMessage ="A senha deve conter no máximo 14 caracteres")]

        public string Senha { get; set; }

        //[DisplayName("Perfil")]
       // [Required(ErrorMessage = "O perfil do usuário é obrigatório")]

        public string RoleId { get; set; }

    }
}
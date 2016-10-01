using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FATEA.ProjetoPoster.Web.ViewModels.Usuario
{
    public class UsuarioLoginViewModel
    {
        
        [DisplayName("Email")]
        [Required(ErrorMessage = "O email do usuário é obrigatório")]
        [MaxLength(30, ErrorMessage = "O email deve conter até 30 caracteres")]
        [MinLength(5, ErrorMessage = "O email deve conter no mínimo 5 caracteres")]

        public string EmailUsuario { get; set; }

        [DisplayName("Senha")]
        [Required(ErrorMessage = "A senha é obrigatória")]
        [DataType(DataType.Password)]
        [MinLength(6, ErrorMessage = "A senha deve conter no mínimo 6 caracteres")]
        [MaxLength(14, ErrorMessage ="A senha deve conter no máximo 14 caracteres")]

        public string Senha { get; set; }

        
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FATEA.ProjetoPoster.Domain
{
    public class Usuario
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public int Rg { get; set; }
        public int Cpf { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public Enum Perfil { get; set; }

        public void fazerLogin() { }
                
        public void alterarSenha() { }

    }
}

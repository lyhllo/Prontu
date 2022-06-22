using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRONTU.Model
{
    public class UsuarioModel
    {
        public UsuarioModel ()
        {
            Contato = new ContatoModel();
        }

        public int Id_usuario { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Registro_profissional { get; set; }
        public string Profissao { get; set; }
        public string Especialidade { get; set; }
        public string Senha { get; set; }
        public ContatoModel Contato { get; set; }
    }
}

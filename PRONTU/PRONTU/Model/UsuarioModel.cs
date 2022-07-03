using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRONTU.Model
{
    public class UsuarioModel
    {
        public int Id_usuario { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Registro_profissional { get; set; }
        public string Profissao { get; set; }
        public string Especialidade { get; set; }
        public string Senha { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Bairro { get; set; }
        public string Complemento { get; set; }
        public string Cidade { get; set; }
        public string Uf { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
    }
}

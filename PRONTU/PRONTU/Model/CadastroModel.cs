using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRONTU.Model
{
    public class CadastroModel
    {
        public int Id_Paciente { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Responsavel_Nome { get; set; }
        public string Responsavel_CPF { get; set; }
        public DateTime Data_Cadastro { get; set; }
        public string Convenio { get; set; }
        public string Convenio_Codigo { get; set; }
        public string Observacoes { get; set; }
        public int Id_contato { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Bairro { get; set; }
        public string Complemento { get; set; }
        public string Cidade { get; set; }
        public string UF { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
    }
}

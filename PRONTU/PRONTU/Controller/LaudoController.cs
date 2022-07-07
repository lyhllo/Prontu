using MySql.Data.MySqlClient;
using PRONTU.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRONTU.Controller
{
    internal class LaudoController
    {
        private Connection c;
        private string sql;

        public List<LaudoModel> RetornarDadosDoProfissional(int _idUsuario)
        {
            try
            {
                c = new Connection();

                var _laudo = new List<LaudoModel>();

                sql = " SELECT usuario.nome_usuario," +
                      "        usuario.profissao," +
                      "        usuario.registro_prof," +
                      "        usuario.cidade," +
                      "        usuario.uf," +
                      "        usuario.telefone," +
                      "        usuario.email," +
                      "        '' as cabecalho," +
                      "        '' as titulo" +
                      "   FROM usuario" +
                      "  WHERE usuario.id_usuario = " + _idUsuario;

                MySqlDataReader rdr = c.QueryData(sql);

                if (rdr != null)
                {
                    while (rdr.Read())
                    {
                        LaudoModel laudo = new LaudoModel();

                        laudo.Nome = Convert.ToString(rdr["nome_usuario"]);
    
                        if (rdr["profissao"] != DBNull.Value)
                        {
                            laudo.Profissao = Convert.ToString(rdr["profissao"]);
                        }
                        else
                        {
                            laudo.Profissao = "";
                        }

                        if (rdr["registro_prof"] != DBNull.Value)
                        {
                            laudo.Registro_profissional = Convert.ToString(rdr["registro_prof"]);
                        }
                        else
                        {
                            laudo.Registro_profissional = "";
                        }

                        if (rdr["cidade"] != DBNull.Value)
                        {
                            laudo.Cidade = Convert.ToString(rdr["cidade"]);
                        }
                        else
                        {
                            laudo.Cidade = "";
                        }

                        if (rdr["uf"] != DBNull.Value)
                        {
                            laudo.Uf = Convert.ToString(rdr["uf"]);
                        }
                        else
                        {
                            laudo.Uf = "";
                        }

                        if (rdr["telefone"] != DBNull.Value)
                        {
                            laudo.Telefone = Convert.ToString(rdr["telefone"]);
                        }
                        else
                        {
                            laudo.Telefone = "";
                        }

                        if (rdr["email"] != DBNull.Value)
                        {
                            laudo.Email = Convert.ToString(rdr["email"]);
                        }
                        else
                        {
                            laudo.Email = "";
                        }

                        laudo.Cabecalho = Convert.ToString(rdr["cabecalho"]);
                        laudo.Titulo = Convert.ToString(rdr["titulo"]);

                        _laudo.Add(laudo);
                    }
                }

                c.Close();
                return _laudo;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return null;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using PRONTU.Model;

namespace PRONTU.Controller
{
    internal class AjustesController
    {
        private Connection c;
        private string sql;

        public bool InserirAjustes(AjustesModel _ajustes)
        {
            try
            {
                c = new Connection();

                sql = "INSERT INTO agenda " +
                      "VALUES (" + _ajustes.id_usuario + ","
                                 + _ajustes.id_agenda + ","
                                 + _ajustes.formato_minutos + ","
                                 + _ajustes.mostrar_valor + ","
                                 + _ajustes.marcador_comparecimento + ","
                                 + _ajustes.marcador_pagamento + ")";


                c.NonQuery(sql);

                c.Close();
                return true;
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }

        public AjustesModel BuscarAjustesUsuario(int _idUsuario)
        {
            try
            {
                c = new Connection();

                var _ajustes = new AjustesModel();

                sql = "SELECT * " +
                        "FROM agenda " +
                       "WHERE agenda.id_usuario = " + _idUsuario;

                MySqlDataReader rdr = c.QueryData(sql);

                if (rdr != null)
                {
                    while (rdr.Read())
                    {
                        _ajustes.id_usuario = Convert.ToInt32(rdr["id_usuario"]);
                        _ajustes.id_agenda = Convert.ToInt32(rdr["id_agenda"]);
                        _ajustes.formato_minutos = Convert.ToInt32(rdr["formato_minutos"]);
                        _ajustes.mostrar_valor = Convert.ToBoolean(rdr["mostrar_valor"]);
                        _ajustes.marcador_pagamento = Convert.ToBoolean(rdr["marcador_pagamento"]);
                        _ajustes.marcador_comparecimento = Convert.ToBoolean(rdr["marcador_comparecimento"]);


                    }
                }
                c.Close();
                return _ajustes;
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return null;
            }
        }

        public bool AtualizarAjustesUsuario(AjustesModel _ajustes)
        {
            try
            {
                c = new Connection();

                sql = "UPDATE agenda " +
                         "SET agenda.formato_minutos = " + _ajustes.formato_minutos + "," +
                             "agenda.mostrar_valor = " + _ajustes.mostrar_valor + "," +
                             "agenda.marcador_comparecimento = " + _ajustes.marcador_comparecimento + "," +
                             "agenda.marcador_pagamento = " + _ajustes.marcador_pagamento +
                       " WHERE agenda.id_usuario = " + _ajustes.id_usuario +
                        " AND agenda.id_agenda = " + _ajustes.id_agenda;

                c.NonQuery(sql);
                c.Close();

                return true;
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }

        public Boolean RemoverAjustesUsuario(int _idUsuario)
        {
            try
            {
                c = new Connection();

                sql = sql = " DELETE " +
                               "FROM agenda" +
                              "WHERE agenda.id_usuario = " + _idUsuario;

                c.NonQuery(sql);

                return true;
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }
    }
}

// fazer insert padrão com as config para o um novo usuario
// fazer o select pra buscar as confirgurações quando o usuario acessar
// os update sem casos de atualizações
// delete em caso de exclusão de usuário
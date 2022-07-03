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


        public bool InserirAjustes(int _idUsuario, int _idAgenda)
        {
            try
            {
                c = new Connection();

                sql = "INSERT INTO agenda " +
                      "VALUES (" + _idUsuario + _idAgenda + "60, true, true, true);";

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

        public List<AjustesModel> BuscarAjustesUsuario(int _idUsuario)
        {
            try
            {
                c = new Connection();

                var _agenda = new List<AjustesModel>();

                sql = "SELECT * " +
                        "FROM agenda " +
                       "WHERE agenda.id_usuario = " + _idUsuario;

                MySqlDataReader rdr = c.QueryData(sql);

                c.Close();
                return _agenda;
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return null;
            }
        }

        public bool AtualizarAjustesUsuario(int _idUsuario, int _idAgenda, int _formatoMinutos, bool _marcadorComparecimento, bool _marcadorPagto, bool _mostrarValor)
        {
            try
            {
                c = new Connection();

                var _ajuste = new List<AjustesModel>();

                sql = "UPDATE agenda " +
                         "SET agenda.formato_minutos = " + _formatoMinutos + "," +
                             "agenda.mostrar_valor = " + _mostrarValor + "," +
                             "agenda.marcador_comparecimento = " + _marcadorComparecimento + "," +
                             "agenda.marcador_pagamento = " + _marcadorPagto + "," +
                       "WHERE agenda.id_usuario = " + _idUsuario +
                        " AND agenda.id_agenda = " + _idAgenda;

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

                object result = c.Query(sql);

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
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using PRONTU.Model;

namespace PRONTU.Controller
{
    internal class PacienteCadastroController
    {
        private Connection c;
        private string sql;
        private MySqlDataReader rdr;
        public bool CadastraPaciente(CadastroModel _cadastro)
        {
            try
            {
                c = new Connection();

                sql = "INSERT INTO paciente" +
                    "       VALUES ( 1," +
                                    _cadastro.Id_Paciente                            + ", " +
                    "   '" +        _cadastro.Nome                                   + "', " +
                    "   '" +        _cadastro.Cpf                                    + "', " +
                    "   '" +        _cadastro.Dt_nasc.Value.ToString("yyyy-MM-dd")   + "', " +
                    "   '" +        _cadastro.Responsavel_CPF                        + "', " +
                    "   '" +        _cadastro.Responsavel_Nome                       + "', " +
                    "   '" +        _cadastro.Convenio                               + "', " +
                    "   '" +        _cadastro.Convenio_Codigo                        + "', " +
                    "   '" +        _cadastro.Observacoes                            + "', " +
                    "   '" +        _cadastro.Logradouro                             + "', " +
                    "   '" +        _cadastro.Numero                                 + "', " +
                    "   '" +        _cadastro.Bairro                                 + "', " +
                    "   '" +        _cadastro.Complemento                            + "', " +
                    "   '" +        _cadastro.Cidade                                 + "', " +
                    "   '" +        _cadastro.UF                                     + "', " +
                    "   '" +        _cadastro.Telefone                               + "', " +
                    "   '" +        _cadastro.Email                                  + "', " +
                    "   '" +        _cadastro.CEP                                    + ") ";

                c.NonQuery(sql);

                c.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool EditaPaciente(CadastroModel _cadastro)
        {
            try
            {
                c = new Connection();

                sql = "UPDATE paciente" +
                    "     SET paciente.nome = '" + _cadastro.Nome + "', " +
                    "         paciente.cpf  = '" + _cadastro.Cpf + "', " +
                    "         paciente.dt_nasc  = '" + _cadastro.Dt_nasc.Value.ToString("yyyy-MM-dd") + "', " +
                    "         paciente.responsavel_cpf  = '" + _cadastro.Responsavel_CPF + "', " +
                    "         paciente.responsavel_nome = '" + _cadastro.Responsavel_Nome + "', " +
                    "         paciente.convenio = '" + _cadastro.Convenio + "', " +
                    "         paciente.convenio_codigo = '" + _cadastro.Convenio_Codigo + "', " +
                    "         paciente.observacoes = '" + _cadastro.Observacoes + "', " +
                    "         paciente.logradouro   = '" + _cadastro.Logradouro + "', " +
                    "         paciente.numero = '" + _cadastro.Numero + "', " +
                    "         paciente.bairro = '" + _cadastro.Bairro + "', " +
                    "         paciente.complemento = '" + _cadastro.Complemento + "', " +
                    "         paciente.cidade = '" + _cadastro.Cidade + "', " +
                    "         paciente.uf   = '" + _cadastro.UF + "', " +
                    "         paciente.telefone = '" + _cadastro.Telefone + "', " +
                    "         paciente.email = '" + _cadastro.Email + "', " +
                    "         paciente.cep = '" + _cadastro.CEP + "' " +
                    "   WHERE paciente.id_usuario = 1" +
                    "     AND paciente.id_paciente = " + _cadastro.Id_Paciente ;

                c.NonQuery(sql);

                c.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public int NovoIdPaciente()
        {
            int _id = 0;
            try
            {
                c = new Connection();

                sql = "SELECT max(paciente.id_paciente) as id" +
                    "    FROM paciente " +
                    "   WHERE paciente.id_usuario = 1";

                rdr = c.QueryData(sql);

                if (rdr != null)
                {
                    while (rdr.Read())
                    {
                        _id = Convert.ToInt32(rdr["id"]);
                    }
                }

                c.Close();

                return _id + 1;
            }
            catch (Exception ex)
            {

                return _id;
            }
        }

        private int NovoIdContato()
        {
            int _id = 0;
            try
            {
                c = new Connection();

                sql = "SELECT max(contato.id_contato) + 1" +
                    "    FROM contato " +
                    "   WHERE contato.id_usuario = 1";

                rdr = c.QueryData(sql);

                if (rdr != null)
                {
                    while (rdr.Read())
                    {
                        _id = Convert.ToInt32(rdr["id_paciente"]);
                    }
                }

                c.Close();

                return _id;
            }
            catch (Exception ex)
            {

                return _id;
            }
        }

        public List<CadastroModel> BuscaCadastrosPacientes()
        {
            try
            {
                c = new Connection();

                var _cadastro = new List<CadastroModel>();

                sql = "select paciente.id_paciente," +
                      "       paciente.nome," +
                      "       paciente.cpf," +
                      "		  paciente.dt_nasc," +
                      "		  paciente.responsavel_cpf," +
                      "		  paciente.responsavel_nome," +
                      "		  paciente.convenio," +
                      "		  paciente.convenio_codigo," +
                      "		  paciente.observacoes," +
                      "		  paciente.logradouro," +
                      "		  paciente.numero," +
                      "		  paciente.bairro," +
                      "		  paciente.complemento," +
                      "		  paciente.cidade," +
                      "		  paciente.uf," +
                      "		  paciente.telefone," +
                      "		  paciente.email" +
                      "  from paciente" +
                      " where paciente.id_usuario = 1" +
                      " order by paciente.nome " ;

                MySqlDataReader rdr = c.QueryData(sql);

                if (rdr != null)
                {
                    while (rdr.Read())
                    {
                        CadastroModel cadastroModel = new CadastroModel();
                        cadastroModel.Id_Paciente = Convert.ToInt32(rdr["id_paciente"]);

                        cadastroModel.Nome = Convert.ToString(rdr["nome"]);

                        if (rdr["cpf"] != DBNull.Value)
                        {
                            cadastroModel.Cpf = Convert.ToString(rdr["cpf"]);
                        }
                        else
                        {
                            cadastroModel.Cpf = null;
                        }

                        if (rdr["dt_nasc"] != DBNull.Value)
                        {
                            cadastroModel.Dt_nasc = Convert.ToDateTime(rdr["dt_nasc"]);
                        }
                        else
                        {
                            cadastroModel.Dt_nasc = null;
                        }

                        if (rdr["responsavel_cpf"] != DBNull.Value)
                        {
                            cadastroModel.Responsavel_CPF = Convert.ToString(rdr["responsavel_cpf"]);
                        }
                        else
                        {
                            cadastroModel.Responsavel_CPF = null;
                        }

                        if (rdr["responsavel_nome"] != DBNull.Value)
                        {
                            cadastroModel.Responsavel_Nome = Convert.ToString(rdr["responsavel_nome"]);
                        }
                        else
                        {
                            cadastroModel.Responsavel_Nome = null;
                        }

                        if (rdr["convenio"] != DBNull.Value)
                        {
                            cadastroModel.Convenio = Convert.ToString(rdr["convenio"]);
                        }
                        else
                        {
                            cadastroModel.Convenio = null;
                        }

                        if (rdr["convenio_codigo"] != DBNull.Value)
                        {
                            cadastroModel.Convenio_Codigo = Convert.ToString(rdr["convenio_codigo"]);
                        }
                        else
                        {
                            cadastroModel.Convenio_Codigo = null;
                        }

                        if (rdr["observacoes"] != DBNull.Value)
                        {
                            cadastroModel.Observacoes = Convert.ToString(rdr["observacoes"]);
                        }
                        else
                        {
                            cadastroModel.Observacoes = null;
                        }

                        if (rdr["logradouro"] != DBNull.Value)
                        {
                            cadastroModel.Logradouro = Convert.ToString(rdr["logradouro"]);
                        }
                        else
                        {
                            cadastroModel.Logradouro = null;
                        }

                        if (rdr["numero"] != DBNull.Value)
                        {
                            cadastroModel.Numero = Convert.ToString(rdr["numero"]);
                        }
                        else
                        {
                            cadastroModel.Numero = null;
                        }

                        if (rdr["bairro"] != DBNull.Value)
                        {
                            cadastroModel.Bairro = Convert.ToString(rdr["bairro"]);
                        }
                        else
                        {
                            cadastroModel.Bairro = null;
                        }

                        if (rdr["complemento"] != DBNull.Value)
                        {
                            cadastroModel.Complemento = Convert.ToString(rdr["complemento"]);
                        }
                        else
                        {
                            cadastroModel.Complemento = null;
                        }

                        if (rdr["cidade"] != DBNull.Value)
                        {
                            cadastroModel.Cidade = Convert.ToString(rdr["cidade"]);
                        }
                        else
                        {
                            cadastroModel.Cidade = null;
                        }

                        if (rdr["uf"] != DBNull.Value)
                        {
                            cadastroModel.UF = Convert.ToString(rdr["uf"]);
                        }
                        else
                        {
                            cadastroModel.UF = null;
                        }

                        if (rdr["telefone"] != DBNull.Value)
                        {
                            cadastroModel.Telefone = Convert.ToString(rdr["telefone"]);
                        }
                        else
                        {
                            cadastroModel.Telefone = null;
                        }

                        if (rdr["email"] != DBNull.Value)
                        {
                            cadastroModel.Email = Convert.ToString(rdr["email"]);
                        }
                        else
                        {
                            cadastroModel.Email = null;
                        }

                        _cadastro.Add(cadastroModel);
                    }
                }

                c.Close();
                return _cadastro;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return null;
            }

        }
    }
}
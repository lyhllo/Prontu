using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PRONTU.Model;

namespace PRONTU.Controller
{
    internal class Agenda
    {
        public bool Login<AgendaModel>(string u, string s)
        {
            Connection c = new Connection();

            string sql = "SELECT * FROM usuario WHERE cpf='" + u + "' AND senha='" + s + "';";

            object result = c.Query(sql);

            if (result != null)
            {
                c.Close();
                return true;
            }
            else
            {
                c.Close();
                return false;
            }
        }
    }
}

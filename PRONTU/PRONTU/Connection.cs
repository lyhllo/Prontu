using MySql.Data.MySqlClient;

namespace PRONTU
{
    public class Connection
    {

        public MySqlConnection conn;

        public Connection ()
        {
            string connStr = "server=localhost;user=root;database=prontu;port=3306;password=root";
            conn = new MySqlConnection(connStr);
            conn.Open ();
        }

        public object Query (string sql)
        {
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            object result = cmd.ExecuteScalar();
            return result;
        }

        public MySqlDataReader QueryData(string sql)
        {
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader rdr = cmd.ExecuteReader();
            return rdr;
        }

        public void NonQuery(string sql)
        {
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.ExecuteNonQuery();
        }

        public void Close()
        {
            conn.Close ();
        }
    }
}

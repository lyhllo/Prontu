using MySql.Data.MySqlClient;

namespace PRONTU
{
    public class Connection
    {

        public MySqlConnection conn;
        public MySqlCommand cmd;
        public MySqlTransaction transaction;

        public Connection ()
        {
            string connStr = "server=localhost;user=root;database=prontu;port=3306;password=root";
            conn = new MySqlConnection(connStr);
            conn.Open ();
        }

        public object Query (string sql)
        {
            if (transaction == null)
                cmd = new MySqlCommand(sql, conn);
            else
                cmd = new MySqlCommand(sql, conn, transaction);

            object result = cmd.ExecuteScalar();
            return result;
        }

        public MySqlDataReader QueryData(string sql)
        {
            if (transaction == null)
                cmd = new MySqlCommand(sql, conn);
            else
                cmd = new MySqlCommand(sql, conn, transaction);

            MySqlDataReader rdr = cmd.ExecuteReader();
            return rdr;
        }

        public void NonQuery(string sql)
        {
            if (transaction == null)
                cmd = new MySqlCommand(sql, conn, transaction);
            else
                cmd = new MySqlCommand(sql, conn);

            cmd.ExecuteNonQuery();
        }

        public void Close()
        {
            conn.Close();
        }

        public void BeginTransaction()
        {
            transaction = conn.BeginTransaction();
        }

    }
}

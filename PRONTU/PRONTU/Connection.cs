using MySql.Data.MySqlClient;

namespace PRONTU
{
    public class Connection
    {

        public MySqlConnection conn;

        public Connection ()
        {
            string connStr = "server=localhost;user=root;database=prontu;port=3306;password=";
            conn = new MySqlConnection(connStr);
            conn.Open ();
        }

        public object Query (string sql)
        {
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            object result = cmd.ExecuteScalar();
            return result;
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

        /*public static void Main()
        {
            string connStr = "server=localhost;user=root;database=prontu;port=3306;password=toor";
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();

                string sql = "SELECT COUNT(*) FROM Country";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                object result = cmd.ExecuteScalar();
                if (result != null)
                {
                    int r = Convert.ToInt32(result);
                    Console.WriteLine("Number of countries in the world database is: " + r);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            conn.Close();
            Console.WriteLine("Done.");
        }*/
    }
}

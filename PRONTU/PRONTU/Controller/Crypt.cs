using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BCrypt;

namespace PRONTU.Controller
{
    public class Crypt
    {
        public static string HashGeneration(string password)
        {
            // Configurations
            int workfactor = 10; // 2 ^ (10) = 1024 iterations.

            string salt = BCrypt.Net.BCrypt.GenerateSalt(workfactor);
            string hash = BCrypt.Net.BCrypt.HashPassword(password, salt);

            return hash;
        }

        public static bool PasswordCompare(string hash, string password)
        {
            if (hash != "" && password != "")
                return BCrypt.Net.BCrypt.Verify(password, hash);
            else
                return false;
        }
    }
}

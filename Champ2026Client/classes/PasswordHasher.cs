using BCrypt.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Champ2026Client.classes
{
    public static class PasswordHasher
    {
        public static string HashPassword(string password)
        {
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(password);
            return hashedPassword;
        }

        public static bool VerifyPassword(string hashedPassword, string verifingPassword)
        {
            return BCrypt.Net.BCrypt.Verify(verifingPassword, hashedPassword);
        }
    }
}

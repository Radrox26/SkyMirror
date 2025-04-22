using SkyMirror.Security.Interfaces;

namespace SkyMirror.Security.Utilities
{
    public class PasswordHasher : IPasswordHasher
    {
        public string HashPassword(string password)
        {
            return BC.EnhancedHashPassword(password, 13);
        }

        public bool VerifyPassword(string hashedPassword, string inputPassword)
        {
            return BC.EnhancedVerify(inputPassword, hashedPassword);
        }
    }
}

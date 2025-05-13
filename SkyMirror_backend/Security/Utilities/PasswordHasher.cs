using SkyMirror.Security.Interfaces;

namespace SkyMirror.Security.Utilities
{
    public class PasswordHasher : IPasswordHasher
    {
        public async Task<string> HashPassword(string password)
        {
            await Task.CompletedTask;
            return BC.EnhancedHashPassword(password, 13);
        }

        public async Task<bool> VerifyPassword(string hashedPassword, string inputPassword)
        {
            await Task.CompletedTask;
            return BC.EnhancedVerify(inputPassword, hashedPassword);
        }
    }
}

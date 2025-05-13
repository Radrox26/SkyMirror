﻿namespace SkyMirror.Security.Interfaces
{
    public interface IPasswordHasher
    {
        Task<string> HashPassword(string password);
        Task<bool> VerifyPassword(string hashedPassword, string inputPassword);
    }
}

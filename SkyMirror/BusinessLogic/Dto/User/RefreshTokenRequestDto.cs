﻿namespace SkyMirror.BusinessLogic.Dto.User
{
    public class RefreshTokenRequestDto
    {
        public string AccessToken { get; set; } = string.Empty;
        public string RefreshToken { get; set; } = string.Empty;
    }
}

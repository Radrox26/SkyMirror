﻿namespace SkyMirror.BusinessLogic.Dto.User
{
    public class ChangePasswordRequestDto
    {
        public string OldPassword { get; set; } = string.Empty;
        public string NewPassword { get; set; } = string.Empty;
        public string ConfirmNewPassword { get; set; } = string.Empty;

    }
}

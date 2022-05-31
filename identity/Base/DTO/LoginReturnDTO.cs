using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LicenseManager.DTO
{
    public enum ErrCode
    {
        Successfully = 0,
        NotExists,
        Looked,
        LoginInvalid,
        UserExist,
        Denied,
        PassWrong,
        RoleNotExist,
        PassWordIsSame,
        Unknown = -1
    };

    public class LoginReturnDTO
    {
        public static Dictionary<ErrCode, string> dictCodeMsgErr
            = new Dictionary<ErrCode, string>()
            {
                {ErrCode.NotExists, "The login name is not exists." },
                {ErrCode.Looked, "The user is locked." },
                {ErrCode.LoginInvalid, "Email or Phone number is invalid." },
                {ErrCode.UserExist, "The user already exists." },
                {ErrCode.Denied, "Access denied."},
                {ErrCode.PassWrong, "Password wrong." },
                {ErrCode.RoleNotExist, "The role is not exists." },
                {ErrCode.PassWordIsSame, "The password is " }
            };

        public LoginReturnDTO()
        {
        }

        public LoginReturnDTO(ErrCode errCode, string msg = "")
        {
            ErrorCode = (int)errCode;
            Msg = msg.Length > 0 ? msg : dictCodeMsgErr[errCode];
        }

        public int ErrorCode { get; set; } = 0;
        public string Msg { get; set; } = "";
        public string Token { get; set; } = "";
        public string Setting { get; set; } = "";
        public UserInfoDTO Info { get; set; }
    }
}
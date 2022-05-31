using System;

namespace LicenseManager.ViewModels
{
    public class UserDTO
    {
        public string UserName { get; set; }
        public string Firstname { get; set; }
        public string CompanyName { get; set; }
        public string Lastname { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Image { get; set; }
        public string PhoneNumber { get; internal set; }
    }

    public class UserUpdateDTO
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string CompanyName { get; set; }
        public string Image { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; internal set; }
    }
}
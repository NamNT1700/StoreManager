using System;
using System.Collections.Generic;

public class UserInfo
{
    /// <summary>
    /// TingId của user
    /// </summary>
    public Guid Id { get; set; }

    public string UserName { get; set; } = "";
    public string Email { get; set; } = "";
    public string PhoneNumber { get; set; } = "";

    /// <summary>
    /// Danh sách các Role của User
    /// </summary>
    public IList<string> Roles { get; set; }
}
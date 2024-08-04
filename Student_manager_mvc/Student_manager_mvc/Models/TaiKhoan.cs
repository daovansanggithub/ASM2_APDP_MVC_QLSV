using System;
using System.Collections.Generic;

namespace Student_manager_mvc.Models;

public partial class TaiKhoan
{
    public int AccountId { get; set; }

    public string? Username { get; set; }

    public string? Password { get; set; }

    public string? Phone { get; set; }

    public string? Address { get; set; }

    public string? Role { get; set; }
}

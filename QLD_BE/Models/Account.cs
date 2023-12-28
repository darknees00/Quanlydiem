using System;
using System.Collections.Generic;

namespace QLD_BE.Models;

public partial class Account
{
    public string Login { get; set; } = null!;

    public string Pass { get; set; } = null!;

    public string? HoTen { get; set; }

    public string? GioiTinh { get; set; }

    public string? Phone { get; set; }

    public string? Email { get; set; }

    public string? PhanQuyen { get; set; }
}

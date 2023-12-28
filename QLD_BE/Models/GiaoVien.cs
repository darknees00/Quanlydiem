using System;
using System.Collections.Generic;

namespace QLD_BE.Models;

public partial class GiaoVien
{
    public int Idgv { get; set; }

    public string? TenGv { get; set; }

    public string? GioiTinh { get; set; }

    public string? Phone { get; set; }

    public string? Email { get; set; }

    public virtual ICollection<HocPhan> HocPhans { get; set; } = new List<HocPhan>();
}

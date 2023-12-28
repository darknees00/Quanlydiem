using System;
using System.Collections.Generic;

namespace QLD_BE.Models;

public partial class HocPhan
{
    public int Idh { get; set; }

    public int? Idgv { get; set; }

    public string? TenHp { get; set; }

    public int? SoTc { get; set; }

    public virtual ICollection<Diem> Diems { get; set; } = new List<Diem>();

    public virtual GiaoVien? IdgvNavigation { get; set; }
}

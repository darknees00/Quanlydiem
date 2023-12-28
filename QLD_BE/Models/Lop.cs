using System;
using System.Collections.Generic;

namespace QLD_BE.Models;

public partial class Lop
{
    public int Idl { get; set; }

    public int? Idk { get; set; }

    public string? TenLop { get; set; }

    public virtual Khoa? IdkNavigation { get; set; }

    public virtual ICollection<SinhVien> SinhViens { get; set; } = new List<SinhVien>();
}

using System;
using System.Collections.Generic;

namespace QLD_BE.Models;

public partial class SinhVien
{
    public int Idsv { get; set; }

    public string? HoTen { get; set; }

    public DateOnly? NgaySinh { get; set; }

    public string? GioiTinh { get; set; }

    public string? DiaChi { get; set; }

    public int? Idl { get; set; }

    public virtual ICollection<Diem> Diems { get; set; } = new List<Diem>();

    public virtual Lop? IdlNavigation { get; set; }
}

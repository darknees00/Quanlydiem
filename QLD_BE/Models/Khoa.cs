using System;
using System.Collections.Generic;

namespace QLD_BE.Models;

public partial class Khoa
{
    public int Idk { get; set; }

    public string?TenKhoa { get; set; }

    public virtual ICollection<Lop> Lops { get; set; } = new List<Lop>();
}

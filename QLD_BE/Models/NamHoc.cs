using System;
using System.Collections.Generic;

namespace QLD_BE.Models;

public partial class NamHoc
{
    public int Idn { get; set; }

    public int? NamHoc1 { get; set; }

    public virtual ICollection<Diem> Diems { get; set; } = new List<Diem>();
}

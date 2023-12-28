using System;
using System.Collections.Generic;

namespace QLD_BE.Models;

public partial class Diem
{
    public int Idd { get; set; }

    public int? DiemCc { get; set; }

    public int? DiemLan1 { get; set; }

    public int? DiemLan2 { get; set; }

    public int? DiemCuoiKy { get; set; }

    public int? DiemTb { get; set; }

    public int? Idsv { get; set; }

    public int? Idh { get; set; }

    public int? Idn { get; set; }

    public virtual HocPhan? IdhNavigation { get; set; }

    public virtual NamHoc? IdnNavigation { get; set; }

    public virtual SinhVien? IdsvNavigation { get; set; }
}

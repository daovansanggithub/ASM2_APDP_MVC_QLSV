using System;
using System.Collections.Generic;

namespace Student_manager_mvc.Models;

public partial class LopHoc
{
    public string ClassId { get; set; } = null!;

    public string? ClassName { get; set; }

    public string? Teacher { get; set; }

    public virtual ICollection<DangKyHoc> DangKyHocs { get; set; } = new List<DangKyHoc>();
}

using System;
using System.Collections.Generic;

namespace Student_manager_mvc.Models;

public partial class MonHoc
{
    public string SubjectId { get; set; } = null!;

    public string? SubjectName { get; set; }

    public int? Credits { get; set; }

    public virtual ICollection<DangKyHoc> DangKyHocs { get; set; } = new List<DangKyHoc>();
}

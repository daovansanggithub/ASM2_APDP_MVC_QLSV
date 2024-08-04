using System;
using System.Collections.Generic;

namespace Student_manager_mvc.Models;

public partial class DangKyHoc
{
    public string EnrollmentId { get; set; } = null!;

	public string? StudentId { get; set; }

    public string? ClassId { get; set; }

    public string? SubjectId { get; set; }

    public virtual LopHoc? Class { get; set; }

    public virtual SinhVien? Student { get; set; }

    public virtual MonHoc? Subject { get; set; }
}

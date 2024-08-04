using System;
using System.Collections.Generic;

namespace Student_manager_mvc.Models;

public partial class SinhVien
{
    public string StudentId { get; set; } = null!;

    public string? FullName { get; set; }

    public DateOnly? DateOfBirth { get; set; }

    public string? Address { get; set; }

    public string? Point {  get; set; }

    public string? Phone { get; set; }

    public string? Email { get; set; }

    public virtual ICollection<DangKyHoc> DangKyHocs { get; set; } = new List<DangKyHoc>();
}

using Microsoft.AspNetCore.Mvc;
using Student_manager_mvc.Models;
using System.Diagnostics;

namespace Student_manager_mvc.Controllers
{
    public class HomeController : Controller
    {
        QuanLySinhVienMvcContext db = new QuanLySinhVienMvcContext();

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

		public IActionResult Page_Home()
		{
            // khai báo list , 
            List<SinhVien> students = new List<SinhVien>();
            students = db.SinhViens.ToList();

            // Truyền danh sách học sinh tới View để hiển thị
            return View(students);
        }

		public IActionResult Dangky()
		{
			return View();
		}
        [HttpPost]
		public IActionResult Dangky(DangKyHoc dangky)
		{
			var Check_id_dangky = db.DangKyHocs.Find(dangky.EnrollmentId);
			var Check_id_sinhvien = db.SinhViens.Find(dangky.StudentId);

			if (Check_id_dangky != null)
			{
				ViewBag.err = "Id đã tồn tại";
			}

            if (dangky.EnrollmentId == null)
            {
                ViewBag.err = "Vui lòng không để trong trường đầu tiên";
            }
            if (dangky.StudentId == null)
            {
                ViewBag.err = "Vui lòng nhập Mã học sinh";
            }
            /*if (Check_id_sinhvien != null)
			{
				ViewBag.err = "Id sinh viên Không chính xác";
			}*/
            else
			{
				if (ModelState.IsValid)
				{
					db.DangKyHocs.Add(dangky);
					db.SaveChanges();

					ViewBag.err = "Đã đăng ký thành công";
				}
			}
			return View(dangky);
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

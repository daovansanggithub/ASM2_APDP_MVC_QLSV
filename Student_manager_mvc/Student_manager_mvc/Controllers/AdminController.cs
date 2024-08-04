using Microsoft.AspNetCore.Mvc;
using Student_manager_mvc.Models;
using System.Diagnostics;

namespace Student_manager_mvc.Controllers
{
    public class AdminController : Controller
    {
        private readonly ILogger<AdminController> _logger;

        QuanLySinhVienMvcContext db = new QuanLySinhVienMvcContext();
        public AdminController(ILogger<AdminController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        // ================================== quản lí học sinh ==========================

        // hiển thị danh sách học sinh
        public IActionResult manager_student()
        {
            // khai báo list , 
            List<SinhVien> students = new List<SinhVien>();
            students = db.SinhViens.ToList();

			// Truyền danh sách học sinh tới View để hiển thị
			return View(students);
			
        }



        // thêm danh sách học sinh
        public IActionResult Add_student()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add_student(SinhVien sv)
        {
            var Check_id = db.SinhViens.Find(sv.StudentId);
            if (Check_id != null)
            {
                ViewBag.err = "Id đã tồn tại";
            }
            else
            {
                if (ModelState.IsValid)
                {
                    db.SinhViens.Add(sv);
                    db.SaveChanges();

                    return RedirectToAction("manager_student", "Admin");
                }
            }

            return View(sv);
        }

        // Sửa học sinh
        public IActionResult Edit_student(string id)
        {
            var search_id = db.SinhViens.Find(id);

            return View(search_id);
        }

        [HttpPost]
        public IActionResult Edit_student(SinhVien sv)
        {
            if (ModelState.IsValid)
            {
                db.SinhViens.Update(sv);
                db.SaveChanges();
                return RedirectToAction("manager_student", "Admin");
            }
            return View(sv);
        }

        // xóa tài khoản
        public IActionResult Delete_student(string id)
        {
            var user = db.SinhViens.Find(id);
            if (user != null)
            {
                db.SinhViens.Remove(user);
                db.SaveChanges();
                return RedirectToAction("manager_student", "Admin");
            }
            return View();
        }


        // ================================== quản lí tài khoản người dùng (thêm sủa xóa)    ============================
        // quan li tai khoan

        // hiển thị tài khoản
        public IActionResult manager_account()
        {
            // khai báo list , 
            List<TaiKhoan> tk = new List<TaiKhoan>();
            tk = db.TaiKhoans.ToList();

            // Truyền danh sách học sinh tới View để hiển thị
            return View(tk);
        }

        // thêm danh sách tài khoản
        public IActionResult Add_account()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add_account(TaiKhoan acc)
        {
            var Check_id = db.TaiKhoans.Find(acc.AccountId);
            if (Check_id != null)
            {
                ViewBag.err = "Id đã tồn tại";
            }
            else
            {
                if (ModelState.IsValid)
                {
                    db.TaiKhoans.Add(acc);
                    db.SaveChanges();

                    return RedirectToAction("manager_account", "Admin");
                }
            }

            return View(acc);
        }

        // Sửa tài khoản
        public IActionResult Edit_account(int id)
        {
            var search_id = db.TaiKhoans.Find(id);
            
            return View(search_id);
        }

        [HttpPost]
        public IActionResult Edit_account(TaiKhoan acc)
        {
            if (ModelState.IsValid)
            {
                db.TaiKhoans.Update(acc);
                db.SaveChanges();
                return RedirectToAction("manager_account", "Admin");
            }
            return View(acc);
        }

        // xóa tài khoản
        public IActionResult Delete_account(int id)
        {
            var user = db.TaiKhoans.Find(id);
            if (user != null)
            {
                db.TaiKhoans.Remove(user);
                db.SaveChanges();
                return RedirectToAction("manager_account", "Admin");
            }
            return View();
        }




        // test
        public IActionResult test_them()
        {
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

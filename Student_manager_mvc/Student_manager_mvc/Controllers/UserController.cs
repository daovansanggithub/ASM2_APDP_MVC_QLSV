using Microsoft.AspNetCore.Mvc;
using Student_manager_mvc.connect;
using Student_manager_mvc.Models;
using System.Diagnostics;


namespace Student_manager_mvc.Controllers
{
    public class UserController : Controller
    {
        private readonly ILogger<UserController> _logger;

        public UserController(ILogger<UserController> logger)
        {
            _logger = logger;
        }

        // code đăng nhập
        // http get
        public IActionResult Login()
        {
            return View();
        }

        // http post
        [HttpPost]        
		public IActionResult Login(string username, string password)
		{
            map_acount map = new map_acount();
            var user = map.tim_tk(username, password);
            // có thì sang trang admin
            if (user != null)
            {
                /*return Redirect("/Admin/manager_student");
*/
                if(user.Role == "admin")
                {
                    return RedirectToAction("manager_account", "Admin");
                }
                else
                {
                    return Redirect("~/Home/Page_Home");
                }
				

			}
            ViewBag.err = "Tên đăng nhập hoặc mật khẩu không đúng";
			return View();
		}

        // đăng ký tài khoản
		public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(TaiKhoan acc)
        {
            
            map_acount map = new map_acount();



            if (map.cre_tk(acc) == true)
            {
                return RedirectToAction("Login", "User");
            }
            else
            {
                return View(acc);
            }

        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

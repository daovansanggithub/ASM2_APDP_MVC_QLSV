using System;
using Student_manager_mvc.Models;
using System.Linq;

namespace Student_manager_mvc.connect
{
	public class map_acount
	{
		// kết nối
		QuanLySinhVienMvcContext db = new QuanLySinhVienMvcContext();

		public TaiKhoan tim_tk(string username, string password)
		{
			// tìm kiếm trong data
			var user = db.TaiKhoans.Where(m=>m.Username == username & m.Password == password).ToList();
			
			// thấy đối tượng trả về đối tượng đầu của mảng, ko thấy trả null
			if (user.Count > 0 )
			{
				return user[0];
			}
			else
			{
				return null;
			}


        }

		// dang ky

        public Boolean cre_tk(TaiKhoan tk)
        {
			
			try
			{
                // ad đối tượng vào đata
                // luu lại
                db.TaiKhoans.Add(tk);
                db.SaveChanges();
                return true;
            }
			catch (Exception ex)
			{
				return false;
			}

        }
    }

	
}

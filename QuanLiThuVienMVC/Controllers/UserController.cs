using QuanLiThuVienMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace QuanLiThuVienMVC.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        thuvienEntities thuvien = new thuvienEntities();
        // GET: UserAdmin
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(NguoiDung _user)
        {
            var checkaccount = thuvien.NguoiDung.Where(s => s.Email == _user.Email && s.MatKhau == _user.MatKhau).FirstOrDefault();
            if (checkaccount == null)
            {
                ViewBag.ErrorInFo = "SaiInfo";
                return View("Index");
            }
            else
            {
                if (_user.Email == "chiminh521@gmail.com" && _user.MatKhau == "27")
                {
                    thuvien.Configuration.ValidateOnSaveEnabled = false;
                    Session["name"] = _user.Email;
                    return RedirectToAction("Index", "Sach/");
                }
                else
                {
                    thuvien.Configuration.ValidateOnSaveEnabled = false;
                    Session["name"] = _user.Email;
                    return RedirectToAction("Index", "Sach/Indexuser");
                }
            }
        }
        public ActionResult logout()
        {
            Session.Abandon();
            return RedirectToAction("Index");
        }
        public ActionResult Resgin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Resgin(NguoiDung user)
        {
            if (ModelState.IsValid)
            {
                var checkid = thuvien.NguoiDung.Where(f => f.MaNguoiDung == user.MaNguoiDung).FirstOrDefault();
                if (checkid == null)
                {
                    thuvien.NguoiDung.Add(user);
                    thuvien.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.errocResgin("tai khoan da ton tai");
                    return RedirectToAction("Resgin");
                }
            }
            return View();
        }
        public ActionResult ForgetPassword()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ForgetPassword(string SoDienThoai)
        {
            if (string.IsNullOrEmpty(SoDienThoai))
            {
                ViewBag.Error = "Vui lòng nhập Email.";
                return View();
            }

            var matchingAccounts = thuvien.NguoiDung.Where(e => e.Email == SoDienThoai).ToList();

            if (matchingAccounts.Count == 0)
            {
                ViewBag.Error = "Không tìm thấy tài khoản này.";
                return View();
            }

            var user = matchingAccounts.FirstOrDefault();
            var email = user.Email; // Lấy email của người dùng
            var resetLink = Url.Action("UpdatePassword", "User", new { email = email }, Request.Url.Scheme);
            var mailService = new MailService();
            Task.Run(() => mailService.SendMailAsync(email, "Cập Nhật Mật Khẩu", $"Nhấn <a href='{resetLink}'>vào đây</a> để cập nhật mật khẩu của bạn."));

            ViewBag.Success = "Liên kết cập nhật mật khẩu đã được gửi đến email của bạn.";
            return View();
        }

        // GET: Cập Nhật Mật Khẩu
        public ActionResult UpdatePassword(string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                return HttpNotFound();
            }

            var user = thuvien.NguoiDung.FirstOrDefault(u => u.Email == email);
            if (user == null)
            {
                ViewBag.Error = "Không tìm thấy tài khoản.";
                return View();
            }

            ViewBag.Email = email; // Lưu email vào ViewBag để truyền vào form
            return View(user);
        }


        [HttpPost]
        public ActionResult UpdatePassword(string email, string newPassword, string confirmPassword)
        {
            // Kiểm tra điều kiện hợp lệ
            if (string.IsNullOrEmpty(newPassword) || string.IsNullOrEmpty(confirmPassword))
            {
                ViewBag.Error = "Vui lòng nhập đầy đủ thông tin.";
                ViewBag.Email = email; // Trả lại email vào form
                return View();
            }

            if (newPassword != confirmPassword)
            {
                ViewBag.Error = "Mật khẩu không khớp. Vui lòng nhập lại.";
                ViewBag.Email = email; // Trả lại email vào form
                return View();
            }

            // Tìm người dùng bằng email
            var user = thuvien.NguoiDung.FirstOrDefault(u => u.Email == email);

            if (user == null)
            {
                ViewBag.Error = "Không tìm thấy tài khoản.";
                return View();
            }

            // Cập nhật mật khẩu
            user.MatKhau = newPassword; // Mã hóa mật khẩu trước khi lưu nếu cần
            thuvien.SaveChanges();

            ViewBag.Success = "Cập nhật mật khẩu thành công.";
            return RedirectToAction("Index"); // Chuyển hướng về trang khác nếu cần
        }
        
    }
}

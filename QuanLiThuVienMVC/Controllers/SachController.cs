using QuanLiThuVienMVC.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace QuanLiThuVienMVC.Controllers
{
    public class SachController : Controller
    {
        thuvienEntities thuvien = new thuvienEntities();
        public ActionResult Index(string category)
        {

            if (category == null)
            {
                var productList = thuvien.Sach.OrderByDescending(x => x.TieuDe);
                return View(productList);
            }
            else
            {
                var productList = thuvien.Sach.OrderByDescending(x => x.TieuDe)
                .Where(x => x.TheLoai == category);
                return View(productList);
            }

        }
        public ActionResult Indexuser(string category)
        {

            if (category == null)
            {
                var productList = thuvien.Sach.OrderByDescending(x => x.TieuDe);
                return View(productList);
            }
            else
            {
                var productList = thuvien.Sach.OrderByDescending(x => x.TieuDe)
                .Where(x => x.TheLoai == category);
                return View(productList);
            }

        }
        public ActionResult Create()
        {
            Sach sach1 = new Sach();
            return View(sach1);
        }
        [HttpPost]

        public ActionResult Create(Sach sach1)
        {
            try
            {
                if (sach1.UploadImage != null)
                {
                    string filename = Path.GetFileNameWithoutExtension(sach1.UploadImage.FileName);
                    string extent = Path.GetExtension(sach1.UploadImage.FileName);
                    filename = filename + extent;
                    sach1.Imagesach = "~/Content/images/" + filename;
                    sach1.UploadImage.SaveAs(Path.Combine(Server.MapPath("~/Content/images/"), filename));
                }
                thuvien.Sach.Add(sach1);
                thuvien.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        public ActionResult Edit(int id)
        {
            var product = thuvien.Sach.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        [HttpPost]
        public ActionResult Edit(Sach sach1)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var existingProduct = thuvien.Sach.Find(sach1.MaSach);
                    if (existingProduct == null)
                    {
                        return HttpNotFound();
                    }

                    // Cập nhật thông tin sách
                    existingProduct.TieuDe = sach1.TieuDe;
                    existingProduct.TacGia = sach1.TacGia;
                    existingProduct.TheLoai = sach1.TheLoai;
                    existingProduct.ISBN = sach1.ISBN;
                    existingProduct.NamXuatBan = sach1.NamXuatBan;
                    existingProduct.NhaXuatBan = sach1.NhaXuatBan;
                    existingProduct.TongSoBan = sach1.TongSoBan;
                    existingProduct.SoBanKhaDung = sach1.SoBanKhaDung;
                    existingProduct.ViTri = sach1.ViTri;

                    // Cập nhật hình ảnh nếu có
                    if (sach1.UploadImage != null)
                    {
                        string filename = Path.GetFileNameWithoutExtension(sach1.UploadImage.FileName);
                        string extent = Path.GetExtension(sach1.UploadImage.FileName);
                        filename = filename + extent;
                        existingProduct.Imagesach = "~/Content/images/" + filename;
                        sach1.UploadImage.SaveAs(Path.Combine(Server.MapPath("~/Content/images/"), filename));
                    }

                    // Lưu thay đổi vào database
                    thuvien.SaveChanges();

                    return RedirectToAction("Index");
                }
                return View(sach1);
            }
            catch
            {
                return View();
            }
        }
        public ActionResult Details(int id)
        {
            var product = thuvien.Sach.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }
        public ActionResult Delete(int id)
        {
            var pro = thuvien.Sach.Find(id);
            if (pro == null)
            {
                return HttpNotFound();
            }
            return View(pro);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var product = thuvien.Sach.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            // Xóa sản phẩm
            thuvien.Sach.Remove(product);
            thuvien.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Search(string searchString)
        {
            var productList = thuvien.Sach.OrderByDescending(x => x.TieuDe);

            if (!string.IsNullOrEmpty(searchString))
            {
                productList = (IOrderedQueryable<Sach>)productList.Where(x => x.TieuDe.Contains(searchString));
            }

            return View("Index", productList.ToList());
        }
        public ActionResult Searchuser(string searchString)
        {
            var productList = thuvien.Sach.OrderByDescending(x => x.TieuDe);

            if (!string.IsNullOrEmpty(searchString))
            {
                productList = (IOrderedQueryable<Sach>)productList.Where(x => x.TieuDe.Contains(searchString));
            }
            var email = "minhchi521@gmail.com"; // Replace with the actual email or retrieve it dynamically
            var mailService = new MailService();
            Task.Run(() => mailService.SendMailAsync(email, "Test new", "Sản phẩm mượn bị quá hạn"));
            return View("Indexuser", productList.ToList());
        }
        public ActionResult AdvancedSearch(string title, string author, string category, int? year)
        {
            var books = thuvien.Sach.AsQueryable();

            if (!string.IsNullOrEmpty(title))
            {
                books = books.Where(b => b.TieuDe.Contains(title));
            }

            if (!string.IsNullOrEmpty(author))
            {
                books = books.Where(b => b.TacGia.Contains(author));
            }

            if (!string.IsNullOrEmpty(category))
            {
                books = books.Where(b => b.TheLoai.Contains(category));
            }

            if (year.HasValue)
            {
                books = books.Where(b => b.NamXuatBan == year.Value);
            }

            return View("Index", books.ToList());
        }
        public ActionResult AdvancedSearchuser(string title, string author, string category, int? year)
        {
            var books = thuvien.Sach.AsQueryable();

            if (!string.IsNullOrEmpty(title))
            {
                books = books.Where(b => b.TieuDe.Contains(title));
            }

            if (!string.IsNullOrEmpty(author))
            {
                books = books.Where(b => b.TacGia.Contains(author));
            }

            if (!string.IsNullOrEmpty(category))
            {
                books = books.Where(b => b.TheLoai.Contains(category));
            }

            if (year.HasValue)
            {
                books = books.Where(b => b.NamXuatBan == year.Value);
            }

            return View("Indexuser", books.ToList());
        }
    }
}
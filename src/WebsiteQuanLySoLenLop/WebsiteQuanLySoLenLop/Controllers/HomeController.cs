using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteQuanLySoLenLop.common;
using WebsiteQuanLySoLenLop.Models;

namespace WebsiteQuanLySoLenLop.Controllers
{
    public class HomeController : Controller
    {
        QuanLySoLenLopEntities db = new QuanLySoLenLopEntities();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AdminLogin()
        {

            return View();
        }
        [HttpPost]
        public ActionResult AdminLogin(Admin admin)
        {
            var username = admin.Username;
            //var encryptedMd5Pas = Encryptor.EncryptMD5(admin.Password);
            //admin.Password = encryptedMd5Pas;
            var password = admin.Password;
            var usercheck = db.Admins.SingleOrDefault(x => x.Username.Equals(username) && x.Password.Equals(password));
            if (usercheck != null)
            {
                Session["admin"] = usercheck;
                return RedirectToAction("Index", "Admins");
            }
            else
            {
                ViewBag.LoginFail = "Đăng nhập thất bại, vui lòng kiểm tra lại!";
                return View("AdminLogin");
            }
        }

        public ActionResult Logout()
        {
            if (Session["admin"] != null)
            {
                Session["admin"] = null;
            }
            if (Session["User"] != null)
            {
                Session["User"] = null;
            }
            return RedirectToAction("Index", "Home");
        }

        public ActionResult UserLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult UserLogin(GiangVien User)
        {
            var MaGV = User.MaGVGD;
            var encryptedMd5Pas = Encryptor.EncryptMD5(User.Matkhau);
            User.Matkhau = encryptedMd5Pas;
            var MatKhau = User.Matkhau;
            var usercheck = db.GiangViens.SingleOrDefault(x => x.MaGVGD.Equals(MaGV) && x.Matkhau.Equals(MatKhau));
            if (usercheck != null)
            {
                Session["User"] = usercheck;
                return RedirectToAction("Index", "GiangViens");
            }
            else
            {
                ViewBag.LoginFail = "Đăng nhập thất bại, vui lòng kiểm tra lại!";
                return View("UserLogin");
            }
        }
    }
}
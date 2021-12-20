using KioskManagementApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;

namespace KioskManagementApp.Controllers
{
    public class AdminController : Controller
    {
        // GET: Dashboard
        public ActionResult Dashboard()
        {
            if(Session["UserId"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }  

        // GET: Login
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        // POST: Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string Username, string Password)
        {
            if (ModelState.IsValid)
            {
                using (var ctx = new AppDbContext())
                {
                    var data = ctx.User
                        .Where(s => s.Username == Username
                        && s.Password == Password).FirstOrDefault();

                    if (data != null)
                    {
                        // Thêm session
                        Session["UserId"] = data.UserId.ToString();
                        Session["Username"] = data.Username.ToString();
                        return RedirectToAction("Dashboard");
                    }
                    else
                    {
                        ViewBag.Error = "Đăng nhập không thành công";
                        return RedirectToAction("Login");
                    }
                }
            }
                return View();
        }
        
        public ActionResult Logout()
        {
            // Xoá Session
            Session.Clear();
            return RedirectToAction("Login");
        }
    }
}
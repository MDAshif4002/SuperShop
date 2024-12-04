using E_Commerce.Models;
using E_Commerce.Services;
using Microsoft.AspNetCore.Mvc;
using System;
namespace E_Commerce.Controllers
{
    public class PublicController : Controller
    {
        public AppDbContext _context;
        public EmailSender _emailSender;
        
        public PublicController(AppDbContext context,EmailSender emailSender)
        {
            _context = context;
            _emailSender = emailSender;
        }
        public IActionResult Index()
        {
            var data = _context.slider.ToList();
            var data1 = _context.miniproduct.ToList();
            var data2 = _context.product.ToList();
            var data3 = _context.womenproduct.ToList();
            var alldata = new HomePage
            {
                slider = data,
                miniproduct = data1,
                product = data2,
                womenproduct = data3,
            };
            return View(alldata);
        }
        public IActionResult AdminLogin()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AdminLogin(string email, string password)
        {
            var data = _context.adminlogin.FirstOrDefault(x => x.email == email && x.password == password);
            if(data !=  null)
            {
                HttpContext.Session.SetString("admin", email);
                return RedirectToAction("Index","Admin");
            }
            else
            {
                TempData["msg"] = "Email or Password Is Incorrect...";
                return RedirectToAction("AdminLogin");
            }
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SaveRegister(register r, string email)
        {
            var data = _context.register.FirstOrDefault(x => x.email == email);
            if(data != null)
            {
                Random rnd = new Random();
                int num = rnd.Next(10000, 99999);

                HttpContext.Session.SetString("otp", num.ToString());
                HttpContext.Session.SetString("email", email);

                string sendto = email;
                string subject = "OTP For Confirmation";
                string mail = "Dear User, OTP For Confirmation is - " +num;
                await _emailSender.SendEmailAsync(sendto, subject, mail);
            }
            
            _context.register.Add(r);
            _context.SaveChanges();
            return RedirectToAction("OTP", "Public");
        }
        public IActionResult OTP()
        {
            return View();
        }
        [HttpPost]
        public IActionResult OTP(string otp)
        {
            string originalotp = HttpContext.Session.GetString("otp");
            if(originalotp == otp)
            {
                string email = HttpContext.Session.GetString("email");
                var data = _context.register.FirstOrDefault(x => x.email == email);

                data.otp = otp;
                _context.register.Update(data);
                _context.SaveChanges();
                return RedirectToAction("Register","Public");
            }
            else
            {
                TempData["msg"] = "OTP Is Incorrect...";
                return RedirectToAction("OTP","Public");
            }
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(string email, string password)
        {
            var data = _context.register.FirstOrDefault(x => x.email == email && x.password == password);
            if(data != null)
            {
                HttpContext.Session.SetString("user", "email");
                return RedirectToAction("Index", "User");
            }
            else
            {
                TempData["msg"] = "Email or Password Is Incorrect...";
                return RedirectToAction("Login");
            }
        }
        public IActionResult Product()
        {
            var data = _context.product.ToList();
            return View(data);
        }
        public IActionResult WomenProduct()
        {
            var data = _context.womenproduct.ToList();
            return View(data);
        }
    }
}

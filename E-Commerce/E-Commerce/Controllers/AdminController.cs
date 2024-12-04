using E_Commerce.Models;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.Controllers
{
    public class AdminController : Controller
    {
        public AppDbContext _context;
        public IWebHostEnvironment _environment;
        public AdminController(AppDbContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("admin") == null)
            {
                return RedirectToAction("Index", "Public");
            }
            return View();
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Public");
        }
        public IActionResult Slider()
        {
            if(HttpContext.Session.GetString("admin") == null)
            {
                return RedirectToAction("Index","Public");
            }
            var data = _context.slider.ToList();
            return View(data);
        }
        [HttpPost]
        public async Task<IActionResult> AddSlider(IFormFile image)
        {
            string folderpath = Path.Combine(_environment.WebRootPath, "slider");
            string filename = image.FileName;
            string filepath = Path.Combine(folderpath, filename);
            var stream = new FileStream(filepath, FileMode.Create);
            await image.CopyToAsync(stream);

            slider s = new slider();
            s.image = filename;

            _context.slider.Add(s);
            _context.SaveChanges();

            return RedirectToAction("Slider","Admin");
        }
        public IActionResult DeleteSlider(int id)
        {
            var data = _context.slider.Find(id);
            string filename = data.image;
            if(filename != null)
            {
                string folderpath = Path.Combine(_environment.WebRootPath, "slider");
                string filepath = Path.Combine(folderpath, filename);
                if(System.IO.File.Exists(filepath))
                {
                    System.IO.File.Delete(filepath);
                }
            }
            _context.slider.Remove(data);
            _context.SaveChanges();
            return RedirectToAction("Slider","Admin");
        }
        public IActionResult MiniProduct()
        {
            var data = _context.miniproduct.ToList();
            return View(data);
        }
        [HttpPost]
        public async Task<IActionResult> AddMiniProduct(miniproduct m,IFormFile mpropic)
        {
            string folderpath = Path.Combine(_environment.WebRootPath, "miniproduct");
            string filename = mpropic.FileName;
            string filepath = Path.Combine(folderpath, filename);
            var stream = new FileStream(filepath, FileMode.Create);
            await mpropic.CopyToAsync(stream);
            m.mpropic = filename;

            _context.miniproduct.Add(m);
            _context.SaveChanges();
            return RedirectToAction("MiniProduct","Admin");
        }
        public IActionResult MiniProductDelete(int id)
        {
            var data = _context.miniproduct.Find(id);
            string filename = data.mpropic;
            if(filename != null)
            {
                string folderpath = Path.Combine(_environment.WebRootPath, "miniproduct");
                string filepath = Path.Combine(folderpath, filename);
                if (System.IO.File.Exists("filepath"))
                {
                    System.IO.File.Delete("filepath");
                }
            }
            _context.miniproduct.Remove(data);
            _context.SaveChanges();
            return RedirectToAction("MiniProduct", "Admin");
        }
        public IActionResult ManageRegister()
        {
            var data = _context.register.ToList();
            return View(data);
        }
        public IActionResult RegisterDelete(int id)
        {
            var data = _context.register.Find(id);
            _context.register.Remove(data);
            _context.SaveChanges();
            return RedirectToAction("ManageRegister");
        }
        public IActionResult ManageMenCloth()
        {
            var data = _context.product.ToList();
            return View(data);
        }
        [HttpPost]
        public async Task<IActionResult> AddMenProduct(product p, IFormFile productimage)
        {
            string folderpath = Path.Combine(_environment.WebRootPath, "menproduct");
            string filename = productimage.FileName;
            string filepath = Path.Combine(folderpath, filename);
            var stream = new FileStream(filepath, FileMode.Create);
            await productimage.CopyToAsync(stream);

            p.productimage = filename;

            _context.product.Add(p);
            _context.SaveChanges();
            return RedirectToAction("ManageMenCloth","Admin");
        }
        public IActionResult ManageMenClothDelete(int id)
        {
            var data = _context.product.Find(id);
            string filename = data.productimage;
            if(filename != null)
            {
                string folderpath = Path.Combine(_environment.WebRootPath, "menproduct");
                string filepath = Path.Combine(folderpath, filename);
                if(System.IO.File.Exists(filepath))
                {
                    System.IO.File.Delete(filepath);
                }
            }
            _context.product.Remove(data);
            _context.SaveChanges();
            return RedirectToAction("ManageMenCloth", "Admin");
        }
        public IActionResult ManageWomenProduct()
        {
            var data =_context.womenproduct.ToList();
            return View(data);
        }
        [HttpPost]
        public async Task<IActionResult> AddWomenProduct(womenproduct w,IFormFile productimg)
        {
            string folderpath = Path.Combine(_environment.WebRootPath, "womenproduct");
            string filename = productimg.FileName;
            string filepath = Path.Combine(folderpath, filename);
            var stream = new FileStream(filepath,FileMode.Create);
            await productimg.CopyToAsync(stream);
            w.productimg = filename;

            _context.womenproduct.Add(w);
            _context.SaveChanges();
            return RedirectToAction("ManageWomenProduct","Admin");
        }
    }
}

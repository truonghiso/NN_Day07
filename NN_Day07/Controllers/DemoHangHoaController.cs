using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NN_Day07.Models;

namespace NN_Day07.Controllers
{
    public class DemoHangHoaController : Controller
    {
        static List<HangHoa> dsHangHoa = new List<HangHoa>();
        public IActionResult Index()
        {
            return View(dsHangHoa);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(HangHoa hh, IFormFile Image)
        {
            if (Image != null)
            {
                var fileName = $"{DateTime.Now.Ticks}_{Image.FileName}";
                var fullPath = System.IO.Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "products", fileName);
                hh.Image = fileName;
                using (var file = new FileStream(fullPath, FileMode.Create))
                {
                    Image.CopyTo(file);
                    dsHangHoa.Add(hh);
                    return Redirect("/DemoHangHoa");    //Đường dẫn " " nằm bên folder Controller
                }
            }
            return View();
        }
    }
}
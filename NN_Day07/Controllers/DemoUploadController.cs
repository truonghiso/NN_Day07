using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace NN_Day07.Controllers
{
    public class DemoUploadController : Controller
    {
        public IActionResult Upload()
        {
            return View();
        }

        public IActionResult UploadSingleFile(IFormFile myfile)
        {
            if (myfile != null)
            {
                var filename = System.IO.Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "data", myfile.FileName);

                //var file = new FileStream(filename, FileMode.Create);
                //myfile.CopyTo(file);
                //file.Close();

                using (var filestream = new FileStream(filename, FileMode.Create))
                {
                    myfile.CopyTo(filestream);
                }
            }
            return RedirectToAction("Upload", "DemoUpload");
        }

        public IActionResult UploadMultipleFile(List<IFormFile> mymultiple)
        {
            if (mymultiple != null)
            {
                foreach (var fileUpload in mymultiple)
                {
                    var filename = System.IO.Path.Combine(Directory.GetCurrentDirectory(), "Documents", DateTime.Now.Ticks.ToString() + fileUpload.FileName);

                    //var file = new FileStream(filename, FileMode.Create);
                    //myfile.CopyTo(file);
                    //file.Close();

                    using (var filestream = new FileStream(filename, FileMode.Create))
                    {
                        fileUpload.CopyTo(filestream);
                    }
                }
            }
            return RedirectToAction("Upload", "DemoUpload");
        }
    }
}


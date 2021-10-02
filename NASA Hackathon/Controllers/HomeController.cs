using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NASA_Hackathon.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

namespace NASA_Hackathon.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Level1()
        {
            return View();
        }

        public IActionResult Level2()
        {
            return View();
        }

        public IActionResult Level3()
        {
            return View(new Level3Model());
        }

        [HttpPost]
        public IActionResult Level3(string base64image)
        {
            double concentration = 0;//濃度
            //影像數組
            string Base64String = base64image.Replace("data:image/jpeg;base64,", String.Empty);
            byte[] imageBytes = Convert.FromBase64String(Base64String);
            Bitmap bmp;
            using (var ms = new System.IO.MemoryStream(imageBytes))
            {
                bmp = new Bitmap(ms);
            }
            Antibody antibody = new Antibody(bmp);
            if (antibody.PeakIntensity.Count >= 2)
            { concentration = antibody.CaculateConcentration(antibody.PeakIntensity[1]); }
            else
            {//彈出訊息 無抗體濃度
            }
            return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

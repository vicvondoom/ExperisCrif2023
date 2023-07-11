using EseWebTemperature.Models;
using Microsoft.AspNetCore.Mvc;

namespace EseWebTemperature.Controllers
{
    public class ConverterController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(TempViewModel tvm)
        {
            decimal fahr = (tvm.Celsius * 5 / 9) + 32;
            ViewBag.Messaggio = tvm.Celsius + "° celsius sono " + fahr.ToString("#.00") + "° fahrenheit";
            return View();
        }
    }
}

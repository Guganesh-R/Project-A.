using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TMS1.Models;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using TMS1.Areas.Identity.Data;
using System.Data;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace TMS1.Controllers
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

            //using (TMS1Context dbContext = new DataTMS1Context1())
            //{
            //    TransportDetails = (from b in dbContext.EmployeeInfo
            //                        where b.APIStatus == "API2-Pass" || b.APIStatus == "API2-Fail"
            //                        select b.BolHeaderID).Distinct().ToList();
            //}
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}






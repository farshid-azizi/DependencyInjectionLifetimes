using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TransientVsScopedVsSingleton.Models;
using TransientVsScopedVsSingleton.Services;

namespace TransientVsScopedVsSingleton.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ITransientService _transientService1;
        private readonly ITransientService _transientService2;

        private readonly IScopedService _scopedService1;
        private readonly IScopedService _scopedService2;

        private readonly ISingletonService _singletonService1;
        private readonly ISingletonService _singletonService2;


        public HomeController(ILogger<HomeController> logger,
            ITransientService transientService1,
            ITransientService transientService2,
            IScopedService scopedService1,
            IScopedService scopedService2,
            ISingletonService singletonService1,
            ISingletonService singletonService2
            )
        {
            _logger = logger;
            _transientService1 = transientService1;
            _transientService2 = transientService2;

            _scopedService1 = scopedService1;
            _scopedService2 = scopedService2;

            _singletonService1 = singletonService1;
            _singletonService2 = singletonService2;
        }

        public IActionResult Index()
        {
            ViewBag.message1 = "First Instance " + _transientService1.GetID().ToString();
            ViewBag.message2 = "Second Instance " + _transientService2.GetID().ToString();


            ViewBag.message3 = "First Instance " + _scopedService1.GetID().ToString();
            ViewBag.message4 = "Second Instance " + _scopedService2.GetID().ToString();

            ViewBag.message5 = "First Instance " + _singletonService1.GetID().ToString();
            ViewBag.message6 = "Second Instance " + _singletonService2.GetID().ToString();

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
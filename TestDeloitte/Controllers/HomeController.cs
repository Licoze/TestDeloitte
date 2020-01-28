using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TestDeloitte.Models;
using TestDeloitte.Services;

namespace TestDeloitte.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IModelExtractionService<List<UserDetailsModel>> _modelExctractionService;

        public HomeController(ILogger<HomeController> logger,
                              IModelExtractionService<List<UserDetailsModel>> modelExctractionService)
        {
            _logger = logger;
            _modelExctractionService = modelExctractionService;
        }

        public IActionResult Index(string tag)
        {

            var model = _modelExctractionService.ExctractModelFromFile().ToList<UserModel>();
            if (!string.IsNullOrEmpty(tag))
            {
                model = model.Where(m => m.Tags.Contains(tag)).ToList();
            }
            return View(model );
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Details(Guid guid)
        {
            var model = _modelExctractionService.ExctractModelFromFile().Where(u => u.Guid == guid).FirstOrDefault();
            return View(model);
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

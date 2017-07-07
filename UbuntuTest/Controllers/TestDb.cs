using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace UbuntuTest.Controllers
{
    public class TestDb : Controller
    {
        private readonly ILogger _logger;
        public TestDb(ILogger<TestDb> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult New()
        {
            _logger.LogInformation("***You have pressed the new button!!***");
            _logger.LogWarning("***This is a warning!!!***");
            return View("Index");
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Web.Helpers;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly RequestHelper _requestHelper;
        private readonly ILogger<HomeController> _logger;

        public HomeController(
          RequestHelper requestHelper,
          ILogger<HomeController> logger)
        {
            _requestHelper = requestHelper;
            _logger = logger;
        }

        public IActionResult Index()
        {
            var data = _requestHelper.GetData();
            return View(data);
        }

        public IActionResult RequestData()
        {
            var data = _requestHelper.GetData();
            return PartialView("_RequestData", data);
        }
    }
}
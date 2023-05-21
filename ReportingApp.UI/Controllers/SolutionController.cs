using Microsoft.AspNetCore.Mvc;

namespace ReportingApp.UI.Controllers
{
    public class SolutionController : Controller
    {
        public IActionResult Index()
        {
            return this.View();
        }
    }
}

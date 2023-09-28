using Microsoft.AspNetCore.Mvc;
using ReportingApp.Application.Email;
using ReportingApp.UI.Models;
using System.Diagnostics;

namespace ReportingApp.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> logger;
        private readonly IEmailService emailService;

        public HomeController(ILogger<HomeController> logger, IEmailService emailService)
        {
            this.logger = logger;
            this.emailService = emailService;
        }

        public IActionResult Index()
        {
            return this.View();
        }

        public IActionResult Privacy()
        {
            return this.View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return this.View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SendEmail(EmailModel emailModel)
        {
            var result = await this.emailService.SendEmailAsync(emailModel);

            if (result)
            {
                return this.StatusCode(StatusCodes.Status200OK, "OK");
            }
            else
            {
                return this.StatusCode(StatusCodes.Status400BadRequest);
            }
        }
    }
}
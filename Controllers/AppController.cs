using DutchTreat.Data;
using DutchTreat.Services;
using DutchTreat.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;

namespace DutchTreat.Controllers
{
    public class AppController : Controller
    {
        private readonly IMailService mailService;
        private readonly IDutchRepository repository;

        public AppController(IMailService MailService, IDutchRepository repository)
        {
            mailService = MailService;
            this.repository = repository;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Shop()
        {
            return View(repository.GetAllProducts());
        }
        [HttpGet("contact")]

        public IActionResult Contact()
        {
            return View();
        }

        [HttpPost("contact")]
        public IActionResult Contact(ContactViewModel model)
        {
            if (ModelState.IsValid)
            {
                mailService.SendMail(model.Name, "jasonb@property24.com", model.Email, model.Message, model.Subject);
                ViewBag.UserMessage = "Mail Sent!";
            } else { }
            return View();
        }

        public IActionResult About()
        {
            ViewBag.Title = "About Us";
            return View();
        }
    }
}

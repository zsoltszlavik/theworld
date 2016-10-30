using Microsoft.AspNet.Mvc;
using System;
using TheWorld.ViewModels;
using TheWorld.Services;
using TheWorld.Models;
using System.Linq;

namespace TheWorld.Controllers.Web
{
    public class AppController : Controller
    {
        private IMailService _mailService;
        private IWorldRepository _repository;

        public AppController(IMailService service, IWorldRepository repository)
        {
            _mailService = service;
            _repository = repository;
        }
        public IActionResult Index()
        {
            var trips = _repository.GetAllTrips();
            return View(trips);
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Contact(ContactViewModel model)
        {
            //Do validation, not only on the client side
            if (ModelState.IsValid)
            {

                var email = Startup.Configuration["AppSettings:SiteEmailAddress"];

                if (string.IsNullOrWhiteSpace(email))
                {
                    ModelState.AddModelError("", "Could not send email, configuration problem"); //Displays on the View
                }

                if (_mailService.SendMail("",
                      "",
                      $"Contact Page from {model.Name} ({model.Email})",
                      model.Message))
                {
                    ModelState.Clear(); // Clears the Form

                    //Message is my name of choice - colud be ViewBag.Foo, this is a dynamic object
                    ViewBag.Message = "Mail Sent. Thanks";
                }
            }
            return View();
        }
    }
}
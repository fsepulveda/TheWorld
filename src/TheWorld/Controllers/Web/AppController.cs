using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TheWorld.ViewModels;
using TheWorld.Services;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace TheWorld.Controllers.Web
{
    public class AppController : Controller
    {
        private IMailService _mailService;

        public AppController(IMailService service)
        {
            _mailService = service;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
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
            if (ModelState.IsValid)
            {
                if (string.IsNullOrWhiteSpace("email"))
                {
                    ModelState.AddModelError("", "Could not send email ");
                }
                if (_mailService.SendMail("",
                                 "",
                                 $"Contact page from {model.Name}, ({model.Email})",
                                 model.Message
                                 ))
                {
                    ModelState.Clear();
                    ViewBag.Message = "Mail Sent, Thanks!";
                }
            }

            return View();
        }
    }
}

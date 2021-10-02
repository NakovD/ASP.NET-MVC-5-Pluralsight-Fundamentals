using OddToFood.Web.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OddToFood.Web.Controllers
{
    public class GreetingController : Controller
    {
        // GET: Greeting
        public ActionResult Index()
        {
            var viewModel = new GreetingViewModel();
            viewModel.Message = ConfigurationManager.AppSettings.Get("message");
            return View(viewModel);
        }
    }
}
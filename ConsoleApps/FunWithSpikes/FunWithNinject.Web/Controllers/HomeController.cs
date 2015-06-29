using FunWithNinject.Web.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FunWithNinject.Web.Controllers
{
    public class HomeController : Controller
    {
        private IService _service;

        public HomeController(IService service)
        {
            _service = service;
        }

        public ActionResult Index()
        {
            ViewBag.Title = _service.Title;
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = _service.AboutMessage;

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
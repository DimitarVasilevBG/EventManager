using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EventManagerWeb.Models;
using EventManager.Services;
using EventManager.Models.ViewModels;

namespace EventManagerWeb.Controllers
{
    public class HomeController : Controller
    {
        EventService EventsService = new EventService();
        public IActionResult Index()
        {
            var model = new EventViewListingModel();
            model.events = EventsService.GetEvents().ToList();
            return View(model);
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

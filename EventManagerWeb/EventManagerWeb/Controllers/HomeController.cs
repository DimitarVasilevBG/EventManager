using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using EventManagerWeb.Models;
using EventManager.Services;
using EventManager.Models.ViewModels;
using AutoMapper;

namespace EventManagerWeb.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var model = new EventViewListingModel();
            model.events = EventService.GetEvents().ToList();
            return View(model);
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

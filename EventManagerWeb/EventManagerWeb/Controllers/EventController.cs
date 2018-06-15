using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EventManager.Database.DbModels;
using EventManager.Models.Models;
using EventManager.Models.ViewModels;
using EventManager.Services;
using Microsoft.AspNetCore.Mvc;

namespace EventManagerWeb.Controllers
{
    public class EventController : Controller
    {
        EventService EventsService = new EventService();
        
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(CreateViewModel model)
        {
            if (!ModelState.IsValid)
            {
               
                return View(model);
            }
            var eventObj = new Event(model.ID,model.Name, model.Location, model.StartTime, model.EndTime);
            EventsService.CreateEvent(eventObj);
            return Redirect("/");
        }
        public IActionResult Edit(int ID)
        {
            var dbEvent = EventsService.FindByID(ID);
            return View(dbEvent);
        }
        [HttpPost]
        public IActionResult Edit(int ID,CreateViewModel model)
        {
            if (!ModelState.IsValid)
            {
                var eventDbModel = new EventDbModel();
                eventDbModel.ID = model.ID;
                eventDbModel.Name = model.Name;
                eventDbModel.Location = model.Location;
                eventDbModel.StartTime = model.StartTime;
                eventDbModel.EndTime = model.EndTime;

                return View(eventDbModel);
            }
            EventsService.EditEvent(model);
            return Redirect("/");
        }
        public IActionResult Delete(int ID)
        {
            var dbEvent = EventsService.FindByID(ID);
            EventsService.Delete(dbEvent.ID);
            return Redirect("/");
        }
    }
}
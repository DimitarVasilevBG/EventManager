using EventManager.Database.DbModels;
using EventManager.Models.Models;
using EventManager.Models.ViewModels;
using EventManager.Services;
using Microsoft.AspNetCore.Mvc;
using AutoMapper.QueryableExtensions;
using AutoMapper;

namespace EventManagerWeb.Controllers
{
    public class EventController : Controller
    {
        private readonly IMapper _mapper;

        public EventController(IMapper mapper)
        {
            _mapper = mapper;
        }
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
            var eventObj = new Event(model.ID, model.Name, model.Location, model.StartTime, model.EndTime);
            var dbEventToCreate = _mapper.Map<EventDbModel>(eventObj);
            EventService.CreateEvent(dbEventToCreate);
            return Redirect("/");
        }
        public IActionResult Edit(int ID)
        {
            var dbEvent = EventService.FindByID(ID);
            return View(dbEvent);
        }
        [HttpPost]
        public IActionResult Edit(int ID, CreateViewModel model)
        {
            if (!ModelState.IsValid)
            {
                var eventDbModel = _mapper.Map<EventDbModel>(model);
                return View(eventDbModel);
            }
            EventService.EditEvent(model);
            return Redirect("/");
        }
        public IActionResult Delete(int ID)
        {
            var dbEvent = EventService.FindByID(ID);
            EventService.Delete(dbEvent.ID);
            return Redirect("/");
        }
    }
}
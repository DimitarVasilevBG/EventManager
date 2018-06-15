using EventManager.Database;
using EventManager.Database.DbModels;
using EventManager.Database.Repository.RepositoryModels;
using EventManager.Models.Models;
using EventManager.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EventManager.Services
{
    public class EventService
    {
        private EventsDbContext Context = new EventsDbContext();
        public ICollection<Event> GetEvents()
        {
            var EventsRepository = new EventDbRepository(Context);
            var dbEvents = EventsRepository.All().ToList();
            var events = new List<Event>();
            foreach (var dbEvent in dbEvents)
            {
                events.Add(new Event(dbEvent.ID,dbEvent.Name,dbEvent.Location, dbEvent.StartTime,dbEvent.EndTime));
            }
            return events;
        }
        public void CreateEvent(Event eventToSave)
        {
            var dbEvent = new EventDbModel();
            dbEvent.Name = eventToSave.Name;
            dbEvent.Location = eventToSave.Location;
            dbEvent.StartTime = eventToSave.StartTime;
            dbEvent.EndTime = eventToSave.EndTime;
            var eventRepository = new EventDbRepository(Context);
            eventRepository.Add(dbEvent,true);

        }
        public EventDbModel FindByID(int ID)
        {
            var eventRepository = new EventDbRepository(Context);
            var dbEvent = eventRepository.GetById(ID);

            return dbEvent;

        }
        public void EditEvent(CreateViewModel model)
        {
            var eventRepository = new EventDbRepository(Context);
            var dbEvent = eventRepository.GetById(model.ID);
            dbEvent.Name = model.Name;
            dbEvent.Location = model.Location;
            dbEvent.StartTime = model.StartTime;
            dbEvent.EndTime = model.EndTime;
            eventRepository.SaveChanges();
        }
        public void Delete(int id)
        {
            var EventsRepository = new EventDbRepository(Context);
            var eventToDelete = EventsRepository.GetById(id);
            EventsRepository.Delete(eventToDelete);
            EventsRepository.SaveChanges();
        }
    }
}

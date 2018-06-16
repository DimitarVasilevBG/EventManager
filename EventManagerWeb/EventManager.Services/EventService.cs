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
    public static class EventService
    {
        private static EventsDbContext Context = new EventsDbContext();
        private static EventDbRepository EventsRepository = new EventDbRepository(Context);
        public static ICollection<Event> GetEvents()
        {
            var dbEvents = EventsRepository.All().ToList();
            var events = new List<Event>();
            foreach (var dbEvent in dbEvents)
            {
                events.Add(new Event(dbEvent.ID, dbEvent.Name, dbEvent.Location, dbEvent.StartTime, dbEvent.EndTime));
            }
            return events;
        }
        public static void CreateEvent(EventDbModel eventToSave)
        {
            EventsRepository.Add(eventToSave, true);

        }
        public static EventDbModel FindByID(int id)
        {
            var dbEvent = EventsRepository.GetById(id);

            return dbEvent;

        }
        public static void EditEvent(CreateViewModel model)
        {
            var dbEvent = EventsRepository.GetById(model.ID);
            dbEvent.Name = model.Name;
            dbEvent.Location = model.Location;
            dbEvent.StartTime = model.StartTime;
            dbEvent.EndTime = model.EndTime;
            EventsRepository.SaveChanges();
        }
        public static void Delete(int id)
        {
            var eventToDelete = EventsRepository.GetById(id);
            EventsRepository.Delete(eventToDelete);
            EventsRepository.SaveChanges();
        }
    }
}

using EventManager.Database.DbModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace EventManager.Database.Repository.RepositoryModels
{
    public class EventDbRepository : BaseRepositoryModel<EventDbModel>
    {
        public EventDbRepository(EventsDbContext dBContext) : base(dBContext)
        {

        }

    }
}

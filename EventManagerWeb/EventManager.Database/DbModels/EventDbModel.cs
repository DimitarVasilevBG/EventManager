using System;
using System.Collections.Generic;
using System.Text;

namespace EventManager.Database.DbModels
{
    public class EventDbModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}

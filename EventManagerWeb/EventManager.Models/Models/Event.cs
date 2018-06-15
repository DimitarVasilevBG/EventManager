using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EventManager.Models.Models
{
    public class Event
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        public Event(int ID,string Name,string Location,DateTime StartTime,DateTime EndTime)
        {
            this.ID = ID;
            this.Name = Name;
            this.Location = Location;
            this.StartTime = StartTime;
            this.EndTime = EndTime;
        }
    }
}

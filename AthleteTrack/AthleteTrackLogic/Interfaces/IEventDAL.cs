using AthleteTrackLogic.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AthleteTrackLogic.Interfaces
{
    public interface IEventDAL
    {
        public Event GetEventDetails(int ID);

        public void AddEvent(Event @event);
    }
}
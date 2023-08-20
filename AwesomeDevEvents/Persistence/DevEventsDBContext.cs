using AwesomeDevEvents.Models;

namespace AwesomeDevEvents.Persistence
{
    public class DevEventsDBContext
    {
        public List<DevEventModels> DevEvents { get; set; }

        public DevEventsDBContext()
        {
            DevEvents = new List<DevEventModels>();
        }
    }
}

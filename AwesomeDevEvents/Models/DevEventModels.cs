namespace AwesomeDevEvents.Models
{
    public class DevEventModels
    {
        public DevEventModels()
        {
            Speaker = new List<DevEventSpeaker>();
        }

        public Guid Id { get; set; } // Guid é usado é criar identificadores unicos universais
        public string Title { get; set; }
        public string Description { get; set; }
        public List<DevEventSpeaker> Speaker { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsDeleted { get; set; }

        public void Update(string title, string description, DateTime startDate, DateTime endDate)
        {
            Title = title;
            Description = description;
            StartDate = startDate;
            EndDate = endDate;
        }

        public void Delete()
        {
            IsDeleted = true;
        }

    }
}

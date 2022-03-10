namespace EduHome_BackEndProject_.Models
{
    public class EventsTeachers
    {
        public int Id { get; set; }
        public int EventId { get; set; }
        public Event Event { get; set; }
        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}

namespace Resellio.Shared.Messages
{
    public class CourseNameChangedEvent
    {
        public string UserId { get; set; }
        public string CourseId { get; set; }
        public string UpdatedName { get; set; }
    }
}

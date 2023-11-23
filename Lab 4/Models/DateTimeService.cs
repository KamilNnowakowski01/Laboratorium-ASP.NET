namespace Lab_4.Models
{
    public class DateTimeService : IDateTimeService
    {
        public DateTime getCurrentDate() => DateTime.Now;
    }
}

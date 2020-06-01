namespace BerlinClock.Classes.DTO
{
    class BerlinClockTimeSpan
    {
        public bool SeconsSectionIsActive { get; set; }
        public bool[] FiveHoursRowItemsState { get; set; } = new bool[4];
        public bool[] OneHourRowItemsState { get; set; } = new bool[4];
        public bool[] FiveMinutesRowItemsState { get; set; } = new bool[11];
        public bool[] OneMinuteRowItemsState { get; set; } = new bool[4];
    }
}

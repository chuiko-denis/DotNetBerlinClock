using System.Text.RegularExpressions;
using BerlinClock.Classes.DTO;

namespace BerlinClock.Classes.Engine.TimeParsers
{
    class StringToBerlinClockTimeSpanParser : ITimeParser<string, BerlinClockTimeSpan>
    {
        public BerlinClockTimeSpan Parse(string timeRepresentation)
        {
            var regex = new Regex(@"^(?<hours>[0-2][0-4])\:(?<minutes>[0-6]\d)\:(?<seconds>[0-6]\d)$");
            var timeParts = regex.Match(timeRepresentation);

            int hours = int.Parse(timeParts.Groups["hours"].Value);
            int minutes = int.Parse(timeParts.Groups["minutes"].Value);
            int seconds = int.Parse(timeParts.Groups["seconds"].Value);

            var result = new BerlinClockTimeSpan
            {
                SeconsSectionIsActive = GetSecondsItemState(seconds),
                FiveHoursRowItemsState = GetFiveHoursItemsRowState(hours),
                OneHourRowItemsState = GetOneHourItemsRowState(hours),
                FiveMinutesRowItemsState = GetFiveMinutesItemsRowState(minutes),
                OneMinuteRowItemsState = GetOneMinuteItemsRowState(minutes)
            };

            return result;
        }

        bool GetSecondsItemState(int seconds)
        {
            var result = (seconds & 1) == 0;

            return result;
        }

        bool[] GetFiveHoursItemsRowState(int hours)
        {
            var result = new bool[4];
            for (int i = 0; i < hours / 5; i++)
            {
                result[i] = true;
            }

            return result;
        }

        bool[] GetOneHourItemsRowState(int hours)
        {
            var result = new bool[4];
            for (int i = 0; i < hours % 5; i++)
            {
                result[i] = true;
            }

            return result;
        }

        bool[] GetFiveMinutesItemsRowState(int minutes)
        {
            var result = new bool[11];
            for (int i = 0; i < minutes / 5; i++)
            {
                result[i] = true;
            }

            return result;
        }

        bool[] GetOneMinuteItemsRowState(int minutes)
        {
            var result = new bool[4];
            for (int i = 0; i < minutes % 5; i++)
            {
                result[i] = true;
            }

            return result;
        }
    }
}

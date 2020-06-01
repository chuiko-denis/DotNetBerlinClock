using System.Linq;
using System.Text;
using BerlinClock.Classes.DTO;

namespace BerlinClock.Classes.Engine.TimeDecorators
{
    class BerlinClockTimeSpanDecorator : ITimeDecorator<BerlinClockTimeSpan, string>
    {
        public string Decorate(BerlinClockTimeSpan timeSpan)
        {
            var totalResult = new StringBuilder();
            totalResult.AppendLine(BuildSecondsStateRepresentation(timeSpan));
            totalResult.AppendLine(BuildFiveHoursItemsRowRepresentation(timeSpan));
            totalResult.AppendLine(BuildOneHourItemsRowRepresentation(timeSpan));
            totalResult.AppendLine(BuildFiveMinutesItemsRowRepresentation(timeSpan));
            totalResult.Append(BuildOneMinuteItemsRowRepresentation(timeSpan));

            var res = totalResult.ToString();

            return res;
        }

        string BuildSecondsStateRepresentation(BerlinClockTimeSpan timeSpan)
        {
            var result = timeSpan.SeconsSectionIsActive ? "Y" : "O";

            return result;
        }

        string BuildFiveHoursItemsRowRepresentation(BerlinClockTimeSpan timeSpan)
        {
            var result = string.Join("", timeSpan.FiveHoursRowItemsState.Select(i => i ? "R" : "O"));

            return result;
        }

        string BuildOneHourItemsRowRepresentation(BerlinClockTimeSpan timeSpan)
        {
            var result = string.Join("", timeSpan.OneHourRowItemsState.Select(i => i ? "R" : "O"));

            return result;
        }

        string BuildFiveMinutesItemsRowRepresentation(BerlinClockTimeSpan timeSpan)
        {
            var result = string.Join("", timeSpan.FiveMinutesRowItemsState.Select((b, i) =>
                    b
                        ? (i + 1) % 3 == 0
                            ? 'R'
                            : 'Y'
                        : 'O'
                )
            );

            return result;
        }

        string BuildOneMinuteItemsRowRepresentation(BerlinClockTimeSpan timeSpan)
        {
            var result = string.Join("", timeSpan.OneMinuteRowItemsState.Select(i => i ? "Y" : "O"));

            return result;
        }
    }
}

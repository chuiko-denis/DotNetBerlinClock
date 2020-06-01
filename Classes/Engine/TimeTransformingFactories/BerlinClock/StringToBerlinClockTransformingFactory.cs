using BerlinClock.Classes.DTO;
using BerlinClock.Classes.Engine.TimeDecorators;
using BerlinClock.Classes.Engine.TimeParsers;

namespace BerlinClock.Classes.Engine.TimeTransformingFactories.BerlinClock
{
    sealed class StringToBerlinClockTransformingFactory 
        : TimeTransformingFactory<string, BerlinClockTimeSpan, string>
    {
        StringToBerlinClockTransformingFactory(StringToBerlinClockTimeSpanParser timeParser, BerlinClockTimeSpanDecorator timeDecorator) 
            : base(timeParser, timeDecorator)
        {
        }

        public static StringToBerlinClockTransformingFactory Build()
        {
            var factory = new StringToBerlinClockTransformingFactory(new StringToBerlinClockTimeSpanParser(), new BerlinClockTimeSpanDecorator());
            return factory;
        }
    }
}

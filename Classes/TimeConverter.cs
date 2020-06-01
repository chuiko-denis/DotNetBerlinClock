#define DEDICATED_FACTORY

using BerlinClock.Classes.DTO;
using BerlinClock.Classes.Engine;
using BerlinClock.Classes.Engine.TimeDecorators;
using BerlinClock.Classes.Engine.TimeParsers;
using BerlinClock.Classes.Engine.TimeTransformingFactories;
using BerlinClock.Classes.Engine.TimeTransformingFactories.BerlinClock;

namespace BerlinClock
{
    public class TimeConverter : ITimeConverter
    {
        public string convertTime(string aTime)
        {
            ITimeTransformingFactory<string, string> timeTransformingFactory;

#if DEDICATED_FACTORY

            timeTransformingFactory = FactoryInstantiation_DefinedByImplementation();

#elif FLEXIBLE_FACTORY

            timeTransformingFactory = FactoryInstantiation_FlexibleVariant();

#endif

            var result = timeTransformingFactory.Transform(aTime);

            return result;
        }

        ITimeTransformingFactory<string, string> FactoryInstantiation_DefinedByImplementation()
        {
             return StringToBerlinClockTransformingFactory.Build();
        }

        ITimeTransformingFactory<string, string> FactoryInstantiation_FlexibleVariant()
        {
            var parser = new StringToBerlinClockTimeSpanParser();
            var decorator = new BerlinClockTimeSpanDecorator();

            return new TimeTransformingFactory<string, BerlinClockTimeSpan, string>(
                    parser,
                    decorator
                );
        }
    }
}

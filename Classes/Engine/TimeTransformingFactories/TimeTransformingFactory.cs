namespace BerlinClock.Classes.Engine.TimeTransformingFactories
{
    class TimeTransformingFactory<TTimeIn, TTimeTarget, TTimeOut> : ITimeTransformingFactory<TTimeIn, TTimeOut>
    {
        protected ITimeParser<TTimeIn, TTimeTarget> _timeParser;
        protected ITimeDecorator<TTimeTarget, TTimeOut> _timeDecorator;

        public TimeTransformingFactory(ITimeParser<TTimeIn, TTimeTarget> timeParser, ITimeDecorator<TTimeTarget, TTimeOut> timeDecorator)
        {
            _timeParser = timeParser;
            _timeDecorator = timeDecorator;
        }

        public TTimeOut Transform(TTimeIn timeRepresentation)
        {
            var timeTarget = _timeParser.Parse(timeRepresentation);
            var result = _timeDecorator.Decorate(timeTarget);

            return result;
        }
    }
}

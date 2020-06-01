namespace BerlinClock.Classes.Engine
{
    interface ITimeTransformingFactory<TTimeIn, TTimeOut>
    {
        TTimeOut Transform(TTimeIn timeRepresentation);
    }
}

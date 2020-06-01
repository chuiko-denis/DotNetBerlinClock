namespace BerlinClock.Classes.Engine
{
    interface ITimeParser<in TTimeIn, out TTimeTarget>
    {
        TTimeTarget Parse(TTimeIn timeRepresentation);
    }
}

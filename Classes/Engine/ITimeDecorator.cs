namespace BerlinClock.Classes.Engine
{
    interface ITimeDecorator<in TTimeTarget, out TOut>
    {
        TOut Decorate(TTimeTarget timeSpan);
    }
}

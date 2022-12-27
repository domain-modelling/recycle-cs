namespace Recycle.WebAPI.Messages;

public class CommandHandler
{
    public Event<PriceWasCalculated> Handle()
    {
        return new Event<PriceWasCalculated>(new PriceWasCalculated("Tom", 0, "EUR"));
    }
}
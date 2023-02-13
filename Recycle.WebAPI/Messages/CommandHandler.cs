namespace Recycle.WebAPI.Messages;

public class CommandHandler
{
    public Event<PriceWasCalculated> Handle()
    {
        return new Event<PriceWasCalculated>(new PriceWasCalculated("123", 0, "EUR"));
    }
}
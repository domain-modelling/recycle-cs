namespace Recycle.WebAPI.Messages;

public class CommandHandler
{
    public Event Handle(IList<Event> history, Command command)
    {
        return new Event<PriceWasCalculated>(new PriceWasCalculated("Tom", 0, "EUR"));
    }
}
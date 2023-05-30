using Recycle.WebAPI.Messages;

namespace Recycle.WebAPI.Domain;

public class PriceCalculator
{
    public PriceCalculator(params Event[] history)
    {
        foreach (var @event in history) Handle(@event);
    }

    public PriceCalculator(List<Event> history)
    {
        foreach (var @event in history) Handle(@event);
    }

    private static void Handle(Event @event)
    {
        switch (@event)
        {
            case Event<IdCardRegistered> cardRegistered:
                // do something with cardRegistered
                break;
            case Event<IdCardScannedAtEntranceGate> cardScanned:
                // do something with cardScanned
                break;
            case Event<FractionWasDropped> fractionDropped:
                // do something with cardScanned
                break;
            case Event<IdCardScannedAtExitGate> cardScanned:
                // do something with cardScanned
                break;
        }
    }

    public double CalculatePrice(string commandCardId)
    {
        return 0;
    }
}
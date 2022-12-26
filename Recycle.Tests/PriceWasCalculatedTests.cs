using Recycle.WebAPI.Messages;

namespace Recycle.Tests;

public class PriceWasCalculatedTest
{
    private CommandHandler commandHandler;

    [SetUp]
    public void Setup()
    {
        commandHandler = new CommandHandler();
    }

    [Test]
    public void NoFractionsDelivered()
    {
        var priceEvent = commandHandler.Handle(null, null) as Event<PriceWasCalculated>;
        
        Assert.That(priceEvent.Type, Is.EqualTo("PriceWasCalculated"));
        Assert.That(priceEvent.Payload, Is.EqualTo(new PriceWasCalculated("Tom", 0, "EUR")));
    }
}
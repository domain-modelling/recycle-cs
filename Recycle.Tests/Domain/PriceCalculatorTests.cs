using Recycle.WebAPI.Domain;
using Recycle.WebAPI.Messages;

namespace Recycle.Tests.Domain;

public class PriceCalculatorTests
{
    [Test]
    public void Request()
    {
        var calculator = new PriceCalculator(
            Create(new IdCardRegistered{CardId = "123", PersonId = "John Doe", Address = "an address", City = "a city"}),
            Create(new IdCardScannedAtEntranceGate{CardId = "123", Date = DateTime.Parse("2023-01-01")}),
            Create(new IdCardScannedAtExitGate{CardId = "123"})
        );
        
        Assert.That(calculator.CalculatePrice("123"), Is.EqualTo(0.0));
    }

    private Event<TEvent> Create<TEvent>(TEvent payload)
    {
        return new Event<TEvent>{EventId = Guid.NewGuid().ToString(), CreatedAt = DateTime.Now, Payload = payload};
    }
}
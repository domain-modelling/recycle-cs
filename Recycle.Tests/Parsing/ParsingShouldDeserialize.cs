using System.Text.Json;
using Recycle.WebAPI.Controllers;
using Recycle.WebAPI.Messages;
using Recycle.WebAPI.Middleware;

namespace Recycle.Tests.Parsing;

public class ParsingShouldDeserialize
{
    [Test]
    public void Request()
    {
        #region Request

        var json = @"{
        ""command"": {      
            ""command_id"": ""TODO"",
            ""created_at"": ""2023-02-15T07:43:43.078177Z"",
            ""payload"": {
                ""card_id"": ""123""
            },
            ""type"": ""CalculatePrice""  
        },
        ""history"": [
        {
            ""created_at"": ""2023-02-15T07:43:43.078156Z"",
            ""event_id"": ""todo"",
            ""payload"": {
                ""address"": ""1428 Elm Street"",
                ""card_id"": ""123"",
                ""city"": ""Moon Village"",
                ""person_id"": ""Freddy""
            },
            ""type"": ""IdCardRegistered""
        },
        {
            ""created_at"": ""2023-02-15T07:43:43.078169Z"",
            ""event_id"": ""todo"",
            ""payload"": {
                ""card_id"": ""123""
            },
            ""type"": ""IdCardScannedAtEntranceGate""
        },
        {
            ""created_at"": ""2023-02-15T07:43:43.078171Z"",
            ""event_id"": ""todo"",
            ""payload"": {
                ""card_id"": ""123"",
                ""weight"": 487
            },
            ""type"": ""WeightWasMeasured""
        },
        {
            ""created_at"": ""2023-02-15T07:43:43.078172Z"",
            ""event_id"": ""todo"",
            ""payload"": {
                ""card_id"": ""123"",
                ""fraction_type"": ""Construction waste""
            },
            ""type"": ""FractionWasSelected""
        },
        {
            ""created_at"": ""2023-02-15T07:43:43.078174Z"",
            ""event_id"": ""todo"",
            ""payload"": {
                ""card_id"": ""123"",
                ""weight"": 422
            },
            ""type"": ""WeightWasMeasured""
        },
        {
            ""created_at"": ""2023-02-15T07:43:43.078175Z"",
            ""event_id"": ""todo"",
            ""payload"": {
                ""card_id"": ""123""
            },
            ""type"": ""IdCardScannedAtExitGate""
        }
        ]
    }";

        #endregion

        var request = Deserialize<RecycleRequest>(json);

        var command = request.Command as Command<CalculatePrice>;
        Assert.That(command.CreatedAt, Is.InstanceOf<DateTime>());
        Assert.That(command.CommandId, Is.EqualTo("TODO"));
        Assert.That(command.Payload, Is.EqualTo(new CalculatePrice { CardId = "123" }));

        Assert.That(request.History, Has.Exactly(6).Items);
    }

    [Test]
    public void CalculatePrice()
    {
        var json = @"{
            ""type"": ""CalculatePrice"",
            ""command_id"": ""456"",
            ""created_at"": ""2023-02-15T07:43:43Z"",
            ""payload"": { ""card_id"": ""123"" }
        }";

        Assert.That(Deserialize<Command>(json), Is.EqualTo(new Command<CalculatePrice>
        {
            CommandId = "456",
            CreatedAt = DateTime.Parse("2023-02-15T06:43:43Z"),
            Payload = new CalculatePrice { CardId = "123" }
        }));
    }

    [Test]
    public void IdCardRegistered()
    {
        var json = @"{
            ""type"": ""IdCardRegistered"",
            ""created_at"": ""2023-02-15T07:43:43.078156Z"",
            ""event_id"": ""789"",
            ""payload"": {
                ""address"": ""1428 Elm Street"",
                ""card_id"": ""123"",
                ""city"": ""Moon Village"",
                ""person_id"": ""Freddy""
            }
        }";

        Assert.That(Deserialize<Event>(json), Is.EqualTo(new Event<IdCardRegistered>
        {
            EventId = "789",
            CreatedAt = DateTime.Parse("2023-02-15T06:43:43.078156Z"),
            Payload = new IdCardRegistered
            {
                CardId = "123",
                Address = "1428 Elm Street",
                City = "Moon Village",
                PersonId = "Freddy"
            }
        }));
    }

    [Test]
    public void IdCardScannedAtEntranceGate()
    {
        var json = @"{
            ""type"": ""IdCardScannedAtEntranceGate"",
            ""event_id"": ""789"",
            ""created_at"": ""2023-02-15T07:43:43Z"",
            ""payload"": {
                ""card_id"": ""123""
            }
        }";

        Assert.That(Deserialize<Event>(json), Is.EqualTo(new Event<IdCardScannedAtEntranceGate>
        {
            EventId = "789",
            CreatedAt = DateTime.Parse("2023-02-15T06:43:43Z"),
            Payload = new IdCardScannedAtEntranceGate
            {
                CardId = "123",
            }
        }));
    }
    
    [Test]
    public void WeightWasMeasured()
    {
        var json = @"{
            ""type"": ""WeightWasMeasured"",
            ""event_id"": ""741"",
            ""created_at"": ""2023-02-15T07:43:43.078171Z"",
            ""payload"": {
                ""card_id"": ""123"",
                ""weight"": 487
            }
        }";

        Assert.That(Deserialize<Event>(json), Is.EqualTo(new Event<WeightWasMeasured>
        {
            EventId = "741",
            CreatedAt = DateTime.Parse("2023-02-15T06:43:43.078171Z"),
            Payload = new WeightWasMeasured
            {
                CardId = "123",
                Weight = 487
            }
        }));
    }
    
    [Test]
    public void FractionWasSelected()
    {
        var json = @"{
            ""type"": ""FractionWasSelected"",
            ""event_id"": ""852"",
            ""created_at"": ""2023-02-15T07:43:43.078172Z"",
            ""payload"": {
                ""card_id"": ""123"",
                ""fraction_type"": ""Construction waste""
            }
        }";

        Assert.That(Deserialize<Event>(json), Is.EqualTo(new Event<FractionWasSelected>
        {
            EventId = "852",
            CreatedAt = DateTime.Parse("2023-02-15T06:43:43.078172Z"),
            Payload = new FractionWasSelected
            {
                CardId = "123",
                FractionType = "Construction waste"
            }
        }));
    }

    [Test]
    public void FractionWasDropped()
    {
        var json = @"{
            ""type"": ""FractionWasDropped"",
            ""event_id"": ""852"",
            ""created_at"": ""2023-02-15T07:43:43.078172Z"",
            ""payload"": {
                ""card_id"": ""123"",
                ""fraction_type"": ""Construction waste"",
                ""weight"": 234
            }
        }";

        Assert.That(Deserialize<Event>(json), Is.EqualTo(new Event<FractionWasDropped>
        {
            EventId = "852",
            CreatedAt = DateTime.Parse("2023-02-15T06:43:43.078172Z"),
            Payload = new FractionWasDropped()
            {
                CardId = "123",
                FractionType = "Construction waste",
                Weight = 234
            }
        }));
    }
    
    [Test]
    public void IdCardScannedAtExitGate()
    {
        var json = @"{
            ""type"": ""IdCardScannedAtExitGate"",
            ""event_id"": ""963"",
            ""created_at"": ""2023-02-15T07:43:43.078175Z"",
            ""payload"": {
                ""card_id"": ""123""
            }
        }";

        Assert.That(Deserialize<Event>(json), Is.EqualTo(new Event<IdCardScannedAtExitGate>
        {
            EventId = "963",
            CreatedAt = DateTime.Parse("2023-02-15T06:43:43.078175Z"),
            Payload = new IdCardScannedAtExitGate
            {
                CardId = "123"
            }
        }));
    }

    [Test]
    public void PriceWasCalculated()
    {
        var json = @"{
            ""type"": ""PriceWasCalculated"",
            ""event_id"": ""963"",
            ""created_at"": ""2023-02-15T10:30:00+01:00"",
            ""payload"": {
                ""card_id"": ""123"",
                ""price_amount"": 10,
                ""price_currency"": ""EUR""
            }
        }";

        Assert.That(Deserialize<Event>(json), Is.EqualTo(new Event<PriceWasCalculated>
        {
            EventId = "963",
            CreatedAt = DateTime.Parse("2023-02-15T10:30:00+01:00"),
            Payload = new PriceWasCalculated
            {
                CardId = "123",
                PriceAmount = 10,
                PriceCurrency = "EUR"
            }
        }));
    }

    private static T Deserialize<T>(string message)
    {
        return JsonSerializer.Deserialize<T>(message, JsonSerializationConfiguration.Default)!;
    }
}

public class ParsingShouldSerialize
{
    [Test]
    public void PriceWasCalculated()
    {
        var @event = new Event<PriceWasCalculated>
        {
            EventId = "963",
            CreatedAt = DateTime.Parse("2023-02-15T10:30:00+01:00"),
            Payload = new PriceWasCalculated
            {
                CardId = "123",
                PriceAmount = 10,
                PriceCurrency = "EUR"
            }
        };
        var json = "{"
                   + @"""type"":""PriceWasCalculated"","
                   + @"""event_id"":""963"","
                   + @"""created_at"":""2023-02-15T10:30:00+01:00"","
                   + @"""payload"":{"
                   + @"""card_id"":""123"","
                   + @"""price_amount"":10,"
                   + @"""price_currency"":""EUR"""
                   + @"}"
                   + @"}";

        Assert.That(Deserialize<Event>(@event), Is.EqualTo(json));
    }

    private string Deserialize<T>(Event @event)
    {
        return JsonSerializer.Serialize(@event, JsonSerializationConfiguration.Default);
    }
}

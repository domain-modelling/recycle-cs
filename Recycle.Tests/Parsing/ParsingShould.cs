using System.Text.Json;
using Recycle.WebAPI.Controllers;
using Recycle.WebAPI.Messages;
using Recycle.WebAPI.Middleware;

namespace Recycle.Tests.Parsing;

public class ParsingShould
{
    [Test]
    public void ConvertToAValidCommand()
    {
        #region Command
        var message = @"{
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

        var serializeOptions = new JsonSerializerOptions();
        serializeOptions.Converters.Add(new EventConverter());
        
        var parsedMessage = JsonSerializer.Deserialize<HandlingRequest>(message,serializeOptions);
        
        Assert.That(parsedMessage, Is.Not.Null);
        Assert.Multiple(() =>
        {
            Assert.That(parsedMessage.Command.GetType(), Is.EqualTo(typeof(Event<CalculatePrice>)));
            Assert.That(parsedMessage.History.Count, Is.EqualTo(6));
        });
    }
}
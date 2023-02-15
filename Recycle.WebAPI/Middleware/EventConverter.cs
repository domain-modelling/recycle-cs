using System.Text.Json;
using System.Text.Json.Serialization;
using Recycle.WebAPI.Messages;

namespace Recycle.WebAPI.Middleware;

public class EventConverter : JsonConverter<Event>
{
    public override Event? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var readerClone = reader;

        if (readerClone.TokenType != JsonTokenType.StartObject)
        {
            throw new JsonException();
        }

        // Read the `className` from our JSON document
        using var jsonDocument = JsonDocument.ParseValue(ref readerClone);
        var type = jsonDocument.RootElement.GetProperty("type").GetString();

        return type switch
        {
            "IdCardRegistered" => JsonSerializer.Deserialize<Event<IdCardRegistered>>(ref reader),
            _ => JsonSerializer.Deserialize<Event>(ref reader)
        };
    }

    public override void Write(Utf8JsonWriter writer, Event value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(writer, value, value.GetType(), options);
    }
}
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

        if (string.IsNullOrWhiteSpace(type))
            return JsonSerializer.Deserialize<Event>(ref reader);

        return type switch
        {
            "CalculatePrice" => JsonSerializer.Deserialize<Event<CalculatePrice>>(ref reader),
            _ => JsonSerializer.Deserialize<Event>(ref reader)
        };
    }

    public override void Write(Utf8JsonWriter writer, Event value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(writer, value, value.GetType(), options);
    }
}

public class CommandConverter : JsonConverter<Command>
{
    public override Command? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var readerClone = reader;

        if (readerClone.TokenType != JsonTokenType.StartObject)
        {
            throw new JsonException();
        }

        // Read the `className` from our JSON document
        using var jsonDocument = JsonDocument.ParseValue(ref readerClone);
        var type = jsonDocument.RootElement.GetProperty("type").GetString();

        if (string.IsNullOrWhiteSpace(type))
            return JsonSerializer.Deserialize<Command>(ref reader);

        return type switch
        {
            "CalculatePrice" => JsonSerializer.Deserialize<Command<CalculatePrice>>(ref reader),
            _ => JsonSerializer.Deserialize<Command>(ref reader)
        };
    }

    public override void Write(Utf8JsonWriter writer, Command value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(writer, value, value.GetType(), options);
    }
}
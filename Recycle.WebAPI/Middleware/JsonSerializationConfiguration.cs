using System.Text.Json;
using Microsoft.AspNetCore.Mvc;

namespace Recycle.WebAPI.Middleware;

public static class JsonSerializationConfiguration
{
    public static JsonOptions Initialize(JsonOptions options)
    {
        InitializeSerializer(options.JsonSerializerOptions);
        return options;
    }

    public static JsonSerializerOptions Default => InitializeSerializer(new JsonSerializerOptions());

    private static JsonSerializerOptions InitializeSerializer(JsonSerializerOptions options)
    {
        options.Converters.Add(new EventConverter());
        options.Converters.Add(new CommandConverter());
        options.WriteIndented = true;
        
        return options;
    }
}
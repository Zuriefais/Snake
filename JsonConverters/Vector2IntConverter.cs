using Newtonsoft.Json;

class Vector2IntConverter : JsonConverter
{
    public override bool CanConvert(Type objectType)
    {
        return objectType == typeof(Vector2Int);
    }

    public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
    {
        var vector2Int = (Vector2Int) value;

        writer.WriteStartObject();
        writer.WritePropertyName("x");
        serializer.Serialize(writer, vector2Int.x);
        writer.WritePropertyName("y");
        serializer.Serialize(writer, vector2Int.y);
        writer.WriteEndObject();
    }

    public override object? ReadJson(JsonReader reader, Type objectType, object? existingValue, JsonSerializer serializer)
    {
        int x = 0;
        int y = 0;
        while (reader.Read())
        {
            if (reader.TokenType != JsonToken.PropertyName)
                break;

            var propertyName = (string)reader.Value;
            if (!reader.Read())
                continue;

            if (propertyName == "x")
            {
                x = serializer.Deserialize<int>(reader);
            }

            if (propertyName == "y")
            {
                y = serializer.Deserialize<int>(reader);
            }
        }
        return new Vector2Int(x, y);
    }
}
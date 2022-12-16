using Newtonsoft.Json;

class WorldObjectConverter: JsonConverter
{
    public override bool CanConvert(Type objectType)
    {
        return objectType == typeof(WorldObject);
    }

    public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
    {
        var worldObject = (WorldObject) value;

        writer.WriteStartObject();
        writer.WritePropertyName("cells");
        serializer.Serialize(writer, worldObject.cells);
        writer.WritePropertyName("position");
        serializer.Serialize(writer, worldObject.position);
        writer.WriteEndObject();
    }

    public override object? ReadJson(JsonReader reader, Type objectType, object? existingValue, JsonSerializer serializer)
    {
        BasicWorldObject obj = new(new(0, 0));
        while (reader.Read())
        {
            if (reader.TokenType != JsonToken.PropertyName)
                break;

            var propertyName = (string)reader.Value;
            if (!reader.Read())
                continue;

            if (propertyName == "cells")
            {
                obj.AddCells(serializer.Deserialize<List<Cell>>(reader));
            }

            if (propertyName == "position")
            {
                obj.position = serializer.Deserialize<Vector2Int>(reader);
            }
        }
        return obj;
    }
}
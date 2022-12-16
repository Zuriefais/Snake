using Newtonsoft.Json;

class CellConverter: JsonConverter
{
    public override bool CanConvert(Type objectType)
    {
        return objectType == typeof(Cell);
    }

    public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
    {
        var cell = (Cell) value;

        writer.WriteStartObject();
        writer.WritePropertyName("position");
        serializer.Serialize(writer, cell.position);
        writer.WritePropertyName("symbol");
        serializer.Serialize(writer, cell.symbol);
        writer.WriteEndObject();
    }

    public override object? ReadJson(JsonReader reader, Type objectType, object? existingValue, JsonSerializer serializer)
    {
        Cell cell = new(' ', new(), new());
        while (reader.Read())
        {
            if (reader.TokenType != JsonToken.PropertyName)
                break;

            var propertyName = (string)reader.Value;
            if (!reader.Read())
                continue;

            if (propertyName == "position")
            {
                cell.position = serializer.Deserialize<Vector2Int>(reader);
            }

            if (propertyName == "symbol")
            {
                cell.symbol = serializer.Deserialize<char>(reader);
            }
        }
        return cell;
    }
}
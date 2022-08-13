namespace Asyncapi.Nats.Client.Models
{
  using System.Collections.Generic;
  using System.Text.Json;
  using System.Text.Json.Serialization;
  using System.Text.RegularExpressions;
  using System.Linq;

  [JsonConverter(typeof(PlayerPositionConverter))]
  public class PlayerPosition
  {
    private double x;
    private double y;
    private double z;
    private Dictionary<string, dynamic> additionalProperties;

    public double X 
    {
      get { return x; }
      set { x = value; }
    }

    public double Y 
    {
      get { return y; }
      set { y = value; }
    }

    public double Z 
    {
      get { return z; }
      set { z = value; }
    }

    public Dictionary<string, dynamic> AdditionalProperties 
    {
      get { return additionalProperties; }
      set { additionalProperties = value; }
    }
  }

  internal class PlayerPositionConverter : JsonConverter<PlayerPosition>
  {
    public override bool CanConvert(System.Type objectType)
    {
      // this converter can be applied to any type
      return true;
    }
    public override PlayerPosition Read(ref Utf8JsonReader reader, System.Type typeToConvert, JsonSerializerOptions options)
    {
      if (reader.TokenType != JsonTokenType.StartObject)
      {
        throw new JsonException();
      }

      var instance = new PlayerPosition();
  
      while (reader.Read())
      {
        if (reader.TokenType == JsonTokenType.EndObject)
        {
          return instance;
        }

        // Get the key.
        if (reader.TokenType != JsonTokenType.PropertyName)
        {
          throw new JsonException();
        }

        string propertyName = reader.GetString();
        if (propertyName == "x")
        {
          var value = JsonSerializer.Deserialize<double?>(ref reader, options);
          instance.X = value;
          continue;
        }
        if (propertyName == "y")
        {
          var value = JsonSerializer.Deserialize<double?>(ref reader, options);
          instance.Y = value;
          continue;
        }
        if (propertyName == "z")
        {
          var value = JsonSerializer.Deserialize<double?>(ref reader, options);
          instance.Z = value;
          continue;
        }

    

        if(instance.AdditionalProperties == null) { instance.AdditionalProperties = new Dictionary<string, dynamic>(); }
        var deserializedValue = JsonSerializer.Deserialize<dynamic>(ref reader, options);
        instance.AdditionalProperties.Add(propertyName, deserializedValue);
        continue;
      }
  
      throw new JsonException();
    }
    public override void Write(Utf8JsonWriter writer, PlayerPosition value, JsonSerializerOptions options)
    {
      if (value == null)
      {
        JsonSerializer.Serialize(writer, null, options);
        return;
      }
      var properties = value.GetType().GetProperties().Where(prop => prop.Name != "AdditionalProperties");
  
      writer.WriteStartObject();

      if(value.X != null) { 
        // write property name and let the serializer serialize the value itself
        writer.WritePropertyName("x");
        JsonSerializer.Serialize(writer, value.X, options);
      }
      if(value.Y != null) { 
        // write property name and let the serializer serialize the value itself
        writer.WritePropertyName("y");
        JsonSerializer.Serialize(writer, value.Y, options);
      }
      if(value.Z != null) { 
        // write property name and let the serializer serialize the value itself
        writer.WritePropertyName("z");
        JsonSerializer.Serialize(writer, value.Z, options);
      }


  

      // Unwrap additional properties in object
      if (value.AdditionalProperties != null) {
        foreach (var additionalProperty in value.AdditionalProperties)
        {
          //Ignore any additional properties which might already be part of the core properties
          if (properties.Any(prop => prop.Name == additionalProperty.Key))
          {
              continue;
          }
          // write property name and let the serializer serialize the value itself
          writer.WritePropertyName(additionalProperty.Key);
          JsonSerializer.Serialize(writer, additionalProperty.Value, options);
        }
      }

      writer.WriteEndObject();
    }

  }

}
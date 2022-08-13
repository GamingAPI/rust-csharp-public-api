namespace Asyncapi.Nats.Client.Models
{
  using System.Collections.Generic;
  using System.Text.Json;
  using System.Text.Json.Serialization;
  using System.Text.RegularExpressions;
  using System.Linq;

  [JsonConverter(typeof(PlayerConverter))]
  public class Player
  {
    private string id;
    private string name;
    private string address;
    private Dictionary<string, dynamic> additionalProperties;

    public string Id 
    {
      get { return id; }
      set { id = value; }
    }

    public string Name 
    {
      get { return name; }
      set { name = value; }
    }

    public string Address 
    {
      get { return address; }
      set { address = value; }
    }

    public Dictionary<string, dynamic> AdditionalProperties 
    {
      get { return additionalProperties; }
      set { additionalProperties = value; }
    }
  }

  internal class PlayerConverter : JsonConverter<Player>
  {
    public override bool CanConvert(System.Type objectType)
    {
      // this converter can be applied to any type
      return true;
    }
    public override Player Read(ref Utf8JsonReader reader, System.Type typeToConvert, JsonSerializerOptions options)
    {
      if (reader.TokenType != JsonTokenType.StartObject)
      {
        throw new JsonException();
      }

      var instance = new Player();
  
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
        if (propertyName == "id")
        {
          var value = JsonSerializer.Deserialize<string>(ref reader, options);
          instance.Id = value;
          continue;
        }
        if (propertyName == "name")
        {
          var value = JsonSerializer.Deserialize<string>(ref reader, options);
          instance.Name = value;
          continue;
        }
        if (propertyName == "address")
        {
          var value = JsonSerializer.Deserialize<string>(ref reader, options);
          instance.Address = value;
          continue;
        }

    

        if(instance.AdditionalProperties == null) { instance.AdditionalProperties = new Dictionary<string, dynamic>(); }
        var deserializedValue = JsonSerializer.Deserialize<dynamic>(ref reader, options);
        instance.AdditionalProperties.Add(propertyName, deserializedValue);
        continue;
      }
  
      throw new JsonException();
    }
    public override void Write(Utf8JsonWriter writer, Player value, JsonSerializerOptions options)
    {
      if (value == null)
      {
        JsonSerializer.Serialize(writer, null, options);
        return;
      }
      var properties = value.GetType().GetProperties().Where(prop => prop.Name != "AdditionalProperties");
  
      writer.WriteStartObject();

      if(value.Id != null) { 
        // write property name and let the serializer serialize the value itself
        writer.WritePropertyName("id");
        JsonSerializer.Serialize(writer, value.Id, options);
      }
      if(value.Name != null) { 
        // write property name and let the serializer serialize the value itself
        writer.WritePropertyName("name");
        JsonSerializer.Serialize(writer, value.Name, options);
      }
      if(value.Address != null) { 
        // write property name and let the serializer serialize the value itself
        writer.WritePropertyName("address");
        JsonSerializer.Serialize(writer, value.Address, options);
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
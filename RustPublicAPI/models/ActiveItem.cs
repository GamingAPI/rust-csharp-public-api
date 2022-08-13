namespace Asyncapi.Nats.Client.Models
{
  using System.Collections.Generic;
  using System.Text.Json;
  using System.Text.Json.Serialization;
  using System.Text.RegularExpressions;
  using System.Linq;

  [JsonConverter(typeof(ActiveItemConverter))]
  public class ActiveItem
  {
    private int? uid;
    private int? itemId;
    private Dictionary<string, dynamic> additionalProperties;

    public int? Uid 
    {
      get { return uid; }
      set { uid = value; }
    }

    public int? ItemId 
    {
      get { return itemId; }
      set { itemId = value; }
    }

    public Dictionary<string, dynamic> AdditionalProperties 
    {
      get { return additionalProperties; }
      set { additionalProperties = value; }
    }
  }

  internal class ActiveItemConverter : JsonConverter<ActiveItem>
  {
    public override bool CanConvert(System.Type objectType)
    {
      // this converter can be applied to any type
      return true;
    }
    public override ActiveItem Read(ref Utf8JsonReader reader, System.Type typeToConvert, JsonSerializerOptions options)
    {
      if (reader.TokenType != JsonTokenType.StartObject)
      {
        throw new JsonException();
      }

      var instance = new ActiveItem();
  
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
        if (propertyName == "uid")
        {
          var value = JsonSerializer.Deserialize<int?>(ref reader, options);
          instance.Uid = value;
          continue;
        }
        if (propertyName == "item_id")
        {
          var value = JsonSerializer.Deserialize<int?>(ref reader, options);
          instance.ItemId = value;
          continue;
        }

    

        if(instance.AdditionalProperties == null) { instance.AdditionalProperties = new Dictionary<string, dynamic>(); }
        var deserializedValue = JsonSerializer.Deserialize<dynamic>(ref reader, options);
        instance.AdditionalProperties.Add(propertyName, deserializedValue);
        continue;
      }
  
      throw new JsonException();
    }
    public override void Write(Utf8JsonWriter writer, ActiveItem value, JsonSerializerOptions options)
    {
      if (value == null)
      {
        JsonSerializer.Serialize(writer, null, options);
        return;
      }
      var properties = value.GetType().GetProperties().Where(prop => prop.Name != "AdditionalProperties");
  
      writer.WriteStartObject();

      if(value.Uid != null) { 
        // write property name and let the serializer serialize the value itself
        writer.WritePropertyName("uid");
        JsonSerializer.Serialize(writer, value.Uid, options);
      }
      if(value.ItemId != null) { 
        // write property name and let the serializer serialize the value itself
        writer.WritePropertyName("item_id");
        JsonSerializer.Serialize(writer, value.ItemId, options);
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
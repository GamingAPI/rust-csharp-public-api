namespace Asyncapi.Nats.Client.Models
{
  using System.Collections.Generic;
  using System.Text.Json;
  using System.Text.Json.Serialization;
  using System.Text.RegularExpressions;
  using System.Linq;

  [JsonConverter(typeof(ServerPlayerDisconnectedConverter))]
  public class ServerPlayerDisconnected
  {
    private string disconnectedTimestamp;
    private ServerPlayerDisconnectedPlayer player;
    private string reason;
    private Dictionary<string, dynamic> additionalProperties;

    public string DisconnectedTimestamp 
    {
      get { return disconnectedTimestamp; }
      set { disconnectedTimestamp = value; }
    }

    public ServerPlayerDisconnectedPlayer Player 
    {
      get { return player; }
      set { player = value; }
    }

    public string Reason 
    {
      get { return reason; }
      set { reason = value; }
    }

    public Dictionary<string, dynamic> AdditionalProperties 
    {
      get { return additionalProperties; }
      set { additionalProperties = value; }
    }
  }

  internal class ServerPlayerDisconnectedConverter : JsonConverter<ServerPlayerDisconnected>
  {
    public override bool CanConvert(System.Type objectType)
    {
      // this converter can be applied to any type
      return true;
    }
    public override ServerPlayerDisconnected Read(ref Utf8JsonReader reader, System.Type typeToConvert, JsonSerializerOptions options)
    {
      if (reader.TokenType != JsonTokenType.StartObject)
      {
        throw new JsonException();
      }

      var instance = new ServerPlayerDisconnected();
  
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
        if (propertyName == "disconnected_timestamp")
        {
          var value = JsonSerializer.Deserialize<string>(ref reader, options);
          instance.DisconnectedTimestamp = value;
          continue;
        }
        if (propertyName == "player")
        {
          var value = JsonSerializer.Deserialize<ServerPlayerDisconnectedPlayer>(ref reader, options);
          instance.Player = value;
          continue;
        }
        if (propertyName == "reason")
        {
          var value = JsonSerializer.Deserialize<string>(ref reader, options);
          instance.Reason = value;
          continue;
        }

    

        if(instance.AdditionalProperties == null) { instance.AdditionalProperties = new Dictionary<string, dynamic>(); }
        var deserializedValue = JsonSerializer.Deserialize<dynamic>(ref reader, options);
        instance.AdditionalProperties.Add(propertyName, deserializedValue);
        continue;
      }
  
      throw new JsonException();
    }
    public override void Write(Utf8JsonWriter writer, ServerPlayerDisconnected value, JsonSerializerOptions options)
    {
      if (value == null)
      {
        JsonSerializer.Serialize(writer, null, options);
        return;
      }
      var properties = value.GetType().GetProperties().Where(prop => prop.Name != "AdditionalProperties");
  
      writer.WriteStartObject();

      if(value.DisconnectedTimestamp != null) { 
        // write property name and let the serializer serialize the value itself
        writer.WritePropertyName("disconnected_timestamp");
        JsonSerializer.Serialize(writer, value.DisconnectedTimestamp, options);
      }
      if(value.Player != null) { 
        // write property name and let the serializer serialize the value itself
        writer.WritePropertyName("player");
        JsonSerializer.Serialize(writer, value.Player, options);
      }
      if(value.Reason != null) { 
        // write property name and let the serializer serialize the value itself
        writer.WritePropertyName("reason");
        JsonSerializer.Serialize(writer, value.Reason, options);
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
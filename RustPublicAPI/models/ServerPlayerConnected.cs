namespace Asyncapi.Nats.Client.Models
{
  using System.Collections.Generic;
  using System.Text.Json;
  using System.Text.Json.Serialization;
  using System.Text.RegularExpressions;
  using System.Linq;

  [JsonConverter(typeof(ServerPlayerConnectedConverter))]
  public class ServerPlayerConnected
  {
    private string connectedTimestamp;
    private Player player;
    private Dictionary<string, dynamic> additionalProperties;

    public string ConnectedTimestamp 
    {
      get { return connectedTimestamp; }
      set { connectedTimestamp = value; }
    }

    public Player Player 
    {
      get { return player; }
      set { player = value; }
    }

    public Dictionary<string, dynamic> AdditionalProperties 
    {
      get { return additionalProperties; }
      set { additionalProperties = value; }
    }
  }

  internal class ServerPlayerConnectedConverter : JsonConverter<ServerPlayerConnected>
  {
    public override bool CanConvert(System.Type objectType)
    {
      // this converter can be applied to any type
      return true;
    }
    public override ServerPlayerConnected Read(ref Utf8JsonReader reader, System.Type typeToConvert, JsonSerializerOptions options)
    {
      if (reader.TokenType != JsonTokenType.StartObject)
      {
        throw new JsonException();
      }

      var instance = new ServerPlayerConnected();
  
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
        if (propertyName == "connected_timestamp")
        {
          var value = JsonSerializer.Deserialize<string>(ref reader, options);
          instance.ConnectedTimestamp = value;
          continue;
        }
        if (propertyName == "player")
        {
          var value = JsonSerializer.Deserialize<Player>(ref reader, options);
          instance.Player = value;
          continue;
        }

    

        if(instance.AdditionalProperties == null) { instance.AdditionalProperties = new Dictionary<string, dynamic>(); }
        var deserializedValue = JsonSerializer.Deserialize<dynamic>(ref reader, options);
        instance.AdditionalProperties.Add(propertyName, deserializedValue);
        continue;
      }
  
      throw new JsonException();
    }
    public override void Write(Utf8JsonWriter writer, ServerPlayerConnected value, JsonSerializerOptions options)
    {
      if (value == null)
      {
        JsonSerializer.Serialize(writer, null, options);
        return;
      }
      var properties = value.GetType().GetProperties().Where(prop => prop.Name != "AdditionalProperties");
  
      writer.WriteStartObject();

      if(value.ConnectedTimestamp != null) { 
        // write property name and let the serializer serialize the value itself
        writer.WritePropertyName("connected_timestamp");
        JsonSerializer.Serialize(writer, value.ConnectedTimestamp, options);
      }
      if(value.Player != null) { 
        // write property name and let the serializer serialize the value itself
        writer.WritePropertyName("player");
        JsonSerializer.Serialize(writer, value.Player, options);
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
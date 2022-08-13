namespace Asyncapi.Nats.Client.Models
{
  using System.Collections.Generic;
  using System.Text.Json;
  using System.Text.Json.Serialization;
  using System.Text.RegularExpressions;
  using System.Linq;

  [JsonConverter(typeof(ServerPlayerBannedConverter))]
  public class ServerPlayerBanned
  {
    private string playerName;
    private string steamId;
    private string reason;
    private string duration;
    private string timestamp;
    private Dictionary<string, dynamic> additionalProperties;

    public string PlayerName 
    {
      get { return playerName; }
      set { playerName = value; }
    }

    public string SteamId 
    {
      get { return steamId; }
      set { steamId = value; }
    }

    public string Reason 
    {
      get { return reason; }
      set { reason = value; }
    }

    public string Duration 
    {
      get { return duration; }
      set { duration = value; }
    }

    public string Timestamp 
    {
      get { return timestamp; }
      set { timestamp = value; }
    }

    public Dictionary<string, dynamic> AdditionalProperties 
    {
      get { return additionalProperties; }
      set { additionalProperties = value; }
    }
  }

  internal class ServerPlayerBannedConverter : JsonConverter<ServerPlayerBanned>
  {
    public override bool CanConvert(System.Type objectType)
    {
      // this converter can be applied to any type
      return true;
    }
    public override ServerPlayerBanned Read(ref Utf8JsonReader reader, System.Type typeToConvert, JsonSerializerOptions options)
    {
      if (reader.TokenType != JsonTokenType.StartObject)
      {
        throw new JsonException();
      }

      var instance = new ServerPlayerBanned();
  
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
        if (propertyName == "player_name")
        {
          var value = JsonSerializer.Deserialize<string>(ref reader, options);
          instance.PlayerName = value;
          continue;
        }
        if (propertyName == "steam_id")
        {
          var value = JsonSerializer.Deserialize<string>(ref reader, options);
          instance.SteamId = value;
          continue;
        }
        if (propertyName == "reason")
        {
          var value = JsonSerializer.Deserialize<string>(ref reader, options);
          instance.Reason = value;
          continue;
        }
        if (propertyName == "duration")
        {
          var value = JsonSerializer.Deserialize<string>(ref reader, options);
          instance.Duration = value;
          continue;
        }
        if (propertyName == "timestamp")
        {
          var value = JsonSerializer.Deserialize<string>(ref reader, options);
          instance.Timestamp = value;
          continue;
        }

    

        if(instance.AdditionalProperties == null) { instance.AdditionalProperties = new Dictionary<string, dynamic>(); }
        var deserializedValue = JsonSerializer.Deserialize<dynamic>(ref reader, options);
        instance.AdditionalProperties.Add(propertyName, deserializedValue);
        continue;
      }
  
      throw new JsonException();
    }
    public override void Write(Utf8JsonWriter writer, ServerPlayerBanned value, JsonSerializerOptions options)
    {
      if (value == null)
      {
        JsonSerializer.Serialize(writer, null, options);
        return;
      }
      var properties = value.GetType().GetProperties().Where(prop => prop.Name != "AdditionalProperties");
  
      writer.WriteStartObject();

      if(value.PlayerName != null) { 
        // write property name and let the serializer serialize the value itself
        writer.WritePropertyName("player_name");
        JsonSerializer.Serialize(writer, value.PlayerName, options);
      }
      if(value.SteamId != null) { 
        // write property name and let the serializer serialize the value itself
        writer.WritePropertyName("steam_id");
        JsonSerializer.Serialize(writer, value.SteamId, options);
      }
      if(value.Reason != null) { 
        // write property name and let the serializer serialize the value itself
        writer.WritePropertyName("reason");
        JsonSerializer.Serialize(writer, value.Reason, options);
      }
      if(value.Duration != null) { 
        // write property name and let the serializer serialize the value itself
        writer.WritePropertyName("duration");
        JsonSerializer.Serialize(writer, value.Duration, options);
      }
      if(value.Timestamp != null) { 
        // write property name and let the serializer serialize the value itself
        writer.WritePropertyName("timestamp");
        JsonSerializer.Serialize(writer, value.Timestamp, options);
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
namespace Asyncapi.Nats.Client.Models
{
  using System.Collections.Generic;
  using System.Text.Json;
  using System.Text.Json.Serialization;
  using System.Text.RegularExpressions;
  using System.Linq;

  [JsonConverter(typeof(ServerPlayerRespawnedConverter))]
  public class ServerPlayerRespawned
  {
    private string steamId;
    private string respawnTimestamp;
    private PlayerPosition respawnPosition;
    private Dictionary<string, dynamic> additionalProperties;

    public string SteamId 
    {
      get { return steamId; }
      set { steamId = value; }
    }

    public string RespawnTimestamp 
    {
      get { return respawnTimestamp; }
      set { respawnTimestamp = value; }
    }

    public PlayerPosition RespawnPosition 
    {
      get { return respawnPosition; }
      set { respawnPosition = value; }
    }

    public Dictionary<string, dynamic> AdditionalProperties 
    {
      get { return additionalProperties; }
      set { additionalProperties = value; }
    }
  }

  internal class ServerPlayerRespawnedConverter : JsonConverter<ServerPlayerRespawned>
  {
    public override bool CanConvert(System.Type objectType)
    {
      // this converter can be applied to any type
      return true;
    }
    public override ServerPlayerRespawned Read(ref Utf8JsonReader reader, System.Type typeToConvert, JsonSerializerOptions options)
    {
      if (reader.TokenType != JsonTokenType.StartObject)
      {
        throw new JsonException();
      }

      var instance = new ServerPlayerRespawned();
  
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
        if (propertyName == "steam_id")
        {
          var value = JsonSerializer.Deserialize<string>(ref reader, options);
          instance.SteamId = value;
          continue;
        }
        if (propertyName == "respawn_timestamp")
        {
          var value = JsonSerializer.Deserialize<string>(ref reader, options);
          instance.RespawnTimestamp = value;
          continue;
        }
        if (propertyName == "respawn_position")
        {
          var value = JsonSerializer.Deserialize<PlayerPosition>(ref reader, options);
          instance.RespawnPosition = value;
          continue;
        }

    

        if(instance.AdditionalProperties == null) { instance.AdditionalProperties = new Dictionary<string, dynamic>(); }
        var deserializedValue = JsonSerializer.Deserialize<dynamic>(ref reader, options);
        instance.AdditionalProperties.Add(propertyName, deserializedValue);
        continue;
      }
  
      throw new JsonException();
    }
    public override void Write(Utf8JsonWriter writer, ServerPlayerRespawned value, JsonSerializerOptions options)
    {
      if (value == null)
      {
        JsonSerializer.Serialize(writer, null, options);
        return;
      }
      var properties = value.GetType().GetProperties().Where(prop => prop.Name != "AdditionalProperties");
  
      writer.WriteStartObject();

      if(value.SteamId != null) { 
        // write property name and let the serializer serialize the value itself
        writer.WritePropertyName("steam_id");
        JsonSerializer.Serialize(writer, value.SteamId, options);
      }
      if(value.RespawnTimestamp != null) { 
        // write property name and let the serializer serialize the value itself
        writer.WritePropertyName("respawn_timestamp");
        JsonSerializer.Serialize(writer, value.RespawnTimestamp, options);
      }
      if(value.RespawnPosition != null) { 
        // write property name and let the serializer serialize the value itself
        writer.WritePropertyName("respawn_position");
        JsonSerializer.Serialize(writer, value.RespawnPosition, options);
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
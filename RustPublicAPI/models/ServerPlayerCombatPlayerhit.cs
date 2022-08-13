namespace Asyncapi.Nats.Client.Models
{
  using System.Collections.Generic;
  using System.Text.Json;
  using System.Text.Json.Serialization;
  using System.Text.RegularExpressions;
  using System.Linq;

  [JsonConverter(typeof(ServerPlayerCombatPlayerhitConverter))]
  public class ServerPlayerCombatPlayerhit
  {
    private string hitTimestamp;
    private PlayerOnPlayerHit playerHit;
    private Dictionary<string, dynamic> additionalProperties;

    public string HitTimestamp 
    {
      get { return hitTimestamp; }
      set { hitTimestamp = value; }
    }

    public PlayerOnPlayerHit PlayerHit 
    {
      get { return playerHit; }
      set { playerHit = value; }
    }

    public Dictionary<string, dynamic> AdditionalProperties 
    {
      get { return additionalProperties; }
      set { additionalProperties = value; }
    }
  }

  internal class ServerPlayerCombatPlayerhitConverter : JsonConverter<ServerPlayerCombatPlayerhit>
  {
    public override bool CanConvert(System.Type objectType)
    {
      // this converter can be applied to any type
      return true;
    }
    public override ServerPlayerCombatPlayerhit Read(ref Utf8JsonReader reader, System.Type typeToConvert, JsonSerializerOptions options)
    {
      if (reader.TokenType != JsonTokenType.StartObject)
      {
        throw new JsonException();
      }

      var instance = new ServerPlayerCombatPlayerhit();
  
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
        if (propertyName == "hit_timestamp")
        {
          var value = JsonSerializer.Deserialize<string>(ref reader, options);
          instance.HitTimestamp = value;
          continue;
        }
        if (propertyName == "player_hit")
        {
          var value = JsonSerializer.Deserialize<PlayerOnPlayerHit>(ref reader, options);
          instance.PlayerHit = value;
          continue;
        }

    

        if(instance.AdditionalProperties == null) { instance.AdditionalProperties = new Dictionary<string, dynamic>(); }
        var deserializedValue = JsonSerializer.Deserialize<dynamic>(ref reader, options);
        instance.AdditionalProperties.Add(propertyName, deserializedValue);
        continue;
      }
  
      throw new JsonException();
    }
    public override void Write(Utf8JsonWriter writer, ServerPlayerCombatPlayerhit value, JsonSerializerOptions options)
    {
      if (value == null)
      {
        JsonSerializer.Serialize(writer, null, options);
        return;
      }
      var properties = value.GetType().GetProperties().Where(prop => prop.Name != "AdditionalProperties");
  
      writer.WriteStartObject();

      if(value.HitTimestamp != null) { 
        // write property name and let the serializer serialize the value itself
        writer.WritePropertyName("hit_timestamp");
        JsonSerializer.Serialize(writer, value.HitTimestamp, options);
      }
      if(value.PlayerHit != null) { 
        // write property name and let the serializer serialize the value itself
        writer.WritePropertyName("player_hit");
        JsonSerializer.Serialize(writer, value.PlayerHit, options);
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
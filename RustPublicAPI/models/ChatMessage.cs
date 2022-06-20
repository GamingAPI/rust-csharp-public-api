namespace Asyncapi.Nats.Client.Models
{
  using System.Collections.Generic;
  using System.Text.Json;
  using System.Text.Json.Serialization;
  using System.Text.RegularExpressions;
  using System.Linq;

  [JsonConverter(typeof(ChatMessageConverter))]
  public class ChatMessage
  {
    private string steamId;
    private string playerName;
    private string rawMessage;
    private string fullMessage;
    private bool isAdmin;
    private int? rank;
    private string title;
    private string timestamp;
    private Dictionary<string, dynamic> additionalProperties;

    public string SteamId 
    {
      get { return steamId; }
      set { steamId = value; }
    }

    public string PlayerName 
    {
      get { return playerName; }
      set { playerName = value; }
    }

    public string RawMessage 
    {
      get { return rawMessage; }
      set { rawMessage = value; }
    }

    public string FullMessage 
    {
      get { return fullMessage; }
      set { fullMessage = value; }
    }

    public bool IsAdmin 
    {
      get { return isAdmin; }
      set { isAdmin = value; }
    }

    public int? Rank 
    {
      get { return rank; }
      set { rank = value; }
    }

    public string Title 
    {
      get { return title; }
      set { title = value; }
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

  internal class ChatMessageConverter : JsonConverter<ChatMessage>
  {
    public override bool CanConvert(System.Type objectType)
    {
      // this converter can be applied to any type
      return true;
    }
    public override ChatMessage Read(ref Utf8JsonReader reader, System.Type typeToConvert, JsonSerializerOptions options)
    {
      if (reader.TokenType != JsonTokenType.StartObject)
      {
        throw new JsonException();
      }

      var instance = new ChatMessage();
  
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
        if (propertyName == "player_name")
        {
          var value = JsonSerializer.Deserialize<string>(ref reader, options);
          instance.PlayerName = value;
          continue;
        }
        if (propertyName == "raw_message")
        {
          var value = JsonSerializer.Deserialize<string>(ref reader, options);
          instance.RawMessage = value;
          continue;
        }
        if (propertyName == "full_message")
        {
          var value = JsonSerializer.Deserialize<string>(ref reader, options);
          instance.FullMessage = value;
          continue;
        }
        if (propertyName == "is_admin")
        {
          var value = JsonSerializer.Deserialize<bool>(ref reader, options);
          instance.IsAdmin = value;
          continue;
        }
        if (propertyName == "rank")
        {
          var value = JsonSerializer.Deserialize<int?>(ref reader, options);
          instance.Rank = value;
          continue;
        }
        if (propertyName == "title")
        {
          var value = JsonSerializer.Deserialize<string>(ref reader, options);
          instance.Title = value;
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
    public override void Write(Utf8JsonWriter writer, ChatMessage value, JsonSerializerOptions options)
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
      if(value.PlayerName != null) { 
        // write property name and let the serializer serialize the value itself
        writer.WritePropertyName("player_name");
        JsonSerializer.Serialize(writer, value.PlayerName, options);
      }
      if(value.RawMessage != null) { 
        // write property name and let the serializer serialize the value itself
        writer.WritePropertyName("raw_message");
        JsonSerializer.Serialize(writer, value.RawMessage, options);
      }
      if(value.FullMessage != null) { 
        // write property name and let the serializer serialize the value itself
        writer.WritePropertyName("full_message");
        JsonSerializer.Serialize(writer, value.FullMessage, options);
      }
      if(value.IsAdmin != null) { 
        // write property name and let the serializer serialize the value itself
        writer.WritePropertyName("is_admin");
        JsonSerializer.Serialize(writer, value.IsAdmin, options);
      }
      if(value.Rank != null) { 
        // write property name and let the serializer serialize the value itself
        writer.WritePropertyName("rank");
        JsonSerializer.Serialize(writer, value.Rank, options);
      }
      if(value.Title != null) { 
        // write property name and let the serializer serialize the value itself
        writer.WritePropertyName("title");
        JsonSerializer.Serialize(writer, value.Title, options);
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
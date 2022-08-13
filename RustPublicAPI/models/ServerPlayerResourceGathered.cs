namespace Asyncapi.Nats.Client.Models
{
  using System.Collections.Generic;
  using System.Text.Json;
  using System.Text.Json.Serialization;
  using System.Text.RegularExpressions;
  using System.Linq;

  [JsonConverter(typeof(ServerPlayerResourceGatheredConverter))]
  public class ServerPlayerResourceGathered
  {
    private string gatheredTimestamp;
    private string steamId;
    private int itemUid;
    private int itemId;
    private int amount;
    private ActiveItem gatheringItem;
    private PlayerPosition gatheringPosition;
    private Dictionary<string, dynamic> additionalProperties;

    public string GatheredTimestamp 
    {
      get { return gatheredTimestamp; }
      set { gatheredTimestamp = value; }
    }

    public string SteamId 
    {
      get { return steamId; }
      set { steamId = value; }
    }

    public int ItemUid 
    {
      get { return itemUid; }
      set { itemUid = value; }
    }

    public int ItemId 
    {
      get { return itemId; }
      set { itemId = value; }
    }

    public int Amount 
    {
      get { return amount; }
      set { amount = value; }
    }

    public ActiveItem GatheringItem 
    {
      get { return gatheringItem; }
      set { gatheringItem = value; }
    }

    public PlayerPosition GatheringPosition 
    {
      get { return gatheringPosition; }
      set { gatheringPosition = value; }
    }

    public Dictionary<string, dynamic> AdditionalProperties 
    {
      get { return additionalProperties; }
      set { additionalProperties = value; }
    }
  }

  internal class ServerPlayerResourceGatheredConverter : JsonConverter<ServerPlayerResourceGathered>
  {
    public override bool CanConvert(System.Type objectType)
    {
      // this converter can be applied to any type
      return true;
    }
    public override ServerPlayerResourceGathered Read(ref Utf8JsonReader reader, System.Type typeToConvert, JsonSerializerOptions options)
    {
      if (reader.TokenType != JsonTokenType.StartObject)
      {
        throw new JsonException();
      }

      var instance = new ServerPlayerResourceGathered();
  
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
        if (propertyName == "gathered_timestamp")
        {
          var value = JsonSerializer.Deserialize<string>(ref reader, options);
          instance.GatheredTimestamp = value;
          continue;
        }
        if (propertyName == "steam_id")
        {
          var value = JsonSerializer.Deserialize<string>(ref reader, options);
          instance.SteamId = value;
          continue;
        }
        if (propertyName == "item_uid")
        {
          var value = JsonSerializer.Deserialize<int?>(ref reader, options);
          instance.ItemUid = value;
          continue;
        }
        if (propertyName == "item_id")
        {
          var value = JsonSerializer.Deserialize<int?>(ref reader, options);
          instance.ItemId = value;
          continue;
        }
        if (propertyName == "amount")
        {
          var value = JsonSerializer.Deserialize<int?>(ref reader, options);
          instance.Amount = value;
          continue;
        }
        if (propertyName == "gathering_item")
        {
          var value = JsonSerializer.Deserialize<ActiveItem>(ref reader, options);
          instance.GatheringItem = value;
          continue;
        }
        if (propertyName == "gathering_position")
        {
          var value = JsonSerializer.Deserialize<PlayerPosition>(ref reader, options);
          instance.GatheringPosition = value;
          continue;
        }

    

        if(instance.AdditionalProperties == null) { instance.AdditionalProperties = new Dictionary<string, dynamic>(); }
        var deserializedValue = JsonSerializer.Deserialize<dynamic>(ref reader, options);
        instance.AdditionalProperties.Add(propertyName, deserializedValue);
        continue;
      }
  
      throw new JsonException();
    }
    public override void Write(Utf8JsonWriter writer, ServerPlayerResourceGathered value, JsonSerializerOptions options)
    {
      if (value == null)
      {
        JsonSerializer.Serialize(writer, null, options);
        return;
      }
      var properties = value.GetType().GetProperties().Where(prop => prop.Name != "AdditionalProperties");
  
      writer.WriteStartObject();

      if(value.GatheredTimestamp != null) { 
        // write property name and let the serializer serialize the value itself
        writer.WritePropertyName("gathered_timestamp");
        JsonSerializer.Serialize(writer, value.GatheredTimestamp, options);
      }
      if(value.SteamId != null) { 
        // write property name and let the serializer serialize the value itself
        writer.WritePropertyName("steam_id");
        JsonSerializer.Serialize(writer, value.SteamId, options);
      }
      if(value.ItemUid != null) { 
        // write property name and let the serializer serialize the value itself
        writer.WritePropertyName("item_uid");
        JsonSerializer.Serialize(writer, value.ItemUid, options);
      }
      if(value.ItemId != null) { 
        // write property name and let the serializer serialize the value itself
        writer.WritePropertyName("item_id");
        JsonSerializer.Serialize(writer, value.ItemId, options);
      }
      if(value.Amount != null) { 
        // write property name and let the serializer serialize the value itself
        writer.WritePropertyName("amount");
        JsonSerializer.Serialize(writer, value.Amount, options);
      }
      if(value.GatheringItem != null) { 
        // write property name and let the serializer serialize the value itself
        writer.WritePropertyName("gathering_item");
        JsonSerializer.Serialize(writer, value.GatheringItem, options);
      }
      if(value.GatheringPosition != null) { 
        // write property name and let the serializer serialize the value itself
        writer.WritePropertyName("gathering_position");
        JsonSerializer.Serialize(writer, value.GatheringPosition, options);
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
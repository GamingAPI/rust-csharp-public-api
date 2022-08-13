namespace Asyncapi.Nats.Client.Models
{
  using System.Collections.Generic;
  using System.Text.Json;
  using System.Text.Json.Serialization;
  using System.Text.RegularExpressions;
  using System.Linq;

  [JsonConverter(typeof(ServerPlayerItemLootConverter))]
  public class ServerPlayerItemLoot
  {
    private string lootTimestamp;
    private string steamId;
    private int itemUid;
    private int itemId;
    private int containerUid;
    private string containerPrefab;
    private PlayerPosition containerPosition;
    private int amount;
    private Dictionary<string, dynamic> additionalProperties;

    public string LootTimestamp 
    {
      get { return lootTimestamp; }
      set { lootTimestamp = value; }
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

    public int ContainerUid 
    {
      get { return containerUid; }
      set { containerUid = value; }
    }

    public string ContainerPrefab 
    {
      get { return containerPrefab; }
      set { containerPrefab = value; }
    }

    public PlayerPosition ContainerPosition 
    {
      get { return containerPosition; }
      set { containerPosition = value; }
    }

    public int Amount 
    {
      get { return amount; }
      set { amount = value; }
    }

    public Dictionary<string, dynamic> AdditionalProperties 
    {
      get { return additionalProperties; }
      set { additionalProperties = value; }
    }
  }

  internal class ServerPlayerItemLootConverter : JsonConverter<ServerPlayerItemLoot>
  {
    public override bool CanConvert(System.Type objectType)
    {
      // this converter can be applied to any type
      return true;
    }
    public override ServerPlayerItemLoot Read(ref Utf8JsonReader reader, System.Type typeToConvert, JsonSerializerOptions options)
    {
      if (reader.TokenType != JsonTokenType.StartObject)
      {
        throw new JsonException();
      }

      var instance = new ServerPlayerItemLoot();
  
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
        if (propertyName == "loot_timestamp")
        {
          var value = JsonSerializer.Deserialize<string>(ref reader, options);
          instance.LootTimestamp = value;
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
        if (propertyName == "container_uid")
        {
          var value = JsonSerializer.Deserialize<int?>(ref reader, options);
          instance.ContainerUid = value;
          continue;
        }
        if (propertyName == "container_prefab")
        {
          var value = JsonSerializer.Deserialize<string>(ref reader, options);
          instance.ContainerPrefab = value;
          continue;
        }
        if (propertyName == "container_position")
        {
          var value = JsonSerializer.Deserialize<PlayerPosition>(ref reader, options);
          instance.ContainerPosition = value;
          continue;
        }
        if (propertyName == "amount")
        {
          var value = JsonSerializer.Deserialize<int?>(ref reader, options);
          instance.Amount = value;
          continue;
        }

    

        if(instance.AdditionalProperties == null) { instance.AdditionalProperties = new Dictionary<string, dynamic>(); }
        var deserializedValue = JsonSerializer.Deserialize<dynamic>(ref reader, options);
        instance.AdditionalProperties.Add(propertyName, deserializedValue);
        continue;
      }
  
      throw new JsonException();
    }
    public override void Write(Utf8JsonWriter writer, ServerPlayerItemLoot value, JsonSerializerOptions options)
    {
      if (value == null)
      {
        JsonSerializer.Serialize(writer, null, options);
        return;
      }
      var properties = value.GetType().GetProperties().Where(prop => prop.Name != "AdditionalProperties");
  
      writer.WriteStartObject();

      if(value.LootTimestamp != null) { 
        // write property name and let the serializer serialize the value itself
        writer.WritePropertyName("loot_timestamp");
        JsonSerializer.Serialize(writer, value.LootTimestamp, options);
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
      if(value.ContainerUid != null) { 
        // write property name and let the serializer serialize the value itself
        writer.WritePropertyName("container_uid");
        JsonSerializer.Serialize(writer, value.ContainerUid, options);
      }
      if(value.ContainerPrefab != null) { 
        // write property name and let the serializer serialize the value itself
        writer.WritePropertyName("container_prefab");
        JsonSerializer.Serialize(writer, value.ContainerPrefab, options);
      }
      if(value.ContainerPosition != null) { 
        // write property name and let the serializer serialize the value itself
        writer.WritePropertyName("container_position");
        JsonSerializer.Serialize(writer, value.ContainerPosition, options);
      }
      if(value.Amount != null) { 
        // write property name and let the serializer serialize the value itself
        writer.WritePropertyName("amount");
        JsonSerializer.Serialize(writer, value.Amount, options);
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
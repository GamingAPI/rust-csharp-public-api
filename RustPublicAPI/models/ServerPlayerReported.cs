namespace Asyncapi.Nats.Client.Models
{
  using System.Collections.Generic;
  using System.Text.Json;
  using System.Text.Json.Serialization;
  using System.Text.RegularExpressions;
  using System.Linq;

  [JsonConverter(typeof(ServerPlayerReportedConverter))]
  public class ServerPlayerReported
  {
    private string reporterSteamId;
    private string reportedTargetSteamId;
    private string subject;
    private string message;
    private string reportedType;
    private string timestamp;
    private Dictionary<string, dynamic> additionalProperties;

    public string ReporterSteamId 
    {
      get { return reporterSteamId; }
      set { reporterSteamId = value; }
    }

    public string ReportedTargetSteamId 
    {
      get { return reportedTargetSteamId; }
      set { reportedTargetSteamId = value; }
    }

    public string Subject 
    {
      get { return subject; }
      set { subject = value; }
    }

    public string Message 
    {
      get { return message; }
      set { message = value; }
    }

    public string ReportedType 
    {
      get { return reportedType; }
      set { reportedType = value; }
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

  internal class ServerPlayerReportedConverter : JsonConverter<ServerPlayerReported>
  {
    public override bool CanConvert(System.Type objectType)
    {
      // this converter can be applied to any type
      return true;
    }
    public override ServerPlayerReported Read(ref Utf8JsonReader reader, System.Type typeToConvert, JsonSerializerOptions options)
    {
      if (reader.TokenType != JsonTokenType.StartObject)
      {
        throw new JsonException();
      }

      var instance = new ServerPlayerReported();
  
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
        if (propertyName == "reporter_steam_id")
        {
          var value = JsonSerializer.Deserialize<string>(ref reader, options);
          instance.ReporterSteamId = value;
          continue;
        }
        if (propertyName == "reported_target_steam_id")
        {
          var value = JsonSerializer.Deserialize<string>(ref reader, options);
          instance.ReportedTargetSteamId = value;
          continue;
        }
        if (propertyName == "subject")
        {
          var value = JsonSerializer.Deserialize<string>(ref reader, options);
          instance.Subject = value;
          continue;
        }
        if (propertyName == "message")
        {
          var value = JsonSerializer.Deserialize<string>(ref reader, options);
          instance.Message = value;
          continue;
        }
        if (propertyName == "reportedType")
        {
          var value = JsonSerializer.Deserialize<string>(ref reader, options);
          instance.ReportedType = value;
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
    public override void Write(Utf8JsonWriter writer, ServerPlayerReported value, JsonSerializerOptions options)
    {
      if (value == null)
      {
        JsonSerializer.Serialize(writer, null, options);
        return;
      }
      var properties = value.GetType().GetProperties().Where(prop => prop.Name != "AdditionalProperties");
  
      writer.WriteStartObject();

      if(value.ReporterSteamId != null) { 
        // write property name and let the serializer serialize the value itself
        writer.WritePropertyName("reporter_steam_id");
        JsonSerializer.Serialize(writer, value.ReporterSteamId, options);
      }
      if(value.ReportedTargetSteamId != null) { 
        // write property name and let the serializer serialize the value itself
        writer.WritePropertyName("reported_target_steam_id");
        JsonSerializer.Serialize(writer, value.ReportedTargetSteamId, options);
      }
      if(value.Subject != null) { 
        // write property name and let the serializer serialize the value itself
        writer.WritePropertyName("subject");
        JsonSerializer.Serialize(writer, value.Subject, options);
      }
      if(value.Message != null) { 
        // write property name and let the serializer serialize the value itself
        writer.WritePropertyName("message");
        JsonSerializer.Serialize(writer, value.Message, options);
      }
      if(value.ReportedType != null) { 
        // write property name and let the serializer serialize the value itself
        writer.WritePropertyName("reportedType");
        JsonSerializer.Serialize(writer, value.ReportedType, options);
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
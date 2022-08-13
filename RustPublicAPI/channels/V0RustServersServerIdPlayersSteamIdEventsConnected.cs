using NATS.Client;
using System;
using System.Text;
using System.Text.Json;
using Asyncapi.Nats.Client.Models;

namespace Asyncapi.Nats.Client.Channels
{
  class V0RustServersServerIdPlayersSteamIdEventsConnected
  {

  internal static ServerPlayerConnected JsonDeserializerSupport(LoggingInterface logger, byte[] buffer)
{
  var srt = Encoding.UTF8.GetString(buffer);
  logger.Debug("Deserializing message " + srt);
  return JsonSerializer.Deserialize<ServerPlayerConnected>(srt);
}
  public static IAsyncSubscription Subscribe(
    LoggingInterface logger,
IEncodedConnection connection,
V0RustServersServerIdPlayersSteamIdEventsConnectedOnRequest onRequest,
String server_id,String steam_id
  )
  {
    EventHandler<EncodedMessageEventArgs> handler = (sender, args) =>
    {
      logger.Debug("Got message for channel subscription: " + $"v0.rust.servers.{server_id}.players.{steam_id}.events.connected");
      var deserializedMessage = JsonDeserializerSupport(logger, (byte[])args.ReceivedObject);

      var unmodifiedChannel = "v0.rust.servers.{server_id}.players.{steam_id}.events.connected";
  var channel = args.Subject;
  var serverIdSplit = unmodifiedChannel.Split(new string[] { "{server_id}" }, StringSplitOptions.None);
var steamIdSplit = serverIdSplit[1].Split(new string[] { "{steam_id}" }, StringSplitOptions.None);
  String[] splits = {
    serverIdSplit[0],
steamIdSplit[0],
steamIdSplit[1]
  };
  channel = channel.Substring(splits[0].Length);
var serverIdEnd = channel.IndexOf(splits[1]);
var serverIdParam = $"{channel.Substring(0, serverIdEnd)}";
channel = channel.Substring(serverIdEnd+splits[1].Length);
var steamIdEnd = channel.IndexOf(splits[2]);
var steamIdParam = $"{channel.Substring(0, steamIdEnd)}";
      
      onRequest(deserializedMessage,
serverIdParam,
steamIdParam);
    };
    logger.Debug("Subscribing to: " + $"v0.rust.servers.{server_id}.players.{steam_id}.events.connected");
    return connection.SubscribeAsync($"v0.rust.servers.{server_id}.players.{steam_id}.events.connected",handler);
  }

  }
}
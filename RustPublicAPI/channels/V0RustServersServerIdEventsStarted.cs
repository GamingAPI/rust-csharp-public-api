using NATS.Client;
using System;
using System.Text;
using System.Text.Json;
using Asyncapi.Nats.Client.Models;

namespace Asyncapi.Nats.Client.Channels
{
  class V0RustServersServerIdEventsStarted
  {

  
  public static IAsyncSubscription Subscribe(
    LoggingInterface logger,
IEncodedConnection connection,
V0RustServersServerIdEventsStartedOnRequest onRequest,
String server_id
  )
  {
    EventHandler<EncodedMessageEventArgs> handler = (sender, args) =>
    {
      logger.Debug("Got message for channel subscription: " + $"v0.rust.servers.{server_id}.events.started");
      

      var unmodifiedChannel = "v0.rust.servers.{server_id}.events.started";
  var channel = args.Subject;
  var serverIdSplit = unmodifiedChannel.Split(new string[] { "{server_id}" }, StringSplitOptions.None);
  String[] splits = {
    serverIdSplit[0],
serverIdSplit[1]
  };
  channel = channel.Substring(splits[0].Length);
var serverIdEnd = channel.IndexOf(splits[1]);
var serverIdParam = $"{channel.Substring(0, serverIdEnd)}";
      
      onRequest(serverIdParam);
    };
    logger.Debug("Subscribing to: " + $"v0.rust.servers.{server_id}.events.started");
    return connection.SubscribeAsync($"v0.rust.servers.{server_id}.events.started",handler);
  }

  }
}
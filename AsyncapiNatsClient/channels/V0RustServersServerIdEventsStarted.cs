using NATS.Client;
using System;
using System.Text;
using System.Text.Json;
using Asyncapi.Nats.Client.Models;

namespace Asyncapi.Nats.Client.Channels
{
  class V0RustServersServerIdEventsStarted
  {




public static void Publish(
  LoggingInterface logger,
IEncodedConnection connection,
String server_id
){
  logger.Debug("Publishing to channel: " + $"v0.rust.servers.{server_id}.events.started");
  connection.Publish($"v0.rust.servers.{server_id}.events.started", Encoding.UTF8.GetBytes("null"));}
}
  }
}
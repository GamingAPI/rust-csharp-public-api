using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Asyncapi.Nats.Client.Channels;
using Asyncapi.Nats.Client.Models;
using NATS.Client;
namespace Asyncapi.Nats.Client
{

  public delegate void V0RustServersServerIdEventsStartedOnRequest(
      ServerStarted request,
String server_id
    );
public delegate void V0RustServersServerIdEventsStoppedOnRequest(
      ServerStopped request,
String server_id
    );
public delegate void V0RustServersServerIdEventsPlayerSteamIdChattedOnRequest(
      ChatMessage request,
String server_id,String steam_id
    );
public delegate void V0RustServersServerIdEventsWipedOnRequest(
      String server_id
    );
public delegate void V0RustServersServerIdPlayersSteamIdEventsConnectedOnRequest(
      ServerPlayerConnected request,
String server_id,String steam_id
    );
public delegate void V0RustServersServerIdPlayersSteamIdEventsDisconnectedOnRequest(
      ServerPlayerDisconnected request,
String server_id,String steam_id
    );
public delegate void V0RustServersServerIdPlayersSteamIdEventsGatheredResourcesOnRequest(
      ServerPlayerResourceGathered request,
String server_id,String steam_id
    );
public delegate void V0RustServersServerIdPlayersSteamIdEventsRespawnedOnRequest(
      ServerPlayerRespawned request,
String server_id,String steam_id
    );
public delegate void V0RustServersServerIdPlayersSteamIdEventsCombatHitOnRequest(
      ServerPlayerCombatPlayerhit request,
String server_id,String steam_id
    );
public delegate void V0RustServersServerIdPlayersSteamIdEventsItemsItemIdPickupOnRequest(
      ServerPlayerItemPickup request,
String server_id,String steam_id,String item_id
    );
public delegate void V0RustServersServerIdPlayersSteamIdEventsItemsItemIdLootOnRequest(
      ServerPlayerItemLoot request,
String server_id,String steam_id,String item_id
    );
public delegate void V0RustServersServerIdPlayersSteamIdEventsItemsItemIdCraftedOnRequest(
      ServerPlayerItemCrafted request,
String server_id,String steam_id,String item_id
    );
public delegate void V0RustServersServerIdEventsCommandOnRequest(
      ServerCommand request,
String server_id
    );
public delegate void V0RustServersServerIdPlayersSteamIdEventsReportedOnRequest(
      ServerPlayerReported request,
String server_id,String steam_id
    );
public delegate void V0RustServersServerIdPlayersSteamIdEventsUnbannedOnRequest(
      ServerPlayerUnbanned request,
String server_id,String steam_id
    );
public delegate void V0RustServersServerIdPlayersSteamIdEventsBannedOnRequest(
      ServerPlayerBanned request,
String server_id,String steam_id
    );

  public class NatsClient
  {
    
	private class DefaultLogger : LoggingInterface
	{
		public void Debug(string m)
		{
		}

		public void Error(string m)
		{
		}

		public void Info(string m)
		{
		}
	}
	private IEncodedConnection connection;
	private LoggingInterface logger;
	public LoggingInterface Logger
	{
		get
		{
			return logger;
		}

		set
		{
			logger = value;
		}
	}	

	internal byte[] JsonSerializer(object obj)
	{
		if (obj == null)
		{
			return null;
		}
		return (byte[])obj;
	}



	internal object JsonDeserializer(byte[] buffer)
	{
		return buffer;
	}

	public void Connect()
	{
		connection = new ConnectionFactory().CreateEncodedConnection();
		setserializers();
	}

	private void setserializers()
	{
		connection.OnDeserialize = JsonDeserializer;
		connection.OnSerialize = JsonSerializer;
	}

	public void Connect(string url)
	{
		connection = new ConnectionFactory().CreateEncodedConnection(url);
		setserializers();
	}
	
	public void Connect(Options opts)
	{
		connection = new ConnectionFactory().CreateEncodedConnection(opts);
		setserializers();
	}
	public Boolean IsConnected()
	{
		return connection != null && !connection.IsClosed();
	}
	
	public void Close()
	{
		if(connection != null && !connection.IsClosed())
		{
			connection.Close();
		}
	}


    
    public NatsClient()
    {
        this.Logger = new DefaultLogger();
    }
    public NatsClient(LoggingInterface logger)
    {
        this.Logger = logger;
    }
    public IAsyncSubscription SubscribeToV0RustServersServerIdEventsStarted(
  V0RustServersServerIdEventsStartedOnRequest onRequest,
String server_id
){
  if (IsConnected())
  {
    return V0RustServersServerIdEventsStarted.Subscribe(logger,
connection,
onRequest,
server_id);
  }
  else
  {
    throw new ClientNotConnected();
  }
}
public IAsyncSubscription SubscribeToV0RustServersServerIdEventsStopped(
  V0RustServersServerIdEventsStoppedOnRequest onRequest,
String server_id
){
  if (IsConnected())
  {
    return V0RustServersServerIdEventsStopped.Subscribe(logger,
connection,
onRequest,
server_id);
  }
  else
  {
    throw new ClientNotConnected();
  }
}
public IAsyncSubscription SubscribeToV0RustServersServerIdEventsPlayerSteamIdChatted(
  V0RustServersServerIdEventsPlayerSteamIdChattedOnRequest onRequest,
String server_id,String steam_id
){
  if (IsConnected())
  {
    return V0RustServersServerIdEventsPlayerSteamIdChatted.Subscribe(logger,
connection,
onRequest,
server_id,steam_id);
  }
  else
  {
    throw new ClientNotConnected();
  }
}
public IAsyncSubscription SubscribeToV0RustServersServerIdEventsWiped(
  V0RustServersServerIdEventsWipedOnRequest onRequest,
String server_id
){
  if (IsConnected())
  {
    return V0RustServersServerIdEventsWiped.Subscribe(logger,
connection,
onRequest,
server_id);
  }
  else
  {
    throw new ClientNotConnected();
  }
}
public IAsyncSubscription SubscribeToV0RustServersServerIdPlayersSteamIdEventsConnected(
  V0RustServersServerIdPlayersSteamIdEventsConnectedOnRequest onRequest,
String server_id,String steam_id
){
  if (IsConnected())
  {
    return V0RustServersServerIdPlayersSteamIdEventsConnected.Subscribe(logger,
connection,
onRequest,
server_id,steam_id);
  }
  else
  {
    throw new ClientNotConnected();
  }
}
public IAsyncSubscription SubscribeToV0RustServersServerIdPlayersSteamIdEventsDisconnected(
  V0RustServersServerIdPlayersSteamIdEventsDisconnectedOnRequest onRequest,
String server_id,String steam_id
){
  if (IsConnected())
  {
    return V0RustServersServerIdPlayersSteamIdEventsDisconnected.Subscribe(logger,
connection,
onRequest,
server_id,steam_id);
  }
  else
  {
    throw new ClientNotConnected();
  }
}
public IAsyncSubscription SubscribeToV0RustServersServerIdPlayersSteamIdEventsGatheredResources(
  V0RustServersServerIdPlayersSteamIdEventsGatheredResourcesOnRequest onRequest,
String server_id,String steam_id
){
  if (IsConnected())
  {
    return V0RustServersServerIdPlayersSteamIdEventsGatheredResources.Subscribe(logger,
connection,
onRequest,
server_id,steam_id);
  }
  else
  {
    throw new ClientNotConnected();
  }
}
public IAsyncSubscription SubscribeToV0RustServersServerIdPlayersSteamIdEventsRespawned(
  V0RustServersServerIdPlayersSteamIdEventsRespawnedOnRequest onRequest,
String server_id,String steam_id
){
  if (IsConnected())
  {
    return V0RustServersServerIdPlayersSteamIdEventsRespawned.Subscribe(logger,
connection,
onRequest,
server_id,steam_id);
  }
  else
  {
    throw new ClientNotConnected();
  }
}
public IAsyncSubscription SubscribeToV0RustServersServerIdPlayersSteamIdEventsCombatHit(
  V0RustServersServerIdPlayersSteamIdEventsCombatHitOnRequest onRequest,
String server_id,String steam_id
){
  if (IsConnected())
  {
    return V0RustServersServerIdPlayersSteamIdEventsCombatHit.Subscribe(logger,
connection,
onRequest,
server_id,steam_id);
  }
  else
  {
    throw new ClientNotConnected();
  }
}
public IAsyncSubscription SubscribeToV0RustServersServerIdPlayersSteamIdEventsItemsItemIdPickup(
  V0RustServersServerIdPlayersSteamIdEventsItemsItemIdPickupOnRequest onRequest,
String server_id,String steam_id,String item_id
){
  if (IsConnected())
  {
    return V0RustServersServerIdPlayersSteamIdEventsItemsItemIdPickup.Subscribe(logger,
connection,
onRequest,
server_id,steam_id,item_id);
  }
  else
  {
    throw new ClientNotConnected();
  }
}
public IAsyncSubscription SubscribeToV0RustServersServerIdPlayersSteamIdEventsItemsItemIdLoot(
  V0RustServersServerIdPlayersSteamIdEventsItemsItemIdLootOnRequest onRequest,
String server_id,String steam_id,String item_id
){
  if (IsConnected())
  {
    return V0RustServersServerIdPlayersSteamIdEventsItemsItemIdLoot.Subscribe(logger,
connection,
onRequest,
server_id,steam_id,item_id);
  }
  else
  {
    throw new ClientNotConnected();
  }
}
public IAsyncSubscription SubscribeToV0RustServersServerIdPlayersSteamIdEventsItemsItemIdCrafted(
  V0RustServersServerIdPlayersSteamIdEventsItemsItemIdCraftedOnRequest onRequest,
String server_id,String steam_id,String item_id
){
  if (IsConnected())
  {
    return V0RustServersServerIdPlayersSteamIdEventsItemsItemIdCrafted.Subscribe(logger,
connection,
onRequest,
server_id,steam_id,item_id);
  }
  else
  {
    throw new ClientNotConnected();
  }
}
public IAsyncSubscription SubscribeToV0RustServersServerIdEventsCommand(
  V0RustServersServerIdEventsCommandOnRequest onRequest,
String server_id
){
  if (IsConnected())
  {
    return V0RustServersServerIdEventsCommand.Subscribe(logger,
connection,
onRequest,
server_id);
  }
  else
  {
    throw new ClientNotConnected();
  }
}
public IAsyncSubscription SubscribeToV0RustServersServerIdPlayersSteamIdEventsReported(
  V0RustServersServerIdPlayersSteamIdEventsReportedOnRequest onRequest,
String server_id,String steam_id
){
  if (IsConnected())
  {
    return V0RustServersServerIdPlayersSteamIdEventsReported.Subscribe(logger,
connection,
onRequest,
server_id,steam_id);
  }
  else
  {
    throw new ClientNotConnected();
  }
}
public IAsyncSubscription SubscribeToV0RustServersServerIdPlayersSteamIdEventsUnbanned(
  V0RustServersServerIdPlayersSteamIdEventsUnbannedOnRequest onRequest,
String server_id,String steam_id
){
  if (IsConnected())
  {
    return V0RustServersServerIdPlayersSteamIdEventsUnbanned.Subscribe(logger,
connection,
onRequest,
server_id,steam_id);
  }
  else
  {
    throw new ClientNotConnected();
  }
}
public IAsyncSubscription SubscribeToV0RustServersServerIdPlayersSteamIdEventsBanned(
  V0RustServersServerIdPlayersSteamIdEventsBannedOnRequest onRequest,
String server_id,String steam_id
){
  if (IsConnected())
  {
    return V0RustServersServerIdPlayersSteamIdEventsBanned.Subscribe(logger,
connection,
onRequest,
server_id,steam_id);
  }
  else
  {
    throw new ClientNotConnected();
  }
}
  }
}
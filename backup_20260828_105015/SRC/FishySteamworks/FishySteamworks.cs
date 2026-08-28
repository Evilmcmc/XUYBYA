using System;
using System.Runtime.CompilerServices;
using FishNet.Managing;
using FishNet.Transporting;
using FishySteamworks.Client;
using FishySteamworks.Server;
using Il2CppDummyDll;
using UnityEngine;

namespace FishySteamworks;

[Token(Token = "0x2000159")]
public class FishySteamworks : Transport
{
	[NonSerialized]
	[Token(Token = "0x4000843")]
	[FieldOffset(Offset = "0x30")]
	public ulong LocalUserSteamID;

	[Token(Token = "0x4000844")]
	[FieldOffset(Offset = "0x38")]
	[Tooltip("Address server should bind to.")]
	[SerializeField]
	private string _serverBindAddress;

	[Token(Token = "0x4000845")]
	[FieldOffset(Offset = "0x40")]
	[Tooltip("Port to use.")]
	[SerializeField]
	private ushort _port;

	[Token(Token = "0x4000846")]
	[FieldOffset(Offset = "0x42")]
	[Tooltip("Maximum number of players which may be connected at once.")]
	[Range(1f, 65535f)]
	[SerializeField]
	private ushort _maximumClients;

	[Token(Token = "0x4000847")]
	[FieldOffset(Offset = "0x44")]
	[Tooltip("True if using peer to peer socket.")]
	[SerializeField]
	private bool _peerToPeer;

	[Token(Token = "0x4000848")]
	[FieldOffset(Offset = "0x48")]
	[Tooltip("Address client should connect to.")]
	[SerializeField]
	private string _clientAddress;

	[Token(Token = "0x4000849")]
	[FieldOffset(Offset = "0x50")]
	private int[] _mtus;

	[Token(Token = "0x400084A")]
	[FieldOffset(Offset = "0x58")]
	private ClientSocket _client;

	[Token(Token = "0x400084B")]
	[FieldOffset(Offset = "0x60")]
	private ClientHostSocket _clientHost;

	[Token(Token = "0x400084C")]
	[FieldOffset(Offset = "0x68")]
	private ServerSocket _server;

	[Token(Token = "0x400084D")]
	[FieldOffset(Offset = "0x70")]
	private bool _shutdownCalled;

	[Token(Token = "0x400084E")]
	internal const int CLIENT_HOST_ID = 32767;

	[Token(Token = "0x14000003")]
	public override event Action<ClientConnectionStateArgs> OnClientConnectionState
	{
		[Token(Token = "0x6000C7C")]
		[Address(RVA = "0x55DB70", Offset = "0x55C570", VA = "0x18055DB70", Slot = "6")]
		[CompilerGenerated]
		add
		{
		}
		[Token(Token = "0x6000C7D")]
		[Address(RVA = "0x55DC70", Offset = "0x55C670", VA = "0x18055DC70", Slot = "7")]
		[CompilerGenerated]
		remove
		{
		}
	}

	[Token(Token = "0x14000004")]
	public override event Action<ServerConnectionStateArgs> OnServerConnectionState
	{
		[Token(Token = "0x6000C7E")]
		[Address(RVA = "0x55DD70", Offset = "0x55C770", VA = "0x18055DD70", Slot = "8")]
		[CompilerGenerated]
		add
		{
		}
		[Token(Token = "0x6000C7F")]
		[Address(RVA = "0x55DE70", Offset = "0x55C870", VA = "0x18055DE70", Slot = "9")]
		[CompilerGenerated]
		remove
		{
		}
	}

	[Token(Token = "0x14000005")]
	public override event Action<RemoteConnectionStateArgs> OnRemoteConnectionState
	{
		[Token(Token = "0x6000C80")]
		[Address(RVA = "0x55DF70", Offset = "0x55C970", VA = "0x18055DF70", Slot = "10")]
		[CompilerGenerated]
		add
		{
		}
		[Token(Token = "0x6000C81")]
		[Address(RVA = "0x55E070", Offset = "0x55CA70", VA = "0x18055E070", Slot = "11")]
		[CompilerGenerated]
		remove
		{
		}
	}

	[Token(Token = "0x14000006")]
	public override event Action<ClientReceivedDataArgs> OnClientReceivedData
	{
		[Token(Token = "0x6000C89")]
		[Address(RVA = "0x55E4C0", Offset = "0x55CEC0", VA = "0x18055E4C0", Slot = "19")]
		[CompilerGenerated]
		add
		{
		}
		[Token(Token = "0x6000C8A")]
		[Address(RVA = "0x55E5C0", Offset = "0x55CFC0", VA = "0x18055E5C0", Slot = "20")]
		[CompilerGenerated]
		remove
		{
		}
	}

	[Token(Token = "0x14000007")]
	public override event Action<ServerReceivedDataArgs> OnServerReceivedData
	{
		[Token(Token = "0x6000C8C")]
		[Address(RVA = "0x55E700", Offset = "0x55D100", VA = "0x18055E700", Slot = "22")]
		[CompilerGenerated]
		add
		{
		}
		[Token(Token = "0x6000C8D")]
		[Address(RVA = "0x55E800", Offset = "0x55D200", VA = "0x18055E800", Slot = "23")]
		[CompilerGenerated]
		remove
		{
		}
	}

	[Token(Token = "0x6000C74")]
	[Address(RVA = "0x55D2C0", Offset = "0x55BCC0", VA = "0x18055D2C0", Slot = "1")]
	~FishySteamworks()
	{
	}

	[Token(Token = "0x6000C75")]
	[Address(RVA = "0x55D310", Offset = "0x55BD10", VA = "0x18055D310", Slot = "4")]
	public override void Initialize(NetworkManager networkManager, int transportIndex)
	{
	}

	[Token(Token = "0x6000C76")]
	[Address(RVA = "0x55D770", Offset = "0x55C170", VA = "0x18055D770")]
	private void OnDestroy()
	{
	}

	[Token(Token = "0x6000C77")]
	[Address(RVA = "0x55D790", Offset = "0x55C190", VA = "0x18055D790")]
	private void Update()
	{
	}

	[Token(Token = "0x6000C78")]
	[Address(RVA = "0x55D7E0", Offset = "0x55C1E0", VA = "0x18055D7E0")]
	private void CreateChannelData()
	{
	}

	[Token(Token = "0x6000C79")]
	[Address(RVA = "0x55D8A0", Offset = "0x55C2A0", VA = "0x18055D8A0")]
	private bool InitializeRelayNetworkAccess()
	{
		return default(bool);
	}

	[Token(Token = "0x6000C7A")]
	[Address(RVA = "0x55D990", Offset = "0x55C390", VA = "0x18055D990")]
	public bool IsNetworkAccessAvailable()
	{
		return default(bool);
	}

	[Token(Token = "0x6000C7B")]
	[Address(RVA = "0x55D9B0", Offset = "0x55C3B0", VA = "0x18055D9B0", Slot = "5")]
	public override string GetConnectionAddress(int connectionId)
	{
		return null;
	}

	[Token(Token = "0x6000C82")]
	[Address(RVA = "0x55E170", Offset = "0x55CB70", VA = "0x18055E170", Slot = "15")]
	public override LocalConnectionState GetConnectionState(bool server)
	{
		return default(LocalConnectionState);
	}

	[Token(Token = "0x6000C83")]
	[Address(RVA = "0x55E1A0", Offset = "0x55CBA0", VA = "0x18055E1A0", Slot = "16")]
	public override RemoteConnectionState GetConnectionState(int connectionId)
	{
		return default(RemoteConnectionState);
	}

	[Token(Token = "0x6000C84")]
	[Address(RVA = "0x55E240", Offset = "0x55CC40", VA = "0x18055E240", Slot = "12")]
	public override void HandleClientConnectionState(ClientConnectionStateArgs connectionStateArgs)
	{
	}

	[Token(Token = "0x6000C85")]
	[Address(RVA = "0x55E260", Offset = "0x55CC60", VA = "0x18055E260", Slot = "13")]
	public override void HandleServerConnectionState(ServerConnectionStateArgs connectionStateArgs)
	{
	}

	[Token(Token = "0x6000C86")]
	[Address(RVA = "0x55E280", Offset = "0x55CC80", VA = "0x18055E280", Slot = "14")]
	public override void HandleRemoteConnectionState(RemoteConnectionStateArgs connectionStateArgs)
	{
	}

	[Token(Token = "0x6000C87")]
	[Address(RVA = "0x55E2C0", Offset = "0x55CCC0", VA = "0x18055E2C0", Slot = "25")]
	public override void IterateIncoming(bool server)
	{
	}

	[Token(Token = "0x6000C88")]
	[Address(RVA = "0x55E470", Offset = "0x55CE70", VA = "0x18055E470", Slot = "26")]
	public override void IterateOutgoing(bool server)
	{
	}

	[Token(Token = "0x6000C8B")]
	[Address(RVA = "0x55E6C0", Offset = "0x55D0C0", VA = "0x18055E6C0", Slot = "21")]
	public override void HandleClientReceivedDataArgs(ClientReceivedDataArgs receivedDataArgs)
	{
	}

	[Token(Token = "0x6000C8E")]
	[Address(RVA = "0x55E900", Offset = "0x55D300", VA = "0x18055E900", Slot = "24")]
	public override void HandleServerReceivedDataArgs(ServerReceivedDataArgs receivedDataArgs)
	{
	}

	[Token(Token = "0x6000C8F")]
	[Address(RVA = "0x55E950", Offset = "0x55D350", VA = "0x18055E950", Slot = "17")]
	public override void SendToServer(byte channelId, ArraySegment<byte> segment)
	{
	}

	[Token(Token = "0x6000C90")]
	[Address(RVA = "0x55EB60", Offset = "0x55D560", VA = "0x18055EB60", Slot = "18")]
	public override void SendToClient(byte channelId, ArraySegment<byte> segment, int connectionId)
	{
	}

	[Token(Token = "0x6000C91")]
	[Address(RVA = "0x55EBA0", Offset = "0x55D5A0", VA = "0x18055EBA0", Slot = "30")]
	public override int GetMaximumClients()
	{
		return default(int);
	}

	[Token(Token = "0x6000C92")]
	[Address(RVA = "0x55EBC0", Offset = "0x55D5C0", VA = "0x18055EBC0", Slot = "31")]
	public override void SetMaximumClients(int value)
	{
	}

	[Token(Token = "0x6000C93")]
	[Address(RVA = "0x513C60", Offset = "0x512660", VA = "0x180513C60", Slot = "32")]
	public override void SetClientAddress(string address)
	{
	}

	[Token(Token = "0x6000C94")]
	[Address(RVA = "0x5549C0", Offset = "0x5533C0", VA = "0x1805549C0", Slot = "34")]
	public override void SetServerBindAddress(string address, IPAddressType addressType)
	{
	}

	[Token(Token = "0x6000C95")]
	[Address(RVA = "0x55EC30", Offset = "0x55D630", VA = "0x18055EC30", Slot = "36")]
	public override void SetPort(ushort port)
	{
	}

	[Token(Token = "0x6000C96")]
	[Address(RVA = "0x55EC40", Offset = "0x55D640", VA = "0x18055EC40", Slot = "38")]
	public override bool StartConnection(bool server)
	{
		return default(bool);
	}

	[Token(Token = "0x6000C97")]
	[Address(RVA = "0x55EC60", Offset = "0x55D660", VA = "0x18055EC60", Slot = "39")]
	public override bool StopConnection(bool server)
	{
		return default(bool);
	}

	[Token(Token = "0x6000C98")]
	[Address(RVA = "0x55ECD0", Offset = "0x55D6D0", VA = "0x18055ECD0", Slot = "40")]
	public override bool StopConnection(int connectionId, bool immediately)
	{
		return default(bool);
	}

	[Token(Token = "0x6000C99")]
	[Address(RVA = "0x55EE90", Offset = "0x55D890", VA = "0x18055EE90", Slot = "41")]
	public override void Shutdown()
	{
	}

	[Token(Token = "0x6000C9A")]
	[Address(RVA = "0x55EEE0", Offset = "0x55D8E0", VA = "0x18055EEE0")]
	private bool StartServer()
	{
		return default(bool);
	}

	[Token(Token = "0x6000C9B")]
	[Address(RVA = "0x55F100", Offset = "0x55DB00", VA = "0x18055F100")]
	private bool StopServer()
	{
		return default(bool);
	}

	[Token(Token = "0x6000C9C")]
	[Address(RVA = "0x55F120", Offset = "0x55DB20", VA = "0x18055F120")]
	private bool StartClient(string address)
	{
		return default(bool);
	}

	[Token(Token = "0x6000C9D")]
	[Address(RVA = "0x55F350", Offset = "0x55DD50", VA = "0x18055F350")]
	private bool StopClient()
	{
		return default(bool);
	}

	[Token(Token = "0x6000C9E")]
	[Address(RVA = "0x55F3B0", Offset = "0x55DDB0", VA = "0x18055F3B0")]
	private bool StopClient(int connectionId, bool immediately)
	{
		return default(bool);
	}

	[Token(Token = "0x6000C9F")]
	[Address(RVA = "0x55F570", Offset = "0x55DF70", VA = "0x18055F570", Slot = "42")]
	public override int GetMTU(byte channel)
	{
		return default(int);
	}

	[Token(Token = "0x6000CA0")]
	[Address(RVA = "0x55F680", Offset = "0x55E080", VA = "0x18055F680")]
	public FishySteamworks()
	{
	}
}

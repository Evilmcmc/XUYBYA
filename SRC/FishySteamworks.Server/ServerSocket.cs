using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using FishNet.Transporting;
using FishySteamworks.Client;
using Il2CppDummyDll;
using Steamworks;

namespace FishySteamworks.Server;

[Token(Token = "0x200015A")]
public class ServerSocket : CommonSocket
{
	[Token(Token = "0x200015B")]
	public struct ConnectionChange
	{
		[Token(Token = "0x4000860")]
		[FieldOffset(Offset = "0x0")]
		public int ConnectionId;

		[Token(Token = "0x4000861")]
		[FieldOffset(Offset = "0x4")]
		public HSteamNetConnection SteamConnection;

		[Token(Token = "0x4000862")]
		[FieldOffset(Offset = "0x8")]
		public CSteamID SteamId;

		[Token(Token = "0x170000F4")]
		public bool IsConnect
		{
			[Token(Token = "0x6000CB5")]
			[Address(RVA = "0x5627A0", Offset = "0x5611A0", VA = "0x1805627A0")]
			get
			{
				return default(bool);
			}
		}

		[Token(Token = "0x6000CB6")]
		[Address(RVA = "0x5627F0", Offset = "0x5611F0", VA = "0x1805627F0")]
		public ConnectionChange(int id)
		{
		}

		[Token(Token = "0x6000CB7")]
		[Address(RVA = "0x562860", Offset = "0x561260", VA = "0x180562860")]
		public ConnectionChange(int id, HSteamNetConnection steamConnection, CSteamID steamId)
		{
		}
	}

	[Token(Token = "0x4000854")]
	[FieldOffset(Offset = "0x30")]
	private BidirectionalDictionary<HSteamNetConnection, int> _steamConnections;

	[Token(Token = "0x4000855")]
	[FieldOffset(Offset = "0x38")]
	private BidirectionalDictionary<CSteamID, int> _steamIds;

	[Token(Token = "0x4000856")]
	[FieldOffset(Offset = "0x40")]
	private int _maximumClients;

	[Token(Token = "0x4000857")]
	[FieldOffset(Offset = "0x44")]
	private int _nextConnectionId;

	[Token(Token = "0x4000858")]
	[FieldOffset(Offset = "0x48")]
	private HSteamListenSocket _socket;

	[Token(Token = "0x4000859")]
	[FieldOffset(Offset = "0x50")]
	private Queue<LocalPacket> _clientHostIncoming;

	[Token(Token = "0x400085A")]
	[FieldOffset(Offset = "0x58")]
	private bool _clientHostStarted;

	[Token(Token = "0x400085B")]
	[FieldOffset(Offset = "0x60")]
	private Callback<SteamNetConnectionStatusChangedCallback_t> _onRemoteConnectionStateCallback;

	[Token(Token = "0x400085C")]
	[FieldOffset(Offset = "0x68")]
	private Queue<int> _cachedConnectionIds;

	[Token(Token = "0x400085D")]
	[FieldOffset(Offset = "0x70")]
	private ClientHostSocket _clientHost;

	[Token(Token = "0x400085E")]
	[FieldOffset(Offset = "0x78")]
	private bool _iteratingConnections;

	[Token(Token = "0x400085F")]
	[FieldOffset(Offset = "0x80")]
	private List<ConnectionChange> _pendingConnectionChanges;

	[Token(Token = "0x6000CA1")]
	[Address(RVA = "0x55F7A0", Offset = "0x55E1A0", VA = "0x18055F7A0")]
	internal RemoteConnectionState GetConnectionState(int connectionId)
	{
		return default(RemoteConnectionState);
	}

	[Token(Token = "0x6000CA2")]
	[Address(RVA = "0x55F840", Offset = "0x55E240", VA = "0x18055F840")]
	internal void ResetInvalidSocket()
	{
	}

	[Token(Token = "0x6000CA3")]
	[Address(RVA = "0x55F8F0", Offset = "0x55E2F0", VA = "0x18055F8F0")]
	internal bool StartConnection(string address, ushort port, int maximumClients, bool peerToPeer)
	{
		return default(bool);
	}

	[Token(Token = "0x6000CA4")]
	[Address(RVA = "0x55FEF0", Offset = "0x55E8F0", VA = "0x18055FEF0")]
	internal bool StopConnection()
	{
		return default(bool);
	}

	[Token(Token = "0x6000CA5")]
	[Address(RVA = "0x5601B0", Offset = "0x55EBB0", VA = "0x1805601B0")]
	internal bool StopConnection(int connectionId)
	{
		return default(bool);
	}

	[Token(Token = "0x6000CA6")]
	[Address(RVA = "0x560370", Offset = "0x55ED70", VA = "0x180560370")]
	private bool StopConnection(int connectionId, HSteamNetConnection socket)
	{
		return default(bool);
	}

	[MethodImpl(256)]
	[Token(Token = "0x6000CA7")]
	[Address(RVA = "0x560520", Offset = "0x55EF20", VA = "0x180560520")]
	private void OnRemoteConnectionState(SteamNetConnectionStatusChangedCallback_t args)
	{
	}

	[Token(Token = "0x6000CA8")]
	[Address(RVA = "0x560AF0", Offset = "0x55F4F0", VA = "0x180560AF0")]
	private void AddConnection(int connectionId, HSteamNetConnection steamConnection, CSteamID steamId)
	{
	}

	[Token(Token = "0x6000CA9")]
	[Address(RVA = "0x560CA0", Offset = "0x55F6A0", VA = "0x180560CA0")]
	private void RemoveConnection(int connectionId)
	{
	}

	[Token(Token = "0x6000CAA")]
	[Address(RVA = "0x560E50", Offset = "0x55F850", VA = "0x180560E50")]
	internal void IterateOutgoing()
	{
	}

	[Token(Token = "0x6000CAB")]
	[Address(RVA = "0x561080", Offset = "0x55FA80", VA = "0x180561080")]
	internal void IterateIncoming()
	{
	}

	[Token(Token = "0x6000CAC")]
	[Address(RVA = "0x5617E0", Offset = "0x5601E0", VA = "0x1805617E0")]
	private void ProcessPendingConnectionChanges()
	{
	}

	[Token(Token = "0x6000CAD")]
	[Address(RVA = "0x561A70", Offset = "0x560470", VA = "0x180561A70")]
	internal void SendToClient(byte channelId, ArraySegment<byte> segment, int connectionId)
	{
	}

	[Token(Token = "0x6000CAE")]
	[Address(RVA = "0x561D40", Offset = "0x560740", VA = "0x180561D40")]
	internal string GetConnectionAddress(int connectionId)
	{
		return null;
	}

	[Token(Token = "0x6000CAF")]
	[Address(RVA = "0x561EF0", Offset = "0x5608F0", VA = "0x180561EF0")]
	internal void SetMaximumClients(int value)
	{
	}

	[Token(Token = "0x6000CB0")]
	[Address(RVA = "0x561F50", Offset = "0x560950", VA = "0x180561F50")]
	internal int GetMaximumClients()
	{
		return default(int);
	}

	[Token(Token = "0x6000CB1")]
	[Address(RVA = "0x561F60", Offset = "0x560960", VA = "0x180561F60")]
	internal void SetClientHostSocket(ClientHostSocket socket)
	{
	}

	[Token(Token = "0x6000CB2")]
	[Address(RVA = "0x561FC0", Offset = "0x5609C0", VA = "0x180561FC0")]
	internal void OnClientHostState(bool started)
	{
	}

	[Token(Token = "0x6000CB3")]
	[Address(RVA = "0x5621B0", Offset = "0x560BB0", VA = "0x1805621B0")]
	internal void ReceivedFromClientHost(LocalPacket packet)
	{
	}

	[Token(Token = "0x6000CB4")]
	[Address(RVA = "0x562220", Offset = "0x560C20", VA = "0x180562220")]
	public ServerSocket()
	{
	}
}

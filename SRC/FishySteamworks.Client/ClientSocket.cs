using System;
using System.Threading;
using Il2CppDummyDll;
using Steamworks;

namespace FishySteamworks.Client;

[Token(Token = "0x200015D")]
public class ClientSocket : CommonSocket
{
	[Token(Token = "0x4000865")]
	[FieldOffset(Offset = "0x30")]
	private Callback<SteamNetConnectionStatusChangedCallback_t> _onLocalConnectionStateCallback;

	[Token(Token = "0x4000866")]
	[FieldOffset(Offset = "0x38")]
	private CSteamID _hostSteamID;

	[Token(Token = "0x4000867")]
	[FieldOffset(Offset = "0x40")]
	private HSteamNetConnection _socket;

	[Token(Token = "0x4000868")]
	[FieldOffset(Offset = "0x48")]
	private Thread _timeoutThread;

	[Token(Token = "0x4000869")]
	[FieldOffset(Offset = "0x50")]
	private float _connectTimeout;

	[Token(Token = "0x400086A")]
	private const float CONNECT_TIMEOUT_DURATION = 8000f;

	[Token(Token = "0x6000CC0")]
	[Address(RVA = "0x562FB0", Offset = "0x5619B0", VA = "0x180562FB0")]
	private void CheckTimeout()
	{
	}

	[Token(Token = "0x6000CC1")]
	[Address(RVA = "0x5631F0", Offset = "0x561BF0", VA = "0x1805631F0")]
	internal bool StartConnection(string address, ushort port, bool peerToPeer)
	{
		return default(bool);
	}

	[Token(Token = "0x6000CC2")]
	[Address(RVA = "0x5639D0", Offset = "0x5623D0", VA = "0x1805639D0")]
	private void OnLocalConnectionState(SteamNetConnectionStatusChangedCallback_t args)
	{
	}

	[Token(Token = "0x6000CC3")]
	[Address(RVA = "0x563BB0", Offset = "0x5625B0", VA = "0x180563BB0")]
	internal bool StopConnection()
	{
		return default(bool);
	}

	[Token(Token = "0x6000CC4")]
	[Address(RVA = "0x563E50", Offset = "0x562850", VA = "0x180563E50")]
	internal void IterateIncoming()
	{
	}

	[Token(Token = "0x6000CC5")]
	[Address(RVA = "0x563FE0", Offset = "0x5629E0", VA = "0x180563FE0")]
	internal void SendToServer(byte channelId, ArraySegment<byte> segment)
	{
	}

	[Token(Token = "0x6000CC6")]
	[Address(RVA = "0x564120", Offset = "0x562B20", VA = "0x180564120")]
	internal void IterateOutgoing()
	{
	}

	[Token(Token = "0x6000CC7")]
	[Address(RVA = "0x564140", Offset = "0x562B40", VA = "0x180564140")]
	public ClientSocket()
	{
	}
}

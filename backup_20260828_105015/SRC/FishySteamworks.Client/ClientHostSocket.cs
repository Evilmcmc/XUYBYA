using System;
using System.Collections.Generic;
using FishNet.Transporting;
using FishySteamworks.Server;
using Il2CppDummyDll;

namespace FishySteamworks.Client;

[Token(Token = "0x200015C")]
public class ClientHostSocket : CommonSocket
{
	[Token(Token = "0x4000863")]
	[FieldOffset(Offset = "0x30")]
	private ServerSocket _server;

	[Token(Token = "0x4000864")]
	[FieldOffset(Offset = "0x38")]
	private Queue<LocalPacket> _incoming;

	[Token(Token = "0x6000CB8")]
	[Address(RVA = "0x562870", Offset = "0x561270", VA = "0x180562870")]
	internal void CheckSetStarted()
	{
	}

	[Token(Token = "0x6000CB9")]
	[Address(RVA = "0x5628B0", Offset = "0x5612B0", VA = "0x1805628B0")]
	internal bool StartConnection(ServerSocket serverSocket)
	{
		return default(bool);
	}

	[Token(Token = "0x6000CBA")]
	[Address(RVA = "0x5629B0", Offset = "0x5613B0", VA = "0x1805629B0", Slot = "4")]
	protected override void SetLocalConnectionState(LocalConnectionState connectionState, bool server)
	{
	}

	[Token(Token = "0x6000CBB")]
	[Address(RVA = "0x562A10", Offset = "0x561410", VA = "0x180562A10")]
	internal bool StopConnection()
	{
		return default(bool);
	}

	[Token(Token = "0x6000CBC")]
	[Address(RVA = "0x562A90", Offset = "0x561490", VA = "0x180562A90")]
	internal void IterateIncoming()
	{
	}

	[Token(Token = "0x6000CBD")]
	[Address(RVA = "0x562DC0", Offset = "0x5617C0", VA = "0x180562DC0")]
	internal void ReceivedFromLocalServer(LocalPacket packet)
	{
	}

	[Token(Token = "0x6000CBE")]
	[Address(RVA = "0x562E30", Offset = "0x561830", VA = "0x180562E30")]
	internal void SendToServer(byte channelId, ArraySegment<byte> segment)
	{
	}

	[Token(Token = "0x6000CBF")]
	[Address(RVA = "0x562EF0", Offset = "0x5618F0", VA = "0x180562EF0")]
	public ClientHostSocket()
	{
	}
}

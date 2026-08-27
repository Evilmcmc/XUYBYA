using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using FishNet.Transporting;
using Il2CppDummyDll;
using Steamworks;

namespace FishySteamworks;

[Token(Token = "0x2000157")]
public abstract class CommonSocket
{
	[Token(Token = "0x400083A")]
	[FieldOffset(Offset = "0x10")]
	private LocalConnectionState _connectionState;

	[Token(Token = "0x400083B")]
	[FieldOffset(Offset = "0x14")]
	protected bool PeerToPeer;

	[Token(Token = "0x400083C")]
	[FieldOffset(Offset = "0x18")]
	protected Transport Transport;

	[Token(Token = "0x400083D")]
	[FieldOffset(Offset = "0x20")]
	protected IntPtr[] MessagePointers;

	[Token(Token = "0x400083E")]
	[FieldOffset(Offset = "0x28")]
	protected byte[] InboundBuffer;

	[Token(Token = "0x400083F")]
	protected const int MAX_MESSAGES = 256;

	[Token(Token = "0x6000C6A")]
	[Address(RVA = "0x4E3820", Offset = "0x4E2220", VA = "0x1804E3820")]
	internal LocalConnectionState GetLocalConnectionState()
	{
		return default(LocalConnectionState);
	}

	[Token(Token = "0x6000C6B")]
	[Address(RVA = "0x55C3C0", Offset = "0x55ADC0", VA = "0x18055C3C0", Slot = "4")]
	protected virtual void SetLocalConnectionState(LocalConnectionState connectionState, bool server)
	{
	}

	[Token(Token = "0x6000C6C")]
	[Address(RVA = "0x55C440", Offset = "0x55AE40", VA = "0x18055C440", Slot = "5")]
	internal virtual void Initialize(Transport t)
	{
	}

	[Token(Token = "0x6000C6D")]
	[Address(RVA = "0x55C5E0", Offset = "0x55AFE0", VA = "0x18055C5E0")]
	protected byte[] GetIPBytes(string address)
	{
		return null;
	}

	[Token(Token = "0x6000C6E")]
	[Address(RVA = "0x55C770", Offset = "0x55B170", VA = "0x18055C770")]
	protected EResult Send(HSteamNetConnection steamConnection, ArraySegment<byte> segment, byte channelId)
	{
		return default(EResult);
	}

	[Token(Token = "0x6000C6F")]
	[Address(RVA = "0x55CBA0", Offset = "0x55B5A0", VA = "0x18055CBA0")]
	internal void ClearQueue(ConcurrentQueue<LocalPacket> queue)
	{
	}

	[Token(Token = "0x6000C70")]
	[Address(RVA = "0x55CC90", Offset = "0x55B690", VA = "0x18055CC90")]
	internal void ClearQueue(Queue<LocalPacket> queue)
	{
	}

	[Token(Token = "0x6000C71")]
	[Address(RVA = "0x55CDF0", Offset = "0x55B7F0", VA = "0x18055CDF0")]
	protected void GetMessage(IntPtr ptr, byte[] buffer, out ArraySegment<byte> segment, out byte channel)
	{
	}

	[Token(Token = "0x6000C72")]
	[Address(RVA = "0x55D0E0", Offset = "0x55BAE0", VA = "0x18055D0E0")]
	protected CommonSocket()
	{
	}
}

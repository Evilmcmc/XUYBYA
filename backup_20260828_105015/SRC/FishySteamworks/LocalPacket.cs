using System;
using Il2CppDummyDll;

namespace FishySteamworks;

[Token(Token = "0x2000158")]
internal struct LocalPacket
{
	[Token(Token = "0x4000840")]
	[FieldOffset(Offset = "0x0")]
	public byte[] Data;

	[Token(Token = "0x4000841")]
	[FieldOffset(Offset = "0x8")]
	public int Length;

	[Token(Token = "0x4000842")]
	[FieldOffset(Offset = "0xC")]
	public byte Channel;

	[Token(Token = "0x6000C73")]
	[Address(RVA = "0x55D180", Offset = "0x55BB80", VA = "0x18055D180")]
	public LocalPacket(ArraySegment<byte> data, byte channel)
	{
	}
}

using System;
using Il2CppDummyDll;

[Token(Token = "0x20000C6")]
public static class UGCHelper
{
	[Token(Token = "0x4000429")]
	[FieldOffset(Offset = "0x0")]
	public static readonly string ContentFileName;

	[Token(Token = "0x6000611")]
	[Address(RVA = "0x4D6070", Offset = "0x4D4A70", VA = "0x1804D6070")]
	public static string GetContentDirectory(string title)
	{
		return null;
	}

	[Token(Token = "0x6000612")]
	[Address(RVA = "0x4D6160", Offset = "0x4D4B60", VA = "0x1804D6160")]
	private static string GetContentFileName(string title)
	{
		return null;
	}

	[Token(Token = "0x6000613")]
	[Address(RVA = "0x4D6260", Offset = "0x4D4C60", VA = "0x1804D6260")]
	public static ulong ReadContent(string title, out DateTime timestamp, out ulong steamUserId, out string content)
	{
		return default(ulong);
	}

	[Token(Token = "0x6000614")]
	[Address(RVA = "0x4D64A0", Offset = "0x4D4EA0", VA = "0x1804D64A0")]
	public static ulong ReadContentFromFile(string filename, out string title, out DateTime timestamp, out ulong steamUserId, out string content)
	{
		return default(ulong);
	}
}

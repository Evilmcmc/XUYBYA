using System.Collections.Generic;
using Il2CppDummyDll;

[Token(Token = "0x200001C")]
public static class CLI
{
	[Token(Token = "0x400006E")]
	[FieldOffset(Offset = "0x0")]
	public static char cmdOutSet;

	[Token(Token = "0x400006F")]
	[FieldOffset(Offset = "0x8")]
	private static string cmdNotFound;

	[Token(Token = "0x4000070")]
	[FieldOffset(Offset = "0x10")]
	public static Dictionary<string, Command> commands;

	[Token(Token = "0x600009E")]
	[Address(RVA = "0x45DE30", Offset = "0x45C830", VA = "0x18045DE30")]
	public static void Execute(string input)
	{
	}
}

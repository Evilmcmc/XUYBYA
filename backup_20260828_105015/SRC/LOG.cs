using System.Collections.Generic;
using Il2CppDummyDll;

[Token(Token = "0x2000027")]
public class LOG
{
	[Token(Token = "0x4000071")]
	[FieldOffset(Offset = "0x0")]
	private static List<string> history;

	[Token(Token = "0x60000C8")]
	[Address(RVA = "0x464590", Offset = "0x462F90", VA = "0x180464590")]
	public static void Write(string input)
	{
	}

	[Token(Token = "0x60000C9")]
	[Address(RVA = "0x464690", Offset = "0x463090", VA = "0x180464690")]
	public static void ClearHistory()
	{
	}

	[Token(Token = "0x60000CA")]
	[Address(RVA = "0x464730", Offset = "0x463130", VA = "0x180464730")]
	public static string GetLastRecords(int howMany = 1)
	{
		return null;
	}

	[Token(Token = "0x60000CB")]
	[Address(RVA = "0x4576C0", Offset = "0x4560C0", VA = "0x1804576C0")]
	public LOG()
	{
	}
}

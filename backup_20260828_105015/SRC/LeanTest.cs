using System.Runtime.InteropServices;
using Il2CppDummyDll;

[Token(Token = "0x2000119")]
public class LeanTest
{
	[Token(Token = "0x40005C6")]
	[Il2CppDummyDll.FieldOffset(Offset = "0x0")]
	public static int expected;

	[Token(Token = "0x40005C7")]
	[Il2CppDummyDll.FieldOffset(Offset = "0x4")]
	private static int tests;

	[Token(Token = "0x40005C8")]
	[Il2CppDummyDll.FieldOffset(Offset = "0x8")]
	private static int passes;

	[Token(Token = "0x40005C9")]
	[Il2CppDummyDll.FieldOffset(Offset = "0xC")]
	public static float timeout;

	[Token(Token = "0x40005CA")]
	[Il2CppDummyDll.FieldOffset(Offset = "0x10")]
	public static bool timeoutStarted;

	[Token(Token = "0x40005CB")]
	[Il2CppDummyDll.FieldOffset(Offset = "0x11")]
	public static bool testsFinished;

	[Token(Token = "0x6000857")]
	[Address(RVA = "0x4FF4B0", Offset = "0x4FDEB0", VA = "0x1804FF4B0")]
	public static void debug(string name, bool didPass, [Optional] string failExplaination)
	{
	}

	[Token(Token = "0x6000858")]
	[Address(RVA = "0x4FF520", Offset = "0x4FDF20", VA = "0x1804FF520")]
	public static void expect(bool didPass, string definition, [Optional] string failExplaination)
	{
	}

	[Token(Token = "0x6000859")]
	[Address(RVA = "0x4FFCA0", Offset = "0x4FE6A0", VA = "0x1804FFCA0")]
	public static string padRight(int len)
	{
		return null;
	}

	[Token(Token = "0x600085A")]
	[Address(RVA = "0x4FFEB0", Offset = "0x4FE8B0", VA = "0x1804FFEB0")]
	public static float printOutLength(string str)
	{
		return default(float);
	}

	[Token(Token = "0x600085B")]
	[Address(RVA = "0x4FFFA0", Offset = "0x4FE9A0", VA = "0x1804FFFA0")]
	public static string formatBC(string str, string color)
	{
		return null;
	}

	[Token(Token = "0x600085C")]
	[Address(RVA = "0x500050", Offset = "0x4FEA50", VA = "0x180500050")]
	public static string formatB(string str)
	{
		return null;
	}

	[Token(Token = "0x600085D")]
	[Address(RVA = "0x5000B0", Offset = "0x4FEAB0", VA = "0x1805000B0")]
	public static string formatC(string str, string color)
	{
		return null;
	}

	[Token(Token = "0x600085E")]
	[Address(RVA = "0x5001B0", Offset = "0x4FEBB0", VA = "0x1805001B0")]
	public static void overview()
	{
	}

	[Token(Token = "0x600085F")]
	[Address(RVA = "0x4576C0", Offset = "0x4560C0", VA = "0x1804576C0")]
	public LeanTest()
	{
	}
}

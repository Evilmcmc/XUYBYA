using Il2CppDummyDll;

namespace Crosstales.BWF.Util;

[Token(Token = "0x20001EE")]
public static class Config
{
	[Token(Token = "0x4000A04")]
	[FieldOffset(Offset = "0x0")]
	public static bool DEBUG;

	[Token(Token = "0x4000A05")]
	[FieldOffset(Offset = "0x1")]
	public static bool DEBUG_BADWORDS;

	[Token(Token = "0x4000A06")]
	[FieldOffset(Offset = "0x2")]
	public static bool DEBUG_DOMAINS;

	[Token(Token = "0x4000A07")]
	[FieldOffset(Offset = "0x3")]
	public static bool _isLoaded;
}

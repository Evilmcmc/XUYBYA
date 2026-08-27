using Crosstales.Common.Util;
using Il2CppDummyDll;

namespace Crosstales.BWF.Util;

[Token(Token = "0x20001F0")]
public abstract class Helper : BaseHelper
{
	[Token(Token = "0x1700014A")]
	public static bool isSupportedPlatform
	{
		[Token(Token = "0x600101D")]
		[Address(RVA = "0x588930", Offset = "0x587330", VA = "0x180588930")]
		get
		{
			return default(bool);
		}
	}

	[Token(Token = "0x600101E")]
	[Address(RVA = "0x4576C0", Offset = "0x4560C0", VA = "0x1804576C0")]
	public static void CreateSource()
	{
	}

	[Token(Token = "0x600101F")]
	[Address(RVA = "0x59DC10", Offset = "0x59C610", VA = "0x18059DC10")]
	protected Helper()
	{
	}
}

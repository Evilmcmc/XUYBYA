using System.Collections.Generic;
using System.Text.RegularExpressions;
using Crosstales.BWF.Model;
using Il2CppDummyDll;

namespace Crosstales.BWF.Provider;

[Token(Token = "0x20001F2")]
public abstract class BadWordProvider : BaseProvider
{
	[Token(Token = "0x4000A1F")]
	[FieldOffset(Offset = "0x58")]
	protected readonly List<BadWords> _badwords;

	[Token(Token = "0x4000A20")]
	[FieldOffset(Offset = "0x60")]
	private Dictionary<string, Regex> _exactBadwordsRegex;

	[Token(Token = "0x4000A21")]
	[FieldOffset(Offset = "0x68")]
	private Dictionary<string, List<Regex>> _debugExactBadwordsRegex;

	[Token(Token = "0x4000A22")]
	[FieldOffset(Offset = "0x70")]
	private Dictionary<string, List<string>> _simpleBadwords;

	[Token(Token = "0x4000A23")]
	private const string EXACT_REGEX_START = "(?<![\\w\\d])";

	[Token(Token = "0x4000A24")]
	private const string EXACT_REGEX_END = "s?(?![\\w\\d])";

	[Token(Token = "0x1700014B")]
	public Dictionary<string, Regex> ExactBadwordsRegex
	{
		[Token(Token = "0x6001023")]
		[Address(RVA = "0x59E250", Offset = "0x59CC50", VA = "0x18059E250")]
		get
		{
			return null;
		}
		[Token(Token = "0x6001024")]
		[Address(RVA = "0x59E260", Offset = "0x59CC60", VA = "0x18059E260")]
		protected set
		{
		}
	}

	[Token(Token = "0x1700014C")]
	public Dictionary<string, List<Regex>> DebugExactBadwordsRegex
	{
		[Token(Token = "0x6001025")]
		[Address(RVA = "0x59E2C0", Offset = "0x59CCC0", VA = "0x18059E2C0")]
		get
		{
			return null;
		}
		[Token(Token = "0x6001026")]
		[Address(RVA = "0x59E2D0", Offset = "0x59CCD0", VA = "0x18059E2D0")]
		protected set
		{
		}
	}

	[Token(Token = "0x1700014D")]
	public Dictionary<string, List<string>> SimpleBadwords
	{
		[Token(Token = "0x6001027")]
		[Address(RVA = "0x59E330", Offset = "0x59CD30", VA = "0x18059E330")]
		get
		{
			return null;
		}
		[Token(Token = "0x6001028")]
		[Address(RVA = "0x561F60", Offset = "0x560960", VA = "0x180561F60")]
		protected set
		{
		}
	}

	[Token(Token = "0x6001029")]
	[Address(RVA = "0x4576C0", Offset = "0x4560C0", VA = "0x1804576C0")]
	private void Start()
	{
	}

	[Token(Token = "0x600102A")]
	[Address(RVA = "0x59E340", Offset = "0x59CD40", VA = "0x18059E340", Slot = "9")]
	public override void Load()
	{
	}

	[Token(Token = "0x600102B")]
	[Address(RVA = "0x59E3B0", Offset = "0x59CDB0", VA = "0x18059E3B0", Slot = "11")]
	protected override void init()
	{
	}

	[Token(Token = "0x600102C")]
	[Address(RVA = "0x59EFE0", Offset = "0x59D9E0", VA = "0x18059EFE0")]
	protected BadWordProvider()
	{
	}
}

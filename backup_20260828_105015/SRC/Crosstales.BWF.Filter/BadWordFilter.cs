using System.Collections.Generic;
using System.Text.RegularExpressions;
using Crosstales.BWF.Model.Enum;
using Crosstales.BWF.Provider;
using Il2CppDummyDll;

namespace Crosstales.BWF.Filter;

[Token(Token = "0x2000222")]
public class BadWordFilter : BaseFilter
{
	[Token(Token = "0x4000B0F")]
	[FieldOffset(Offset = "0x28")]
	public string ReplaceCharacters;

	[Token(Token = "0x4000B10")]
	[FieldOffset(Offset = "0x30")]
	public ReplaceMode Mode;

	[Token(Token = "0x4000B11")]
	[FieldOffset(Offset = "0x34")]
	public bool RemoveSpaces;

	[Token(Token = "0x4000B12")]
	[FieldOffset(Offset = "0x38")]
	public int MaxTextLength;

	[Token(Token = "0x4000B13")]
	[FieldOffset(Offset = "0x40")]
	public string RemoveCharacters;

	[Token(Token = "0x4000B14")]
	[FieldOffset(Offset = "0x48")]
	public bool SimpleCheck;

	[Token(Token = "0x4000B15")]
	[FieldOffset(Offset = "0x50")]
	private readonly List<BadWordProvider> _tempBadWordProviderLTR;

	[Token(Token = "0x4000B16")]
	[FieldOffset(Offset = "0x58")]
	private readonly List<BadWordProvider> _tempBadWordProviderRTL;

	[Token(Token = "0x4000B17")]
	[FieldOffset(Offset = "0x60")]
	private readonly Dictionary<string, Regex> _exactBadwordsRegex;

	[Token(Token = "0x4000B18")]
	[FieldOffset(Offset = "0x68")]
	private readonly Dictionary<string, List<Regex>> _debugExactBadwordsRegex;

	[Token(Token = "0x4000B19")]
	[FieldOffset(Offset = "0x70")]
	private readonly Dictionary<string, List<string>> _simpleBadwords;

	[Token(Token = "0x4000B1A")]
	[FieldOffset(Offset = "0x78")]
	private bool _ready;

	[Token(Token = "0x4000B1B")]
	[FieldOffset(Offset = "0x79")]
	private bool _readyFirstTime;

	[Token(Token = "0x4000B1C")]
	[FieldOffset(Offset = "0x80")]
	private List<BadWordProvider> _badWordProviderLTR;

	[Token(Token = "0x4000B1D")]
	[FieldOffset(Offset = "0x88")]
	private List<BadWordProvider> _badWordProviderRTL;

	[Token(Token = "0x17000194")]
	public List<BadWordProvider> BadWordProviderLTR
	{
		[Token(Token = "0x600115C")]
		[Address(RVA = "0x49DF40", Offset = "0x49C940", VA = "0x18049DF40")]
		get
		{
			return null;
		}
		[Token(Token = "0x600115D")]
		[Address(RVA = "0x5AD290", Offset = "0x5ABC90", VA = "0x1805AD290")]
		set
		{
		}
	}

	[Token(Token = "0x17000195")]
	public List<BadWordProvider> BadWordProviderRTL
	{
		[Token(Token = "0x600115E")]
		[Address(RVA = "0x49DFB0", Offset = "0x49C9B0", VA = "0x18049DFB0")]
		get
		{
			return null;
		}
		[Token(Token = "0x600115F")]
		[Address(RVA = "0x5AD750", Offset = "0x5AC150", VA = "0x1805AD750")]
		set
		{
		}
	}

	[Token(Token = "0x17000196")]
	public override bool isReady
	{
		[Token(Token = "0x6001160")]
		[Address(RVA = "0x5ADC10", Offset = "0x5AC610", VA = "0x1805ADC10", Slot = "12")]
		get
		{
			return default(bool);
		}
	}

	[Token(Token = "0x6001161")]
	[Address(RVA = "0x5AEC30", Offset = "0x5AD630", VA = "0x1805AEC30")]
	public BadWordFilter(List<BadWordProvider> badWordProviderLTR, List<BadWordProvider> badWordProviderRTL, string replaceCharacters = "*", ReplaceMode mode = ReplaceMode.Default, bool simpleCheck = false, bool removeSpaces = false, bool disableOrdering = false, string removeCharacters = "")
	{
	}

	[Token(Token = "0x6001162")]
	[Address(RVA = "0x5AF260", Offset = "0x5ADC60", VA = "0x1805AF260", Slot = "13")]
	public override bool Contains(string text, params string[] sourceNames)
	{
		return default(bool);
	}

	[Token(Token = "0x6001163")]
	[Address(RVA = "0x5B0360", Offset = "0x5AED60", VA = "0x1805B0360", Slot = "14")]
	public override List<string> GetAll(string text, params string[] sourceNames)
	{
		return null;
	}

	[Token(Token = "0x6001164")]
	[Address(RVA = "0x5B2ED0", Offset = "0x5B18D0", VA = "0x1805B2ED0", Slot = "15")]
	public override string ReplaceAll(string text, bool markOnly = false, string prefix = "", string postfix = "", params string[] sourceNames)
	{
		return null;
	}

	[Token(Token = "0x6001165")]
	[Address(RVA = "0x5B4A00", Offset = "0x5B3400", VA = "0x1805B4A00")]
	private string replaceCapture(string text, Capture capture, bool markOnly, string prefix, string postfix, int offset)
	{
		return null;
	}

	[Token(Token = "0x6001166")]
	[Address(RVA = "0x5B4BC0", Offset = "0x5B35C0", VA = "0x1805B4BC0")]
	protected string replaceText(string input)
	{
		return null;
	}

	[Token(Token = "0x6001167")]
	[Address(RVA = "0x5B4DD0", Offset = "0x5B37D0", VA = "0x1805B4DD0")]
	private static string replaceNonLettersOrDigits(string input)
	{
		return null;
	}

	[Token(Token = "0x6001168")]
	[Address(RVA = "0x5B5020", Offset = "0x5B3A20", VA = "0x1805B5020")]
	private static string replaceSpacesBetweenLetters(string text, int maxTextLength = 4)
	{
		return null;
	}

	[Token(Token = "0x6001169")]
	[Address(RVA = "0x5B51F0", Offset = "0x5B3BF0", VA = "0x1805B51F0")]
	private static string removeChars(string input, string removeChars)
	{
		return null;
	}

	[Token(Token = "0x600116A")]
	[Address(RVA = "0x5B53A0", Offset = "0x5B3DA0", VA = "0x1805B53A0")]
	private static string replaceLeetToText(string input)
	{
		return null;
	}

	[Token(Token = "0x600116B")]
	[Address(RVA = "0x5B59D0", Offset = "0x5B43D0", VA = "0x1805B59D0")]
	private static string replaceLeetAdvancedToText(string input)
	{
		return null;
	}
}

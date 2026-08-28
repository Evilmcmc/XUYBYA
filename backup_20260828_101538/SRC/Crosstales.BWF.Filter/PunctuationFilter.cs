using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using Il2CppDummyDll;

namespace Crosstales.BWF.Filter;

[Token(Token = "0x2000231")]
public class PunctuationFilter : BaseFilter
{
	[Token(Token = "0x4000B95")]
	[FieldOffset(Offset = "0x30")]
	private int _characterNumber;

	[Token(Token = "0x170001A0")]
	public Regex RegularExpression
	{
		[Token(Token = "0x6001205")]
		[Address(RVA = "0x48F970", Offset = "0x48E370", VA = "0x18048F970")]
		[CompilerGenerated]
		get
		{
			return null;
		}
		[Token(Token = "0x6001206")]
		[Address(RVA = "0x5C0720", Offset = "0x5BF120", VA = "0x1805C0720")]
		[CompilerGenerated]
		private set
		{
		}
	}

	[Token(Token = "0x170001A1")]
	public int CharacterNumber
	{
		[Token(Token = "0x6001207")]
		[Address(RVA = "0x5C0780", Offset = "0x5BF180", VA = "0x1805C0780")]
		get
		{
			return default(int);
		}
		[Token(Token = "0x6001208")]
		[Address(RVA = "0x5C0790", Offset = "0x5BF190", VA = "0x1805C0790")]
		set
		{
		}
	}

	[Token(Token = "0x170001A2")]
	public override bool isReady
	{
		[Token(Token = "0x6001209")]
		[Address(RVA = "0x588930", Offset = "0x587330", VA = "0x180588930", Slot = "12")]
		get
		{
			return default(bool);
		}
	}

	[Token(Token = "0x600120A")]
	[Address(RVA = "0x5C08E0", Offset = "0x5BF2E0", VA = "0x1805C08E0")]
	public PunctuationFilter(int punctuationCharacterNumber = 3, bool disableOrdering = false)
	{
	}

	[Token(Token = "0x600120B")]
	[Address(RVA = "0x5C0920", Offset = "0x5BF320", VA = "0x1805C0920", Slot = "13")]
	public override bool Contains(string text, params string[] sourceNames)
	{
		return default(bool);
	}

	[Token(Token = "0x600120C")]
	[Address(RVA = "0x5C09A0", Offset = "0x5BF3A0", VA = "0x1805C09A0", Slot = "14")]
	public override List<string> GetAll(string text, params string[] sourceNames)
	{
		return null;
	}

	[Token(Token = "0x600120D")]
	[Address(RVA = "0x5C1240", Offset = "0x5BFC40", VA = "0x1805C1240", Slot = "15")]
	public override string ReplaceAll(string text, bool markOnly = false, string prefix = "", string postfix = "", params string[] sourceNames)
	{
		return null;
	}
}

using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using Il2CppDummyDll;

namespace Crosstales.BWF.Filter;

[Token(Token = "0x2000229")]
public class CapitalizationFilter : BaseFilter
{
	[Token(Token = "0x4000B5C")]
	[FieldOffset(Offset = "0x28")]
	private int _characterNumber;

	[Token(Token = "0x17000199")]
	public Regex RegularExpression
	{
		[Token(Token = "0x60011BE")]
		[Address(RVA = "0x5B9630", Offset = "0x5B8030", VA = "0x1805B9630")]
		[CompilerGenerated]
		get
		{
			return null;
		}
		[Token(Token = "0x60011BF")]
		[Address(RVA = "0x554960", Offset = "0x553360", VA = "0x180554960")]
		[CompilerGenerated]
		private set
		{
		}
	}

	[Token(Token = "0x1700019A")]
	public int CharacterNumber
	{
		[Token(Token = "0x60011C0")]
		[Address(RVA = "0x5B9640", Offset = "0x5B8040", VA = "0x1805B9640")]
		get
		{
			return default(int);
		}
		[Token(Token = "0x60011C1")]
		[Address(RVA = "0x5B9650", Offset = "0x5B8050", VA = "0x1805B9650")]
		set
		{
		}
	}

	[Token(Token = "0x1700019B")]
	public override bool isReady
	{
		[Token(Token = "0x60011C2")]
		[Address(RVA = "0x588930", Offset = "0x587330", VA = "0x180588930", Slot = "12")]
		get
		{
			return default(bool);
		}
	}

	[Token(Token = "0x60011C3")]
	[Address(RVA = "0x5B97A0", Offset = "0x5B81A0", VA = "0x1805B97A0")]
	public CapitalizationFilter(int capitalizationCharsNumber = 3, bool disableOrdering = false)
	{
	}

	[Token(Token = "0x60011C4")]
	[Address(RVA = "0x5B97E0", Offset = "0x5B81E0", VA = "0x1805B97E0", Slot = "13")]
	public override bool Contains(string text, params string[] sourceNames)
	{
		return default(bool);
	}

	[Token(Token = "0x60011C5")]
	[Address(RVA = "0x5B9860", Offset = "0x5B8260", VA = "0x1805B9860", Slot = "14")]
	public override List<string> GetAll(string text, params string[] sourceNames)
	{
		return null;
	}

	[Token(Token = "0x60011C6")]
	[Address(RVA = "0x5BA100", Offset = "0x5B8B00", VA = "0x1805BA100", Slot = "15")]
	public override string ReplaceAll(string text, bool markOnly = false, string prefix = "", string postfix = "", params string[] sourceNames)
	{
		return null;
	}
}

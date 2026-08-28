using System.Collections.Generic;
using System.Text.RegularExpressions;
using Crosstales.BWF.Provider;
using Il2CppDummyDll;

namespace Crosstales.BWF.Filter;

[Token(Token = "0x200022B")]
public class DomainFilter : BaseFilter
{
	[Token(Token = "0x4000B64")]
	[FieldOffset(Offset = "0x28")]
	public string ReplaceCharacters;

	[Token(Token = "0x4000B65")]
	[FieldOffset(Offset = "0x30")]
	private List<DomainProvider> _domainProvider;

	[Token(Token = "0x4000B66")]
	[FieldOffset(Offset = "0x38")]
	private readonly List<DomainProvider> _tempDomainProvider;

	[Token(Token = "0x4000B67")]
	[FieldOffset(Offset = "0x40")]
	private readonly Dictionary<string, Regex> _domainsRegex;

	[Token(Token = "0x4000B68")]
	[FieldOffset(Offset = "0x48")]
	private readonly Dictionary<string, List<Regex>> _debugDomainsRegex;

	[Token(Token = "0x4000B69")]
	[FieldOffset(Offset = "0x50")]
	private bool _ready;

	[Token(Token = "0x4000B6A")]
	[FieldOffset(Offset = "0x51")]
	private bool _readyFirstTime;

	[Token(Token = "0x1700019C")]
	public List<DomainProvider> DomainProvider
	{
		[Token(Token = "0x60011CE")]
		[Address(RVA = "0x5B9630", Offset = "0x5B8030", VA = "0x1805B9630")]
		get
		{
			return null;
		}
		[Token(Token = "0x60011CF")]
		[Address(RVA = "0x5BA8D0", Offset = "0x5B92D0", VA = "0x1805BA8D0")]
		set
		{
		}
	}

	[Token(Token = "0x1700019D")]
	public override bool isReady
	{
		[Token(Token = "0x60011D0")]
		[Address(RVA = "0x5BAD50", Offset = "0x5B9750", VA = "0x1805BAD50", Slot = "12")]
		get
		{
			return default(bool);
		}
	}

	[Token(Token = "0x60011D1")]
	[Address(RVA = "0x5BB500", Offset = "0x5B9F00", VA = "0x1805BB500")]
	public DomainFilter(List<DomainProvider> domainProvider, string replaceCharacters = "*", bool disableOrdering = false)
	{
	}

	[Token(Token = "0x60011D2")]
	[Address(RVA = "0x5BB7C0", Offset = "0x5BA1C0", VA = "0x1805BB7C0", Slot = "13")]
	public override bool Contains(string text, params string[] sourceNames)
	{
		return default(bool);
	}

	[Token(Token = "0x60011D3")]
	[Address(RVA = "0x5BC260", Offset = "0x5BAC60", VA = "0x1805BC260", Slot = "14")]
	public override List<string> GetAll(string text, params string[] sourceNames)
	{
		return null;
	}

	[Token(Token = "0x60011D4")]
	[Address(RVA = "0x5BE000", Offset = "0x5BCA00", VA = "0x1805BE000", Slot = "15")]
	public override string ReplaceAll(string text, bool markOnly = false, string prefix = "", string postfix = "", params string[] sourceNames)
	{
		return null;
	}
}

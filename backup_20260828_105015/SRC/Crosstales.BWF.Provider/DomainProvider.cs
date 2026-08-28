using System.Collections.Generic;
using System.Text.RegularExpressions;
using Crosstales.BWF.Model;
using Il2CppDummyDll;

namespace Crosstales.BWF.Provider;

[Token(Token = "0x20001F9")]
public abstract class DomainProvider : BaseProvider
{
	[Token(Token = "0x4000A41")]
	[FieldOffset(Offset = "0x58")]
	protected readonly List<Domains> _domains;

	[Token(Token = "0x4000A42")]
	[FieldOffset(Offset = "0x60")]
	private Dictionary<string, Regex> _domainsRegex;

	[Token(Token = "0x4000A43")]
	[FieldOffset(Offset = "0x68")]
	private Dictionary<string, List<Regex>> _debugDomainsRegex;

	[Token(Token = "0x4000A44")]
	private const string DOMAIN_REGEGX_START = "\\b{0,1}((ht|f)tp(s?)\\:\\/\\/)?[\\w\\-\\.\\@]*[\\.]";

	[Token(Token = "0x4000A45")]
	private const string DOMAIN_REGEGX_END = "(:\\d{1,5})?(\\/|\\b)";

	[Token(Token = "0x17000154")]
	public Dictionary<string, Regex> DomainsRegex
	{
		[Token(Token = "0x6001051")]
		[Address(RVA = "0x59E250", Offset = "0x59CC50", VA = "0x18059E250")]
		get
		{
			return null;
		}
		[Token(Token = "0x6001052")]
		[Address(RVA = "0x59E260", Offset = "0x59CC60", VA = "0x18059E260")]
		protected set
		{
		}
	}

	[Token(Token = "0x17000155")]
	public Dictionary<string, List<Regex>> DebugDomainsRegex
	{
		[Token(Token = "0x6001053")]
		[Address(RVA = "0x59E2C0", Offset = "0x59CCC0", VA = "0x18059E2C0")]
		get
		{
			return null;
		}
		[Token(Token = "0x6001054")]
		[Address(RVA = "0x59E2D0", Offset = "0x59CCD0", VA = "0x18059E2D0")]
		protected set
		{
		}
	}

	[Token(Token = "0x6001055")]
	[Address(RVA = "0x4576C0", Offset = "0x4560C0", VA = "0x1804576C0")]
	private void Start()
	{
	}

	[Token(Token = "0x6001056")]
	[Address(RVA = "0x5A1820", Offset = "0x5A0220", VA = "0x1805A1820", Slot = "9")]
	public override void Load()
	{
	}

	[Token(Token = "0x6001057")]
	[Address(RVA = "0x5A1890", Offset = "0x5A0290", VA = "0x1805A1890", Slot = "11")]
	protected override void init()
	{
	}

	[Token(Token = "0x6001058")]
	[Address(RVA = "0x5A2300", Offset = "0x5A0D00", VA = "0x1805A2300")]
	protected DomainProvider()
	{
	}
}

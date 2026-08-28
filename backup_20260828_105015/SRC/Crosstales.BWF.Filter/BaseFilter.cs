using System.Collections.Generic;
using Crosstales.BWF.Data;
using Il2CppDummyDll;

namespace Crosstales.BWF.Filter;

[Token(Token = "0x2000227")]
public abstract class BaseFilter : IFilter
{
	[Token(Token = "0x4000B56")]
	[FieldOffset(Offset = "0x10")]
	public bool DisableOrdering;

	[Token(Token = "0x4000B57")]
	[FieldOffset(Offset = "0x18")]
	protected readonly Dictionary<string, Source> _sources;

	[Token(Token = "0x4000B58")]
	[FieldOffset(Offset = "0x20")]
	protected readonly List<string> _getAllResult;

	[Token(Token = "0x17000197")]
	public virtual List<Source> Sources
	{
		[Token(Token = "0x60011AE")]
		[Address(RVA = "0x5B89D0", Offset = "0x5B73D0", VA = "0x1805B89D0", Slot = "11")]
		get
		{
			return null;
		}
	}

	[Token(Token = "0x17000198")]
	public abstract bool isReady
	{
		[Token(Token = "0x60011AF")]
		get;
	}

	[Token(Token = "0x60011AD")]
	[Address(RVA = "0x5B8850", Offset = "0x5B7250", VA = "0x1805B8850")]
	public BaseFilter(bool disableOrdering)
	{
	}

	[Token(Token = "0x60011B0")]
	public abstract bool Contains(string text, params string[] sourceNames);

	[Token(Token = "0x60011B1")]
	public abstract List<string> GetAll(string text, params string[] sourceNames);

	[Token(Token = "0x60011B2")]
	public abstract string ReplaceAll(string text, bool markOnly = false, string prefix = "", string postfix = "", params string[] sourceNames);

	[Token(Token = "0x60011B3")]
	[Address(RVA = "0x5B8DC0", Offset = "0x5B77C0", VA = "0x1805B8DC0", Slot = "16")]
	public virtual string Unmark(string text, string prefix = "<b><color=red>", string postfix = "</color></b>")
	{
		return null;
	}

	[Token(Token = "0x60011B4")]
	[Address(RVA = "0x5B9080", Offset = "0x5B7A80", VA = "0x1805B9080", Slot = "17")]
	public virtual string Mark(string text, bool replace = false, string prefix = "<b><color=red>", string postfix = "</color></b>", params string[] sourceNames)
	{
		return null;
	}

	[Token(Token = "0x60011B5")]
	[Address(RVA = "0x5B90A0", Offset = "0x5B7AA0", VA = "0x1805B90A0")]
	protected static void logFilterNotReady()
	{
	}

	[Token(Token = "0x60011B6")]
	[Address(RVA = "0x5B9100", Offset = "0x5B7B00", VA = "0x1805B9100")]
	protected static void logResourceNotFound(string res)
	{
	}

	[Token(Token = "0x60011B7")]
	[Address(RVA = "0x5B9270", Offset = "0x5B7C70", VA = "0x1805B9270")]
	protected static void logContains()
	{
	}

	[Token(Token = "0x60011B8")]
	[Address(RVA = "0x5B9350", Offset = "0x5B7D50", VA = "0x1805B9350")]
	protected static void logGetAll()
	{
	}

	[Token(Token = "0x60011B9")]
	[Address(RVA = "0x5B9430", Offset = "0x5B7E30", VA = "0x1805B9430")]
	protected static void logReplaceAll()
	{
	}
}

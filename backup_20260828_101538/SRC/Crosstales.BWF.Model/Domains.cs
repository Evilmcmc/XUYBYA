using System;
using System.Collections.Generic;
using Crosstales.BWF.Data;
using Il2CppDummyDll;

namespace Crosstales.BWF.Model;

[Serializable]
[Token(Token = "0x2000200")]
public class Domains
{
	[Token(Token = "0x4000A58")]
	[FieldOffset(Offset = "0x10")]
	public Source Source;

	[Token(Token = "0x4000A59")]
	[FieldOffset(Offset = "0x18")]
	public List<string> DomainList;

	[Token(Token = "0x6001078")]
	[Address(RVA = "0x5A4A60", Offset = "0x5A3460", VA = "0x1805A4A60")]
	public Domains(Source source, IEnumerable<string> domainList)
	{
	}

	[Token(Token = "0x6001079")]
	[Address(RVA = "0x5A4E40", Offset = "0x5A3840", VA = "0x1805A4E40", Slot = "3")]
	public override string ToString()
	{
		return null;
	}

	[Token(Token = "0x600107A")]
	[Address(RVA = "0x5A50C0", Offset = "0x5A3AC0", VA = "0x1805A50C0", Slot = "0")]
	public override bool Equals(object obj)
	{
		return default(bool);
	}

	[Token(Token = "0x600107B")]
	[Address(RVA = "0x5A4A50", Offset = "0x5A3450", VA = "0x1805A4A50", Slot = "2")]
	public override int GetHashCode()
	{
		return default(int);
	}
}

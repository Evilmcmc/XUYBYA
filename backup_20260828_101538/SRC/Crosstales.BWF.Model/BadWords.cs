using System;
using System.Collections.Generic;
using Crosstales.BWF.Data;
using Il2CppDummyDll;

namespace Crosstales.BWF.Model;

[Serializable]
[Token(Token = "0x20001FF")]
public class BadWords
{
	[Token(Token = "0x4000A56")]
	[FieldOffset(Offset = "0x10")]
	public Source Source;

	[Token(Token = "0x4000A57")]
	[FieldOffset(Offset = "0x18")]
	public List<string> BadWordList;

	[Token(Token = "0x6001074")]
	[Address(RVA = "0x5A4230", Offset = "0x5A2C30", VA = "0x1805A4230")]
	public BadWords(Source source, IEnumerable<string> badWordList)
	{
	}

	[Token(Token = "0x6001075")]
	[Address(RVA = "0x5A4610", Offset = "0x5A3010", VA = "0x1805A4610", Slot = "3")]
	public override string ToString()
	{
		return null;
	}

	[Token(Token = "0x6001076")]
	[Address(RVA = "0x5A4890", Offset = "0x5A3290", VA = "0x1805A4890", Slot = "0")]
	public override bool Equals(object obj)
	{
		return default(bool);
	}

	[Token(Token = "0x6001077")]
	[Address(RVA = "0x5A4A50", Offset = "0x5A3450", VA = "0x1805A4A50", Slot = "2")]
	public override int GetHashCode()
	{
		return default(int);
	}
}

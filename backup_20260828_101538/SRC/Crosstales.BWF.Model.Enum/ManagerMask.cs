using System;
using Il2CppDummyDll;

namespace Crosstales.BWF.Model.Enum;

[Token(Token = "0x2000201")]
[Flags]
public enum ManagerMask
{
	[Token(Token = "0x4000A5B")]
	None = 0,
	[Token(Token = "0x4000A5C")]
	All = 1,
	[Token(Token = "0x4000A5D")]
	BadWord = 2,
	[Token(Token = "0x4000A5E")]
	Domain = 4,
	[Token(Token = "0x4000A5F")]
	Capitalization = 8,
	[Token(Token = "0x4000A60")]
	Punctuation = 0x10
}

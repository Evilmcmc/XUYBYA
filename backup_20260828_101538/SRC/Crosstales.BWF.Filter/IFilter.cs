using System.Collections.Generic;
using Crosstales.BWF.Data;
using Il2CppDummyDll;

namespace Crosstales.BWF.Filter;

[Token(Token = "0x2000230")]
public interface IFilter
{
	[Token(Token = "0x1700019E")]
	List<Source> Sources
	{
		[Token(Token = "0x60011FE")]
		get;
	}

	[Token(Token = "0x1700019F")]
	bool isReady
	{
		[Token(Token = "0x60011FF")]
		get;
	}

	[Token(Token = "0x6001200")]
	bool Contains(string text, params string[] sourceNames);

	[Token(Token = "0x6001201")]
	List<string> GetAll(string text, params string[] sourceNames);

	[Token(Token = "0x6001202")]
	string ReplaceAll(string text, bool markOnly = false, string prefix = "", string postfix = "", params string[] sourceNames);

	[Token(Token = "0x6001203")]
	string Mark(string text, bool replace = false, string prefix = "<b><color=red>", string postfix = "</color></b>", params string[] sourceNames);

	[Token(Token = "0x6001204")]
	string Unmark(string text, string prefix = "<b><color=red>", string postfix = "</color></b>");
}

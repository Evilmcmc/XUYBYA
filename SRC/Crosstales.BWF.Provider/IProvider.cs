using System.Collections.Generic;
using Crosstales.BWF.Data;
using Il2CppDummyDll;

namespace Crosstales.BWF.Provider;

[Token(Token = "0x20001FE")]
public interface IProvider
{
	[Token(Token = "0x1700015A")]
	bool isReady
	{
		[Token(Token = "0x600106F")]
		get;
		[Token(Token = "0x6001070")]
		set;
	}

	[Token(Token = "0x6001071")]
	void Load();

	[Token(Token = "0x6001072")]
	void Save();

	[Token(Token = "0x6001073")]
	List<string> Verify(Source source);
}

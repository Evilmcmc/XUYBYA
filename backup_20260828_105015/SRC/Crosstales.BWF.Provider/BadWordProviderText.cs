using System.Collections;
using System.Runtime.CompilerServices;
using Crosstales.BWF.Data;
using Il2CppDummyDll;
using UnityEngine;

namespace Crosstales.BWF.Provider;

[Token(Token = "0x20001F3")]
[HelpURL("https://www.crosstales.com/media/data/assets/badwordfilter/api/class_crosstales_1_1_b_w_f_1_1_provider_1_1_bad_word_provider_text.html")]
public class BadWordProviderText : BadWordProvider
{
	[Token(Token = "0x4000A25")]
	[FieldOffset(Offset = "0x78")]
	private bool _webSuccess;

	[Token(Token = "0x600102E")]
	[Address(RVA = "0x59F360", Offset = "0x59DD60", VA = "0x18059F360", Slot = "9")]
	public override void Load()
	{
	}

	[Token(Token = "0x600102F")]
	[Address(RVA = "0x59F7D0", Offset = "0x59E1D0", VA = "0x18059F7D0", Slot = "10")]
	public override void Save()
	{
	}

	[Token(Token = "0x6001030")]
	[Address(RVA = "0x59F840", Offset = "0x59E240", VA = "0x18059F840")]
	[IteratorStateMachine(typeof(_003CloadWeb_003Ed__3))]
	private IEnumerator loadWeb(Source src)
	{
		return null;
	}

	[Token(Token = "0x6001031")]
	[Address(RVA = "0x59F940", Offset = "0x59E340", VA = "0x18059F940")]
	[IteratorStateMachine(typeof(_003CloadResource_003Ed__4))]
	private IEnumerator loadResource(Source src)
	{
		return null;
	}

	[Token(Token = "0x6001032")]
	[Address(RVA = "0x59FA40", Offset = "0x59E440", VA = "0x18059FA40")]
	public BadWordProviderText()
	{
	}
}

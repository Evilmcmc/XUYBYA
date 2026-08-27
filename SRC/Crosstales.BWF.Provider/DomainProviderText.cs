using System.Collections;
using System.Runtime.CompilerServices;
using Crosstales.BWF.Data;
using Il2CppDummyDll;
using UnityEngine;

namespace Crosstales.BWF.Provider;

[Token(Token = "0x20001FA")]
[HelpURL("https://www.crosstales.com/media/data/assets/badwordfilter/api/class_crosstales_1_1_b_w_f_1_1_provider_1_1_domain_provider_text.html")]
public class DomainProviderText : DomainProvider
{
	[Token(Token = "0x4000A46")]
	[FieldOffset(Offset = "0x70")]
	private bool _webSuccess;

	[Token(Token = "0x600105A")]
	[Address(RVA = "0x5A25E0", Offset = "0x5A0FE0", VA = "0x1805A25E0", Slot = "9")]
	public override void Load()
	{
	}

	[Token(Token = "0x600105B")]
	[Address(RVA = "0x5A2A50", Offset = "0x5A1450", VA = "0x1805A2A50", Slot = "10")]
	public override void Save()
	{
	}

	[Token(Token = "0x600105C")]
	[Address(RVA = "0x5A2AC0", Offset = "0x5A14C0", VA = "0x1805A2AC0")]
	[IteratorStateMachine(typeof(_003CloadWeb_003Ed__3))]
	private IEnumerator loadWeb(Source src)
	{
		return null;
	}

	[Token(Token = "0x600105D")]
	[Address(RVA = "0x5A2BC0", Offset = "0x5A15C0", VA = "0x1805A2BC0")]
	[IteratorStateMachine(typeof(_003CloadResource_003Ed__4))]
	private IEnumerator loadResource(Source src)
	{
		return null;
	}

	[Token(Token = "0x600105E")]
	[Address(RVA = "0x5A2CC0", Offset = "0x5A16C0", VA = "0x1805A2CC0")]
	public DomainProviderText()
	{
	}
}

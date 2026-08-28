using System;
using Il2CppDummyDll;
using UnityEngine.Events;

namespace Crosstales.BWF;

[Serializable]
[Token(Token = "0x20001E9")]
public class OnGetAllCompleted : UnityEvent<string, string>
{
	[Token(Token = "0x600100C")]
	[Address(RVA = "0x59D730", Offset = "0x59C130", VA = "0x18059D730")]
	public OnGetAllCompleted()
	{
	}
}

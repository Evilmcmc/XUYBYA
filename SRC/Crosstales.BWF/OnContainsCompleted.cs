using System;
using Il2CppDummyDll;
using UnityEngine.Events;

namespace Crosstales.BWF;

[Serializable]
[Token(Token = "0x20001E8")]
public class OnContainsCompleted : UnityEvent<string, bool>
{
	[Token(Token = "0x600100B")]
	[Address(RVA = "0x59D6A0", Offset = "0x59C0A0", VA = "0x18059D6A0")]
	public OnContainsCompleted()
	{
	}
}

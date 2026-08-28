using System;
using Il2CppDummyDll;
using UnityEngine.Events;

namespace Crosstales.BWF;

[Serializable]
[Token(Token = "0x20001EA")]
public class OnReplaceAllCompleted : UnityEvent<string, string>
{
	[Token(Token = "0x600100D")]
	[Address(RVA = "0x59D770", Offset = "0x59C170", VA = "0x18059D770")]
	public OnReplaceAllCompleted()
	{
	}
}

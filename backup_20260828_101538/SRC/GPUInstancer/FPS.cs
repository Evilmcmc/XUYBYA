using System.Collections;
using System.Runtime.CompilerServices;
using Il2CppDummyDll;
using UnityEngine;

namespace GPUInstancer;

[Token(Token = "0x2000150")]
public class FPS : MonoBehaviour
{
	[Token(Token = "0x4000812")]
	[FieldOffset(Offset = "0x20")]
	public float FPSCount;

	[Token(Token = "0x6000C3A")]
	[Address(RVA = "0x559A60", Offset = "0x558460", VA = "0x180559A60")]
	[IteratorStateMachine(typeof(_003CStart_003Ed__1))]
	private IEnumerator Start()
	{
		return null;
	}

	[Token(Token = "0x6000C3B")]
	[Address(RVA = "0x457FB0", Offset = "0x4569B0", VA = "0x180457FB0")]
	public FPS()
	{
	}
}

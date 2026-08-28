using System.Collections;
using System.Runtime.CompilerServices;
using Il2CppDummyDll;
using UnityEngine;

[Token(Token = "0x2000117")]
public class LeanTester : MonoBehaviour
{
	[Token(Token = "0x40005C1")]
	[FieldOffset(Offset = "0x20")]
	public float timeout;

	[Token(Token = "0x600084E")]
	[Address(RVA = "0x4FF020", Offset = "0x4FDA20", VA = "0x1804FF020")]
	public void Start()
	{
	}

	[Token(Token = "0x600084F")]
	[Address(RVA = "0x4FF0D0", Offset = "0x4FDAD0", VA = "0x1804FF0D0")]
	[IteratorStateMachine(typeof(_003CtimeoutCheck_003Ed__2))]
	private IEnumerator timeoutCheck()
	{
		return null;
	}

	[Token(Token = "0x6000850")]
	[Address(RVA = "0x4FF170", Offset = "0x4FDB70", VA = "0x1804FF170")]
	public LeanTester()
	{
	}
}

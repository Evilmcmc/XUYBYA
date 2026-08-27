using System.Collections;
using System.Runtime.CompilerServices;
using Il2CppDummyDll;
using UnityEngine;

[Token(Token = "0x20000C9")]
public class HostButton : MonoBehaviour
{
	[Token(Token = "0x400043B")]
	[FieldOffset(Offset = "0x20")]
	[SerializeField]
	private HostMatchSettings hostMatchSettings;

	[Token(Token = "0x600061E")]
	[Address(RVA = "0x4D7F70", Offset = "0x4D6970", VA = "0x1804D7F70")]
	public void Host()
	{
	}

	[Token(Token = "0x600061F")]
	[Address(RVA = "0x4D8020", Offset = "0x4D6A20", VA = "0x1804D8020")]
	[IteratorStateMachine(typeof(_003CStartHost_003Ed__2))]
	private IEnumerator StartHost()
	{
		return null;
	}

	[Token(Token = "0x6000620")]
	[Address(RVA = "0x457FB0", Offset = "0x4569B0", VA = "0x180457FB0")]
	public HostButton()
	{
	}
}

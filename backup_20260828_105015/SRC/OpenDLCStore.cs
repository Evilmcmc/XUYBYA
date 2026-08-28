using Il2CppDummyDll;
using Steamworks;
using UnityEngine;

[Token(Token = "0x2000073")]
public class OpenDLCStore : MonoBehaviour
{
	[Token(Token = "0x40001F1")]
	[FieldOffset(Offset = "0x20")]
	public AppId_t appId_T;

	[Token(Token = "0x60002E4")]
	[Address(RVA = "0x48FDF0", Offset = "0x48E7F0", VA = "0x18048FDF0")]
	public void OpenStore()
	{
	}

	[Token(Token = "0x60002E5")]
	[Address(RVA = "0x457FB0", Offset = "0x4569B0", VA = "0x180457FB0")]
	public OpenDLCStore()
	{
	}
}

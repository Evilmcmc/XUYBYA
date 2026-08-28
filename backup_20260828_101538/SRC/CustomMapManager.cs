using Il2CppDummyDll;
using UnityEngine;

[Token(Token = "0x200002F")]
public class CustomMapManager : MonoBehaviour
{
	[Token(Token = "0x400008C")]
	[FieldOffset(Offset = "0x20")]
	public Transform mapToggleParent;

	[Token(Token = "0x400008D")]
	[FieldOffset(Offset = "0x28")]
	public Transform mapToggleParent2;

	[Token(Token = "0x400008E")]
	[FieldOffset(Offset = "0x30")]
	public MapToggle mapTogglePrefab;

	[Token(Token = "0x60000E3")]
	[Address(RVA = "0x4656C0", Offset = "0x4640C0", VA = "0x1804656C0")]
	private void Start()
	{
	}

	[Token(Token = "0x60000E4")]
	[Address(RVA = "0x457FB0", Offset = "0x4569B0", VA = "0x180457FB0")]
	public CustomMapManager()
	{
	}
}

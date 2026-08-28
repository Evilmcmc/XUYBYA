using Il2CppDummyDll;
using UnityEngine;
using UnityEngine.UI;

[Token(Token = "0x200006A")]
public class MapTogglesMin1Toggle : MonoBehaviour
{
	[Token(Token = "0x40001AF")]
	[FieldOffset(Offset = "0x20")]
	[SerializeField]
	private Transform[] mapToggleParents;

	[Token(Token = "0x40001B0")]
	[FieldOffset(Offset = "0x28")]
	[SerializeField]
	private GameObject hostButton;

	[Token(Token = "0x60002B0")]
	[Address(RVA = "0x48D220", Offset = "0x48BC20", VA = "0x18048D220")]
	public void CheckToggles(Toggle toggle)
	{
	}

	[Token(Token = "0x60002B1")]
	[Address(RVA = "0x457FB0", Offset = "0x4569B0", VA = "0x180457FB0")]
	public MapTogglesMin1Toggle()
	{
	}
}

using Il2CppDummyDll;
using UnityEngine;
using UnityEngine.UI;

[Token(Token = "0x20000D3")]
public class Min1Toggle : MonoBehaviour
{
	[Token(Token = "0x4000466")]
	[FieldOffset(Offset = "0x20")]
	[SerializeField]
	private Toggle[] toggles;

	[Token(Token = "0x6000655")]
	[Address(RVA = "0x4576C0", Offset = "0x4560C0", VA = "0x1804576C0")]
	private void Start()
	{
	}

	[Token(Token = "0x6000656")]
	[Address(RVA = "0x4DB300", Offset = "0x4D9D00", VA = "0x1804DB300")]
	public void CheckToggles(Toggle toggle)
	{
	}

	[Token(Token = "0x6000657")]
	[Address(RVA = "0x457FB0", Offset = "0x4569B0", VA = "0x180457FB0")]
	public Min1Toggle()
	{
	}
}

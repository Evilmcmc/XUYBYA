using System.Collections.Generic;
using Il2CppDummyDll;
using UnityEngine;

[Token(Token = "0x20000D4")]
public class TabGroup : MonoBehaviour
{
	[Token(Token = "0x4000467")]
	[FieldOffset(Offset = "0x20")]
	[SerializeField]
	private List<Tab_Button> tabButtons;

	[Token(Token = "0x4000468")]
	[FieldOffset(Offset = "0x28")]
	[SerializeField]
	private Sprite tabIdle;

	[Token(Token = "0x4000469")]
	[FieldOffset(Offset = "0x30")]
	[SerializeField]
	private Sprite tabHover;

	[Token(Token = "0x400046A")]
	[FieldOffset(Offset = "0x38")]
	[SerializeField]
	private Sprite tabActive;

	[Token(Token = "0x400046B")]
	[FieldOffset(Offset = "0x40")]
	[SerializeField]
	private Tab_Button selectedTab;

	[Token(Token = "0x400046C")]
	[FieldOffset(Offset = "0x48")]
	[SerializeField]
	private List<GameObject> objectsToSwap;

	[Token(Token = "0x6000658")]
	[Address(RVA = "0x4DB4E0", Offset = "0x4D9EE0", VA = "0x1804DB4E0")]
	public void Subscribe(Tab_Button button)
	{
	}

	[Token(Token = "0x6000659")]
	[Address(RVA = "0x4DB620", Offset = "0x4DA020", VA = "0x1804DB620")]
	public void OnTabEnter(Tab_Button button)
	{
	}

	[Token(Token = "0x600065A")]
	[Address(RVA = "0x4DB7D0", Offset = "0x4DA1D0", VA = "0x1804DB7D0")]
	public void OnTabExit(Tab_Button button)
	{
	}

	[Token(Token = "0x600065B")]
	[Address(RVA = "0x4DB7E0", Offset = "0x4DA1E0", VA = "0x1804DB7E0")]
	public void OnTabSelected(Tab_Button button)
	{
	}

	[Token(Token = "0x600065C")]
	[Address(RVA = "0x4DB9A0", Offset = "0x4DA3A0", VA = "0x1804DB9A0")]
	public void ResetTabs()
	{
	}

	[Token(Token = "0x600065D")]
	[Address(RVA = "0x457FB0", Offset = "0x4569B0", VA = "0x180457FB0")]
	public TabGroup()
	{
	}
}

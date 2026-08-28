using Il2CppDummyDll;
using TMPro;
using UnityEngine;

[Token(Token = "0x20000C7")]
public class ButtonHover : MonoBehaviour
{
	[Token(Token = "0x400042A")]
	[FieldOffset(Offset = "0x20")]
	[SerializeField]
	private TMP_Text text;

	[Token(Token = "0x400042B")]
	[FieldOffset(Offset = "0x28")]
	[SerializeField]
	private TMP_FontAsset normalFont;

	[Token(Token = "0x400042C")]
	[FieldOffset(Offset = "0x30")]
	[SerializeField]
	private TMP_FontAsset hoverFont;

	[Token(Token = "0x400042D")]
	[FieldOffset(Offset = "0x38")]
	[SerializeField]
	private bool changeColor;

	[Token(Token = "0x400042E")]
	[FieldOffset(Offset = "0x3C")]
	[SerializeField]
	private Color normalColor;

	[Token(Token = "0x400042F")]
	[FieldOffset(Offset = "0x4C")]
	[SerializeField]
	private Color hoverColor;

	[Token(Token = "0x4000430")]
	[FieldOffset(Offset = "0x60")]
	[SerializeField]
	private AudioSource hoverSoundEffect;

	[Token(Token = "0x4000431")]
	[FieldOffset(Offset = "0x68")]
	public bool canInteract;

	[Token(Token = "0x6000616")]
	[Address(RVA = "0x4D6890", Offset = "0x4D5290", VA = "0x1804D6890")]
	private void OnEnable()
	{
	}

	[Token(Token = "0x6000617")]
	[Address(RVA = "0x4D6980", Offset = "0x4D5380", VA = "0x1804D6980")]
	public void HoverButton()
	{
	}

	[Token(Token = "0x6000618")]
	[Address(RVA = "0x4D6CB0", Offset = "0x4D56B0", VA = "0x1804D6CB0")]
	public void NormalButton()
	{
	}

	[Token(Token = "0x6000619")]
	[Address(RVA = "0x4D6F50", Offset = "0x4D5950", VA = "0x1804D6F50")]
	public ButtonHover()
	{
	}
}

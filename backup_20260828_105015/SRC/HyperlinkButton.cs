using Il2CppDummyDll;
using UnityEngine;

[Token(Token = "0x20000CB")]
public class HyperlinkButton : MonoBehaviour
{
	[Token(Token = "0x400043F")]
	[FieldOffset(Offset = "0x20")]
	[HideInInspector]
	public string public_url;

	[Token(Token = "0x6000627")]
	[Address(RVA = "0x4D8380", Offset = "0x4D6D80", VA = "0x1804D8380")]
	public void OpenURL()
	{
	}

	[Token(Token = "0x6000628")]
	[Address(RVA = "0x4D83E0", Offset = "0x4D6DE0", VA = "0x1804D83E0")]
	public void OpenURL(string url)
	{
	}

	[Token(Token = "0x6000629")]
	[Address(RVA = "0x457FB0", Offset = "0x4569B0", VA = "0x180457FB0")]
	public HyperlinkButton()
	{
	}
}

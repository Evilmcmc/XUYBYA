using Il2CppDummyDll;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[Token(Token = "0x20000F1")]
public class MapToggle : MonoBehaviour
{
	[Token(Token = "0x4000508")]
	[FieldOffset(Offset = "0x20")]
	public MapData mapData;

	[Token(Token = "0x4000509")]
	[FieldOffset(Offset = "0x28")]
	[SerializeField]
	private RawImage graphic;

	[Token(Token = "0x400050A")]
	[FieldOffset(Offset = "0x30")]
	[SerializeField]
	private RawImage disabledGraphic;

	[Token(Token = "0x400050B")]
	[FieldOffset(Offset = "0x38")]
	[SerializeField]
	private TMP_Text label;

	[Token(Token = "0x6000737")]
	[Address(RVA = "0x4EB5D0", Offset = "0x4E9FD0", VA = "0x1804EB5D0")]
	public void CheckMin1Toggle()
	{
	}

	[Token(Token = "0x6000738")]
	[Address(RVA = "0x4EB7B0", Offset = "0x4EA1B0", VA = "0x1804EB7B0")]
	public void AddCustomMap(Texture2D mapImage, string customMapTitle, ulong steamFileId)
	{
	}

	[Token(Token = "0x6000739")]
	[Address(RVA = "0x457FB0", Offset = "0x4569B0", VA = "0x180457FB0")]
	public MapToggle()
	{
	}
}

using System;
using Il2CppDummyDll;
using UnityEngine.Localization;

[Serializable]
[Token(Token = "0x20000F0")]
public class MapData
{
	[Token(Token = "0x4000504")]
	[FieldOffset(Offset = "0x10")]
	public string sceneName;

	[Token(Token = "0x4000505")]
	[FieldOffset(Offset = "0x18")]
	public LocalizedString mapTitle;

	[Token(Token = "0x4000506")]
	[FieldOffset(Offset = "0x20")]
	public string customMapTitle;

	[Token(Token = "0x4000507")]
	[FieldOffset(Offset = "0x28")]
	public ulong steamFileId;

	[Token(Token = "0x6000736")]
	[Address(RVA = "0x4576C0", Offset = "0x4560C0", VA = "0x1804576C0")]
	public MapData()
	{
	}
}

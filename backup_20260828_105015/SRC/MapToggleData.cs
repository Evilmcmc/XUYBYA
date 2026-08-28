using Il2CppDummyDll;
using Steamworks;
using UnityEngine;

[Token(Token = "0x20000FE")]
public class MapToggleData
{
	[Token(Token = "0x4000533")]
	[FieldOffset(Offset = "0x10")]
	public string name;

	[Token(Token = "0x4000534")]
	[FieldOffset(Offset = "0x18")]
	public PublishedFileId_t id;

	[Token(Token = "0x4000535")]
	[FieldOffset(Offset = "0x20")]
	public Texture2D preview;

	[Token(Token = "0x60007B9")]
	[Address(RVA = "0x4F2720", Offset = "0x4F1120", VA = "0x1804F2720")]
	public MapToggleData(string name, PublishedFileId_t id, Texture2D preview)
	{
	}
}

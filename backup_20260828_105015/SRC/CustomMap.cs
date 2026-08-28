using Il2CppDummyDll;
using Steamworks;
using UnityEngine;

[Token(Token = "0x20000B4")]
public struct CustomMap
{
	[Token(Token = "0x40003E1")]
	[FieldOffset(Offset = "0x0")]
	public string name;

	[Token(Token = "0x40003E2")]
	[FieldOffset(Offset = "0x8")]
	public Sprite image;

	[Token(Token = "0x40003E3")]
	[FieldOffset(Offset = "0x10")]
	public GameObject gameObject;

	[Token(Token = "0x40003E4")]
	[FieldOffset(Offset = "0x18")]
	public PublishedFileId_t fileId;

	[Token(Token = "0x40003E5")]
	[FieldOffset(Offset = "0x20")]
	public string filePath;
}

using System;
using Il2CppDummyDll;
using UnityEngine;
using UnityEngine.Localization;

[Serializable]
[Token(Token = "0x2000028")]
public struct PlayerCosmetic
{
	[Token(Token = "0x4000072")]
	[FieldOffset(Offset = "0x0")]
	public LocalizedString cosmeticName;

	[Token(Token = "0x4000073")]
	[FieldOffset(Offset = "0x8")]
	public string itemDef;

	[Token(Token = "0x4000074")]
	[FieldOffset(Offset = "0x10")]
	public Mesh cosmetic;

	[Token(Token = "0x4000075")]
	[FieldOffset(Offset = "0x18")]
	public Material[] materials;

	[Token(Token = "0x4000076")]
	[FieldOffset(Offset = "0x20")]
	[HideInInspector]
	public CosmeticPack cosmeticsPack;
}

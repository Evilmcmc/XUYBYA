using System;
using Il2CppDummyDll;
using UnityEngine;
using UnityEngine.Localization;

[Serializable]
[Token(Token = "0x2000029")]
public struct HatCosmetic
{
	[Token(Token = "0x4000077")]
	[FieldOffset(Offset = "0x0")]
	public LocalizedString name;

	[Token(Token = "0x4000078")]
	[FieldOffset(Offset = "0x8")]
	public string itemDef;

	[Token(Token = "0x4000079")]
	[FieldOffset(Offset = "0x10")]
	public GameObject cosmeticGameObject;

	[Token(Token = "0x400007A")]
	[FieldOffset(Offset = "0x18")]
	[HideInInspector]
	public CosmeticPack cosmeticsPack;
}

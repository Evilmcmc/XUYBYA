using Il2CppDummyDll;
using UnityEngine;

[Token(Token = "0x200002A")]
[CreateAssetMenu(fileName = "Cosmetics", menuName = "Cosmetics/Cosmetic Pack")]
public class CosmeticPack : ScriptableObject
{
	[Token(Token = "0x400007B")]
	[FieldOffset(Offset = "0x18")]
	public int DLC_ID;

	[Token(Token = "0x400007C")]
	[FieldOffset(Offset = "0x20")]
	public Sprite header_Texture;

	[Token(Token = "0x400007D")]
	[FieldOffset(Offset = "0x28")]
	public HatCosmetic[] hats;

	[Token(Token = "0x400007E")]
	[FieldOffset(Offset = "0x30")]
	public PlayerCosmetic[] bodies;

	[Token(Token = "0x60000CD")]
	[Address(RVA = "0x464A10", Offset = "0x463410", VA = "0x180464A10")]
	public CosmeticPack()
	{
	}
}

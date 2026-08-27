using Il2CppDummyDll;
using UnityEngine;
using UnityEngine.Localization;

[Token(Token = "0x20000A3")]
[CreateAssetMenu(fileName = "Weapon", menuName = "Weapons/Weapon")]
public class WeaponScriptableObject : ScriptableObject
{
	[Token(Token = "0x400038D")]
	[FieldOffset(Offset = "0x18")]
	[Header("Stats")]
	public int minimumDamage;

	[Token(Token = "0x400038E")]
	[FieldOffset(Offset = "0x1C")]
	public int maximumDamage;

	[Token(Token = "0x400038F")]
	[FieldOffset(Offset = "0x20")]
	public float range;

	[Token(Token = "0x4000390")]
	[FieldOffset(Offset = "0x24")]
	public float attackRate;

	[Token(Token = "0x4000391")]
	[FieldOffset(Offset = "0x28")]
	public float aimAssist;

	[Token(Token = "0x4000392")]
	[FieldOffset(Offset = "0x2C")]
	public float knockBack;

	[Token(Token = "0x4000393")]
	[FieldOffset(Offset = "0x30")]
	public int maximumAttacks;

	[Token(Token = "0x4000394")]
	[FieldOffset(Offset = "0x38")]
	[Header("Effects")]
	public GameObject impact;

	[Token(Token = "0x4000395")]
	[FieldOffset(Offset = "0x40")]
	public TrailRenderer trail;

	[Token(Token = "0x4000396")]
	[FieldOffset(Offset = "0x48")]
	public string[] sfx;

	[Token(Token = "0x4000397")]
	[FieldOffset(Offset = "0x50")]
	public float cameraShakeMagnitude;

	[Token(Token = "0x4000398")]
	[FieldOffset(Offset = "0x54")]
	public float trailTravelTime;

	[Token(Token = "0x4000399")]
	[FieldOffset(Offset = "0x58")]
	public float handRbMultiplier;

	[Token(Token = "0x400039A")]
	[FieldOffset(Offset = "0x60")]
	[Header("Info")]
	public Sprite sprite;

	[Token(Token = "0x400039B")]
	[FieldOffset(Offset = "0x68")]
	public LocalizedString weaponName;

	[Token(Token = "0x60004EE")]
	[Address(RVA = "0x4C1D50", Offset = "0x4C0750", VA = "0x1804C1D50")]
	public WeaponScriptableObject()
	{
	}
}

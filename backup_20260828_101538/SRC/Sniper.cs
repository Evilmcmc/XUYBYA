using FishNet.Object;
using Il2CppDummyDll;
using UnityEngine;

[Token(Token = "0x200009E")]
public class Sniper : Weapon
{
	[Token(Token = "0x400036C")]
	[FieldOffset(Offset = "0x128")]
	[SerializeField]
	public float aimingFOV;

	[Token(Token = "0x400036D")]
	[FieldOffset(Offset = "0x12C")]
	[HideInInspector]
	public bool aiming;

	[Token(Token = "0x400036E")]
	[FieldOffset(Offset = "0x12D")]
	private bool fireKeyWasHeld;

	[Token(Token = "0x400036F")]
	[FieldOffset(Offset = "0x12E")]
	private bool NetworkInitialize___EarlySniperAssembly_002DCSharp_002Edll_Excuted;

	[Token(Token = "0x4000370")]
	[FieldOffset(Offset = "0x12F")]
	private bool NetworkInitialize__LateSniperAssembly_002DCSharp_002Edll_Excuted;

	[Token(Token = "0x60004B2")]
	[Address(RVA = "0x4BC9F0", Offset = "0x4BB3F0", VA = "0x1804BC9F0", Slot = "27")]
	[Client]
	public override void ClientTryShoot()
	{
	}

	[Token(Token = "0x60004B3")]
	[Address(RVA = "0x464E10", Offset = "0x463810", VA = "0x180464E10")]
	public Sniper()
	{
	}

	[Token(Token = "0x60004B4")]
	[Address(RVA = "0x4BCD20", Offset = "0x4BB720", VA = "0x1804BCD20", Slot = "37")]
	public override void NetworkInitialize___Early()
	{
	}

	[Token(Token = "0x60004B5")]
	[Address(RVA = "0x4BCD40", Offset = "0x4BB740", VA = "0x1804BCD40", Slot = "38")]
	public override void NetworkInitialize__Late()
	{
	}

	[Token(Token = "0x60004B6")]
	[Address(RVA = "0x4B3B30", Offset = "0x4B2530", VA = "0x1804B3B30", Slot = "18")]
	public override void NetworkInitializeIfDisabled()
	{
	}

	[Token(Token = "0x60004B7")]
	[Address(RVA = "0x4B3B70", Offset = "0x4B2570", VA = "0x1804B3B70", Slot = "41")]
	public override void Awake()
	{
	}
}

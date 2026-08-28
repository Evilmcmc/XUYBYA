using System.Collections;
using System.Runtime.CompilerServices;
using FishNet.Object;
using Il2CppDummyDll;
using UnityEngine;

[Token(Token = "0x200009C")]
public class Shotgun : Weapon
{
	[Token(Token = "0x400035D")]
	[FieldOffset(Offset = "0x128")]
	[SerializeField]
	private float trailRandomness;

	[Token(Token = "0x400035E")]
	[FieldOffset(Offset = "0x12C")]
	[SerializeField]
	private int numberOfTrails;

	[Token(Token = "0x400035F")]
	[FieldOffset(Offset = "0x130")]
	private bool NetworkInitialize___EarlyShotgunAssembly_002DCSharp_002Edll_Excuted;

	[Token(Token = "0x4000360")]
	[FieldOffset(Offset = "0x131")]
	private bool NetworkInitialize__LateShotgunAssembly_002DCSharp_002Edll_Excuted;

	[Token(Token = "0x60004A5")]
	[Address(RVA = "0x4BB5A0", Offset = "0x4B9FA0", VA = "0x1804BB5A0", Slot = "29")]
	[Server]
	public override int GetDamage(Vector3 hitPoint)
	{
		return default(int);
	}

	[Token(Token = "0x60004A6")]
	[Address(RVA = "0x4BB850", Offset = "0x4BA250", VA = "0x1804BB850", Slot = "35")]
	[IteratorStateMachine(typeof(_003CSharedEffects_003Ed__3))]
	[Client]
	public override IEnumerator SharedEffects(Vector3 hitPoint, int hitId, bool didHit, short damage, bool applyDamage)
	{
		return null;
	}

	[Token(Token = "0x60004A7")]
	[Address(RVA = "0x464E10", Offset = "0x463810", VA = "0x180464E10")]
	public Shotgun()
	{
	}

	[Token(Token = "0x60004A8")]
	[Address(RVA = "0x4B3AE0", Offset = "0x4B24E0", VA = "0x1804B3AE0", Slot = "37")]
	public override void NetworkInitialize___Early()
	{
	}

	[Token(Token = "0x60004A9")]
	[Address(RVA = "0x4B3B00", Offset = "0x4B2500", VA = "0x1804B3B00", Slot = "38")]
	public override void NetworkInitialize__Late()
	{
	}

	[Token(Token = "0x60004AA")]
	[Address(RVA = "0x4B3B30", Offset = "0x4B2530", VA = "0x1804B3B30", Slot = "18")]
	public override void NetworkInitializeIfDisabled()
	{
	}

	[Token(Token = "0x60004AB")]
	[Address(RVA = "0x4B3B70", Offset = "0x4B2570", VA = "0x1804B3B70", Slot = "41")]
	public override void Awake()
	{
	}
}

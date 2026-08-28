using System.Collections;
using System.Runtime.CompilerServices;
using FishNet.Object;
using Il2CppDummyDll;
using UnityEngine;

[Token(Token = "0x2000095")]
public class BurstRifle : Weapon
{
	[Token(Token = "0x4000333")]
	[FieldOffset(Offset = "0x128")]
	[SerializeField]
	private int burstShots;

	[Token(Token = "0x4000334")]
	[FieldOffset(Offset = "0x12C")]
	[SerializeField]
	private float timeBetweenShots;

	[Token(Token = "0x4000335")]
	[FieldOffset(Offset = "0x130")]
	private bool NetworkInitialize___EarlyBurstRifleAssembly_002DCSharp_002Edll_Excuted;

	[Token(Token = "0x4000336")]
	[FieldOffset(Offset = "0x131")]
	private bool NetworkInitialize__LateBurstRifleAssembly_002DCSharp_002Edll_Excuted;

	[Token(Token = "0x6000447")]
	[Address(RVA = "0x4B3840", Offset = "0x4B2240", VA = "0x1804B3840", Slot = "27")]
	[Client]
	public override void ClientTryShoot()
	{
	}

	[Token(Token = "0x6000448")]
	[Address(RVA = "0x4B3A20", Offset = "0x4B2420", VA = "0x1804B3A20")]
	[IteratorStateMachine(typeof(_003CBurstFire_003Ed__3))]
	private IEnumerator BurstFire()
	{
		return null;
	}

	[Token(Token = "0x6000449")]
	[Address(RVA = "0x4B3AC0", Offset = "0x4B24C0", VA = "0x1804B3AC0")]
	public BurstRifle()
	{
	}

	[Token(Token = "0x600044A")]
	[Address(RVA = "0x4B3AE0", Offset = "0x4B24E0", VA = "0x1804B3AE0", Slot = "37")]
	public override void NetworkInitialize___Early()
	{
	}

	[Token(Token = "0x600044B")]
	[Address(RVA = "0x4B3B00", Offset = "0x4B2500", VA = "0x1804B3B00", Slot = "38")]
	public override void NetworkInitialize__Late()
	{
	}

	[Token(Token = "0x600044C")]
	[Address(RVA = "0x4B3B30", Offset = "0x4B2530", VA = "0x1804B3B30", Slot = "18")]
	public override void NetworkInitializeIfDisabled()
	{
	}

	[Token(Token = "0x600044D")]
	[Address(RVA = "0x4B3B70", Offset = "0x4B2570", VA = "0x1804B3B70", Slot = "41")]
	public override void Awake()
	{
	}
}

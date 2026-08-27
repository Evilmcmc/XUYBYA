using FishNet.Object;
using FishNet.Serializing;
using FishNet.Transporting;
using Il2CppDummyDll;
using UnityEngine;

[Token(Token = "0x2000098")]
public class Machete : Weapon
{
	[Token(Token = "0x400033D")]
	[FieldOffset(Offset = "0x128")]
	[SerializeField]
	private ParticleSystem slash;

	[Token(Token = "0x400033E")]
	[FieldOffset(Offset = "0x130")]
	private bool hasSlashed;

	[Token(Token = "0x400033F")]
	[FieldOffset(Offset = "0x131")]
	private bool NetworkInitialize___EarlyMacheteAssembly_002DCSharp_002Edll_Excuted;

	[Token(Token = "0x4000340")]
	[FieldOffset(Offset = "0x132")]
	private bool NetworkInitialize__LateMacheteAssembly_002DCSharp_002Edll_Excuted;

	[Token(Token = "0x600045E")]
	[Address(RVA = "0x4B53C0", Offset = "0x4B3DC0", VA = "0x1804B53C0", Slot = "27")]
	[Client]
	public override void ClientTryShoot()
	{
	}

	[Token(Token = "0x600045F")]
	[Address(RVA = "0x4B5670", Offset = "0x4B4070", VA = "0x1804B5670", Slot = "33")]
	[ObserversRpc]
	public override void StartSharedEffects(short[] hitPointData, int hitId, bool didHit, short damage, bool applyDamage)
	{
	}

	[Token(Token = "0x6000460")]
	[Address(RVA = "0x464E10", Offset = "0x463810", VA = "0x180464E10")]
	public Machete()
	{
	}

	[Token(Token = "0x6000461")]
	[Address(RVA = "0x4B56A0", Offset = "0x4B40A0", VA = "0x1804B56A0", Slot = "37")]
	public override void NetworkInitialize___Early()
	{
	}

	[Token(Token = "0x6000462")]
	[Address(RVA = "0x4B5740", Offset = "0x4B4140", VA = "0x1804B5740", Slot = "38")]
	public override void NetworkInitialize__Late()
	{
	}

	[Token(Token = "0x6000463")]
	[Address(RVA = "0x4B3B30", Offset = "0x4B2530", VA = "0x1804B3B30", Slot = "18")]
	public override void NetworkInitializeIfDisabled()
	{
	}

	[Token(Token = "0x6000464")]
	[Address(RVA = "0x4B5770", Offset = "0x4B4170", VA = "0x1804B5770")]
	private void RpcWriter___Observers_StartSharedEffects_3088379076(short[] hitPointData, int hitId, bool didHit, short damage, bool applyDamage)
	{
	}

	[Token(Token = "0x6000465")]
	[Address(RVA = "0x4B59C0", Offset = "0x4B43C0", VA = "0x1804B59C0", Slot = "40")]
	public override void RpcLogic___StartSharedEffects_3088379076(short[] hitPointData, int hitId, bool didHit, short damage, bool applyDamage)
	{
	}

	[Token(Token = "0x6000466")]
	[Address(RVA = "0x4B6530", Offset = "0x4B4F30", VA = "0x1804B6530")]
	private void RpcReader___Observers_StartSharedEffects_3088379076(PooledReader PooledReader0, Channel channel)
	{
	}

	[Token(Token = "0x6000467")]
	[Address(RVA = "0x4B3B70", Offset = "0x4B2570", VA = "0x1804B3B70", Slot = "41")]
	public override void Awake()
	{
	}
}

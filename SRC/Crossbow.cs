using FishNet.Object;
using FishNet.Serializing;
using FishNet.Transporting;
using Il2CppDummyDll;

[Token(Token = "0x2000097")]
public class Crossbow : Weapon
{
	[Token(Token = "0x400033B")]
	[FieldOffset(Offset = "0x128")]
	private bool NetworkInitialize___EarlyCrossbowAssembly_002DCSharp_002Edll_Excuted;

	[Token(Token = "0x400033C")]
	[FieldOffset(Offset = "0x129")]
	private bool NetworkInitialize__LateCrossbowAssembly_002DCSharp_002Edll_Excuted;

	[Token(Token = "0x6000454")]
	[Address(RVA = "0x4B3F60", Offset = "0x4B2960", VA = "0x1804B3F60", Slot = "34")]
	[Client]
	public override void LocalEffects()
	{
	}

	[Token(Token = "0x6000455")]
	[Address(RVA = "0x4B49F0", Offset = "0x4B33F0", VA = "0x1804B49F0", Slot = "33")]
	[ObserversRpc]
	public override void StartSharedEffects(short[] hitPointData, int hitId, bool didHit, short damage, bool applyDamage)
	{
	}

	[Token(Token = "0x6000456")]
	[Address(RVA = "0x464E10", Offset = "0x463810", VA = "0x180464E10")]
	public Crossbow()
	{
	}

	[Token(Token = "0x6000457")]
	[Address(RVA = "0x4B4A20", Offset = "0x4B3420", VA = "0x1804B4A20", Slot = "37")]
	public override void NetworkInitialize___Early()
	{
	}

	[Token(Token = "0x6000458")]
	[Address(RVA = "0x4B4AC0", Offset = "0x4B34C0", VA = "0x1804B4AC0", Slot = "38")]
	public override void NetworkInitialize__Late()
	{
	}

	[Token(Token = "0x6000459")]
	[Address(RVA = "0x4B3B30", Offset = "0x4B2530", VA = "0x1804B3B30", Slot = "18")]
	public override void NetworkInitializeIfDisabled()
	{
	}

	[Token(Token = "0x600045A")]
	[Address(RVA = "0x4B4AF0", Offset = "0x4B34F0", VA = "0x1804B4AF0")]
	private void RpcWriter___Observers_StartSharedEffects_3088379076(short[] hitPointData, int hitId, bool didHit, short damage, bool applyDamage)
	{
	}

	[Token(Token = "0x600045B")]
	[Address(RVA = "0x4B4D40", Offset = "0x4B3740", VA = "0x1804B4D40", Slot = "40")]
	public override void RpcLogic___StartSharedEffects_3088379076(short[] hitPointData, int hitId, bool didHit, short damage, bool applyDamage)
	{
	}

	[Token(Token = "0x600045C")]
	[Address(RVA = "0x4B4FD0", Offset = "0x4B39D0", VA = "0x1804B4FD0")]
	private void RpcReader___Observers_StartSharedEffects_3088379076(PooledReader PooledReader0, Channel channel)
	{
	}

	[Token(Token = "0x600045D")]
	[Address(RVA = "0x4B3B70", Offset = "0x4B2570", VA = "0x1804B3B70", Slot = "41")]
	public override void Awake()
	{
	}
}

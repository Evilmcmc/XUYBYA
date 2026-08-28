using System.Collections;
using System.Runtime.CompilerServices;
using FishNet.Object;
using FishNet.Serializing;
using FishNet.Transporting;
using Il2CppDummyDll;
using UnityEngine;

[Token(Token = "0x2000038")]
public class Barrel : NetworkBehaviour
{
	[Token(Token = "0x40000AA")]
	[FieldOffset(Offset = "0xF8")]
	[HideInInspector]
	public bool isExploding;

	[Token(Token = "0x40000AB")]
	[FieldOffset(Offset = "0x100")]
	[SerializeField]
	private GameObject explosionEffect;

	[Token(Token = "0x40000AC")]
	[FieldOffset(Offset = "0x108")]
	[SerializeField]
	private Material normalMat;

	[Token(Token = "0x40000AD")]
	[FieldOffset(Offset = "0x110")]
	[SerializeField]
	private Material ditheredMat;

	[Token(Token = "0x40000AE")]
	[FieldOffset(Offset = "0x118")]
	[SerializeField]
	private float explosionRadius;

	[Token(Token = "0x40000AF")]
	[FieldOffset(Offset = "0x11C")]
	[SerializeField]
	private int damage;

	[Token(Token = "0x40000B0")]
	[FieldOffset(Offset = "0x120")]
	private MeshRenderer meshRenderer;

	[Token(Token = "0x40000B1")]
	[FieldOffset(Offset = "0x128")]
	private MeshCollider meshCollider;

	[Token(Token = "0x40000B2")]
	[FieldOffset(Offset = "0x130")]
	private bool NetworkInitialize___EarlyBarrelAssembly_002DCSharp_002Edll_Excuted;

	[Token(Token = "0x40000B3")]
	[FieldOffset(Offset = "0x131")]
	private bool NetworkInitialize__LateBarrelAssembly_002DCSharp_002Edll_Excuted;

	[Token(Token = "0x6000116")]
	[Address(RVA = "0x469360", Offset = "0x467D60", VA = "0x180469360", Slot = "27")]
	public override void Awake()
	{
	}

	[Token(Token = "0x6000117")]
	[Address(RVA = "0x4694A0", Offset = "0x467EA0", VA = "0x1804694A0")]
	[Server]
	public void Explode(int shootingPlayerIndex, bool shootingPlayerIsAwayTeam)
	{
	}

	[Token(Token = "0x6000118")]
	[Address(RVA = "0x469670", Offset = "0x468070", VA = "0x180469670")]
	[IteratorStateMachine(typeof(_003CExplodeWithDelay_003Ed__10))]
	[Server]
	public IEnumerator ExplodeWithDelay(int shootingPlayerIndex, bool awayTeam)
	{
		return null;
	}

	[Token(Token = "0x6000119")]
	[Address(RVA = "0x4697A0", Offset = "0x4681A0", VA = "0x1804697A0")]
	[IteratorStateMachine(typeof(_003CDestroyAndRespawn_003Ed__11))]
	[Server]
	private IEnumerator DestroyAndRespawn()
	{
		return null;
	}

	[Token(Token = "0x600011A")]
	[Address(RVA = "0x469890", Offset = "0x468290", VA = "0x180469890")]
	[ObserversRpc]
	private void ChangeObjectState(bool active)
	{
	}

	[Token(Token = "0x600011B")]
	[Address(RVA = "0x469A10", Offset = "0x468410", VA = "0x180469A10")]
	[ObserversRpc]
	private void ClientExplosion()
	{
	}

	[Token(Token = "0x600011C")]
	[Address(RVA = "0x469B70", Offset = "0x468570", VA = "0x180469B70")]
	public Barrel()
	{
	}

	[Token(Token = "0x600011D")]
	[Address(RVA = "0x469B90", Offset = "0x468590", VA = "0x180469B90", Slot = "28")]
	public override void NetworkInitialize___Early()
	{
	}

	[Token(Token = "0x600011E")]
	[Address(RVA = "0x469C70", Offset = "0x468670", VA = "0x180469C70", Slot = "29")]
	public override void NetworkInitialize__Late()
	{
	}

	[Token(Token = "0x600011F")]
	[Address(RVA = "0x469C90", Offset = "0x468690", VA = "0x180469C90", Slot = "18")]
	public override void NetworkInitializeIfDisabled()
	{
	}

	[Token(Token = "0x6000120")]
	[Address(RVA = "0x469890", Offset = "0x468290", VA = "0x180469890")]
	private void RpcWriter___Observers_ChangeObjectState_1140765316(bool active)
	{
	}

	[Token(Token = "0x6000121")]
	[Address(RVA = "0x469CD0", Offset = "0x4686D0", VA = "0x180469CD0")]
	private void RpcLogic___ChangeObjectState_1140765316(bool active)
	{
	}

	[Token(Token = "0x6000122")]
	[Address(RVA = "0x46A110", Offset = "0x468B10", VA = "0x18046A110")]
	private void RpcReader___Observers_ChangeObjectState_1140765316(PooledReader PooledReader0, Channel channel)
	{
	}

	[Token(Token = "0x6000123")]
	[Address(RVA = "0x469A10", Offset = "0x468410", VA = "0x180469A10")]
	private void RpcWriter___Observers_ClientExplosion_2166136261()
	{
	}

	[Token(Token = "0x6000124")]
	[Address(RVA = "0x46A170", Offset = "0x468B70", VA = "0x18046A170")]
	private void RpcLogic___ClientExplosion_2166136261()
	{
	}

	[Token(Token = "0x6000125")]
	[Address(RVA = "0x46A380", Offset = "0x468D80", VA = "0x18046A380")]
	private void RpcReader___Observers_ClientExplosion_2166136261(PooledReader PooledReader0, Channel channel)
	{
	}

	[Token(Token = "0x6000126")]
	[Address(RVA = "0x46A3B0", Offset = "0x468DB0", VA = "0x18046A3B0")]
	private void Awake_UserLogic_Barrel_Assembly_002DCSharp_002Edll()
	{
	}
}

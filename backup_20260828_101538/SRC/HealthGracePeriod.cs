using System.Collections;
using System.Runtime.CompilerServices;
using FishNet.Object;
using FishNet.Object.Synchronizing;
using FishNet.Serializing;
using FishNet.Transporting;
using Il2CppDummyDll;
using UnityEngine;

[Token(Token = "0x2000059")]
public class HealthGracePeriod : NetworkBehaviour
{
	[Token(Token = "0x4000161")]
	[FieldOffset(Offset = "0xF8")]
	[SerializeField]
	private GameObject Shield;

	[Token(Token = "0x4000162")]
	[FieldOffset(Offset = "0x100")]
	[SerializeField]
	private float ShieldLerpSpeed;

	[Token(Token = "0x4000163")]
	[FieldOffset(Offset = "0x108")]
	[SerializeField]
	private AudioManager audioManager;

	[Token(Token = "0x4000164")]
	[FieldOffset(Offset = "0x110")]
	[HideInInspector]
	public readonly SyncVar<bool> canTakeDamage;

	[Token(Token = "0x4000165")]
	[FieldOffset(Offset = "0x118")]
	private float dissolve;

	[Token(Token = "0x4000166")]
	[FieldOffset(Offset = "0x11C")]
	private int gracePeriod;

	[Token(Token = "0x4000167")]
	[FieldOffset(Offset = "0x120")]
	private bool NetworkInitialize___EarlyHealthGracePeriodAssembly_002DCSharp_002Edll_Excuted;

	[Token(Token = "0x4000168")]
	[FieldOffset(Offset = "0x121")]
	private bool NetworkInitialize__LateHealthGracePeriodAssembly_002DCSharp_002Edll_Excuted;

	[Token(Token = "0x600023F")]
	[Address(RVA = "0x4867E0", Offset = "0x4851E0", VA = "0x1804867E0", Slot = "10")]
	public override void OnStartServer()
	{
	}

	[Token(Token = "0x6000240")]
	[Address(RVA = "0x4868B0", Offset = "0x4852B0", VA = "0x1804868B0")]
	[IteratorStateMachine(typeof(_003CServerInvincibility_003Ed__7))]
	[Server]
	private IEnumerator ServerInvincibility()
	{
		return null;
	}

	[Token(Token = "0x6000241")]
	[Address(RVA = "0x4869A0", Offset = "0x4853A0", VA = "0x1804869A0")]
	[Server]
	public void StopInvincibility()
	{
	}

	[Token(Token = "0x6000242")]
	[Address(RVA = "0x486A30", Offset = "0x485430", VA = "0x180486A30")]
	[Server]
	private void RemoveShield()
	{
	}

	[Token(Token = "0x6000243")]
	[Address(RVA = "0x486C30", Offset = "0x485630", VA = "0x180486C30")]
	[ObserversRpc]
	private void StartClientInvinsibilityOpen()
	{
	}

	[Token(Token = "0x6000244")]
	[Address(RVA = "0x486D90", Offset = "0x485790", VA = "0x180486D90")]
	[IteratorStateMachine(typeof(_003CClientInvincibilityOpen_003Ed__11))]
	[Client]
	private IEnumerator ClientInvincibilityOpen()
	{
		return null;
	}

	[Token(Token = "0x6000245")]
	[Address(RVA = "0x486E80", Offset = "0x485880", VA = "0x180486E80")]
	[ObserversRpc]
	private void ClientRemoveShield()
	{
	}

	[Token(Token = "0x6000246")]
	[Address(RVA = "0x486FE0", Offset = "0x4859E0", VA = "0x180486FE0")]
	[IteratorStateMachine(typeof(_003CClientShieldFade_003Ed__13))]
	[Client]
	private IEnumerator ClientShieldFade()
	{
		return null;
	}

	[Token(Token = "0x6000247")]
	[Address(RVA = "0x4870D0", Offset = "0x485AD0", VA = "0x1804870D0")]
	public HealthGracePeriod()
	{
	}

	[Token(Token = "0x6000248")]
	[Address(RVA = "0x4871D0", Offset = "0x485BD0", VA = "0x1804871D0", Slot = "27")]
	public override void NetworkInitialize___Early()
	{
	}

	[Token(Token = "0x6000249")]
	[Address(RVA = "0x4872E0", Offset = "0x485CE0", VA = "0x1804872E0", Slot = "28")]
	public override void NetworkInitialize__Late()
	{
	}

	[Token(Token = "0x600024A")]
	[Address(RVA = "0x4592B0", Offset = "0x457CB0", VA = "0x1804592B0", Slot = "18")]
	public override void NetworkInitializeIfDisabled()
	{
	}

	[Token(Token = "0x600024B")]
	[Address(RVA = "0x486C30", Offset = "0x485630", VA = "0x180486C30")]
	private void RpcWriter___Observers_StartClientInvinsibilityOpen_2166136261()
	{
	}

	[Token(Token = "0x600024C")]
	[Address(RVA = "0x487320", Offset = "0x485D20", VA = "0x180487320")]
	private void RpcLogic___StartClientInvinsibilityOpen_2166136261()
	{
	}

	[Token(Token = "0x600024D")]
	[Address(RVA = "0x487420", Offset = "0x485E20", VA = "0x180487420")]
	private void RpcReader___Observers_StartClientInvinsibilityOpen_2166136261(PooledReader PooledReader0, Channel channel)
	{
	}

	[Token(Token = "0x600024E")]
	[Address(RVA = "0x486E80", Offset = "0x485880", VA = "0x180486E80")]
	private void RpcWriter___Observers_ClientRemoveShield_2166136261()
	{
	}

	[Token(Token = "0x600024F")]
	[Address(RVA = "0x487540", Offset = "0x485F40", VA = "0x180487540")]
	private void RpcLogic___ClientRemoveShield_2166136261()
	{
	}

	[Token(Token = "0x6000250")]
	[Address(RVA = "0x487680", Offset = "0x486080", VA = "0x180487680")]
	private void RpcReader___Observers_ClientRemoveShield_2166136261(PooledReader PooledReader0, Channel channel)
	{
	}

	[Token(Token = "0x6000251")]
	[Address(RVA = "0x4592B0", Offset = "0x457CB0", VA = "0x1804592B0", Slot = "29")]
	public override void Awake()
	{
	}
}

using System.Collections;
using System.Runtime.CompilerServices;
using FishNet.Object;
using FishNet.Object.Synchronizing;
using FishNet.Serializing;
using FishNet.Transporting;
using Il2CppDummyDll;
using UnityEngine;

[Token(Token = "0x20000BC")]
public class SpeedBoost : NetworkBehaviour
{
	[Token(Token = "0x40003F9")]
	[FieldOffset(Offset = "0xF8")]
	[SerializeField]
	private Material enabledMaterial;

	[Token(Token = "0x40003FA")]
	[FieldOffset(Offset = "0x100")]
	[SerializeField]
	private Material disabledMaterial;

	[Token(Token = "0x40003FB")]
	[FieldOffset(Offset = "0x108")]
	public readonly SyncVar<int> index;

	[Token(Token = "0x40003FC")]
	[FieldOffset(Offset = "0x110")]
	[SerializeField]
	private ParticleSystem particles;

	[Token(Token = "0x40003FD")]
	[FieldOffset(Offset = "0x118")]
	[HideInInspector]
	public bool boostEnabled;

	[Token(Token = "0x40003FE")]
	[FieldOffset(Offset = "0x119")]
	private bool NetworkInitialize___EarlySpeedBoostAssembly_002DCSharp_002Edll_Excuted;

	[Token(Token = "0x40003FF")]
	[FieldOffset(Offset = "0x11A")]
	private bool NetworkInitialize__LateSpeedBoostAssembly_002DCSharp_002Edll_Excuted;

	[Token(Token = "0x60005D1")]
	[Address(RVA = "0x4D2120", Offset = "0x4D0B20", VA = "0x1804D2120", Slot = "10")]
	public override void OnStartServer()
	{
	}

	[Token(Token = "0x60005D2")]
	[Address(RVA = "0x4D2130", Offset = "0x4D0B30", VA = "0x1804D2130")]
	[Server]
	public void ServerStartToggle()
	{
	}

	[Token(Token = "0x60005D3")]
	[Address(RVA = "0x4D2290", Offset = "0x4D0C90", VA = "0x1804D2290")]
	[IteratorStateMachine(typeof(_003CServerToggle_003Ed__7))]
	[Server]
	private IEnumerator ServerToggle()
	{
		return null;
	}

	[Token(Token = "0x60005D4")]
	[Address(RVA = "0x4D2380", Offset = "0x4D0D80", VA = "0x1804D2380")]
	[ObserversRpc]
	private void ClientToggleSpeedBoost(bool isEnabled)
	{
	}

	[Token(Token = "0x60005D5")]
	[Address(RVA = "0x4D2500", Offset = "0x4D0F00", VA = "0x1804D2500")]
	public SpeedBoost()
	{
	}

	[Token(Token = "0x60005D6")]
	[Address(RVA = "0x4D25F0", Offset = "0x4D0FF0", VA = "0x1804D25F0", Slot = "27")]
	public override void NetworkInitialize___Early()
	{
	}

	[Token(Token = "0x60005D7")]
	[Address(RVA = "0x4D26B0", Offset = "0x4D10B0", VA = "0x1804D26B0", Slot = "28")]
	public override void NetworkInitialize__Late()
	{
	}

	[Token(Token = "0x60005D8")]
	[Address(RVA = "0x4592B0", Offset = "0x457CB0", VA = "0x1804592B0", Slot = "18")]
	public override void NetworkInitializeIfDisabled()
	{
	}

	[Token(Token = "0x60005D9")]
	[Address(RVA = "0x4D2380", Offset = "0x4D0D80", VA = "0x1804D2380")]
	private void RpcWriter___Observers_ClientToggleSpeedBoost_1140765316(bool isEnabled)
	{
	}

	[Token(Token = "0x60005DA")]
	[Address(RVA = "0x4D26F0", Offset = "0x4D10F0", VA = "0x1804D26F0")]
	private void RpcLogic___ClientToggleSpeedBoost_1140765316(bool isEnabled)
	{
	}

	[Token(Token = "0x60005DB")]
	[Address(RVA = "0x4D2780", Offset = "0x4D1180", VA = "0x1804D2780")]
	private void RpcReader___Observers_ClientToggleSpeedBoost_1140765316(PooledReader PooledReader0, Channel channel)
	{
	}

	[Token(Token = "0x60005DC")]
	[Address(RVA = "0x4592B0", Offset = "0x457CB0", VA = "0x1804592B0", Slot = "29")]
	public override void Awake()
	{
	}
}

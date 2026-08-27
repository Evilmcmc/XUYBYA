using System.Collections.Generic;
using EZCameraShake;
using FishNet.Connection;
using FishNet.Object;
using FishNet.Serializing;
using FishNet.Transporting;
using Il2CppDummyDll;
using UnityEngine;
using UnityEngine.UI;

[Token(Token = "0x2000099")]
public class Railgun : Weapon
{
	[Token(Token = "0x4000341")]
	[FieldOffset(Offset = "0x128")]
	[SerializeField]
	private string chargeUpSound;

	[Token(Token = "0x4000342")]
	[FieldOffset(Offset = "0x130")]
	[SerializeField]
	private string chargeUpCancelSound;

	[Token(Token = "0x4000343")]
	[FieldOffset(Offset = "0x138")]
	[SerializeField]
	private ParticleSystem chargeUpParticles;

	[Token(Token = "0x4000344")]
	[FieldOffset(Offset = "0x140")]
	[SerializeField]
	private Image railgunChargeUI;

	[Token(Token = "0x4000345")]
	[FieldOffset(Offset = "0x148")]
	private List<CameraShakeInstance> currentShakeInstances;

	[Token(Token = "0x4000346")]
	[FieldOffset(Offset = "0x150")]
	private float currentCharge;

	[Token(Token = "0x4000347")]
	[FieldOffset(Offset = "0x154")]
	private bool NetworkInitialize___EarlyRailgunAssembly_002DCSharp_002Edll_Excuted;

	[Token(Token = "0x4000348")]
	[FieldOffset(Offset = "0x155")]
	private bool NetworkInitialize__LateRailgunAssembly_002DCSharp_002Edll_Excuted;

	[Token(Token = "0x6000468")]
	[Address(RVA = "0x4B66B0", Offset = "0x4B50B0", VA = "0x1804B66B0", Slot = "27")]
	[Client]
	public override void ClientTryShoot()
	{
	}

	[Token(Token = "0x6000469")]
	[Address(RVA = "0x4B6BD0", Offset = "0x4B55D0", VA = "0x1804B6BD0")]
	[ServerRpc]
	private void StopChargingServer()
	{
	}

	[Token(Token = "0x600046A")]
	[Address(RVA = "0x4B6D80", Offset = "0x4B5780", VA = "0x1804B6D80")]
	[Server]
	public void PublicStopChargingServer()
	{
	}

	[Token(Token = "0x600046B")]
	[Address(RVA = "0x4B6E00", Offset = "0x4B5800", VA = "0x1804B6E00")]
	[ObserversRpc(ExcludeOwner = true)]
	private void StopChargingObservers()
	{
	}

	[Token(Token = "0x600046C")]
	[Address(RVA = "0x4B6F60", Offset = "0x4B5960", VA = "0x1804B6F60")]
	[ObserversRpc]
	private void StopChargingAllObservers()
	{
	}

	[Token(Token = "0x600046D")]
	[Address(RVA = "0x4B70C0", Offset = "0x4B5AC0", VA = "0x1804B70C0")]
	public void StopCharging()
	{
	}

	[Token(Token = "0x600046E")]
	[Address(RVA = "0x4B73D0", Offset = "0x4B5DD0", VA = "0x1804B73D0", Slot = "31")]
	[Server]
	public override void ServerPostShoot()
	{
	}

	[Token(Token = "0x600046F")]
	[Address(RVA = "0x4B75C0", Offset = "0x4B5FC0", VA = "0x1804B75C0")]
	[ServerRpc]
	private void StartChargingServer()
	{
	}

	[Token(Token = "0x6000470")]
	[Address(RVA = "0x4B7770", Offset = "0x4B6170", VA = "0x1804B7770")]
	[ObserversRpc(ExcludeOwner = true)]
	private void StartChargingObservers()
	{
	}

	[Token(Token = "0x6000471")]
	[Address(RVA = "0x4B78D0", Offset = "0x4B62D0", VA = "0x1804B78D0")]
	private void StartCharging()
	{
	}

	[Token(Token = "0x6000472")]
	[Address(RVA = "0x4B7C60", Offset = "0x4B6660", VA = "0x1804B7C60")]
	public Railgun()
	{
	}

	[Token(Token = "0x6000473")]
	[Address(RVA = "0x4B7D30", Offset = "0x4B6730", VA = "0x1804B7D30", Slot = "37")]
	public override void NetworkInitialize___Early()
	{
	}

	[Token(Token = "0x6000474")]
	[Address(RVA = "0x4B7F10", Offset = "0x4B6910", VA = "0x1804B7F10", Slot = "38")]
	public override void NetworkInitialize__Late()
	{
	}

	[Token(Token = "0x6000475")]
	[Address(RVA = "0x4B3B30", Offset = "0x4B2530", VA = "0x1804B3B30", Slot = "18")]
	public override void NetworkInitializeIfDisabled()
	{
	}

	[Token(Token = "0x6000476")]
	[Address(RVA = "0x4B6BD0", Offset = "0x4B55D0", VA = "0x1804B6BD0")]
	private void RpcWriter___Server_StopChargingServer_2166136261()
	{
	}

	[Token(Token = "0x6000477")]
	[Address(RVA = "0x4B6E00", Offset = "0x4B5800", VA = "0x1804B6E00")]
	private void RpcLogic___StopChargingServer_2166136261()
	{
	}

	[Token(Token = "0x6000478")]
	[Address(RVA = "0x4B7F40", Offset = "0x4B6940", VA = "0x1804B7F40")]
	private void RpcReader___Server_StopChargingServer_2166136261(PooledReader PooledReader0, Channel channel, NetworkConnection conn)
	{
	}

	[Token(Token = "0x6000479")]
	[Address(RVA = "0x4B6E00", Offset = "0x4B5800", VA = "0x1804B6E00")]
	private void RpcWriter___Observers_StopChargingObservers_2166136261()
	{
	}

	[Token(Token = "0x600047A")]
	[Address(RVA = "0x4B8150", Offset = "0x4B6B50", VA = "0x1804B8150")]
	private void RpcLogic___StopChargingObservers_2166136261()
	{
	}

	[Token(Token = "0x600047B")]
	[Address(RVA = "0x4B8160", Offset = "0x4B6B60", VA = "0x1804B8160")]
	private void RpcReader___Observers_StopChargingObservers_2166136261(PooledReader PooledReader0, Channel channel)
	{
	}

	[Token(Token = "0x600047C")]
	[Address(RVA = "0x4B6F60", Offset = "0x4B5960", VA = "0x1804B6F60")]
	private void RpcWriter___Observers_StopChargingAllObservers_2166136261()
	{
	}

	[Token(Token = "0x600047D")]
	[Address(RVA = "0x4B8150", Offset = "0x4B6B50", VA = "0x1804B8150")]
	private void RpcLogic___StopChargingAllObservers_2166136261()
	{
	}

	[Token(Token = "0x600047E")]
	[Address(RVA = "0x4B8160", Offset = "0x4B6B60", VA = "0x1804B8160")]
	private void RpcReader___Observers_StopChargingAllObservers_2166136261(PooledReader PooledReader0, Channel channel)
	{
	}

	[Token(Token = "0x600047F")]
	[Address(RVA = "0x4B75C0", Offset = "0x4B5FC0", VA = "0x1804B75C0")]
	private void RpcWriter___Server_StartChargingServer_2166136261()
	{
	}

	[Token(Token = "0x6000480")]
	[Address(RVA = "0x4B7770", Offset = "0x4B6170", VA = "0x1804B7770")]
	private void RpcLogic___StartChargingServer_2166136261()
	{
	}

	[Token(Token = "0x6000481")]
	[Address(RVA = "0x4B8190", Offset = "0x4B6B90", VA = "0x1804B8190")]
	private void RpcReader___Server_StartChargingServer_2166136261(PooledReader PooledReader0, Channel channel, NetworkConnection conn)
	{
	}

	[Token(Token = "0x6000482")]
	[Address(RVA = "0x4B7770", Offset = "0x4B6170", VA = "0x1804B7770")]
	private void RpcWriter___Observers_StartChargingObservers_2166136261()
	{
	}

	[Token(Token = "0x6000483")]
	[Address(RVA = "0x4B83A0", Offset = "0x4B6DA0", VA = "0x1804B83A0")]
	private void RpcLogic___StartChargingObservers_2166136261()
	{
	}

	[Token(Token = "0x6000484")]
	[Address(RVA = "0x4B83B0", Offset = "0x4B6DB0", VA = "0x1804B83B0")]
	private void RpcReader___Observers_StartChargingObservers_2166136261(PooledReader PooledReader0, Channel channel)
	{
	}

	[Token(Token = "0x6000485")]
	[Address(RVA = "0x4B3B70", Offset = "0x4B2570", VA = "0x1804B3B70", Slot = "41")]
	public override void Awake()
	{
	}
}

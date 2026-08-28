using FishNet.Connection;
using FishNet.Object;
using FishNet.Serializing;
using FishNet.Transporting;
using Il2CppDummyDll;
using UnityEngine;

[Token(Token = "0x200009B")]
public class RocketLauncher : Weapon
{
	[Token(Token = "0x4000357")]
	[FieldOffset(Offset = "0x128")]
	[SerializeField]
	private GameObject rocketPrefab;

	[Token(Token = "0x4000358")]
	[FieldOffset(Offset = "0x130")]
	[SerializeField]
	private float projectileSpeed;

	[Token(Token = "0x4000359")]
	[FieldOffset(Offset = "0x138")]
	private GameObject currentRocket;

	[Token(Token = "0x400035A")]
	[FieldOffset(Offset = "0x140")]
	[SerializeField]
	private GameObject explosion;

	[Token(Token = "0x400035B")]
	[FieldOffset(Offset = "0x148")]
	private bool NetworkInitialize___EarlyRocketLauncherAssembly_002DCSharp_002Edll_Excuted;

	[Token(Token = "0x400035C")]
	[FieldOffset(Offset = "0x149")]
	private bool NetworkInitialize__LateRocketLauncherAssembly_002DCSharp_002Edll_Excuted;

	[Token(Token = "0x600048E")]
	[Address(RVA = "0x4B9800", Offset = "0x4B8200", VA = "0x1804B9800", Slot = "27")]
	[Client]
	public override void ClientTryShoot()
	{
	}

	[Token(Token = "0x600048F")]
	[Address(RVA = "0x4B9C10", Offset = "0x4B8610", VA = "0x1804B9C10")]
	private void SpawnRocketLocal(Vector3 startPosition, Vector3 cameraForward, Vector3 cameraUp)
	{
	}

	[Token(Token = "0x6000490")]
	[Address(RVA = "0x4B9FE0", Offset = "0x4B89E0", VA = "0x1804B9FE0")]
	[ServerRpc]
	private void SpawnRocket(Vector3 cameraPosition, Vector3 cameraForward, Vector3 cameraUp, uint startTick)
	{
	}

	[Token(Token = "0x6000491")]
	[Address(RVA = "0x4BA050", Offset = "0x4B8A50", VA = "0x1804BA050")]
	[ObserversRpc(ExcludeOwner = true)]
	private void SpawnRocketObserver(Vector3 cameraPosition, Vector3 cameraForward, Vector3 cameraUp, uint startTick)
	{
	}

	[Token(Token = "0x6000492")]
	[Address(RVA = "0x4BA0C0", Offset = "0x4B8AC0", VA = "0x1804BA0C0")]
	[ServerRpc(RequireOwnership = false)]
	public void ExplodeRocket(Vector3 position)
	{
	}

	[Token(Token = "0x6000493")]
	[Address(RVA = "0x4BA260", Offset = "0x4B8C60", VA = "0x1804BA260")]
	[ObserversRpc]
	private void ExplodeCurrentRocket(Vector3 position)
	{
	}

	[Token(Token = "0x6000494")]
	[Address(RVA = "0x464E10", Offset = "0x463810", VA = "0x180464E10")]
	public RocketLauncher()
	{
	}

	[Token(Token = "0x6000495")]
	[Address(RVA = "0x4BA400", Offset = "0x4B8E00", VA = "0x1804BA400", Slot = "37")]
	public override void NetworkInitialize___Early()
	{
	}

	[Token(Token = "0x6000496")]
	[Address(RVA = "0x4BA590", Offset = "0x4B8F90", VA = "0x1804BA590", Slot = "38")]
	public override void NetworkInitialize__Late()
	{
	}

	[Token(Token = "0x6000497")]
	[Address(RVA = "0x4B3B30", Offset = "0x4B2530", VA = "0x1804B3B30", Slot = "18")]
	public override void NetworkInitializeIfDisabled()
	{
	}

	[Token(Token = "0x6000498")]
	[Address(RVA = "0x4BA5C0", Offset = "0x4B8FC0", VA = "0x1804BA5C0")]
	private void RpcWriter___Server_SpawnRocket_1571246238(Vector3 cameraPosition, Vector3 cameraForward, Vector3 cameraUp, uint startTick)
	{
	}

	[Token(Token = "0x6000499")]
	[Address(RVA = "0x4BA830", Offset = "0x4B9230", VA = "0x1804BA830")]
	private void RpcLogic___SpawnRocket_1571246238(Vector3 cameraPosition, Vector3 cameraForward, Vector3 cameraUp, uint startTick)
	{
	}

	[Token(Token = "0x600049A")]
	[Address(RVA = "0x4BA8C0", Offset = "0x4B92C0", VA = "0x1804BA8C0")]
	private void RpcReader___Server_SpawnRocket_1571246238(PooledReader PooledReader0, Channel channel, NetworkConnection conn)
	{
	}

	[Token(Token = "0x600049B")]
	[Address(RVA = "0x4BAB10", Offset = "0x4B9510", VA = "0x1804BAB10")]
	private void RpcWriter___Observers_SpawnRocketObserver_1571246238(Vector3 cameraPosition, Vector3 cameraForward, Vector3 cameraUp, uint startTick)
	{
	}

	[Token(Token = "0x600049C")]
	[Address(RVA = "0x4BAD40", Offset = "0x4B9740", VA = "0x1804BAD40")]
	private void RpcLogic___SpawnRocketObserver_1571246238(Vector3 cameraPosition, Vector3 cameraForward, Vector3 cameraUp, uint startTick)
	{
	}

	[Token(Token = "0x600049D")]
	[Address(RVA = "0x4BAE60", Offset = "0x4B9860", VA = "0x1804BAE60")]
	private void RpcReader___Observers_SpawnRocketObserver_1571246238(PooledReader PooledReader0, Channel channel)
	{
	}

	[Token(Token = "0x600049E")]
	[Address(RVA = "0x4BA0C0", Offset = "0x4B8AC0", VA = "0x1804BA0C0")]
	private void RpcWriter___Server_ExplodeRocket_4276783012(Vector3 position)
	{
	}

	[Token(Token = "0x600049F")]
	[Address(RVA = "0x4BA260", Offset = "0x4B8C60", VA = "0x1804BA260")]
	public void RpcLogic___ExplodeRocket_4276783012(Vector3 position)
	{
	}

	[Token(Token = "0x60004A0")]
	[Address(RVA = "0x4BB0A0", Offset = "0x4B9AA0", VA = "0x1804BB0A0")]
	private void RpcReader___Server_ExplodeRocket_4276783012(PooledReader PooledReader0, Channel channel, NetworkConnection conn)
	{
	}

	[Token(Token = "0x60004A1")]
	[Address(RVA = "0x4BA260", Offset = "0x4B8C60", VA = "0x1804BA260")]
	private void RpcWriter___Observers_ExplodeCurrentRocket_4276783012(Vector3 position)
	{
	}

	[Token(Token = "0x60004A2")]
	[Address(RVA = "0x4BB290", Offset = "0x4B9C90", VA = "0x1804BB290")]
	private void RpcLogic___ExplodeCurrentRocket_4276783012(Vector3 position)
	{
	}

	[Token(Token = "0x60004A3")]
	[Address(RVA = "0x4BB3D0", Offset = "0x4B9DD0", VA = "0x1804BB3D0")]
	private void RpcReader___Observers_ExplodeCurrentRocket_4276783012(PooledReader PooledReader0, Channel channel)
	{
	}

	[Token(Token = "0x60004A4")]
	[Address(RVA = "0x4B3B70", Offset = "0x4B2570", VA = "0x1804B3B70", Slot = "41")]
	public override void Awake()
	{
	}
}

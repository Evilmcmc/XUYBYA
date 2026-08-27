using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using FishNet.Connection;
using FishNet.Object;
using FishNet.Serializing;
using FishNet.Transporting;
using Il2CppDummyDll;
using UnityEngine;

[Token(Token = "0x2000106")]
public class WeaponSpawnMarkerManager : NetworkBehaviour
{
	[Token(Token = "0x400056A")]
	[FieldOffset(Offset = "0xF8")]
	[SerializeField]
	private Transform markerParent;

	[Token(Token = "0x400056B")]
	[FieldOffset(Offset = "0x100")]
	[SerializeField]
	private GameObject markerPrefab;

	[Token(Token = "0x400056C")]
	[FieldOffset(Offset = "0x108")]
	[SerializeField]
	private Transform root;

	[Token(Token = "0x400056D")]
	[FieldOffset(Offset = "0x110")]
	[SerializeField]
	private Camera cam;

	[Token(Token = "0x400056E")]
	[FieldOffset(Offset = "0x118")]
	private List<GameObject> spawnedMarkers;

	[Token(Token = "0x400056F")]
	[FieldOffset(Offset = "0x120")]
	private bool NetworkInitialize___EarlyWeaponSpawnMarkerManagerAssembly_002DCSharp_002Edll_Excuted;

	[Token(Token = "0x4000570")]
	[FieldOffset(Offset = "0x121")]
	private bool NetworkInitialize__LateWeaponSpawnMarkerManagerAssembly_002DCSharp_002Edll_Excuted;

	[Token(Token = "0x60007F2")]
	[Address(RVA = "0x4F7330", Offset = "0x4F5D30", VA = "0x1804F7330", Slot = "10")]
	public override void OnStartServer()
	{
	}

	[Token(Token = "0x60007F3")]
	[Address(RVA = "0x4F73E0", Offset = "0x4F5DE0", VA = "0x1804F73E0")]
	[IteratorStateMachine(typeof(_003CGetWeaponIDs_003Ed__6))]
	private IEnumerator GetWeaponIDs()
	{
		return null;
	}

	[Token(Token = "0x60007F4")]
	[Address(RVA = "0x4F7480", Offset = "0x4F5E80", VA = "0x1804F7480")]
	[TargetRpc]
	public void SpawnDirectionMarkers(NetworkConnection target, int[] weaponSpawns)
	{
	}

	[Token(Token = "0x60007F5")]
	[Address(RVA = "0x4F7490", Offset = "0x4F5E90", VA = "0x1804F7490")]
	[Client]
	public void ClearAllMarkers()
	{
	}

	[Token(Token = "0x60007F6")]
	[Address(RVA = "0x4F7740", Offset = "0x4F6140", VA = "0x1804F7740")]
	public WeaponSpawnMarkerManager()
	{
	}

	[Token(Token = "0x60007F7")]
	[Address(RVA = "0x4F7810", Offset = "0x4F6210", VA = "0x1804F7810", Slot = "27")]
	public override void NetworkInitialize___Early()
	{
	}

	[Token(Token = "0x60007F8")]
	[Address(RVA = "0x47B5F0", Offset = "0x479FF0", VA = "0x18047B5F0", Slot = "28")]
	public override void NetworkInitialize__Late()
	{
	}

	[Token(Token = "0x60007F9")]
	[Address(RVA = "0x4592B0", Offset = "0x457CB0", VA = "0x1804592B0", Slot = "18")]
	public override void NetworkInitializeIfDisabled()
	{
	}

	[Token(Token = "0x60007FA")]
	[Address(RVA = "0x4F78A0", Offset = "0x4F62A0", VA = "0x1804F78A0")]
	private void RpcWriter___Target_SpawnDirectionMarkers_4004264107(NetworkConnection target, int[] weaponSpawns)
	{
	}

	[Token(Token = "0x60007FB")]
	[Address(RVA = "0x4F7AA0", Offset = "0x4F64A0", VA = "0x1804F7AA0")]
	public void RpcLogic___SpawnDirectionMarkers_4004264107(NetworkConnection target, int[] weaponSpawns)
	{
	}

	[Token(Token = "0x60007FC")]
	[Address(RVA = "0x4F7F40", Offset = "0x4F6940", VA = "0x1804F7F40")]
	private void RpcReader___Target_SpawnDirectionMarkers_4004264107(PooledReader PooledReader0, Channel channel)
	{
	}

	[Token(Token = "0x60007FD")]
	[Address(RVA = "0x4592B0", Offset = "0x457CB0", VA = "0x1804592B0", Slot = "29")]
	public override void Awake()
	{
	}
}

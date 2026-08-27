using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using FishNet.Object;
using Il2CppDummyDll;
using UnityEngine;

[Token(Token = "0x2000012")]
public class GameWeaponManager : NetworkBehaviour
{
	[Token(Token = "0x4000032")]
	[FieldOffset(Offset = "0xF8")]
	[Header("Attack Charges")]
	[SerializeField]
	private WeaponSpawn weaponSpawnPrefab;

	[Token(Token = "0x4000033")]
	[FieldOffset(Offset = "0x100")]
	[SerializeField]
	private int attackChargeCount;

	[Token(Token = "0x4000034")]
	[FieldOffset(Offset = "0x104")]
	[SerializeField]
	private int healthCount;

	[Token(Token = "0x4000035")]
	[FieldOffset(Offset = "0x0")]
	[HideInInspector]
	public static List<WeaponSpawn> weaponSpawns;

	[Token(Token = "0x4000036")]
	[FieldOffset(Offset = "0x8")]
	[HideInInspector]
	public static int currentWeaponSpawn;

	[Token(Token = "0x4000037")]
	[FieldOffset(Offset = "0x108")]
	[HideInInspector]
	public List<int> weapons;

	[Token(Token = "0x4000038")]
	[FieldOffset(Offset = "0x110")]
	private bool NetworkInitialize___EarlyGameWeaponManagerAssembly_002DCSharp_002Edll_Excuted;

	[Token(Token = "0x4000039")]
	[FieldOffset(Offset = "0x111")]
	private bool NetworkInitialize__LateGameWeaponManagerAssembly_002DCSharp_002Edll_Excuted;

	[Token(Token = "0x600005A")]
	[Address(RVA = "0x458000", Offset = "0x456A00", VA = "0x180458000", Slot = "10")]
	public override void OnStartServer()
	{
	}

	[Token(Token = "0x600005B")]
	[Address(RVA = "0x4582F0", Offset = "0x456CF0", VA = "0x1804582F0", Slot = "11")]
	public override void OnStopServer()
	{
	}

	[Token(Token = "0x600005C")]
	[Address(RVA = "0x4584E0", Offset = "0x456EE0", VA = "0x1804584E0")]
	[Server]
	public void AddWeaponSpawn(Transform spawnPoint, bool rotate)
	{
	}

	[Token(Token = "0x600005D")]
	[Address(RVA = "0x458A60", Offset = "0x457460", VA = "0x180458A60")]
	[Server]
	public void InitNewWeaponSpawn(bool isHealth)
	{
	}

	[Token(Token = "0x600005E")]
	[Address(RVA = "0x458CE0", Offset = "0x4576E0", VA = "0x180458CE0")]
	[IteratorStateMachine(typeof(_003CInitializeWeaponSpawn_003Ed__10))]
	private IEnumerator InitializeWeaponSpawn(WeaponSpawn newWeaponSpawn)
	{
		return null;
	}

	[Token(Token = "0x600005F")]
	[Address(RVA = "0x458DE0", Offset = "0x4577E0", VA = "0x180458DE0")]
	public void ClearWeaponSpawns()
	{
	}

	[Token(Token = "0x6000060")]
	[Address(RVA = "0x4590C0", Offset = "0x457AC0", VA = "0x1804590C0")]
	public GameWeaponManager()
	{
	}

	[Token(Token = "0x6000062")]
	[Address(RVA = "0x459270", Offset = "0x457C70", VA = "0x180459270", Slot = "27")]
	public override void NetworkInitialize___Early()
	{
	}

	[Token(Token = "0x6000063")]
	[Address(RVA = "0x459290", Offset = "0x457C90", VA = "0x180459290", Slot = "28")]
	public override void NetworkInitialize__Late()
	{
	}

	[Token(Token = "0x6000064")]
	[Address(RVA = "0x4592B0", Offset = "0x457CB0", VA = "0x1804592B0", Slot = "18")]
	public override void NetworkInitializeIfDisabled()
	{
	}

	[Token(Token = "0x6000065")]
	[Address(RVA = "0x4592B0", Offset = "0x457CB0", VA = "0x1804592B0", Slot = "29")]
	public override void Awake()
	{
	}
}

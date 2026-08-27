using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using FishNet.Connection;
using FishNet.Object;
using Il2CppDummyDll;
using UnityEngine;

[Token(Token = "0x200004C")]
public class GamePlayerSpawnManager : NetworkBehaviour
{
	[Token(Token = "0x4000125")]
	[FieldOffset(Offset = "0xF8")]
	[SerializeField]
	private GameObject playerPrefab;

	[Token(Token = "0x4000126")]
	[FieldOffset(Offset = "0x0")]
	private static List<Transform> playerSpawnPoints;

	[Token(Token = "0x4000127")]
	[FieldOffset(Offset = "0x100")]
	private bool NetworkInitialize___EarlyGamePlayerSpawnManagerAssembly_002DCSharp_002Edll_Excuted;

	[Token(Token = "0x4000128")]
	[FieldOffset(Offset = "0x101")]
	private bool NetworkInitialize__LateGamePlayerSpawnManagerAssembly_002DCSharp_002Edll_Excuted;

	[Token(Token = "0x60001E8")]
	[Address(RVA = "0x47F7F0", Offset = "0x47E1F0", VA = "0x18047F7F0")]
	public static void AddSpawnPoint(Transform transform)
	{
	}

	[Token(Token = "0x60001E9")]
	[Address(RVA = "0x47FB00", Offset = "0x47E500", VA = "0x18047FB00")]
	public static void RemoveSpawnPoint(Transform transform)
	{
	}

	[Token(Token = "0x60001EA")]
	[Address(RVA = "0x47FB90", Offset = "0x47E590", VA = "0x18047FB90")]
	public static int GetSpawnPointCount()
	{
		return default(int);
	}

	[Token(Token = "0x60001EB")]
	[Address(RVA = "0x47FC10", Offset = "0x47E610", VA = "0x18047FC10")]
	public void StartSpawnPlayer(NetworkConnection conn)
	{
	}

	[Token(Token = "0x60001EC")]
	[Address(RVA = "0x47FD70", Offset = "0x47E770", VA = "0x18047FD70")]
	[IteratorStateMachine(typeof(_003CSpawnPlayer_003Ed__6))]
	[Server]
	private IEnumerator SpawnPlayer(NetworkConnection conn)
	{
		return null;
	}

	[Token(Token = "0x60001ED")]
	[Address(RVA = "0x464E10", Offset = "0x463810", VA = "0x180464E10")]
	public GamePlayerSpawnManager()
	{
	}

	[Token(Token = "0x60001EF")]
	[Address(RVA = "0x47FFB0", Offset = "0x47E9B0", VA = "0x18047FFB0", Slot = "27")]
	public override void NetworkInitialize___Early()
	{
	}

	[Token(Token = "0x60001F0")]
	[Address(RVA = "0x47FFD0", Offset = "0x47E9D0", VA = "0x18047FFD0", Slot = "28")]
	public override void NetworkInitialize__Late()
	{
	}

	[Token(Token = "0x60001F1")]
	[Address(RVA = "0x4592B0", Offset = "0x457CB0", VA = "0x1804592B0", Slot = "18")]
	public override void NetworkInitializeIfDisabled()
	{
	}

	[Token(Token = "0x60001F2")]
	[Address(RVA = "0x4592B0", Offset = "0x457CB0", VA = "0x1804592B0", Slot = "29")]
	public override void Awake()
	{
	}
}

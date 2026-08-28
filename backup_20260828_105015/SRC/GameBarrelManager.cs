using System.Collections.Generic;
using FishNet.Object;
using Il2CppDummyDll;
using UnityEngine;

[Token(Token = "0x2000048")]
public class GameBarrelManager : NetworkBehaviour
{
	[Token(Token = "0x4000105")]
	[FieldOffset(Offset = "0xF8")]
	[SerializeField]
	private GameObject barrelPrefab;

	[Token(Token = "0x4000106")]
	[FieldOffset(Offset = "0x100")]
	[HideInInspector]
	public BarrelSpawnType barrelSpawnType;

	[Token(Token = "0x4000107")]
	[FieldOffset(Offset = "0x108")]
	private List<GameObject> barrels;

	[Token(Token = "0x4000108")]
	[FieldOffset(Offset = "0x110")]
	private bool NetworkInitialize___EarlyGameBarrelManagerAssembly_002DCSharp_002Edll_Excuted;

	[Token(Token = "0x4000109")]
	[FieldOffset(Offset = "0x111")]
	private bool NetworkInitialize__LateGameBarrelManagerAssembly_002DCSharp_002Edll_Excuted;

	[Token(Token = "0x60001AE")]
	[Address(RVA = "0x478B80", Offset = "0x477580", VA = "0x180478B80")]
	public void AddBarrel(BarrelSpawnPoint barrelSpawnPoint)
	{
	}

	[Token(Token = "0x60001AF")]
	[Address(RVA = "0x479130", Offset = "0x477B30", VA = "0x180479130", Slot = "10")]
	public override void OnStartServer()
	{
	}

	[Token(Token = "0x60001B0")]
	[Address(RVA = "0x4792A0", Offset = "0x477CA0", VA = "0x1804792A0", Slot = "11")]
	public override void OnStopServer()
	{
	}

	[Token(Token = "0x60001B1")]
	[Address(RVA = "0x479410", Offset = "0x477E10", VA = "0x180479410")]
	public void ClearBarrels()
	{
	}

	[Token(Token = "0x60001B2")]
	[Address(RVA = "0x479690", Offset = "0x478090", VA = "0x180479690")]
	public GameBarrelManager()
	{
	}

	[Token(Token = "0x60001B3")]
	[Address(RVA = "0x459270", Offset = "0x457C70", VA = "0x180459270", Slot = "27")]
	public override void NetworkInitialize___Early()
	{
	}

	[Token(Token = "0x60001B4")]
	[Address(RVA = "0x459290", Offset = "0x457C90", VA = "0x180459290", Slot = "28")]
	public override void NetworkInitialize__Late()
	{
	}

	[Token(Token = "0x60001B5")]
	[Address(RVA = "0x4592B0", Offset = "0x457CB0", VA = "0x1804592B0", Slot = "18")]
	public override void NetworkInitializeIfDisabled()
	{
	}

	[Token(Token = "0x60001B6")]
	[Address(RVA = "0x4592B0", Offset = "0x457CB0", VA = "0x1804592B0", Slot = "29")]
	public override void Awake()
	{
	}
}

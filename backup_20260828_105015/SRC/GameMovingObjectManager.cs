using System.Collections.Generic;
using FishNet.Object;
using Il2CppDummyDll;
using UnityEngine;

[Token(Token = "0x200004B")]
public class GameMovingObjectManager : NetworkBehaviour
{
	[Token(Token = "0x400011A")]
	[FieldOffset(Offset = "0xF8")]
	[Header("Pillars")]
	[SerializeField]
	private PillarObstacle pillarPrefab;

	[Token(Token = "0x400011B")]
	[FieldOffset(Offset = "0x0")]
	[HideInInspector]
	public static List<PillarObstacle> pillarObstacles;

	[Token(Token = "0x400011C")]
	[FieldOffset(Offset = "0x100")]
	[Header("Crusher")]
	[SerializeField]
	private CrusherObstacle crusherPrefab;

	[Token(Token = "0x400011D")]
	[FieldOffset(Offset = "0x8")]
	[HideInInspector]
	public static List<CrusherObstacle> crusherObstacles;

	[Token(Token = "0x400011E")]
	[FieldOffset(Offset = "0x108")]
	[Header("Drones")]
	[SerializeField]
	private DroneMovement dronePrefab;

	[Token(Token = "0x400011F")]
	[FieldOffset(Offset = "0x10")]
	[HideInInspector]
	public static List<DroneMovement> drones;

	[Token(Token = "0x4000120")]
	[FieldOffset(Offset = "0x110")]
	[Header("Crain")]
	[SerializeField]
	private CrainMovement cityCrainPrefab;

	[Token(Token = "0x4000121")]
	[FieldOffset(Offset = "0x118")]
	[SerializeField]
	private CrainMovement towerCrainPrefab;

	[Token(Token = "0x4000122")]
	[FieldOffset(Offset = "0x18")]
	[HideInInspector]
	public static List<CrainMovement> crains;

	[Token(Token = "0x4000123")]
	[FieldOffset(Offset = "0x120")]
	private bool NetworkInitialize___EarlyGameMovingObjectManagerAssembly_002DCSharp_002Edll_Excuted;

	[Token(Token = "0x4000124")]
	[FieldOffset(Offset = "0x121")]
	private bool NetworkInitialize__LateGameMovingObjectManagerAssembly_002DCSharp_002Edll_Excuted;

	[Token(Token = "0x60001DB")]
	[Address(RVA = "0x47D2E0", Offset = "0x47BCE0", VA = "0x18047D2E0", Slot = "10")]
	public override void OnStartServer()
	{
	}

	[Token(Token = "0x60001DC")]
	[Address(RVA = "0x47D740", Offset = "0x47C140", VA = "0x18047D740", Slot = "11")]
	public override void OnStopServer()
	{
	}

	[Token(Token = "0x60001DD")]
	[Address(RVA = "0x47DA10", Offset = "0x47C410", VA = "0x18047DA10")]
	[Server]
	public void AddPillar(Transform spawnPoint, PillarType type, float frequency, float magnitude, float offset)
	{
	}

	[Token(Token = "0x60001DE")]
	[Address(RVA = "0x47DE00", Offset = "0x47C800", VA = "0x18047DE00")]
	[Server]
	public void AddCrusher(Transform spawnPoint, float frequency, float magnitude)
	{
	}

	[Token(Token = "0x60001DF")]
	[Address(RVA = "0x47E1D0", Offset = "0x47CBD0", VA = "0x18047E1D0")]
	[Server]
	public void AddDrone(Transform spawnPoint, float radius, float orbitSpeed, float floatMagnitude, float floatFrequency)
	{
	}

	[Token(Token = "0x60001E0")]
	[Address(RVA = "0x47E5C0", Offset = "0x47CFC0", VA = "0x18047E5C0")]
	[Server]
	public void AddCrain(Transform spawnPoint, float rotationSpeed, bool taxi)
	{
	}

	[Token(Token = "0x60001E1")]
	[Address(RVA = "0x47EA10", Offset = "0x47D410", VA = "0x18047EA10")]
	public void ClearMovingObjects()
	{
	}

	[Token(Token = "0x60001E2")]
	[Address(RVA = "0x464E10", Offset = "0x463810", VA = "0x180464E10")]
	public GameMovingObjectManager()
	{
	}

	[Token(Token = "0x60001E4")]
	[Address(RVA = "0x47F7D0", Offset = "0x47E1D0", VA = "0x18047F7D0", Slot = "27")]
	public override void NetworkInitialize___Early()
	{
	}

	[Token(Token = "0x60001E5")]
	[Address(RVA = "0x47B5F0", Offset = "0x479FF0", VA = "0x18047B5F0", Slot = "28")]
	public override void NetworkInitialize__Late()
	{
	}

	[Token(Token = "0x60001E6")]
	[Address(RVA = "0x4592B0", Offset = "0x457CB0", VA = "0x1804592B0", Slot = "18")]
	public override void NetworkInitializeIfDisabled()
	{
	}

	[Token(Token = "0x60001E7")]
	[Address(RVA = "0x4592B0", Offset = "0x457CB0", VA = "0x1804592B0", Slot = "29")]
	public override void Awake()
	{
	}
}

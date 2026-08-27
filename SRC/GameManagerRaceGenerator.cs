using System.Collections.Generic;
using FishNet.Managing.Scened;
using FishNet.Object;
using Il2CppDummyDll;
using UnityEngine;

[Token(Token = "0x200004A")]
public class GameManagerRaceGenerator : NetworkBehaviour
{
	[Token(Token = "0x4000114")]
	[FieldOffset(Offset = "0xF8")]
	[SerializeField]
	private GameObject[] obstacles;

	[Token(Token = "0x4000115")]
	[FieldOffset(Offset = "0x100")]
	[SerializeField]
	private GameObject endPrefab;

	[Token(Token = "0x4000116")]
	[FieldOffset(Offset = "0x108")]
	private List<GameObject> spawnedObstacles;

	[Token(Token = "0x4000117")]
	[FieldOffset(Offset = "0x110")]
	private GameObject endBox;

	[Token(Token = "0x4000118")]
	[FieldOffset(Offset = "0x118")]
	private bool NetworkInitialize___EarlyGameManagerRaceGeneratorAssembly_002DCSharp_002Edll_Excuted;

	[Token(Token = "0x4000119")]
	[FieldOffset(Offset = "0x119")]
	private bool NetworkInitialize__LateGameManagerRaceGeneratorAssembly_002DCSharp_002Edll_Excuted;

	[Token(Token = "0x60001D1")]
	[Address(RVA = "0x47BE00", Offset = "0x47A800", VA = "0x18047BE00", Slot = "10")]
	public override void OnStartServer()
	{
	}

	[Token(Token = "0x60001D2")]
	[Address(RVA = "0x47BEA0", Offset = "0x47A8A0", VA = "0x18047BEA0", Slot = "11")]
	public override void OnStopServer()
	{
	}

	[Token(Token = "0x60001D3")]
	[Address(RVA = "0x47BF40", Offset = "0x47A940", VA = "0x18047BF40")]
	private void OnSceneLoaded(SceneLoadEndEventArgs obj)
	{
	}

	[Token(Token = "0x60001D4")]
	[Address(RVA = "0x47BFF0", Offset = "0x47A9F0", VA = "0x18047BFF0")]
	[Server]
	public void ServerGenerateMap()
	{
	}

	[Token(Token = "0x60001D5")]
	[Address(RVA = "0x47CF10", Offset = "0x47B910", VA = "0x18047CF10")]
	[Server]
	public float DistanceToEnd(Vector3 point)
	{
		return default(float);
	}

	[Token(Token = "0x60001D6")]
	[Address(RVA = "0x47D1D0", Offset = "0x47BBD0", VA = "0x18047D1D0")]
	public GameManagerRaceGenerator()
	{
	}

	[Token(Token = "0x60001D7")]
	[Address(RVA = "0x47D2A0", Offset = "0x47BCA0", VA = "0x18047D2A0", Slot = "27")]
	public override void NetworkInitialize___Early()
	{
	}

	[Token(Token = "0x60001D8")]
	[Address(RVA = "0x47D2C0", Offset = "0x47BCC0", VA = "0x18047D2C0", Slot = "28")]
	public override void NetworkInitialize__Late()
	{
	}

	[Token(Token = "0x60001D9")]
	[Address(RVA = "0x4592B0", Offset = "0x457CB0", VA = "0x1804592B0", Slot = "18")]
	public override void NetworkInitializeIfDisabled()
	{
	}

	[Token(Token = "0x60001DA")]
	[Address(RVA = "0x4592B0", Offset = "0x457CB0", VA = "0x1804592B0", Slot = "29")]
	public override void Awake()
	{
	}
}

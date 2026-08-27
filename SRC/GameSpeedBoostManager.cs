using System.Collections.Generic;
using FishNet.Object;
using Il2CppDummyDll;
using UnityEngine;

[Token(Token = "0x2000051")]
public class GameSpeedBoostManager : NetworkBehaviour
{
	[Token(Token = "0x4000133")]
	[FieldOffset(Offset = "0xF8")]
	[Header("SpeedBoosts")]
	[SerializeField]
	private SpeedBoost speedBoostPrefab;

	[Token(Token = "0x4000134")]
	[FieldOffset(Offset = "0x0")]
	[HideInInspector]
	public static List<SpeedBoost> speedBoosts;

	[Token(Token = "0x4000135")]
	[FieldOffset(Offset = "0x100")]
	private bool NetworkInitialize___EarlyGameSpeedBoostManagerAssembly_002DCSharp_002Edll_Excuted;

	[Token(Token = "0x4000136")]
	[FieldOffset(Offset = "0x101")]
	private bool NetworkInitialize__LateGameSpeedBoostManagerAssembly_002DCSharp_002Edll_Excuted;

	[Token(Token = "0x6000203")]
	[Address(RVA = "0x480F60", Offset = "0x47F960", VA = "0x180480F60", Slot = "10")]
	public override void OnStartServer()
	{
	}

	[Token(Token = "0x6000204")]
	[Address(RVA = "0x4811A0", Offset = "0x47FBA0", VA = "0x1804811A0", Slot = "11")]
	public override void OnStopServer()
	{
	}

	[Token(Token = "0x6000205")]
	[Address(RVA = "0x481390", Offset = "0x47FD90", VA = "0x180481390")]
	[Server]
	public void AddSpeedBoost(Transform spawnPoint)
	{
	}

	[Token(Token = "0x6000206")]
	[Address(RVA = "0x4817E0", Offset = "0x4801E0", VA = "0x1804817E0")]
	public void ClearSpeedBoosts()
	{
	}

	[Token(Token = "0x6000207")]
	[Address(RVA = "0x464E10", Offset = "0x463810", VA = "0x180464E10")]
	public GameSpeedBoostManager()
	{
	}

	[Token(Token = "0x6000209")]
	[Address(RVA = "0x47FFB0", Offset = "0x47E9B0", VA = "0x18047FFB0", Slot = "27")]
	public override void NetworkInitialize___Early()
	{
	}

	[Token(Token = "0x600020A")]
	[Address(RVA = "0x47FFD0", Offset = "0x47E9D0", VA = "0x18047FFD0", Slot = "28")]
	public override void NetworkInitialize__Late()
	{
	}

	[Token(Token = "0x600020B")]
	[Address(RVA = "0x4592B0", Offset = "0x457CB0", VA = "0x1804592B0", Slot = "18")]
	public override void NetworkInitializeIfDisabled()
	{
	}

	[Token(Token = "0x600020C")]
	[Address(RVA = "0x4592B0", Offset = "0x457CB0", VA = "0x1804592B0", Slot = "29")]
	public override void Awake()
	{
	}
}

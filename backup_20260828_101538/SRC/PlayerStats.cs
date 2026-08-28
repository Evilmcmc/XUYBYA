using FishNet.Managing.Scened;
using FishNet.Object;
using FishNet.Object.Synchronizing;
using Il2CppDummyDll;
using Steamworks;
using UnityEngine;

[Token(Token = "0x20000FB")]
public class PlayerStats : NetworkBehaviour
{
	[Token(Token = "0x4000526")]
	[FieldOffset(Offset = "0xF8")]
	[HideInInspector]
	public readonly SyncVar<short> kills;

	[Token(Token = "0x4000527")]
	[FieldOffset(Offset = "0x100")]
	[HideInInspector]
	public readonly SyncVar<short> deaths;

	[Token(Token = "0x4000528")]
	[FieldOffset(Offset = "0x108")]
	[HideInInspector]
	public readonly SyncVar<short> assists;

	[Token(Token = "0x4000529")]
	[FieldOffset(Offset = "0x110")]
	public readonly SyncVar<short> killStreak;

	[Token(Token = "0x400052A")]
	[FieldOffset(Offset = "0x118")]
	public readonly SyncVar<short> bonusPoints;

	[Token(Token = "0x400052B")]
	[FieldOffset(Offset = "0x120")]
	private bool NetworkInitialize___EarlyPlayerStatsAssembly_002DCSharp_002Edll_Excuted;

	[Token(Token = "0x400052C")]
	[FieldOffset(Offset = "0x121")]
	private bool NetworkInitialize__LatePlayerStatsAssembly_002DCSharp_002Edll_Excuted;

	[Token(Token = "0x600079F")]
	[Address(RVA = "0x4EFED0", Offset = "0x4EE8D0", VA = "0x1804EFED0")]
	private string GetUsernameFromSteamID(CSteamID steamID)
	{
		return null;
	}

	[Token(Token = "0x60007A0")]
	[Address(RVA = "0x4576C0", Offset = "0x4560C0", VA = "0x1804576C0")]
	private void Update()
	{
	}

	[Token(Token = "0x60007A1")]
	[Address(RVA = "0x4EFF60", Offset = "0x4EE960", VA = "0x1804EFF60", Slot = "10")]
	public override void OnStartServer()
	{
	}

	[Token(Token = "0x60007A2")]
	[Address(RVA = "0x4F0350", Offset = "0x4EED50", VA = "0x1804F0350")]
	private void ResetStats(SceneLoadEndEventArgs obj)
	{
	}

	[Token(Token = "0x60007A3")]
	[Address(RVA = "0x4F04A0", Offset = "0x4EEEA0", VA = "0x1804F04A0")]
	public PlayerStats()
	{
	}

	[Token(Token = "0x60007A4")]
	[Address(RVA = "0x4F0880", Offset = "0x4EF280", VA = "0x1804F0880", Slot = "27")]
	public override void NetworkInitialize___Early()
	{
	}

	[Token(Token = "0x60007A5")]
	[Address(RVA = "0x4F0970", Offset = "0x4EF370", VA = "0x1804F0970", Slot = "28")]
	public override void NetworkInitialize__Late()
	{
	}

	[Token(Token = "0x60007A6")]
	[Address(RVA = "0x4592B0", Offset = "0x457CB0", VA = "0x1804592B0", Slot = "18")]
	public override void NetworkInitializeIfDisabled()
	{
	}

	[Token(Token = "0x60007A7")]
	[Address(RVA = "0x4592B0", Offset = "0x457CB0", VA = "0x1804592B0", Slot = "29")]
	public override void Awake()
	{
	}
}

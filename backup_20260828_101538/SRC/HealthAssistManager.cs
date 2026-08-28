using FishNet.Object;
using FishNet.Object.Synchronizing;
using Il2CppDummyDll;
using UnityEngine;

[Token(Token = "0x2000056")]
public class HealthAssistManager : NetworkBehaviour
{
	[Token(Token = "0x4000154")]
	[FieldOffset(Offset = "0xF8")]
	[HideInInspector]
	public readonly SyncList<int> playersWhoShotMe;

	[Token(Token = "0x4000155")]
	[FieldOffset(Offset = "0x100")]
	private bool NetworkInitialize___EarlyHealthAssistManagerAssembly_002DCSharp_002Edll_Excuted;

	[Token(Token = "0x4000156")]
	[FieldOffset(Offset = "0x101")]
	private bool NetworkInitialize__LateHealthAssistManagerAssembly_002DCSharp_002Edll_Excuted;

	[Token(Token = "0x6000226")]
	[Address(RVA = "0x484020", Offset = "0x482A20", VA = "0x180484020")]
	[Server]
	public void HandleAssists(int shootingPlayerIndex)
	{
	}

	[Token(Token = "0x6000227")]
	[Address(RVA = "0x4845C0", Offset = "0x482FC0", VA = "0x1804845C0")]
	[Server]
	public void ClearAssists()
	{
	}

	[Token(Token = "0x6000228")]
	[Address(RVA = "0x4846D0", Offset = "0x4830D0", VA = "0x1804846D0")]
	public void AddAssistingPlayer(int player)
	{
	}

	[Token(Token = "0x6000229")]
	[Address(RVA = "0x4849C0", Offset = "0x4833C0", VA = "0x1804849C0")]
	public HealthAssistManager()
	{
	}

	[Token(Token = "0x600022A")]
	[Address(RVA = "0x484B30", Offset = "0x483530", VA = "0x180484B30", Slot = "27")]
	public override void NetworkInitialize___Early()
	{
	}

	[Token(Token = "0x600022B")]
	[Address(RVA = "0x484B80", Offset = "0x483580", VA = "0x180484B80", Slot = "28")]
	public override void NetworkInitialize__Late()
	{
	}

	[Token(Token = "0x600022C")]
	[Address(RVA = "0x4592B0", Offset = "0x457CB0", VA = "0x1804592B0", Slot = "18")]
	public override void NetworkInitializeIfDisabled()
	{
	}

	[Token(Token = "0x600022D")]
	[Address(RVA = "0x4592B0", Offset = "0x457CB0", VA = "0x1804592B0", Slot = "29")]
	public override void Awake()
	{
	}
}

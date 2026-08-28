using DapperDino.InputSystemTutorials;
using FishNet.Connection;
using FishNet.Object;
using Il2CppDummyDll;
using UnityEngine;

[Token(Token = "0x20000F8")]
public class PlayerLoadKeyBindings : NetworkBehaviour
{
	[Token(Token = "0x400051C")]
	[FieldOffset(Offset = "0xF8")]
	[SerializeField]
	private RebindingDisplay[] rebindings;

	[Token(Token = "0x400051D")]
	[FieldOffset(Offset = "0x100")]
	private bool NetworkInitialize___EarlyPlayerLoadKeyBindingsAssembly_002DCSharp_002Edll_Excuted;

	[Token(Token = "0x400051E")]
	[FieldOffset(Offset = "0x101")]
	private bool NetworkInitialize__LatePlayerLoadKeyBindingsAssembly_002DCSharp_002Edll_Excuted;

	[Token(Token = "0x6000788")]
	[Address(RVA = "0x4EED90", Offset = "0x4ED790", VA = "0x1804EED90", Slot = "17")]
	public override void OnOwnershipClient(NetworkConnection prevOwner)
	{
	}

	[Token(Token = "0x6000789")]
	[Address(RVA = "0x464E10", Offset = "0x463810", VA = "0x180464E10")]
	public PlayerLoadKeyBindings()
	{
	}

	[Token(Token = "0x600078A")]
	[Address(RVA = "0x47FFB0", Offset = "0x47E9B0", VA = "0x18047FFB0", Slot = "27")]
	public override void NetworkInitialize___Early()
	{
	}

	[Token(Token = "0x600078B")]
	[Address(RVA = "0x47FFD0", Offset = "0x47E9D0", VA = "0x18047FFD0", Slot = "28")]
	public override void NetworkInitialize__Late()
	{
	}

	[Token(Token = "0x600078C")]
	[Address(RVA = "0x4592B0", Offset = "0x457CB0", VA = "0x1804592B0", Slot = "18")]
	public override void NetworkInitializeIfDisabled()
	{
	}

	[Token(Token = "0x600078D")]
	[Address(RVA = "0x4592B0", Offset = "0x457CB0", VA = "0x1804592B0", Slot = "29")]
	public override void Awake()
	{
	}
}

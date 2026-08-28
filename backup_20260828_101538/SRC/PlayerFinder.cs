using FishNet.Object;
using Il2CppDummyDll;
using UnityEngine;

[Token(Token = "0x20000F6")]
public class PlayerFinder : NetworkBehaviour
{
	[Token(Token = "0x4000517")]
	[FieldOffset(Offset = "0xF8")]
	public GameObject playerGameObject;

	[Token(Token = "0x4000518")]
	[FieldOffset(Offset = "0x100")]
	private bool NetworkInitialize___EarlyPlayerFinderAssembly_002DCSharp_002Edll_Excuted;

	[Token(Token = "0x4000519")]
	[FieldOffset(Offset = "0x101")]
	private bool NetworkInitialize__LatePlayerFinderAssembly_002DCSharp_002Edll_Excuted;

	[Token(Token = "0x6000777")]
	[Address(RVA = "0x4EE700", Offset = "0x4ED100", VA = "0x1804EE700")]
	private void FindPlayerObject(bool oldValue, bool newValue, bool asServer)
	{
	}

	[Token(Token = "0x6000778")]
	[Address(RVA = "0x464E10", Offset = "0x463810", VA = "0x180464E10")]
	public PlayerFinder()
	{
	}

	[Token(Token = "0x6000779")]
	[Address(RVA = "0x47FFB0", Offset = "0x47E9B0", VA = "0x18047FFB0", Slot = "27")]
	public override void NetworkInitialize___Early()
	{
	}

	[Token(Token = "0x600077A")]
	[Address(RVA = "0x47FFD0", Offset = "0x47E9D0", VA = "0x18047FFD0", Slot = "28")]
	public override void NetworkInitialize__Late()
	{
	}

	[Token(Token = "0x600077B")]
	[Address(RVA = "0x4592B0", Offset = "0x457CB0", VA = "0x1804592B0", Slot = "18")]
	public override void NetworkInitializeIfDisabled()
	{
	}

	[Token(Token = "0x600077C")]
	[Address(RVA = "0x4592B0", Offset = "0x457CB0", VA = "0x1804592B0", Slot = "29")]
	public override void Awake()
	{
	}
}

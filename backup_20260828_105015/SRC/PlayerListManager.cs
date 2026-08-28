using FishNet.Object;
using Il2CppDummyDll;

[Token(Token = "0x20000F7")]
public class PlayerListManager : NetworkBehaviour
{
	[Token(Token = "0x400051A")]
	[FieldOffset(Offset = "0xF8")]
	private bool NetworkInitialize___EarlyPlayerListManagerAssembly_002DCSharp_002Edll_Excuted;

	[Token(Token = "0x400051B")]
	[FieldOffset(Offset = "0xF9")]
	private bool NetworkInitialize__LatePlayerListManagerAssembly_002DCSharp_002Edll_Excuted;

	[Token(Token = "0x600077D")]
	[Address(RVA = "0x4EE910", Offset = "0x4ED310", VA = "0x1804EE910", Slot = "15")]
	public override void OnStartClient()
	{
	}

	[Token(Token = "0x600077E")]
	[Address(RVA = "0x4EE940", Offset = "0x4ED340", VA = "0x1804EE940", Slot = "10")]
	public override void OnStartServer()
	{
	}

	[Token(Token = "0x600077F")]
	[Address(RVA = "0x4EE950", Offset = "0x4ED350", VA = "0x1804EE950", Slot = "16")]
	public override void OnStopClient()
	{
	}

	[Token(Token = "0x6000780")]
	[Address(RVA = "0x4EE980", Offset = "0x4ED380", VA = "0x1804EE980", Slot = "11")]
	public override void OnStopServer()
	{
	}

	[Token(Token = "0x6000781")]
	[Address(RVA = "0x4EE990", Offset = "0x4ED390", VA = "0x1804EE990")]
	private void AddPlayer()
	{
	}

	[Token(Token = "0x6000782")]
	[Address(RVA = "0x4EEC20", Offset = "0x4ED620", VA = "0x1804EEC20")]
	private void RemovePlayer()
	{
	}

	[Token(Token = "0x6000783")]
	[Address(RVA = "0x464E10", Offset = "0x463810", VA = "0x180464E10")]
	public PlayerListManager()
	{
	}

	[Token(Token = "0x6000784")]
	[Address(RVA = "0x46BB60", Offset = "0x46A560", VA = "0x18046BB60", Slot = "27")]
	public override void NetworkInitialize___Early()
	{
	}

	[Token(Token = "0x6000785")]
	[Address(RVA = "0x46BB80", Offset = "0x46A580", VA = "0x18046BB80", Slot = "28")]
	public override void NetworkInitialize__Late()
	{
	}

	[Token(Token = "0x6000786")]
	[Address(RVA = "0x4592B0", Offset = "0x457CB0", VA = "0x1804592B0", Slot = "18")]
	public override void NetworkInitializeIfDisabled()
	{
	}

	[Token(Token = "0x6000787")]
	[Address(RVA = "0x4592B0", Offset = "0x457CB0", VA = "0x1804592B0", Slot = "29")]
	public override void Awake()
	{
	}
}

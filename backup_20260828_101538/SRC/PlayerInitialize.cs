using FishNet.Connection;
using FishNet.Object;
using Il2CppDummyDll;

[Token(Token = "0x20000A6")]
public class PlayerInitialize : NetworkBehaviour
{
	[Token(Token = "0x40003A7")]
	[FieldOffset(Offset = "0xF8")]
	private bool NetworkInitialize___EarlyPlayerInitializeAssembly_002DCSharp_002Edll_Excuted;

	[Token(Token = "0x40003A8")]
	[FieldOffset(Offset = "0xF9")]
	private bool NetworkInitialize__LatePlayerInitializeAssembly_002DCSharp_002Edll_Excuted;

	[Token(Token = "0x6000507")]
	[Address(RVA = "0x4C3D60", Offset = "0x4C2760", VA = "0x1804C3D60", Slot = "15")]
	public override void OnStartClient()
	{
	}

	[Token(Token = "0x6000508")]
	[Address(RVA = "0x4C3E30", Offset = "0x4C2830", VA = "0x1804C3E30", Slot = "10")]
	public override void OnStartServer()
	{
	}

	[Token(Token = "0x6000509")]
	[Address(RVA = "0x4C3ED0", Offset = "0x4C28D0", VA = "0x1804C3ED0")]
	public void OnLoadedScene()
	{
	}

	[Token(Token = "0x600050A")]
	[Address(RVA = "0x4C3F80", Offset = "0x4C2980", VA = "0x1804C3F80")]
	public void ServerOnLoadedScene(NetworkConnection connection, bool asServer)
	{
	}

	[Token(Token = "0x600050B")]
	[Address(RVA = "0x464E10", Offset = "0x463810", VA = "0x180464E10")]
	public PlayerInitialize()
	{
	}

	[Token(Token = "0x600050C")]
	[Address(RVA = "0x46BB60", Offset = "0x46A560", VA = "0x18046BB60", Slot = "27")]
	public override void NetworkInitialize___Early()
	{
	}

	[Token(Token = "0x600050D")]
	[Address(RVA = "0x46BB80", Offset = "0x46A580", VA = "0x18046BB80", Slot = "28")]
	public override void NetworkInitialize__Late()
	{
	}

	[Token(Token = "0x600050E")]
	[Address(RVA = "0x4592B0", Offset = "0x457CB0", VA = "0x1804592B0", Slot = "18")]
	public override void NetworkInitializeIfDisabled()
	{
	}

	[Token(Token = "0x600050F")]
	[Address(RVA = "0x4592B0", Offset = "0x457CB0", VA = "0x1804592B0", Slot = "29")]
	public override void Awake()
	{
	}
}

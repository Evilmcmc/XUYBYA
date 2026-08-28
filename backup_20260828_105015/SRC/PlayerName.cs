using FishNet.Connection;
using FishNet.Object;
using FishNet.Object.Synchronizing;
using FishNet.Serializing;
using FishNet.Transporting;
using Il2CppDummyDll;

[Token(Token = "0x20000FA")]
public class PlayerName : NetworkBehaviour
{
	[Token(Token = "0x4000523")]
	[FieldOffset(Offset = "0xF8")]
	public readonly SyncVar<string> playerName;

	[Token(Token = "0x4000524")]
	[FieldOffset(Offset = "0x100")]
	private bool NetworkInitialize___EarlyPlayerNameAssembly_002DCSharp_002Edll_Excuted;

	[Token(Token = "0x4000525")]
	[FieldOffset(Offset = "0x101")]
	private bool NetworkInitialize__LatePlayerNameAssembly_002DCSharp_002Edll_Excuted;

	[Token(Token = "0x6000795")]
	[Address(RVA = "0x4EF7B0", Offset = "0x4EE1B0", VA = "0x1804EF7B0", Slot = "15")]
	public override void OnStartClient()
	{
	}

	[Token(Token = "0x6000796")]
	[Address(RVA = "0x4EF9B0", Offset = "0x4EE3B0", VA = "0x1804EF9B0")]
	[ServerRpc]
	public void CMDSetPlayerName(string playerName)
	{
	}

	[Token(Token = "0x6000797")]
	[Address(RVA = "0x4EFB70", Offset = "0x4EE570", VA = "0x1804EFB70")]
	public PlayerName()
	{
	}

	[Token(Token = "0x6000798")]
	[Address(RVA = "0x4EFC50", Offset = "0x4EE650", VA = "0x1804EFC50", Slot = "27")]
	public override void NetworkInitialize___Early()
	{
	}

	[Token(Token = "0x6000799")]
	[Address(RVA = "0x484B80", Offset = "0x483580", VA = "0x180484B80", Slot = "28")]
	public override void NetworkInitialize__Late()
	{
	}

	[Token(Token = "0x600079A")]
	[Address(RVA = "0x4592B0", Offset = "0x457CB0", VA = "0x1804592B0", Slot = "18")]
	public override void NetworkInitializeIfDisabled()
	{
	}

	[Token(Token = "0x600079B")]
	[Address(RVA = "0x4EF9B0", Offset = "0x4EE3B0", VA = "0x1804EF9B0")]
	private void RpcWriter___Server_CMDSetPlayerName_3615296227(string playerName)
	{
	}

	[Token(Token = "0x600079C")]
	[Address(RVA = "0x4EFD10", Offset = "0x4EE710", VA = "0x1804EFD10")]
	public void RpcLogic___CMDSetPlayerName_3615296227(string playerName)
	{
	}

	[Token(Token = "0x600079D")]
	[Address(RVA = "0x4EFD90", Offset = "0x4EE790", VA = "0x1804EFD90")]
	private void RpcReader___Server_CMDSetPlayerName_3615296227(PooledReader PooledReader0, Channel channel, NetworkConnection conn)
	{
	}

	[Token(Token = "0x600079E")]
	[Address(RVA = "0x4592B0", Offset = "0x457CB0", VA = "0x1804592B0", Slot = "29")]
	public override void Awake()
	{
	}
}

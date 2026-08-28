using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using FishNet.Connection;
using FishNet.Managing.Scened;
using FishNet.Object;
using FishNet.Serializing;
using FishNet.Transporting;
using Il2CppDummyDll;

[Token(Token = "0x20000E6")]
public class GameManagerStartGame : NetworkBehaviour
{
	[Token(Token = "0x40004B0")]
	[FieldOffset(Offset = "0x0")]
	public static List<NetworkConnection> playerWhoHaveDownloadedTheLevel;

	[Token(Token = "0x40004B1")]
	[FieldOffset(Offset = "0xF8")]
	private bool NetworkInitialize___EarlyGameManagerStartGameAssembly_002DCSharp_002Edll_Excuted;

	[Token(Token = "0x40004B2")]
	[FieldOffset(Offset = "0xF9")]
	private bool NetworkInitialize__LateGameManagerStartGameAssembly_002DCSharp_002Edll_Excuted;

	[Token(Token = "0x60006D7")]
	[Address(RVA = "0x4E47C0", Offset = "0x4E31C0", VA = "0x1804E47C0", Slot = "10")]
	public override void OnStartServer()
	{
	}

	[Token(Token = "0x60006D8")]
	[Address(RVA = "0x4E49A0", Offset = "0x4E33A0", VA = "0x1804E49A0", Slot = "11")]
	public override void OnStopServer()
	{
	}

	[Token(Token = "0x60006D9")]
	[Address(RVA = "0x4E4A40", Offset = "0x4E3440", VA = "0x1804E4A40")]
	[Server]
	private void ServerInitializeClient(ClientPresenceChangeEventArgs data)
	{
	}

	[Token(Token = "0x60006DA")]
	[Address(RVA = "0x4E4D30", Offset = "0x4E3730", VA = "0x1804E4D30")]
	[IteratorStateMachine(typeof(_003CServerSpawnClient_003Ed__4))]
	[Server]
	public IEnumerator ServerSpawnClient(NetworkConnection connection)
	{
		return null;
	}

	[Token(Token = "0x60006DB")]
	[Address(RVA = "0x4E4E90", Offset = "0x4E3890", VA = "0x1804E4E90")]
	[TargetRpc]
	private void ClientStartGame(NetworkConnection conn)
	{
	}

	[Token(Token = "0x60006DC")]
	[Address(RVA = "0x464E10", Offset = "0x463810", VA = "0x180464E10")]
	public GameManagerStartGame()
	{
	}

	[Token(Token = "0x60006DD")]
	[Address(RVA = "0x4E5000", Offset = "0x4E3A00", VA = "0x1804E5000", Slot = "27")]
	public override void NetworkInitialize___Early()
	{
	}

	[Token(Token = "0x60006DE")]
	[Address(RVA = "0x46BB80", Offset = "0x46A580", VA = "0x18046BB80", Slot = "28")]
	public override void NetworkInitialize__Late()
	{
	}

	[Token(Token = "0x60006DF")]
	[Address(RVA = "0x4592B0", Offset = "0x457CB0", VA = "0x1804592B0", Slot = "18")]
	public override void NetworkInitializeIfDisabled()
	{
	}

	[Token(Token = "0x60006E0")]
	[Address(RVA = "0x4E4E90", Offset = "0x4E3890", VA = "0x1804E4E90")]
	private void RpcWriter___Target_ClientStartGame_328543758(NetworkConnection conn)
	{
	}

	[Token(Token = "0x60006E1")]
	[Address(RVA = "0x4E5090", Offset = "0x4E3A90", VA = "0x1804E5090")]
	private void RpcLogic___ClientStartGame_328543758(NetworkConnection conn)
	{
	}

	[Token(Token = "0x60006E2")]
	[Address(RVA = "0x4E5150", Offset = "0x4E3B50", VA = "0x1804E5150")]
	private void RpcReader___Target_ClientStartGame_328543758(PooledReader PooledReader0, Channel channel)
	{
	}

	[Token(Token = "0x60006E3")]
	[Address(RVA = "0x4592B0", Offset = "0x457CB0", VA = "0x1804592B0", Slot = "29")]
	public override void Awake()
	{
	}
}

using System.Collections;
using System.Runtime.CompilerServices;
using FishNet.Connection;
using FishNet.Object;
using FishNet.Serializing;
using FishNet.Transporting;
using Il2CppDummyDll;

[Token(Token = "0x200003E")]
public class PlayerEndGame : NetworkBehaviour
{
	[Token(Token = "0x40000C0")]
	[FieldOffset(Offset = "0xF8")]
	private bool NetworkInitialize___EarlyPlayerEndGameAssembly_002DCSharp_002Edll_Excuted;

	[Token(Token = "0x40000C1")]
	[FieldOffset(Offset = "0xF9")]
	private bool NetworkInitialize__LatePlayerEndGameAssembly_002DCSharp_002Edll_Excuted;

	[Token(Token = "0x6000140")]
	[Address(RVA = "0x46C080", Offset = "0x46AA80", VA = "0x18046C080")]
	[Server]
	public void StartEndGame()
	{
	}

	[Token(Token = "0x6000141")]
	[Address(RVA = "0x46C250", Offset = "0x46AC50", VA = "0x18046C250")]
	[TargetRpc]
	private void ClientEndGame(NetworkConnection target)
	{
	}

	[Token(Token = "0x6000142")]
	[Address(RVA = "0x46C3C0", Offset = "0x46ADC0", VA = "0x18046C3C0")]
	[IteratorStateMachine(typeof(_003CWaitAndStartLevelTransition_003Ed__2))]
	[Client]
	private IEnumerator WaitAndStartLevelTransition()
	{
		return null;
	}

	[Token(Token = "0x6000143")]
	[Address(RVA = "0x46C4B0", Offset = "0x46AEB0", VA = "0x18046C4B0")]
	[ServerRpc]
	private void DestroyPlayer(int playerItemID)
	{
	}

	[Token(Token = "0x6000144")]
	[Address(RVA = "0x464E10", Offset = "0x463810", VA = "0x180464E10")]
	public PlayerEndGame()
	{
	}

	[Token(Token = "0x6000145")]
	[Address(RVA = "0x46C4C0", Offset = "0x46AEC0", VA = "0x18046C4C0", Slot = "27")]
	public override void NetworkInitialize___Early()
	{
	}

	[Token(Token = "0x6000146")]
	[Address(RVA = "0x46BB80", Offset = "0x46A580", VA = "0x18046BB80", Slot = "28")]
	public override void NetworkInitialize__Late()
	{
	}

	[Token(Token = "0x6000147")]
	[Address(RVA = "0x4592B0", Offset = "0x457CB0", VA = "0x1804592B0", Slot = "18")]
	public override void NetworkInitializeIfDisabled()
	{
	}

	[Token(Token = "0x6000148")]
	[Address(RVA = "0x46C250", Offset = "0x46AC50", VA = "0x18046C250")]
	private void RpcWriter___Target_ClientEndGame_328543758(NetworkConnection target)
	{
	}

	[Token(Token = "0x6000149")]
	[Address(RVA = "0x46C5B0", Offset = "0x46AFB0", VA = "0x18046C5B0")]
	private void RpcLogic___ClientEndGame_328543758(NetworkConnection target)
	{
	}

	[Token(Token = "0x600014A")]
	[Address(RVA = "0x46CB30", Offset = "0x46B530", VA = "0x18046CB30")]
	private void RpcReader___Target_ClientEndGame_328543758(PooledReader PooledReader0, Channel channel)
	{
	}

	[Token(Token = "0x600014B")]
	[Address(RVA = "0x46CB80", Offset = "0x46B580", VA = "0x18046CB80")]
	private void RpcWriter___Server_DestroyPlayer_3316948804(int playerItemID)
	{
	}

	[Token(Token = "0x600014C")]
	[Address(RVA = "0x46CD50", Offset = "0x46B750", VA = "0x18046CD50")]
	private void RpcLogic___DestroyPlayer_3316948804(int playerItemID)
	{
	}

	[Token(Token = "0x600014D")]
	[Address(RVA = "0x46CED0", Offset = "0x46B8D0", VA = "0x18046CED0")]
	private void RpcReader___Server_DestroyPlayer_3316948804(PooledReader PooledReader0, Channel channel, NetworkConnection conn)
	{
	}

	[Token(Token = "0x600014E")]
	[Address(RVA = "0x4592B0", Offset = "0x457CB0", VA = "0x1804592B0", Slot = "29")]
	public override void Awake()
	{
	}
}

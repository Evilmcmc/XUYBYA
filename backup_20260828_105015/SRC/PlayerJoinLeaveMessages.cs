using System.Collections;
using System.Runtime.CompilerServices;
using FishNet.Object;
using FishNet.Serializing;
using FishNet.Transporting;
using Il2CppDummyDll;
using Steamworks;
using UnityEngine;
using UnityEngine.Localization;

[Token(Token = "0x20000A7")]
public class PlayerJoinLeaveMessages : NetworkBehaviour
{
	[Token(Token = "0x40003A9")]
	[FieldOffset(Offset = "0xF8")]
	[SerializeField]
	private LocalizedString joinText;

	[Token(Token = "0x40003AA")]
	[FieldOffset(Offset = "0x100")]
	[SerializeField]
	private LocalizedString leaveText;

	[Token(Token = "0x40003AB")]
	[FieldOffset(Offset = "0x108")]
	private bool joined;

	[Token(Token = "0x40003AC")]
	[FieldOffset(Offset = "0x109")]
	private bool NetworkInitialize___EarlyPlayerJoinLeaveMessagesAssembly_002DCSharp_002Edll_Excuted;

	[Token(Token = "0x40003AD")]
	[FieldOffset(Offset = "0x10A")]
	private bool NetworkInitialize__LatePlayerJoinLeaveMessagesAssembly_002DCSharp_002Edll_Excuted;

	[Token(Token = "0x6000510")]
	[Address(RVA = "0x4C4030", Offset = "0x4C2A30", VA = "0x1804C4030", Slot = "10")]
	public override void OnStartServer()
	{
	}

	[Token(Token = "0x6000511")]
	[Address(RVA = "0x4C40E0", Offset = "0x4C2AE0", VA = "0x1804C40E0")]
	[IteratorStateMachine(typeof(_003CSendJoinGameMessage_003Ed__4))]
	private IEnumerator SendJoinGameMessage()
	{
		return null;
	}

	[Token(Token = "0x6000512")]
	[Address(RVA = "0x4C4180", Offset = "0x4C2B80", VA = "0x1804C4180")]
	[ObserversRpc(ExcludeOwner = true)]
	private void JoinMessage(string username)
	{
	}

	[Token(Token = "0x6000513")]
	[Address(RVA = "0x4C4300", Offset = "0x4C2D00", VA = "0x1804C4300", Slot = "16")]
	public override void OnStopClient()
	{
	}

	[Token(Token = "0x6000514")]
	[Address(RVA = "0x4C4620", Offset = "0x4C3020", VA = "0x1804C4620")]
	private string GetUsernameFromSteamID(CSteamID steamID)
	{
		return null;
	}

	[Token(Token = "0x6000515")]
	[Address(RVA = "0x464E10", Offset = "0x463810", VA = "0x180464E10")]
	public PlayerJoinLeaveMessages()
	{
	}

	[Token(Token = "0x6000516")]
	[Address(RVA = "0x4C46B0", Offset = "0x4C30B0", VA = "0x1804C46B0", Slot = "27")]
	public override void NetworkInitialize___Early()
	{
	}

	[Token(Token = "0x6000517")]
	[Address(RVA = "0x4C4740", Offset = "0x4C3140", VA = "0x1804C4740", Slot = "28")]
	public override void NetworkInitialize__Late()
	{
	}

	[Token(Token = "0x6000518")]
	[Address(RVA = "0x4592B0", Offset = "0x457CB0", VA = "0x1804592B0", Slot = "18")]
	public override void NetworkInitializeIfDisabled()
	{
	}

	[Token(Token = "0x6000519")]
	[Address(RVA = "0x4C4180", Offset = "0x4C2B80", VA = "0x1804C4180")]
	private void RpcWriter___Observers_JoinMessage_3615296227(string username)
	{
	}

	[Token(Token = "0x600051A")]
	[Address(RVA = "0x4C4760", Offset = "0x4C3160", VA = "0x1804C4760")]
	private void RpcLogic___JoinMessage_3615296227(string username)
	{
	}

	[Token(Token = "0x600051B")]
	[Address(RVA = "0x4C4910", Offset = "0x4C3310", VA = "0x1804C4910")]
	private void RpcReader___Observers_JoinMessage_3615296227(PooledReader PooledReader0, Channel channel)
	{
	}

	[Token(Token = "0x600051C")]
	[Address(RVA = "0x4592B0", Offset = "0x457CB0", VA = "0x1804592B0", Slot = "29")]
	public override void Awake()
	{
	}
}

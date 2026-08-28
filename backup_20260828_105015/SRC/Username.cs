using FishNet.Connection;
using FishNet.Object;
using FishNet.Object.Synchronizing;
using FishNet.Serializing;
using FishNet.Transporting;
using Il2CppDummyDll;
using TMPro;
using UnityEngine;

[Token(Token = "0x2000091")]
public class Username : NetworkBehaviour
{
	[Token(Token = "0x4000314")]
	[FieldOffset(Offset = "0xF8")]
	[SerializeField]
	private TMP_Text usernameText;

	[Token(Token = "0x4000315")]
	[FieldOffset(Offset = "0x100")]
	public readonly SyncVar<string> username;

	[Token(Token = "0x4000316")]
	[FieldOffset(Offset = "0x108")]
	private bool NetworkInitialize___EarlyUsernameAssembly_002DCSharp_002Edll_Excuted;

	[Token(Token = "0x4000317")]
	[FieldOffset(Offset = "0x109")]
	private bool NetworkInitialize__LateUsernameAssembly_002DCSharp_002Edll_Excuted;

	[Token(Token = "0x6000412")]
	[Address(RVA = "0x4AFE00", Offset = "0x4AE800", VA = "0x1804AFE00", Slot = "7")]
	public override void OnStartNetwork()
	{
	}

	[Token(Token = "0x6000413")]
	[Address(RVA = "0x4AFEB0", Offset = "0x4AE8B0", VA = "0x1804AFEB0", Slot = "9")]
	public override void OnStopNetwork()
	{
	}

	[Token(Token = "0x6000414")]
	[Address(RVA = "0x4AFF60", Offset = "0x4AE960", VA = "0x1804AFF60", Slot = "15")]
	public override void OnStartClient()
	{
	}

	[Token(Token = "0x6000415")]
	[Address(RVA = "0x4B01E0", Offset = "0x4AEBE0", VA = "0x1804B01E0")]
	[Server]
	public void UpdateUsernameForLatePlayer(NetworkConnection target)
	{
	}

	[Token(Token = "0x6000416")]
	[Address(RVA = "0x4B03C0", Offset = "0x4AEDC0", VA = "0x1804B03C0")]
	[TargetRpc]
	private void RPCUpdateUsernameForLatePlayer(NetworkConnection target, string _username)
	{
	}

	[Token(Token = "0x6000417")]
	[Address(RVA = "0x4B0540", Offset = "0x4AEF40", VA = "0x1804B0540")]
	[ServerRpc]
	private void CMDSetPlayerName(string playerName)
	{
	}

	[Token(Token = "0x6000418")]
	[Address(RVA = "0x4B0700", Offset = "0x4AF100", VA = "0x1804B0700")]
	public void PlayerNameUpdate(string oldValue, string newValue, bool asServer)
	{
	}

	[Token(Token = "0x6000419")]
	[Address(RVA = "0x4B07C0", Offset = "0x4AF1C0", VA = "0x1804B07C0")]
	public Username()
	{
	}

	[Token(Token = "0x600041A")]
	[Address(RVA = "0x4B08A0", Offset = "0x4AF2A0", VA = "0x1804B08A0", Slot = "27")]
	public override void NetworkInitialize___Early()
	{
	}

	[Token(Token = "0x600041B")]
	[Address(RVA = "0x4B09C0", Offset = "0x4AF3C0", VA = "0x1804B09C0", Slot = "28")]
	public override void NetworkInitialize__Late()
	{
	}

	[Token(Token = "0x600041C")]
	[Address(RVA = "0x4592B0", Offset = "0x457CB0", VA = "0x1804592B0", Slot = "18")]
	public override void NetworkInitializeIfDisabled()
	{
	}

	[Token(Token = "0x600041D")]
	[Address(RVA = "0x4B03C0", Offset = "0x4AEDC0", VA = "0x1804B03C0")]
	private void RpcWriter___Target_RPCUpdateUsernameForLatePlayer_2971853958(NetworkConnection target, string _username)
	{
	}

	[Token(Token = "0x600041E")]
	[Address(RVA = "0x4B0A00", Offset = "0x4AF400", VA = "0x1804B0A00")]
	private void RpcLogic___RPCUpdateUsernameForLatePlayer_2971853958(NetworkConnection target, string _username)
	{
	}

	[Token(Token = "0x600041F")]
	[Address(RVA = "0x4B0A40", Offset = "0x4AF440", VA = "0x1804B0A40")]
	private void RpcReader___Target_RPCUpdateUsernameForLatePlayer_2971853958(PooledReader PooledReader0, Channel channel)
	{
	}

	[Token(Token = "0x6000420")]
	[Address(RVA = "0x4B0540", Offset = "0x4AEF40", VA = "0x1804B0540")]
	private void RpcWriter___Server_CMDSetPlayerName_3615296227(string playerName)
	{
	}

	[Token(Token = "0x6000421")]
	[Address(RVA = "0x4B0AB0", Offset = "0x4AF4B0", VA = "0x1804B0AB0")]
	private void RpcLogic___CMDSetPlayerName_3615296227(string playerName)
	{
	}

	[Token(Token = "0x6000422")]
	[Address(RVA = "0x4B0B90", Offset = "0x4AF590", VA = "0x1804B0B90")]
	private void RpcReader___Server_CMDSetPlayerName_3615296227(PooledReader PooledReader0, Channel channel, NetworkConnection conn)
	{
	}

	[Token(Token = "0x6000423")]
	[Address(RVA = "0x4592B0", Offset = "0x457CB0", VA = "0x1804592B0", Slot = "29")]
	public override void Awake()
	{
	}
}

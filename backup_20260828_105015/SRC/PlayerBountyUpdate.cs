using System.Collections;
using System.Runtime.CompilerServices;
using FishNet.Connection;
using FishNet.Object;
using FishNet.Serializing;
using FishNet.Transporting;
using Il2CppDummyDll;
using UnityEngine;

[Token(Token = "0x200008A")]
public class PlayerBountyUpdate : NetworkBehaviour
{
	[Token(Token = "0x4000293")]
	[FieldOffset(Offset = "0xF8")]
	[SerializeField]
	[ColorUsage(true, true)]
	private Color bountyOutlineColor;

	[Token(Token = "0x4000294")]
	[FieldOffset(Offset = "0x108")]
	[SerializeField]
	[ColorUsage(true, true)]
	private Color homeTeamColor;

	[Token(Token = "0x4000295")]
	[FieldOffset(Offset = "0x118")]
	[SerializeField]
	[ColorUsage(true, true)]
	private Color awayTeamColor;

	[Token(Token = "0x4000296")]
	[FieldOffset(Offset = "0x128")]
	[SerializeField]
	private PhysicalOutline[] outlines;

	[Token(Token = "0x4000297")]
	[FieldOffset(Offset = "0x130")]
	[SerializeField]
	private Transform hatParent;

	[Token(Token = "0x4000298")]
	[FieldOffset(Offset = "0x138")]
	[SerializeField]
	private Transform bodyMesh;

	[Token(Token = "0x4000299")]
	[FieldOffset(Offset = "0x140")]
	private bool NetworkInitialize___EarlyPlayerBountyUpdateAssembly_002DCSharp_002Edll_Excuted;

	[Token(Token = "0x400029A")]
	[FieldOffset(Offset = "0x141")]
	private bool NetworkInitialize__LatePlayerBountyUpdateAssembly_002DCSharp_002Edll_Excuted;

	[Token(Token = "0x60003A8")]
	[Address(RVA = "0x4A4590", Offset = "0x4A2F90", VA = "0x1804A4590", Slot = "15")]
	public override void OnStartClient()
	{
	}

	[Token(Token = "0x60003A9")]
	[Address(RVA = "0x4A45C0", Offset = "0x4A2FC0", VA = "0x1804A45C0")]
	[TargetRpc]
	public void RefreshOutlines(NetworkConnection target)
	{
	}

	[Token(Token = "0x60003AA")]
	[Address(RVA = "0x4A4730", Offset = "0x4A3130", VA = "0x1804A4730")]
	[IteratorStateMachine(typeof(_003CUpdateOutlines_003Ed__8))]
	private IEnumerator UpdateOutlines()
	{
		return null;
	}

	[Token(Token = "0x60003AB")]
	[Address(RVA = "0x4A47D0", Offset = "0x4A31D0", VA = "0x1804A47D0")]
	public void EnableOutlines()
	{
	}

	[Token(Token = "0x60003AC")]
	[Address(RVA = "0x4A47E0", Offset = "0x4A31E0", VA = "0x1804A47E0")]
	[ServerRpc]
	private void CMDEnableOutlines()
	{
	}

	[Token(Token = "0x60003AD")]
	[Address(RVA = "0x4A4990", Offset = "0x4A3390", VA = "0x1804A4990")]
	[ObserversRpc]
	public void RPCEnableOutlines()
	{
	}

	[Token(Token = "0x60003AE")]
	[Address(RVA = "0x4A4AF0", Offset = "0x4A34F0", VA = "0x1804A4AF0")]
	[Server]
	public void ServerDisableOutlines()
	{
	}

	[Token(Token = "0x60003AF")]
	[Address(RVA = "0x4A4C90", Offset = "0x4A3690", VA = "0x1804A4C90")]
	[ObserversRpc]
	private void RPCDisableOutlines()
	{
	}

	[Token(Token = "0x60003B0")]
	[Address(RVA = "0x464E10", Offset = "0x463810", VA = "0x180464E10")]
	public PlayerBountyUpdate()
	{
	}

	[Token(Token = "0x60003B1")]
	[Address(RVA = "0x4A4DF0", Offset = "0x4A37F0", VA = "0x1804A4DF0", Slot = "27")]
	public override void NetworkInitialize___Early()
	{
	}

	[Token(Token = "0x60003B2")]
	[Address(RVA = "0x483DA0", Offset = "0x4827A0", VA = "0x180483DA0", Slot = "28")]
	public override void NetworkInitialize__Late()
	{
	}

	[Token(Token = "0x60003B3")]
	[Address(RVA = "0x4592B0", Offset = "0x457CB0", VA = "0x1804592B0", Slot = "18")]
	public override void NetworkInitializeIfDisabled()
	{
	}

	[Token(Token = "0x60003B4")]
	[Address(RVA = "0x4A45C0", Offset = "0x4A2FC0", VA = "0x1804A45C0")]
	private void RpcWriter___Target_RefreshOutlines_328543758(NetworkConnection target)
	{
	}

	[Token(Token = "0x60003B5")]
	[Address(RVA = "0x4A4590", Offset = "0x4A2F90", VA = "0x1804A4590")]
	public void RpcLogic___RefreshOutlines_328543758(NetworkConnection target)
	{
	}

	[Token(Token = "0x60003B6")]
	[Address(RVA = "0x4A4F70", Offset = "0x4A3970", VA = "0x1804A4F70")]
	private void RpcReader___Target_RefreshOutlines_328543758(PooledReader PooledReader0, Channel channel)
	{
	}

	[Token(Token = "0x60003B7")]
	[Address(RVA = "0x4A47E0", Offset = "0x4A31E0", VA = "0x1804A47E0")]
	private void RpcWriter___Server_CMDEnableOutlines_2166136261()
	{
	}

	[Token(Token = "0x60003B8")]
	[Address(RVA = "0x4A4990", Offset = "0x4A3390", VA = "0x1804A4990")]
	private void RpcLogic___CMDEnableOutlines_2166136261()
	{
	}

	[Token(Token = "0x60003B9")]
	[Address(RVA = "0x4A4FC0", Offset = "0x4A39C0", VA = "0x1804A4FC0")]
	private void RpcReader___Server_CMDEnableOutlines_2166136261(PooledReader PooledReader0, Channel channel, NetworkConnection conn)
	{
	}

	[Token(Token = "0x60003BA")]
	[Address(RVA = "0x4A4990", Offset = "0x4A3390", VA = "0x1804A4990")]
	private void RpcWriter___Observers_RPCEnableOutlines_2166136261()
	{
	}

	[Token(Token = "0x60003BB")]
	[Address(RVA = "0x4A51D0", Offset = "0x4A3BD0", VA = "0x1804A51D0")]
	public void RpcLogic___RPCEnableOutlines_2166136261()
	{
	}

	[Token(Token = "0x60003BC")]
	[Address(RVA = "0x4A5600", Offset = "0x4A4000", VA = "0x1804A5600")]
	private void RpcReader___Observers_RPCEnableOutlines_2166136261(PooledReader PooledReader0, Channel channel)
	{
	}

	[Token(Token = "0x60003BD")]
	[Address(RVA = "0x4A4C90", Offset = "0x4A3690", VA = "0x1804A4C90")]
	private void RpcWriter___Observers_RPCDisableOutlines_2166136261()
	{
	}

	[Token(Token = "0x60003BE")]
	[Address(RVA = "0x4A5630", Offset = "0x4A4030", VA = "0x1804A5630")]
	private void RpcLogic___RPCDisableOutlines_2166136261()
	{
	}

	[Token(Token = "0x60003BF")]
	[Address(RVA = "0x4A5A60", Offset = "0x4A4460", VA = "0x1804A5A60")]
	private void RpcReader___Observers_RPCDisableOutlines_2166136261(PooledReader PooledReader0, Channel channel)
	{
	}

	[Token(Token = "0x60003C0")]
	[Address(RVA = "0x4592B0", Offset = "0x457CB0", VA = "0x1804592B0", Slot = "29")]
	public override void Awake()
	{
	}
}

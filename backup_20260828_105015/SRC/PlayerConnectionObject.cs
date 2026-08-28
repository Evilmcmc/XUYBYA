using System;
using System.Collections;
using System.Runtime.CompilerServices;
using FishNet.Connection;
using FishNet.Object;
using FishNet.Object.Synchronizing;
using FishNet.Serializing;
using FishNet.Transporting;
using Il2CppDummyDll;
using UnityEngine.InputSystem;

[Serializable]
[Token(Token = "0x20000F2")]
public class PlayerConnectionObject : NetworkBehaviour
{
	[Token(Token = "0x400050C")]
	[FieldOffset(Offset = "0xF8")]
	public readonly SyncVar<int> ConnectionID;

	[Token(Token = "0x400050D")]
	[FieldOffset(Offset = "0x100")]
	private PlayerInput playerInput;

	[Token(Token = "0x400050E")]
	[FieldOffset(Offset = "0x108")]
	private bool NetworkInitialize___EarlyPlayerConnectionObjectAssembly_002DCSharp_002Edll_Excuted;

	[Token(Token = "0x400050F")]
	[FieldOffset(Offset = "0x109")]
	private bool NetworkInitialize__LatePlayerConnectionObjectAssembly_002DCSharp_002Edll_Excuted;

	[Token(Token = "0x600073A")]
	[Address(RVA = "0x4EB9A0", Offset = "0x4EA3A0", VA = "0x1804EB9A0", Slot = "10")]
	public override void OnStartServer()
	{
	}

	[Token(Token = "0x600073B")]
	[Address(RVA = "0x4EBB10", Offset = "0x4EA510", VA = "0x1804EBB10")]
	[Server]
	public void LoadIntoGame()
	{
	}

	[Token(Token = "0x600073C")]
	[Address(RVA = "0x4EBCE0", Offset = "0x4EA6E0", VA = "0x1804EBCE0")]
	[TargetRpc]
	public void RPCLoadIntoGame(NetworkConnection target)
	{
	}

	[Token(Token = "0x600073D")]
	[Address(RVA = "0x4EBE50", Offset = "0x4EA850", VA = "0x1804EBE50")]
	[Server]
	public void SpawnLateJoiningPlayer(NetworkConnection conn)
	{
	}

	[Token(Token = "0x600073E")]
	[Address(RVA = "0x4EC020", Offset = "0x4EAA20", VA = "0x1804EC020")]
	[TargetRpc]
	public void RPCSetLateJoiningPlayerName(NetworkConnection target)
	{
	}

	[Token(Token = "0x600073F")]
	[Address(RVA = "0x4EC190", Offset = "0x4EAB90", VA = "0x1804EC190")]
	[Server]
	public void StartSceneTransition()
	{
	}

	[Token(Token = "0x6000740")]
	[Address(RVA = "0x4EC330", Offset = "0x4EAD30", VA = "0x1804EC330")]
	[ObserversRpc]
	private void RPCStartSceneTransition()
	{
	}

	[Token(Token = "0x6000741")]
	[Address(RVA = "0x4EC490", Offset = "0x4EAE90", VA = "0x1804EC490")]
	public void CanStartGame(string sceneName)
	{
	}

	[Token(Token = "0x6000742")]
	[Address(RVA = "0x4EC690", Offset = "0x4EB090", VA = "0x1804EC690")]
	[ServerRpc]
	public void CMDCanStartGame(string sceneName)
	{
	}

	[Token(Token = "0x6000743")]
	[Address(RVA = "0x4EC850", Offset = "0x4EB250", VA = "0x1804EC850")]
	[IteratorStateMachine(typeof(_003CServerStartGame_003Ed__11))]
	private IEnumerator ServerStartGame(string sceneName)
	{
		return null;
	}

	[Token(Token = "0x6000744")]
	[Address(RVA = "0x4EC8F0", Offset = "0x4EB2F0", VA = "0x1804EC8F0")]
	[Server]
	public void UpdateLatePlayerList()
	{
	}

	[Token(Token = "0x6000745")]
	[Address(RVA = "0x4ECAC0", Offset = "0x4EB4C0", VA = "0x1804ECAC0")]
	[TargetRpc]
	private void RPCUpdateLatePlayerList(NetworkConnection target)
	{
	}

	[Token(Token = "0x6000746")]
	[Address(RVA = "0x4ECC30", Offset = "0x4EB630", VA = "0x1804ECC30")]
	[IteratorStateMachine(typeof(_003CRPCUpdateLatePlayerListAfterABit_003Ed__14))]
	private IEnumerator RPCUpdateLatePlayerListAfterABit()
	{
		return null;
	}

	[Token(Token = "0x6000747")]
	[Address(RVA = "0x4ECC70", Offset = "0x4EB670", VA = "0x1804ECC70")]
	public PlayerConnectionObject()
	{
	}

	[Token(Token = "0x6000748")]
	[Address(RVA = "0x4ECD60", Offset = "0x4EB760", VA = "0x1804ECD60", Slot = "27")]
	public override void NetworkInitialize___Early()
	{
	}

	[Token(Token = "0x6000749")]
	[Address(RVA = "0x4ECF60", Offset = "0x4EB960", VA = "0x1804ECF60", Slot = "28")]
	public override void NetworkInitialize__Late()
	{
	}

	[Token(Token = "0x600074A")]
	[Address(RVA = "0x4592B0", Offset = "0x457CB0", VA = "0x1804592B0", Slot = "18")]
	public override void NetworkInitializeIfDisabled()
	{
	}

	[Token(Token = "0x600074B")]
	[Address(RVA = "0x4EBCE0", Offset = "0x4EA6E0", VA = "0x1804EBCE0")]
	private void RpcWriter___Target_RPCLoadIntoGame_328543758(NetworkConnection target)
	{
	}

	[Token(Token = "0x600074C")]
	[Address(RVA = "0x4ECFA0", Offset = "0x4EB9A0", VA = "0x1804ECFA0")]
	public void RpcLogic___RPCLoadIntoGame_328543758(NetworkConnection target)
	{
	}

	[Token(Token = "0x600074D")]
	[Address(RVA = "0x4ED070", Offset = "0x4EBA70", VA = "0x1804ED070")]
	private void RpcReader___Target_RPCLoadIntoGame_328543758(PooledReader PooledReader0, Channel channel)
	{
	}

	[Token(Token = "0x600074E")]
	[Address(RVA = "0x4EC020", Offset = "0x4EAA20", VA = "0x1804EC020")]
	private void RpcWriter___Target_RPCSetLateJoiningPlayerName_328543758(NetworkConnection target)
	{
	}

	[Token(Token = "0x600074F")]
	[Address(RVA = "0x4ED170", Offset = "0x4EBB70", VA = "0x1804ED170")]
	public void RpcLogic___RPCSetLateJoiningPlayerName_328543758(NetworkConnection target)
	{
	}

	[Token(Token = "0x6000750")]
	[Address(RVA = "0x4ED1D0", Offset = "0x4EBBD0", VA = "0x1804ED1D0")]
	private void RpcReader___Target_RPCSetLateJoiningPlayerName_328543758(PooledReader PooledReader0, Channel channel)
	{
	}

	[Token(Token = "0x6000751")]
	[Address(RVA = "0x4EC330", Offset = "0x4EAD30", VA = "0x1804EC330")]
	private void RpcWriter___Observers_RPCStartSceneTransition_2166136261()
	{
	}

	[Token(Token = "0x6000752")]
	[Address(RVA = "0x4ED250", Offset = "0x4EBC50", VA = "0x1804ED250")]
	private void RpcLogic___RPCStartSceneTransition_2166136261()
	{
	}

	[Token(Token = "0x6000753")]
	[Address(RVA = "0x4ED340", Offset = "0x4EBD40", VA = "0x1804ED340")]
	private void RpcReader___Observers_RPCStartSceneTransition_2166136261(PooledReader PooledReader0, Channel channel)
	{
	}

	[Token(Token = "0x6000754")]
	[Address(RVA = "0x4EC690", Offset = "0x4EB090", VA = "0x1804EC690")]
	private void RpcWriter___Server_CMDCanStartGame_3615296227(string sceneName)
	{
	}

	[Token(Token = "0x6000755")]
	[Address(RVA = "0x4ED450", Offset = "0x4EBE50", VA = "0x1804ED450")]
	public void RpcLogic___CMDCanStartGame_3615296227(string sceneName)
	{
	}

	[Token(Token = "0x6000756")]
	[Address(RVA = "0x4ED500", Offset = "0x4EBF00", VA = "0x1804ED500")]
	private void RpcReader___Server_CMDCanStartGame_3615296227(PooledReader PooledReader0, Channel channel, NetworkConnection conn)
	{
	}

	[Token(Token = "0x6000757")]
	[Address(RVA = "0x4ECAC0", Offset = "0x4EB4C0", VA = "0x1804ECAC0")]
	private void RpcWriter___Target_RPCUpdateLatePlayerList_328543758(NetworkConnection target)
	{
	}

	[Token(Token = "0x6000758")]
	[Address(RVA = "0x4ED680", Offset = "0x4EC080", VA = "0x1804ED680")]
	private void RpcLogic___RPCUpdateLatePlayerList_328543758(NetworkConnection target)
	{
	}

	[Token(Token = "0x6000759")]
	[Address(RVA = "0x4ED6D0", Offset = "0x4EC0D0", VA = "0x1804ED6D0")]
	private void RpcReader___Target_RPCUpdateLatePlayerList_328543758(PooledReader PooledReader0, Channel channel)
	{
	}

	[Token(Token = "0x600075A")]
	[Address(RVA = "0x4592B0", Offset = "0x457CB0", VA = "0x1804592B0", Slot = "29")]
	public override void Awake()
	{
	}
}

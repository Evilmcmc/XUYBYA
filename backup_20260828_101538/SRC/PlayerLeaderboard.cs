using System.Collections.Generic;
using System.Runtime.InteropServices;
using FishNet.Connection;
using FishNet.Object;
using FishNet.Serializing;
using FishNet.Transporting;
using Il2CppDummyDll;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Localization;

[Token(Token = "0x2000043")]
public class PlayerLeaderboard : NetworkBehaviour
{
	[Token(Token = "0x40000D7")]
	[Il2CppDummyDll.FieldOffset(Offset = "0xF8")]
	[SerializeField]
	private LocalizedString blueText;

	[Token(Token = "0x40000D8")]
	[Il2CppDummyDll.FieldOffset(Offset = "0x100")]
	[SerializeField]
	private LocalizedString redText;

	[Token(Token = "0x40000D9")]
	[Il2CppDummyDll.FieldOffset(Offset = "0x108")]
	[SerializeField]
	private LocalizedString nobodyText;

	[Token(Token = "0x40000DA")]
	[Il2CppDummyDll.FieldOffset(Offset = "0x110")]
	[SerializeField]
	private LocalizedString[] gameModes;

	[Token(Token = "0x40000DB")]
	[Il2CppDummyDll.FieldOffset(Offset = "0x118")]
	[SerializeField]
	private LocalizedString[] gunNames;

	[Token(Token = "0x40000DC")]
	[Il2CppDummyDll.FieldOffset(Offset = "0x120")]
	[SerializeField]
	private GameObject leaderboardParent;

	[Token(Token = "0x40000DD")]
	[Il2CppDummyDll.FieldOffset(Offset = "0x128")]
	private bool NetworkInitialize___EarlyPlayerLeaderboardAssembly_002DCSharp_002Edll_Excuted;

	[Token(Token = "0x40000DE")]
	[Il2CppDummyDll.FieldOffset(Offset = "0x129")]
	private bool NetworkInitialize__LatePlayerLeaderboardAssembly_002DCSharp_002Edll_Excuted;

	[Token(Token = "0x6000177")]
	[Address(RVA = "0x4706E0", Offset = "0x46F0E0", VA = "0x1804706E0", Slot = "17")]
	public override void OnOwnershipClient(NetworkConnection prevOwner)
	{
	}

	[Token(Token = "0x6000178")]
	[Address(RVA = "0x4706F0", Offset = "0x46F0F0", VA = "0x1804706F0")]
	public void StartToggleLeaderBoard([Optional] InputAction.CallbackContext context)
	{
	}

	[Token(Token = "0x6000179")]
	[Address(RVA = "0x470770", Offset = "0x46F170", VA = "0x180470770")]
	public void StopToggleLeaderBoard([Optional] InputAction.CallbackContext context)
	{
	}

	[Token(Token = "0x600017A")]
	[Address(RVA = "0x4707A0", Offset = "0x46F1A0", VA = "0x1804707A0")]
	[ServerRpc]
	public void CMDUpdateLeaderBoard(bool isEndGame)
	{
	}

	[Token(Token = "0x600017B")]
	[Address(RVA = "0x470960", Offset = "0x46F360", VA = "0x180470960")]
	[TargetRpc]
	private void UpdateLeaderBoard(NetworkConnection target, List<LeaderBoardPlayerData> playerData, bool isEndGame, int homeScore, int awayScore)
	{
	}

	[Token(Token = "0x600017C")]
	[Address(RVA = "0x470970", Offset = "0x46F370", VA = "0x180470970")]
	private void AddPlayersToLeaderboard(List<LeaderBoardPlayerData> playerData)
	{
	}

	[Token(Token = "0x600017D")]
	[Address(RVA = "0x473120", Offset = "0x471B20", VA = "0x180473120")]
	public void ToggleOffEndGame()
	{
	}

	[Token(Token = "0x600017E")]
	[Address(RVA = "0x473210", Offset = "0x471C10", VA = "0x180473210")]
	public List<LeaderBoardPlayerData> SortPlayers(List<LeaderBoardPlayerData> playerObjects)
	{
		return null;
	}

	[Token(Token = "0x600017F")]
	[Address(RVA = "0x464E10", Offset = "0x463810", VA = "0x180464E10")]
	public PlayerLeaderboard()
	{
	}

	[Token(Token = "0x6000180")]
	[Address(RVA = "0x4732F0", Offset = "0x471CF0", VA = "0x1804732F0", Slot = "27")]
	public override void NetworkInitialize___Early()
	{
	}

	[Token(Token = "0x6000181")]
	[Address(RVA = "0x4733E0", Offset = "0x471DE0", VA = "0x1804733E0", Slot = "28")]
	public override void NetworkInitialize__Late()
	{
	}

	[Token(Token = "0x6000182")]
	[Address(RVA = "0x4592B0", Offset = "0x457CB0", VA = "0x1804592B0", Slot = "18")]
	public override void NetworkInitializeIfDisabled()
	{
	}

	[Token(Token = "0x6000183")]
	[Address(RVA = "0x4707A0", Offset = "0x46F1A0", VA = "0x1804707A0")]
	private void RpcWriter___Server_CMDUpdateLeaderBoard_1140765316(bool isEndGame)
	{
	}

	[Token(Token = "0x6000184")]
	[Address(RVA = "0x473400", Offset = "0x471E00", VA = "0x180473400")]
	public void RpcLogic___CMDUpdateLeaderBoard_1140765316(bool isEndGame)
	{
	}

	[Token(Token = "0x6000185")]
	[Address(RVA = "0x473E70", Offset = "0x472870", VA = "0x180473E70")]
	private void RpcReader___Server_CMDUpdateLeaderBoard_1140765316(PooledReader PooledReader0, Channel channel, NetworkConnection conn)
	{
	}

	[Token(Token = "0x6000186")]
	[Address(RVA = "0x473F80", Offset = "0x472980", VA = "0x180473F80")]
	private void RpcWriter___Target_UpdateLeaderBoard_2922933245(NetworkConnection target, List<LeaderBoardPlayerData> playerData, bool isEndGame, int homeScore, int awayScore)
	{
	}

	[Token(Token = "0x6000187")]
	[Address(RVA = "0x4741D0", Offset = "0x472BD0", VA = "0x1804741D0")]
	private void RpcLogic___UpdateLeaderBoard_2922933245(NetworkConnection target, List<LeaderBoardPlayerData> playerData, bool isEndGame, int homeScore, int awayScore)
	{
	}

	[Token(Token = "0x6000188")]
	[Address(RVA = "0x4752B0", Offset = "0x473CB0", VA = "0x1804752B0")]
	private void RpcReader___Target_UpdateLeaderBoard_2922933245(PooledReader PooledReader0, Channel channel)
	{
	}

	[Token(Token = "0x6000189")]
	[Address(RVA = "0x4592B0", Offset = "0x457CB0", VA = "0x1804592B0", Slot = "29")]
	public override void Awake()
	{
	}
}

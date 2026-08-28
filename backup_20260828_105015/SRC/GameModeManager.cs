using FishNet.Managing.Scened;
using FishNet.Object;
using FishNet.Object.Synchronizing;
using Il2CppDummyDll;
using UnityEngine;

[Token(Token = "0x20000E9")]
public class GameModeManager : NetworkBehaviour
{
	[Token(Token = "0x40004BD")]
	[FieldOffset(Offset = "0xF8")]
	[HideInInspector]
	public readonly SyncVar<GameMode> gameMode;

	[Token(Token = "0x40004BE")]
	[FieldOffset(Offset = "0x100")]
	[HideInInspector]
	public readonly SyncVar<int> awayScore;

	[Token(Token = "0x40004BF")]
	[FieldOffset(Offset = "0x108")]
	[HideInInspector]
	public readonly SyncVar<int> homeScore;

	[Token(Token = "0x40004C0")]
	[FieldOffset(Offset = "0x110")]
	private bool NetworkInitialize___EarlyGameModeManagerAssembly_002DCSharp_002Edll_Excuted;

	[Token(Token = "0x40004C1")]
	[FieldOffset(Offset = "0x111")]
	private bool NetworkInitialize__LateGameModeManagerAssembly_002DCSharp_002Edll_Excuted;

	[Token(Token = "0x60006F7")]
	[Address(RVA = "0x4E6910", Offset = "0x4E5310", VA = "0x1804E6910", Slot = "10")]
	public override void OnStartServer()
	{
	}

	[Token(Token = "0x60006F8")]
	[Address(RVA = "0x4E6A30", Offset = "0x4E5430", VA = "0x1804E6A30")]
	private void ResetScore(SceneLoadEndEventArgs obj)
	{
	}

	[Token(Token = "0x60006F9")]
	[Address(RVA = "0x4E6AD0", Offset = "0x4E54D0", VA = "0x1804E6AD0")]
	public void TryUpdateTeamScore(bool awayTeam, int score)
	{
	}

	[Token(Token = "0x60006FA")]
	[Address(RVA = "0x4E6BA0", Offset = "0x4E55A0", VA = "0x1804E6BA0")]
	public bool AwayTeamIsWinning()
	{
		return default(bool);
	}

	[Token(Token = "0x60006FB")]
	[Address(RVA = "0x4E6C00", Offset = "0x4E5600", VA = "0x1804E6C00")]
	public GameModeManager()
	{
	}

	[Token(Token = "0x60006FC")]
	[Address(RVA = "0x4E6E70", Offset = "0x4E5870", VA = "0x1804E6E70", Slot = "27")]
	public override void NetworkInitialize___Early()
	{
	}

	[Token(Token = "0x60006FD")]
	[Address(RVA = "0x48BFA0", Offset = "0x48A9A0", VA = "0x18048BFA0", Slot = "28")]
	public override void NetworkInitialize__Late()
	{
	}

	[Token(Token = "0x60006FE")]
	[Address(RVA = "0x4592B0", Offset = "0x457CB0", VA = "0x1804592B0", Slot = "18")]
	public override void NetworkInitializeIfDisabled()
	{
	}

	[Token(Token = "0x60006FF")]
	[Address(RVA = "0x4592B0", Offset = "0x457CB0", VA = "0x1804592B0", Slot = "29")]
	public override void Awake()
	{
	}
}

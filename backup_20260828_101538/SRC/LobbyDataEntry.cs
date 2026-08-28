using System.Collections;
using System.Runtime.CompilerServices;
using Il2CppDummyDll;
using Steamworks;
using TMPro;
using UnityEngine;
using UnityEngine.Localization;

[Token(Token = "0x2000067")]
public class LobbyDataEntry : MonoBehaviour
{
	[Token(Token = "0x4000195")]
	[FieldOffset(Offset = "0x20")]
	public CSteamID lobbyID;

	[Token(Token = "0x4000196")]
	[FieldOffset(Offset = "0x28")]
	public string lobbyName;

	[Token(Token = "0x4000197")]
	[FieldOffset(Offset = "0x30")]
	public string status;

	[Token(Token = "0x4000198")]
	[FieldOffset(Offset = "0x38")]
	public int playersCount;

	[Token(Token = "0x4000199")]
	[FieldOffset(Offset = "0x3C")]
	public int maxPlayersCount;

	[Token(Token = "0x400019A")]
	[FieldOffset(Offset = "0x40")]
	public int ping;

	[Token(Token = "0x400019B")]
	[FieldOffset(Offset = "0x44")]
	public bool containsFriend;

	[Token(Token = "0x400019C")]
	[FieldOffset(Offset = "0x48")]
	public TMP_Text lobbyNameText;

	[Token(Token = "0x400019D")]
	[FieldOffset(Offset = "0x50")]
	public TMP_Text lobbyPlayersText;

	[Token(Token = "0x400019E")]
	[FieldOffset(Offset = "0x58")]
	public TMP_Text gameStatusText;

	[Token(Token = "0x400019F")]
	[FieldOffset(Offset = "0x60")]
	public TMP_Text joinButtonText;

	[Token(Token = "0x40001A0")]
	[FieldOffset(Offset = "0x68")]
	public TMP_Text playersText;

	[Token(Token = "0x40001A1")]
	[FieldOffset(Offset = "0x70")]
	public TMP_Text pingText;

	[Token(Token = "0x40001A2")]
	[FieldOffset(Offset = "0x78")]
	public GameObject containsFriendIcon;

	[Token(Token = "0x40001A3")]
	[FieldOffset(Offset = "0x80")]
	public LocalizedString noNameText;

	[Token(Token = "0x40001A4")]
	[FieldOffset(Offset = "0x88")]
	public LocalizedString unableToFetchStatusText;

	[Token(Token = "0x40001A5")]
	[FieldOffset(Offset = "0x90")]
	public LocalizedString unableToJoinText;

	[Token(Token = "0x40001A6")]
	[FieldOffset(Offset = "0x98")]
	public LocalizedString joinLobbyText;

	[Token(Token = "0x40001A7")]
	[FieldOffset(Offset = "0xA0")]
	public LocalizedString tryToJoinText;

	[Token(Token = "0x40001A8")]
	[FieldOffset(Offset = "0xA8")]
	public LocalizedString inGameText;

	[Token(Token = "0x40001A9")]
	[FieldOffset(Offset = "0xB0")]
	public LocalizedString inLobbyText;

	[Token(Token = "0x40001AA")]
	[FieldOffset(Offset = "0xB8")]
	public LocalizedString msLobbyText;

	[Token(Token = "0x60002A4")]
	[Address(RVA = "0x48CC10", Offset = "0x48B610", VA = "0x18048CC10")]
	public void SetLobbyData()
	{
	}

	[Token(Token = "0x60002A5")]
	[Address(RVA = "0x48CDC0", Offset = "0x48B7C0", VA = "0x18048CDC0")]
	public void JoinLobby()
	{
	}

	[Token(Token = "0x60002A6")]
	[Address(RVA = "0x48CE70", Offset = "0x48B870", VA = "0x18048CE70")]
	[IteratorStateMachine(typeof(_003CActuallyJoinLobby_003Ed__24))]
	private IEnumerator ActuallyJoinLobby()
	{
		return null;
	}

	[Token(Token = "0x60002A7")]
	[Address(RVA = "0x457FB0", Offset = "0x4569B0", VA = "0x180457FB0")]
	public LobbyDataEntry()
	{
	}
}

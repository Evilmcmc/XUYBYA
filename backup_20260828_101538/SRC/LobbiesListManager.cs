using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Il2CppDummyDll;
using Steamworks;
using TMPro;
using UnityEngine;

[Token(Token = "0x2000063")]
public class LobbiesListManager : MonoBehaviour
{
	[Token(Token = "0x4000183")]
	[FieldOffset(Offset = "0x0")]
	public static LobbiesListManager instance;

	[Token(Token = "0x4000184")]
	[FieldOffset(Offset = "0x20")]
	public GameObject lobbyDataItemPrefab;

	[Token(Token = "0x4000185")]
	[FieldOffset(Offset = "0x28")]
	public GameObject lobbyListContent;

	[Token(Token = "0x4000186")]
	[FieldOffset(Offset = "0x30")]
	public GameObject loadingCircle;

	[Token(Token = "0x4000187")]
	[FieldOffset(Offset = "0x38")]
	public GameObject noLobbiesFoundText;

	[Token(Token = "0x4000188")]
	[FieldOffset(Offset = "0x40")]
	public MainMenu mainMenu;

	[Token(Token = "0x4000189")]
	[FieldOffset(Offset = "0x48")]
	public List<GameObject> listOfLobbies;

	[Token(Token = "0x400018A")]
	[FieldOffset(Offset = "0x50")]
	public TMP_InputField searchBar;

	[Token(Token = "0x600027E")]
	[Address(RVA = "0x48A4A0", Offset = "0x488EA0", VA = "0x18048A4A0")]
	private void Awake()
	{
	}

	[Token(Token = "0x600027F")]
	[Address(RVA = "0x48A5F0", Offset = "0x488FF0", VA = "0x18048A5F0")]
	public void GetListOfLobbies()
	{
	}

	[Token(Token = "0x6000280")]
	[Address(RVA = "0x48A700", Offset = "0x489100", VA = "0x18048A700")]
	public void RefreshLobbies()
	{
	}

	[Token(Token = "0x6000281")]
	[Address(RVA = "0x48A7F0", Offset = "0x4891F0", VA = "0x18048A7F0")]
	public void DisplayLobbies(List<LobbyListData> lobbyIDs, LobbyDataUpdate_t result)
	{
	}

	[Token(Token = "0x6000282")]
	[Address(RVA = "0x48B120", Offset = "0x489B20", VA = "0x18048B120")]
	[IteratorStateMachine(typeof(_003CWaitAndRefreshLobbies_003Ed__12))]
	private IEnumerator WaitAndRefreshLobbies()
	{
		return null;
	}

	[Token(Token = "0x6000283")]
	[Address(RVA = "0x48B160", Offset = "0x489B60", VA = "0x18048B160")]
	public void DestroyLobbies()
	{
	}

	[Token(Token = "0x6000284")]
	[Address(RVA = "0x48B350", Offset = "0x489D50", VA = "0x18048B350")]
	public LobbiesListManager()
	{
	}
}

using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using FishNet.Managing;
using FishySteamworks;
using Il2CppDummyDll;
using Steamworks;
using UnityEngine;

[Token(Token = "0x20000D9")]
public class BootstrapManager : MonoBehaviour
{
	[Token(Token = "0x4000476")]
	[FieldOffset(Offset = "0x20")]
	[SerializeField]
	private NetworkManager networkManager;

	[Token(Token = "0x4000477")]
	[FieldOffset(Offset = "0x28")]
	[SerializeField]
	private global::FishySteamworks.FishySteamworks fishySteamworks;

	[Token(Token = "0x4000478")]
	[FieldOffset(Offset = "0x30")]
	[SerializeField]
	private GameObject gameManager;

	[Token(Token = "0x4000479")]
	private const string HostAddressKey = "HostAddress";

	[Token(Token = "0x400047A")]
	[FieldOffset(Offset = "0x38")]
	public ulong CurrentLobbyID;

	[Token(Token = "0x400047B")]
	[FieldOffset(Offset = "0x40")]
	protected Callback<LobbyCreated_t> LobbyCreated;

	[Token(Token = "0x400047C")]
	[FieldOffset(Offset = "0x48")]
	protected Callback<GameLobbyJoinRequested_t> JoinRequest;

	[Token(Token = "0x400047D")]
	[FieldOffset(Offset = "0x50")]
	protected Callback<LobbyEnter_t> LobbyEntered;

	[Token(Token = "0x400047E")]
	[FieldOffset(Offset = "0x58")]
	protected Callback<LobbyKicked_t> LobbyKicked;

	[Token(Token = "0x400047F")]
	[FieldOffset(Offset = "0x60")]
	protected Callback<LobbyMatchList_t> LobbyList;

	[Token(Token = "0x4000480")]
	[FieldOffset(Offset = "0x68")]
	protected Callback<LobbyDataUpdate_t> LobbyDataUpdated;

	[Token(Token = "0x4000481")]
	[FieldOffset(Offset = "0x8")]
	public static List<LobbyListData> lobbyIDs;

	[Token(Token = "0x17000085")]
	public static BootstrapManager Instance
	{
		[Token(Token = "0x6000669")]
		[Address(RVA = "0x4DC530", Offset = "0x4DAF30", VA = "0x1804DC530")]
		[CompilerGenerated]
		get
		{
			return null;
		}
		[Token(Token = "0x600066A")]
		[Address(RVA = "0x4DC590", Offset = "0x4DAF90", VA = "0x1804DC590")]
		[CompilerGenerated]
		private set
		{
		}
	}

	[Token(Token = "0x600066B")]
	[Address(RVA = "0x4DC640", Offset = "0x4DB040", VA = "0x1804DC640")]
	private void Awake()
	{
	}

	[Token(Token = "0x600066C")]
	[Address(RVA = "0x4DC9A0", Offset = "0x4DB3A0", VA = "0x1804DC9A0")]
	private void Start()
	{
	}

	[Token(Token = "0x600066D")]
	[Address(RVA = "0x4DD350", Offset = "0x4DBD50", VA = "0x1804DD350")]
	public void HostLobby(bool privateLobby)
	{
	}

	[Token(Token = "0x600066E")]
	[Address(RVA = "0x4DD4B0", Offset = "0x4DBEB0", VA = "0x1804DD4B0")]
	public void JoinLobby(CSteamID lobbyID)
	{
	}

	[Token(Token = "0x600066F")]
	[Address(RVA = "0x4DD580", Offset = "0x4DBF80", VA = "0x1804DD580")]
	public void LeaveLobby()
	{
	}

	[Token(Token = "0x6000670")]
	[Address(RVA = "0x4DD6E0", Offset = "0x4DC0E0", VA = "0x1804DD6E0")]
	public void GetLobbiesList(string searchBar)
	{
	}

	[Token(Token = "0x6000671")]
	[Address(RVA = "0x4DD930", Offset = "0x4DC330", VA = "0x1804DD930")]
	private void OnLobbyKicked(LobbyKicked_t callback)
	{
	}

	[Token(Token = "0x6000672")]
	[Address(RVA = "0x4DDA30", Offset = "0x4DC430", VA = "0x1804DDA30")]
	private void OnLobbyCreated(LobbyCreated_t callback)
	{
	}

	[Token(Token = "0x6000673")]
	[Address(RVA = "0x4DE7E0", Offset = "0x4DD1E0", VA = "0x1804DE7E0")]
	[IteratorStateMachine(typeof(_003CLoadFirstMap_003Ed__24))]
	private IEnumerator LoadFirstMap(GameMapManager gameMapManager)
	{
		return null;
	}

	[Token(Token = "0x6000674")]
	[Address(RVA = "0x4DE880", Offset = "0x4DD280", VA = "0x1804DE880")]
	private void OnJoinRequest(GameLobbyJoinRequested_t callback)
	{
	}

	[Token(Token = "0x6000675")]
	[Address(RVA = "0x4DE890", Offset = "0x4DD290", VA = "0x1804DE890")]
	private void OnLobbyEntered(LobbyEnter_t callback)
	{
	}

	[Token(Token = "0x6000676")]
	[Address(RVA = "0x4DEB10", Offset = "0x4DD510", VA = "0x1804DEB10")]
	private void OnGetLobbyList(LobbyMatchList_t result)
	{
	}

	[Token(Token = "0x6000677")]
	[Address(RVA = "0x4DEF60", Offset = "0x4DD960", VA = "0x1804DEF60")]
	private void OnGetLobbyData(LobbyDataUpdate_t result)
	{
	}

	[Token(Token = "0x6000678")]
	[Address(RVA = "0x4DF030", Offset = "0x4DDA30", VA = "0x1804DF030")]
	private void SetLobbyMatchSettingsData(CSteamID lobbyID)
	{
	}

	[Token(Token = "0x6000679")]
	[Address(RVA = "0x457FB0", Offset = "0x4569B0", VA = "0x180457FB0")]
	public BootstrapManager()
	{
	}
}

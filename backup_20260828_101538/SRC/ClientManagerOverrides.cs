using FishNet.Connection;
using FishNet.Transporting;
using Il2CppDummyDll;
using Steamworks;
using UnityEngine;

[Token(Token = "0x200001B")]
public class ClientManagerOverrides : MonoBehaviour
{
	[Token(Token = "0x400006D")]
	[FieldOffset(Offset = "0x20")]
	private Callback<SteamNetConnectionStatusChangedCallback_t> _onLocalConnectionStateCallback;

	[Token(Token = "0x6000095")]
	[Address(RVA = "0x45D280", Offset = "0x45BC80", VA = "0x18045D280")]
	public void Start()
	{
	}

	[Token(Token = "0x6000096")]
	[Address(RVA = "0x45D510", Offset = "0x45BF10", VA = "0x18045D510")]
	private void OnLocalConnectionState(SteamNetConnectionStatusChangedCallback_t args)
	{
	}

	[Token(Token = "0x6000097")]
	[Address(RVA = "0x45D590", Offset = "0x45BF90", VA = "0x18045D590")]
	private void ServerManager_OnRemoteConnectionState(NetworkConnection arg1, RemoteConnectionStateArgs arg2)
	{
	}

	[Token(Token = "0x6000098")]
	[Address(RVA = "0x45D690", Offset = "0x45C090", VA = "0x18045D690")]
	public void OnDestroy()
	{
	}

	[Token(Token = "0x6000099")]
	[Address(RVA = "0x45D990", Offset = "0x45C390", VA = "0x18045D990")]
	private void ClientManager_OnConnectedClients(ConnectedClientsArgs obj)
	{
	}

	[Token(Token = "0x600009A")]
	[Address(RVA = "0x45DB30", Offset = "0x45C530", VA = "0x18045DB30")]
	private void ClientManager_OnClientTimeOut()
	{
	}

	[Token(Token = "0x600009B")]
	[Address(RVA = "0x45DB90", Offset = "0x45C590", VA = "0x18045DB90")]
	private void ClientManager_OnClientConnectionState(ClientConnectionStateArgs obj)
	{
	}

	[Token(Token = "0x600009C")]
	[Address(RVA = "0x45DDD0", Offset = "0x45C7D0", VA = "0x18045DDD0")]
	private void ClientManager_OnAuthenticated()
	{
	}

	[Token(Token = "0x600009D")]
	[Address(RVA = "0x457FB0", Offset = "0x4569B0", VA = "0x180457FB0")]
	public ClientManagerOverrides()
	{
	}
}

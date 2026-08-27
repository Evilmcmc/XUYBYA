using System.Collections.Generic;
using FishNet.Connection;
using FishNet.Transporting;
using Il2CppDummyDll;
using Steamworks;
using UnityEngine;

[Token(Token = "0x2000033")]
public class DisconnectedPlayerStats : MonoBehaviour
{
	[Token(Token = "0x2000034")]
	public struct PlayerStatsData
	{
		[Token(Token = "0x400009B")]
		[FieldOffset(Offset = "0x0")]
		public short kills;

		[Token(Token = "0x400009C")]
		[FieldOffset(Offset = "0x2")]
		public short deaths;

		[Token(Token = "0x400009D")]
		[FieldOffset(Offset = "0x4")]
		public short assists;

		[Token(Token = "0x400009E")]
		[FieldOffset(Offset = "0x6")]
		public short distance;

		[Token(Token = "0x600010A")]
		[Address(RVA = "0x4687C0", Offset = "0x4671C0", VA = "0x1804687C0")]
		public PlayerStatsData(short _kills, short _deaths, short _assists, short _distance)
		{
		}
	}

	[Token(Token = "0x400009A")]
	[FieldOffset(Offset = "0x0")]
	public static Dictionary<string, PlayerStatsData> playersWhoHaveLeft;

	[Token(Token = "0x6000103")]
	[Address(RVA = "0x468030", Offset = "0x466A30", VA = "0x180468030")]
	public void Start()
	{
	}

	[Token(Token = "0x6000104")]
	[Address(RVA = "0x468140", Offset = "0x466B40", VA = "0x180468140")]
	public void OnDestroy()
	{
	}

	[Token(Token = "0x6000105")]
	[Address(RVA = "0x468250", Offset = "0x466C50", VA = "0x180468250")]
	private string GetUsernameFromSteamID(CSteamID steamID)
	{
		return null;
	}

	[Token(Token = "0x6000106")]
	[Address(RVA = "0x4682E0", Offset = "0x466CE0", VA = "0x1804682E0")]
	private void ServerManager_OnServerConnectionState(ServerConnectionStateArgs obj)
	{
	}

	[Token(Token = "0x6000107")]
	[Address(RVA = "0x468370", Offset = "0x466D70", VA = "0x180468370")]
	private void ServerManager_OnRemoteConnectionState(NetworkConnection arg1, RemoteConnectionStateArgs arg2)
	{
	}

	[Token(Token = "0x6000108")]
	[Address(RVA = "0x457FB0", Offset = "0x4569B0", VA = "0x180457FB0")]
	public DisconnectedPlayerStats()
	{
	}
}

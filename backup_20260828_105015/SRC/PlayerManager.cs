using System.Collections.Generic;
using System.Runtime.CompilerServices;
using FishNet.Connection;
using Il2CppDummyDll;
using UnityEngine;

[Token(Token = "0x20000F9")]
public class PlayerManager : MonoBehaviour
{
	[Token(Token = "0x4000520")]
	[FieldOffset(Offset = "0x20")]
	[SerializeField]
	private PlayerConnectionObject playerPrefab;

	[Token(Token = "0x4000522")]
	[FieldOffset(Offset = "0x30")]
	[HideInInspector]
	public List<string> bannedIDs;

	[Token(Token = "0x170000A2")]
	public static PlayerManager Instance
	{
		[Token(Token = "0x600078E")]
		[Address(RVA = "0x4EEE10", Offset = "0x4ED810", VA = "0x1804EEE10")]
		[CompilerGenerated]
		get
		{
			return null;
		}
		[Token(Token = "0x600078F")]
		[Address(RVA = "0x4EEE50", Offset = "0x4ED850", VA = "0x1804EEE50")]
		[CompilerGenerated]
		private set
		{
		}
	}

	[Token(Token = "0x170000A3")]
	[HideInInspector]
	public List<PlayerConnectionObject> players
	{
		[Token(Token = "0x6000790")]
		[Address(RVA = "0x48F970", Offset = "0x48E370", VA = "0x18048F970")]
		[CompilerGenerated]
		get
		{
			return null;
		}
	}

	[Token(Token = "0x6000791")]
	[Address(RVA = "0x4EEEF0", Offset = "0x4ED8F0", VA = "0x1804EEEF0")]
	private void Awake()
	{
	}

	[Token(Token = "0x6000792")]
	[Address(RVA = "0x4EF210", Offset = "0x4EDC10", VA = "0x1804EF210")]
	public void OnServerAddPlayer(NetworkConnection conn, bool asServer)
	{
	}

	[Token(Token = "0x6000793")]
	[Address(RVA = "0x4EF590", Offset = "0x4EDF90", VA = "0x1804EF590")]
	private PlayerConnectionObject SpawnNewPlayer(NetworkConnection conn)
	{
		return null;
	}

	[Token(Token = "0x6000794")]
	[Address(RVA = "0x4EF6B0", Offset = "0x4EE0B0", VA = "0x1804EF6B0")]
	public PlayerManager()
	{
	}
}

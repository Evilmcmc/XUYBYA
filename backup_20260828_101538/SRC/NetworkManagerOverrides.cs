using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using FishNet.Connection;
using Il2CppDummyDll;
using UnityEngine;

[Token(Token = "0x2000071")]
public class NetworkManagerOverrides : MonoBehaviour
{
	[Token(Token = "0x40001E8")]
	[FieldOffset(Offset = "0x20")]
	[SerializeField]
	private PlayerConnectionObject playerPrefab;

	[Token(Token = "0x40001EA")]
	[FieldOffset(Offset = "0x30")]
	[HideInInspector]
	public List<string> bannedIDs;

	[Token(Token = "0x40001EB")]
	[FieldOffset(Offset = "0x38")]
	[HideInInspector]
	public ulong customMapFileID;

	[Token(Token = "0x40001EC")]
	[FieldOffset(Offset = "0x40")]
	[HideInInspector]
	public GameMode gamemode;

	[Token(Token = "0x40001ED")]
	[FieldOffset(Offset = "0x44")]
	[HideInInspector]
	public bool disconnectedManually;

	[Token(Token = "0x40001EE")]
	[FieldOffset(Offset = "0x48")]
	[HideInInspector]
	public int redScore;

	[Token(Token = "0x40001EF")]
	[FieldOffset(Offset = "0x4C")]
	[HideInInspector]
	public int blueScore;

	[Token(Token = "0x17000052")]
	public static NetworkManagerOverrides Instance
	{
		[Token(Token = "0x60002D6")]
		[Address(RVA = "0x48F590", Offset = "0x48DF90", VA = "0x18048F590")]
		[CompilerGenerated]
		get
		{
			return null;
		}
		[Token(Token = "0x60002D7")]
		[Address(RVA = "0x48F5D0", Offset = "0x48DFD0", VA = "0x18048F5D0")]
		[CompilerGenerated]
		private set
		{
		}
	}

	[Token(Token = "0x17000053")]
	[HideInInspector]
	public List<PlayerConnectionObject> players
	{
		[Token(Token = "0x60002D9")]
		[Address(RVA = "0x48F970", Offset = "0x48E370", VA = "0x18048F970")]
		[CompilerGenerated]
		get
		{
			return null;
		}
	}

	[Token(Token = "0x14000001")]
	public static event Action<NetworkConnection> OnServerReadied
	{
		[Token(Token = "0x60002DC")]
		[Address(RVA = "0x48F980", Offset = "0x48E380", VA = "0x18048F980")]
		[CompilerGenerated]
		add
		{
		}
		[Token(Token = "0x60002DD")]
		[Address(RVA = "0x48FAC0", Offset = "0x48E4C0", VA = "0x18048FAC0")]
		[CompilerGenerated]
		remove
		{
		}
	}

	[Token(Token = "0x60002D8")]
	[Address(RVA = "0x48F670", Offset = "0x48E070", VA = "0x18048F670")]
	private void Awake()
	{
	}

	[Token(Token = "0x60002DA")]
	[Address(RVA = "0x4576C0", Offset = "0x4560C0", VA = "0x1804576C0")]
	public void OnServerAddPlayer(NetworkConnection conn, bool asServer)
	{
	}

	[Token(Token = "0x60002DB")]
	[Address(RVA = "0x4576C0", Offset = "0x4560C0", VA = "0x1804576C0")]
	private void Start()
	{
	}

	[Token(Token = "0x60002DE")]
	[Address(RVA = "0x48FC00", Offset = "0x48E600", VA = "0x18048FC00")]
	public void StartCustomMapGame(NetworkConnection conn)
	{
	}

	[Token(Token = "0x60002DF")]
	[Address(RVA = "0x4576C0", Offset = "0x4560C0", VA = "0x1804576C0")]
	public void StartGame(string sceneName)
	{
	}

	[Token(Token = "0x60002E0")]
	[Address(RVA = "0x48FCF0", Offset = "0x48E6F0", VA = "0x18048FCF0")]
	public NetworkManagerOverrides()
	{
	}
}

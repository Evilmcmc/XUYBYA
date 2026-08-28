using System.Collections.Generic;
using FishNet.Managing.Scened;
using FishNet.Object;
using FishNet.Object.Synchronizing;
using Il2CppDummyDll;
using UnityEngine;

[Token(Token = "0x20000E8")]
public class GameMapManager : NetworkBehaviour
{
	[Token(Token = "0x40004B7")]
	[FieldOffset(Offset = "0xF8")]
	[HideInInspector]
	public List<MapData> mapPool;

	[Token(Token = "0x40004B8")]
	[FieldOffset(Offset = "0x100")]
	[SerializeField]
	private MapData racingMap;

	[Token(Token = "0x40004B9")]
	[FieldOffset(Offset = "0x108")]
	public readonly SyncVar<ulong> currentSteamFileId;

	[Token(Token = "0x40004BA")]
	[FieldOffset(Offset = "0x110")]
	private int currentMap;

	[Token(Token = "0x40004BB")]
	[FieldOffset(Offset = "0x114")]
	private bool NetworkInitialize___EarlyGameMapManagerAssembly_002DCSharp_002Edll_Excuted;

	[Token(Token = "0x40004BC")]
	[FieldOffset(Offset = "0x115")]
	private bool NetworkInitialize__LateGameMapManagerAssembly_002DCSharp_002Edll_Excuted;

	[Token(Token = "0x60006EA")]
	[Address(RVA = "0x4E5700", Offset = "0x4E4100", VA = "0x1804E5700", Slot = "10")]
	public override void OnStartServer()
	{
	}

	[Token(Token = "0x60006EB")]
	[Address(RVA = "0x4E57B0", Offset = "0x4E41B0", VA = "0x1804E57B0")]
	private void RandomizeMapOrder()
	{
	}

	[Token(Token = "0x60006EC")]
	[Address(RVA = "0x4E5980", Offset = "0x4E4380", VA = "0x1804E5980", Slot = "11")]
	public override void OnStopServer()
	{
	}

	[Token(Token = "0x60006ED")]
	[Address(RVA = "0x4E5A20", Offset = "0x4E4420", VA = "0x1804E5A20")]
	private void OnSceneLoaded(SceneLoadEndEventArgs obj)
	{
	}

	[Token(Token = "0x60006EE")]
	[Address(RVA = "0x4E5AB0", Offset = "0x4E44B0", VA = "0x1804E5AB0")]
	public void LoadNewMap()
	{
	}

	[Token(Token = "0x60006EF")]
	[Address(RVA = "0x4E5B30", Offset = "0x4E4530", VA = "0x1804E5B30")]
	[Server]
	public void LoadRandomMap()
	{
	}

	[Token(Token = "0x60006F0")]
	[Address(RVA = "0x4E6070", Offset = "0x4E4A70", VA = "0x1804E6070")]
	private SceneLoadData GetSceneLoadData(string sceneName)
	{
		return null;
	}

	[Token(Token = "0x60006F1")]
	[Address(RVA = "0x4E6670", Offset = "0x4E5070", VA = "0x1804E6670")]
	private void IncrementMap()
	{
	}

	[Token(Token = "0x60006F2")]
	[Address(RVA = "0x4E66D0", Offset = "0x4E50D0", VA = "0x1804E66D0")]
	public GameMapManager()
	{
	}

	[Token(Token = "0x60006F3")]
	[Address(RVA = "0x4E6880", Offset = "0x4E5280", VA = "0x1804E6880", Slot = "27")]
	public override void NetworkInitialize___Early()
	{
	}

	[Token(Token = "0x60006F4")]
	[Address(RVA = "0x4E68D0", Offset = "0x4E52D0", VA = "0x1804E68D0", Slot = "28")]
	public override void NetworkInitialize__Late()
	{
	}

	[Token(Token = "0x60006F5")]
	[Address(RVA = "0x4592B0", Offset = "0x457CB0", VA = "0x1804592B0", Slot = "18")]
	public override void NetworkInitializeIfDisabled()
	{
	}

	[Token(Token = "0x60006F6")]
	[Address(RVA = "0x4592B0", Offset = "0x457CB0", VA = "0x1804592B0", Slot = "29")]
	public override void Awake()
	{
	}
}

using FishNet.Connection;
using FishNet.Managing.Scened;
using FishNet.Object;
using FishNet.Serializing;
using FishNet.Transporting;
using Il2CppDummyDll;
using LeTai.Asset.TranslucentImage;
using Steamworks;
using UnityEngine;
using UnityEngine.Audio;

[Token(Token = "0x2000049")]
public class GameCustomLevelLoader : NetworkBehaviour
{
	[Token(Token = "0x400010A")]
	[FieldOffset(Offset = "0x0")]
	public static GameObject[] assetLoadRequest;

	[Token(Token = "0x400010B")]
	[FieldOffset(Offset = "0xF8")]
	private Callback<DownloadItemResult_t> downloadItemResult;

	[Token(Token = "0x400010C")]
	[FieldOffset(Offset = "0x8")]
	private static AssetBundle loadedLevel;

	[Token(Token = "0x400010D")]
	[FieldOffset(Offset = "0x10")]
	private static GameObject loadedLevelGameObject;

	[Token(Token = "0x400010E")]
	[FieldOffset(Offset = "0x100")]
	[SerializeField]
	private BlurConfig blurConfig;

	[Token(Token = "0x400010F")]
	[FieldOffset(Offset = "0x108")]
	[SerializeField]
	private GameObject cameraPrefab;

	[Token(Token = "0x4000110")]
	[FieldOffset(Offset = "0x110")]
	[SerializeField]
	private AudioMixerGroup musicMixerGroup;

	[Token(Token = "0x4000111")]
	[FieldOffset(Offset = "0x118")]
	[SerializeField]
	private AudioMixerGroup sfxMixerGroup;

	[Token(Token = "0x4000112")]
	[FieldOffset(Offset = "0x120")]
	private bool NetworkInitialize___EarlyGameCustomLevelLoaderAssembly_002DCSharp_002Edll_Excuted;

	[Token(Token = "0x4000113")]
	[FieldOffset(Offset = "0x121")]
	private bool NetworkInitialize__LateGameCustomLevelLoaderAssembly_002DCSharp_002Edll_Excuted;

	[Token(Token = "0x60001B7")]
	[Address(RVA = "0x479760", Offset = "0x478160", VA = "0x180479760", Slot = "10")]
	public override void OnStartServer()
	{
	}

	[Token(Token = "0x60001B8")]
	[Address(RVA = "0x479800", Offset = "0x478200", VA = "0x180479800", Slot = "11")]
	public override void OnStopServer()
	{
	}

	[Token(Token = "0x60001B9")]
	[Address(RVA = "0x4798A0", Offset = "0x4782A0", VA = "0x1804798A0")]
	private void OnClientPresenceChangeEnd(ClientPresenceChangeEventArgs args)
	{
	}

	[Token(Token = "0x60001BA")]
	[Address(RVA = "0x479AF0", Offset = "0x4784F0", VA = "0x180479AF0")]
	[TargetRpc]
	public void Old_ClientSpawnGameObjects(NetworkConnection target)
	{
	}

	[Token(Token = "0x60001BB")]
	[Address(RVA = "0x479C60", Offset = "0x478660", VA = "0x180479C60")]
	private void Old_SpawnGameObjects()
	{
	}

	[Token(Token = "0x60001BC")]
	[Address(RVA = "0x47A590", Offset = "0x478F90", VA = "0x18047A590")]
	[ServerRpc(RequireOwnership = false)]
	private void NotifyServerOfDownload(NetworkConnection connection)
	{
	}

	[Token(Token = "0x60001BD")]
	[Address(RVA = "0x47A740", Offset = "0x479140", VA = "0x18047A740")]
	[TargetRpc]
	public void New_ClientInitializeUGC(NetworkConnection target)
	{
	}

	[Token(Token = "0x60001BE")]
	[Address(RVA = "0x47A8B0", Offset = "0x4792B0", VA = "0x18047A8B0")]
	private void TryInitializeMusic(GameObject gameObject)
	{
	}

	[Token(Token = "0x60001BF")]
	[Address(RVA = "0x47ABD0", Offset = "0x4795D0", VA = "0x18047ABD0")]
	private void TryInitializeCamera(GameObject gameObject)
	{
	}

	[Token(Token = "0x60001C0")]
	[Address(RVA = "0x47B020", Offset = "0x479A20", VA = "0x18047B020")]
	private void TryInitializeWeaponSpawn(GameObject gameObject)
	{
	}

	[Token(Token = "0x60001C1")]
	[Address(RVA = "0x47B1A0", Offset = "0x479BA0", VA = "0x18047B1A0")]
	private void TryInitializePlayerSpawn(GameObject gameObject)
	{
	}

	[Token(Token = "0x60001C2")]
	[Address(RVA = "0x47B310", Offset = "0x479D10", VA = "0x18047B310")]
	private void TryInitializeBarrel(GameObject gameObject, string barrelType)
	{
	}

	[Token(Token = "0x60001C3")]
	[Address(RVA = "0x464E10", Offset = "0x463810", VA = "0x180464E10")]
	public GameCustomLevelLoader()
	{
	}

	[Token(Token = "0x60001C4")]
	[Address(RVA = "0x47B4B0", Offset = "0x479EB0", VA = "0x18047B4B0", Slot = "27")]
	public override void NetworkInitialize___Early()
	{
	}

	[Token(Token = "0x60001C5")]
	[Address(RVA = "0x47B5F0", Offset = "0x479FF0", VA = "0x18047B5F0", Slot = "28")]
	public override void NetworkInitialize__Late()
	{
	}

	[Token(Token = "0x60001C6")]
	[Address(RVA = "0x4592B0", Offset = "0x457CB0", VA = "0x1804592B0", Slot = "18")]
	public override void NetworkInitializeIfDisabled()
	{
	}

	[Token(Token = "0x60001C7")]
	[Address(RVA = "0x479AF0", Offset = "0x4784F0", VA = "0x180479AF0")]
	private void RpcWriter___Target_Old_ClientSpawnGameObjects_328543758(NetworkConnection target)
	{
	}

	[Token(Token = "0x60001C8")]
	[Address(RVA = "0x47B610", Offset = "0x47A010", VA = "0x18047B610")]
	public void RpcLogic___Old_ClientSpawnGameObjects_328543758(NetworkConnection target)
	{
	}

	[Token(Token = "0x60001C9")]
	[Address(RVA = "0x47B620", Offset = "0x47A020", VA = "0x18047B620")]
	private void RpcReader___Target_Old_ClientSpawnGameObjects_328543758(PooledReader PooledReader0, Channel channel)
	{
	}

	[Token(Token = "0x60001CA")]
	[Address(RVA = "0x47A590", Offset = "0x478F90", VA = "0x18047A590")]
	private void RpcWriter___Server_NotifyServerOfDownload_328543758(NetworkConnection connection)
	{
	}

	[Token(Token = "0x60001CB")]
	[Address(RVA = "0x47B660", Offset = "0x47A060", VA = "0x18047B660")]
	private void RpcLogic___NotifyServerOfDownload_328543758(NetworkConnection connection)
	{
	}

	[Token(Token = "0x60001CC")]
	[Address(RVA = "0x47B710", Offset = "0x47A110", VA = "0x18047B710")]
	private void RpcReader___Server_NotifyServerOfDownload_328543758(PooledReader PooledReader0, Channel channel, NetworkConnection conn)
	{
	}

	[Token(Token = "0x60001CD")]
	[Address(RVA = "0x47A740", Offset = "0x479140", VA = "0x18047A740")]
	private void RpcWriter___Target_New_ClientInitializeUGC_328543758(NetworkConnection target)
	{
	}

	[Token(Token = "0x60001CE")]
	[Address(RVA = "0x47B800", Offset = "0x47A200", VA = "0x18047B800")]
	public void RpcLogic___New_ClientInitializeUGC_328543758(NetworkConnection target)
	{
	}

	[Token(Token = "0x60001CF")]
	[Address(RVA = "0x47BDB0", Offset = "0x47A7B0", VA = "0x18047BDB0")]
	private void RpcReader___Target_New_ClientInitializeUGC_328543758(PooledReader PooledReader0, Channel channel)
	{
	}

	[Token(Token = "0x60001D0")]
	[Address(RVA = "0x4592B0", Offset = "0x457CB0", VA = "0x1804592B0", Slot = "29")]
	public override void Awake()
	{
	}
}

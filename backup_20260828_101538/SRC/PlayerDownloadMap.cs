using FishNet.Connection;
using FishNet.Managing.Scened;
using FishNet.Object;
using FishNet.Serializing;
using FishNet.Transporting;
using Il2CppDummyDll;

[Token(Token = "0x20000F5")]
public class PlayerDownloadMap : NetworkBehaviour
{
	[Token(Token = "0x4000515")]
	[FieldOffset(Offset = "0xF8")]
	private bool NetworkInitialize___EarlyPlayerDownloadMapAssembly_002DCSharp_002Edll_Excuted;

	[Token(Token = "0x4000516")]
	[FieldOffset(Offset = "0xF9")]
	private bool NetworkInitialize__LatePlayerDownloadMapAssembly_002DCSharp_002Edll_Excuted;

	[Token(Token = "0x6000767")]
	[Address(RVA = "0x4EDCE0", Offset = "0x4EC6E0", VA = "0x1804EDCE0")]
	private void SceneManager_OnLoadEnd(SceneLoadEndEventArgs obj)
	{
	}

	[Token(Token = "0x6000768")]
	[Address(RVA = "0x4EDD90", Offset = "0x4EC790", VA = "0x1804EDD90")]
	[Server]
	public void StartDownloadCustomMap(ulong fileID)
	{
	}

	[Token(Token = "0x6000769")]
	[Address(RVA = "0x4EDF80", Offset = "0x4EC980", VA = "0x1804EDF80")]
	[TargetRpc]
	private void DownloadCustomMap(NetworkConnection target, ulong fileID)
	{
	}

	[Token(Token = "0x600076A")]
	[Address(RVA = "0x4EE100", Offset = "0x4ECB00", VA = "0x1804EE100")]
	public void DownloadComplete()
	{
	}

	[Token(Token = "0x600076B")]
	[Address(RVA = "0x4EE100", Offset = "0x4ECB00", VA = "0x1804EE100")]
	[ServerRpc]
	private void CMDDownloadComplete()
	{
	}

	[Token(Token = "0x600076C")]
	[Address(RVA = "0x464E10", Offset = "0x463810", VA = "0x180464E10")]
	public PlayerDownloadMap()
	{
	}

	[Token(Token = "0x600076D")]
	[Address(RVA = "0x4EE2B0", Offset = "0x4ECCB0", VA = "0x1804EE2B0", Slot = "27")]
	public override void NetworkInitialize___Early()
	{
	}

	[Token(Token = "0x600076E")]
	[Address(RVA = "0x46BB80", Offset = "0x46A580", VA = "0x18046BB80", Slot = "28")]
	public override void NetworkInitialize__Late()
	{
	}

	[Token(Token = "0x600076F")]
	[Address(RVA = "0x4592B0", Offset = "0x457CB0", VA = "0x1804592B0", Slot = "18")]
	public override void NetworkInitializeIfDisabled()
	{
	}

	[Token(Token = "0x6000770")]
	[Address(RVA = "0x4EDF80", Offset = "0x4EC980", VA = "0x1804EDF80")]
	private void RpcWriter___Target_DownloadCustomMap_302673671(NetworkConnection target, ulong fileID)
	{
	}

	[Token(Token = "0x6000771")]
	[Address(RVA = "0x4EE3A0", Offset = "0x4ECDA0", VA = "0x1804EE3A0")]
	private void RpcLogic___DownloadCustomMap_302673671(NetworkConnection target, ulong fileID)
	{
	}

	[Token(Token = "0x6000772")]
	[Address(RVA = "0x4EE510", Offset = "0x4ECF10", VA = "0x1804EE510")]
	private void RpcReader___Target_DownloadCustomMap_302673671(PooledReader PooledReader0, Channel channel)
	{
	}

	[Token(Token = "0x6000773")]
	[Address(RVA = "0x4EE100", Offset = "0x4ECB00", VA = "0x1804EE100")]
	private void RpcWriter___Server_CMDDownloadComplete_2166136261()
	{
	}

	[Token(Token = "0x6000774")]
	[Address(RVA = "0x4576C0", Offset = "0x4560C0", VA = "0x1804576C0")]
	private void RpcLogic___CMDDownloadComplete_2166136261()
	{
	}

	[Token(Token = "0x6000775")]
	[Address(RVA = "0x4EE6B0", Offset = "0x4ED0B0", VA = "0x1804EE6B0")]
	private void RpcReader___Server_CMDDownloadComplete_2166136261(PooledReader PooledReader0, Channel channel, NetworkConnection conn)
	{
	}

	[Token(Token = "0x6000776")]
	[Address(RVA = "0x4592B0", Offset = "0x457CB0", VA = "0x1804592B0", Slot = "29")]
	public override void Awake()
	{
	}
}

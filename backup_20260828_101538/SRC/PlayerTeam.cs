using FishNet.Connection;
using FishNet.Managing.Scened;
using FishNet.Object;
using FishNet.Object.Synchronizing;
using FishNet.Serializing;
using FishNet.Transporting;
using Il2CppDummyDll;

[Token(Token = "0x20000FC")]
public class PlayerTeam : NetworkBehaviour
{
	[Token(Token = "0x400052D")]
	[FieldOffset(Offset = "0xF8")]
	public readonly SyncVar<bool> awayTeam;

	[Token(Token = "0x400052E")]
	[FieldOffset(Offset = "0x100")]
	private bool NetworkInitialize___EarlyPlayerTeamAssembly_002DCSharp_002Edll_Excuted;

	[Token(Token = "0x400052F")]
	[FieldOffset(Offset = "0x101")]
	private bool NetworkInitialize__LatePlayerTeamAssembly_002DCSharp_002Edll_Excuted;

	[Token(Token = "0x60007A8")]
	[Address(RVA = "0x4F0A30", Offset = "0x4EF430", VA = "0x1804F0A30", Slot = "10")]
	public override void OnStartServer()
	{
	}

	[Token(Token = "0x60007A9")]
	[Address(RVA = "0x4F0AE0", Offset = "0x4EF4E0", VA = "0x1804F0AE0", Slot = "11")]
	public override void OnStopServer()
	{
	}

	[Token(Token = "0x60007AA")]
	[Address(RVA = "0x4F0B80", Offset = "0x4EF580", VA = "0x1804F0B80")]
	[Server]
	private void NewMatchStarted(SceneLoadEndEventArgs obj)
	{
	}

	[Token(Token = "0x60007AB")]
	[Address(RVA = "0x4F0C90", Offset = "0x4EF690", VA = "0x1804F0C90")]
	[Server]
	private void AssignSmallestTeam()
	{
	}

	[Token(Token = "0x60007AC")]
	[Address(RVA = "0x4F0EF0", Offset = "0x4EF8F0", VA = "0x1804F0EF0")]
	public bool IsOnSmallestTeam()
	{
		return default(bool);
	}

	[Token(Token = "0x60007AD")]
	[Address(RVA = "0x4F1070", Offset = "0x4EFA70", VA = "0x1804F1070")]
	public string GetSmallestTeam()
	{
		return null;
	}

	[Token(Token = "0x60007AE")]
	[Address(RVA = "0x4F1990", Offset = "0x4F0390", VA = "0x1804F1990")]
	[Client]
	public void SwapTeams()
	{
	}

	[Token(Token = "0x60007AF")]
	[Address(RVA = "0x4F1B80", Offset = "0x4F0580", VA = "0x1804F1B80")]
	[ServerRpc]
	public void ServerSwapTeams()
	{
	}

	[Token(Token = "0x60007B0")]
	[Address(RVA = "0x4F1D30", Offset = "0x4F0730", VA = "0x1804F1D30")]
	public PlayerTeam()
	{
	}

	[Token(Token = "0x60007B1")]
	[Address(RVA = "0x4F1E20", Offset = "0x4F0820", VA = "0x1804F1E20", Slot = "27")]
	public override void NetworkInitialize___Early()
	{
	}

	[Token(Token = "0x60007B2")]
	[Address(RVA = "0x484B80", Offset = "0x483580", VA = "0x180484B80", Slot = "28")]
	public override void NetworkInitialize__Late()
	{
	}

	[Token(Token = "0x60007B3")]
	[Address(RVA = "0x4592B0", Offset = "0x457CB0", VA = "0x1804592B0", Slot = "18")]
	public override void NetworkInitializeIfDisabled()
	{
	}

	[Token(Token = "0x60007B4")]
	[Address(RVA = "0x4F1B80", Offset = "0x4F0580", VA = "0x1804F1B80")]
	private void RpcWriter___Server_ServerSwapTeams_2166136261()
	{
	}

	[Token(Token = "0x60007B5")]
	[Address(RVA = "0x4F1EE0", Offset = "0x4F08E0", VA = "0x1804F1EE0")]
	public void RpcLogic___ServerSwapTeams_2166136261()
	{
	}

	[Token(Token = "0x60007B6")]
	[Address(RVA = "0x4F2650", Offset = "0x4F1050", VA = "0x1804F2650")]
	private void RpcReader___Server_ServerSwapTeams_2166136261(PooledReader PooledReader0, Channel channel, NetworkConnection conn)
	{
	}

	[Token(Token = "0x60007B7")]
	[Address(RVA = "0x4592B0", Offset = "0x457CB0", VA = "0x1804592B0", Slot = "29")]
	public override void Awake()
	{
	}
}

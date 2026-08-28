using FishNet.Connection;
using FishNet.Object;
using FishNet.Serializing;
using FishNet.Transporting;
using Il2CppDummyDll;

[Token(Token = "0x2000040")]
public class PlayerKillAndDeathEvents : NetworkBehaviour
{
	[Token(Token = "0x40000C5")]
	[FieldOffset(Offset = "0xF8")]
	private bool NetworkInitialize___EarlyPlayerKillAndDeathEventsAssembly_002DCSharp_002Edll_Excuted;

	[Token(Token = "0x40000C6")]
	[FieldOffset(Offset = "0xF9")]
	private bool NetworkInitialize__LatePlayerKillAndDeathEventsAssembly_002DCSharp_002Edll_Excuted;

	[Token(Token = "0x6000155")]
	[Address(RVA = "0x46D450", Offset = "0x46BE50", VA = "0x18046D450")]
	[Server]
	public void InvokeAssistEvent(int killingID, int dyingID)
	{
	}

	[Token(Token = "0x6000156")]
	[Address(RVA = "0x46D4F0", Offset = "0x46BEF0", VA = "0x18046D4F0")]
	[Server]
	public void InvokeKillandDeathEvent(int killingID, int dyingID, int bounty)
	{
	}

	[Token(Token = "0x6000157")]
	[Address(RVA = "0x46D940", Offset = "0x46C340", VA = "0x18046D940")]
	[ObserversRpc]
	private void AssistEvent(int killingIndex, int dyingIndex)
	{
	}

	[Token(Token = "0x6000158")]
	[Address(RVA = "0x46D950", Offset = "0x46C350", VA = "0x18046D950")]
	[ObserversRpc]
	private void KillandDeathEvent(int killingIndex, int dyingIndex, int bounty)
	{
	}

	[Token(Token = "0x6000159")]
	[Address(RVA = "0x46D960", Offset = "0x46C360", VA = "0x18046D960")]
	[TargetRpc]
	public void RPCStartEnableBounty(NetworkConnection target)
	{
	}

	[Token(Token = "0x600015A")]
	[Address(RVA = "0x464E10", Offset = "0x463810", VA = "0x180464E10")]
	public PlayerKillAndDeathEvents()
	{
	}

	[Token(Token = "0x600015B")]
	[Address(RVA = "0x46DAD0", Offset = "0x46C4D0", VA = "0x18046DAD0", Slot = "27")]
	public override void NetworkInitialize___Early()
	{
	}

	[Token(Token = "0x600015C")]
	[Address(RVA = "0x46BB80", Offset = "0x46A580", VA = "0x18046BB80", Slot = "28")]
	public override void NetworkInitialize__Late()
	{
	}

	[Token(Token = "0x600015D")]
	[Address(RVA = "0x4592B0", Offset = "0x457CB0", VA = "0x1804592B0", Slot = "18")]
	public override void NetworkInitializeIfDisabled()
	{
	}

	[Token(Token = "0x600015E")]
	[Address(RVA = "0x46DC00", Offset = "0x46C600", VA = "0x18046DC00")]
	private void RpcWriter___Observers_AssistEvent_1692629761(int killingIndex, int dyingIndex)
	{
	}

	[Token(Token = "0x600015F")]
	[Address(RVA = "0x46DDB0", Offset = "0x46C7B0", VA = "0x18046DDB0")]
	private void RpcLogic___AssistEvent_1692629761(int killingIndex, int dyingIndex)
	{
	}

	[Token(Token = "0x6000160")]
	[Address(RVA = "0x46E1F0", Offset = "0x46CBF0", VA = "0x18046E1F0")]
	private void RpcReader___Observers_AssistEvent_1692629761(PooledReader PooledReader0, Channel channel)
	{
	}

	[Token(Token = "0x6000161")]
	[Address(RVA = "0x46E290", Offset = "0x46CC90", VA = "0x18046E290")]
	private void RpcWriter___Observers_KillandDeathEvent_1805552400(int killingIndex, int dyingIndex, int bounty)
	{
	}

	[Token(Token = "0x6000162")]
	[Address(RVA = "0x46E460", Offset = "0x46CE60", VA = "0x18046E460")]
	private void RpcLogic___KillandDeathEvent_1805552400(int killingIndex, int dyingIndex, int bounty)
	{
	}

	[Token(Token = "0x6000163")]
	[Address(RVA = "0x46E780", Offset = "0x46D180", VA = "0x18046E780")]
	private void RpcReader___Observers_KillandDeathEvent_1805552400(PooledReader PooledReader0, Channel channel)
	{
	}

	[Token(Token = "0x6000164")]
	[Address(RVA = "0x46D960", Offset = "0x46C360", VA = "0x18046D960")]
	private void RpcWriter___Target_RPCStartEnableBounty_328543758(NetworkConnection target)
	{
	}

	[Token(Token = "0x6000165")]
	[Address(RVA = "0x46E860", Offset = "0x46D260", VA = "0x18046E860")]
	public void RpcLogic___RPCStartEnableBounty_328543758(NetworkConnection target)
	{
	}

	[Token(Token = "0x6000166")]
	[Address(RVA = "0x46EA20", Offset = "0x46D420", VA = "0x18046EA20")]
	private void RpcReader___Target_RPCStartEnableBounty_328543758(PooledReader PooledReader0, Channel channel)
	{
	}

	[Token(Token = "0x6000167")]
	[Address(RVA = "0x4592B0", Offset = "0x457CB0", VA = "0x1804592B0", Slot = "29")]
	public override void Awake()
	{
	}
}

using System.Collections;
using System.Runtime.CompilerServices;
using FishNet.Connection;
using FishNet.Object;
using FishNet.Serializing;
using FishNet.Transporting;
using Il2CppDummyDll;
using TMPro;
using UnityEngine;

[Token(Token = "0x20000EA")]
public class GameTimer : NetworkBehaviour
{
	[Token(Token = "0x40004C2")]
	[FieldOffset(Offset = "0xF8")]
	[SerializeField]
	private TMP_Text uiTimer;

	[Token(Token = "0x40004C3")]
	[FieldOffset(Offset = "0x100")]
	[SerializeField]
	private AudioSource clockTick;

	[Token(Token = "0x40004C4")]
	[FieldOffset(Offset = "0x108")]
	[SerializeField]
	private UIRotate uiRotate;

	[Token(Token = "0x40004C5")]
	[FieldOffset(Offset = "0x110")]
	[HideInInspector]
	public int matchLength;

	[Token(Token = "0x40004C6")]
	[FieldOffset(Offset = "0x114")]
	[HideInInspector]
	public int currentMatchTime;

	[Token(Token = "0x40004C7")]
	[FieldOffset(Offset = "0x118")]
	private bool NetworkInitialize___EarlyGameTimerAssembly_002DCSharp_002Edll_Excuted;

	[Token(Token = "0x40004C8")]
	[FieldOffset(Offset = "0x119")]
	private bool NetworkInitialize__LateGameTimerAssembly_002DCSharp_002Edll_Excuted;

	[Token(Token = "0x6000700")]
	[Address(RVA = "0x4E6F10", Offset = "0x4E5910", VA = "0x1804E6F10", Slot = "10")]
	public override void OnStartServer()
	{
	}

	[Token(Token = "0x6000701")]
	[Address(RVA = "0x4E7020", Offset = "0x4E5A20", VA = "0x1804E7020", Slot = "11")]
	public override void OnStopServer()
	{
	}

	[Token(Token = "0x6000702")]
	[Address(RVA = "0x4E7200", Offset = "0x4E5C00", VA = "0x1804E7200")]
	[Server]
	public void SceneManager_OnQueueEnd()
	{
	}

	[Token(Token = "0x6000703")]
	[Address(RVA = "0x4E7470", Offset = "0x4E5E70", VA = "0x1804E7470")]
	[Server]
	private void SceneManager_OnClientLoadedStartScenes(NetworkConnection connection, bool asServer)
	{
	}

	[Token(Token = "0x6000704")]
	[Address(RVA = "0x4E7720", Offset = "0x4E6120", VA = "0x1804E7720")]
	[IteratorStateMachine(typeof(_003CDelaySetTimerActive_003Ed__9))]
	[Server]
	private IEnumerator DelaySetTimerActive(NetworkConnection connection)
	{
		return null;
	}

	[Token(Token = "0x6000705")]
	[Address(RVA = "0x4E7880", Offset = "0x4E6280", VA = "0x1804E7880")]
	[IteratorStateMachine(typeof(_003CTimer_003Ed__10))]
	[Server]
	private IEnumerator Timer()
	{
		return null;
	}

	[Token(Token = "0x6000706")]
	[Address(RVA = "0x4E7970", Offset = "0x4E6370", VA = "0x1804E7970")]
	[Server]
	public void SetTimerActive(bool active)
	{
	}

	[Token(Token = "0x6000707")]
	[Address(RVA = "0x4E7B60", Offset = "0x4E6560", VA = "0x1804E7B60")]
	[ObserversRpc]
	public void RefreshTimerUI(int _currentMatchTime)
	{
	}

	[Token(Token = "0x6000708")]
	[Address(RVA = "0x4E7CF0", Offset = "0x4E66F0", VA = "0x1804E7CF0")]
	[ObserversRpc]
	public void ClientSetTimerActive(bool active)
	{
	}

	[Token(Token = "0x6000709")]
	[Address(RVA = "0x4E7E70", Offset = "0x4E6870", VA = "0x1804E7E70")]
	[TargetRpc]
	public void LateClientSetTimerActive(NetworkConnection target)
	{
	}

	[Token(Token = "0x600070A")]
	[Address(RVA = "0x464E10", Offset = "0x463810", VA = "0x180464E10")]
	public GameTimer()
	{
	}

	[Token(Token = "0x600070B")]
	[Address(RVA = "0x4E7FE0", Offset = "0x4E69E0", VA = "0x1804E7FE0", Slot = "27")]
	public override void NetworkInitialize___Early()
	{
	}

	[Token(Token = "0x600070C")]
	[Address(RVA = "0x47D2C0", Offset = "0x47BCC0", VA = "0x18047D2C0", Slot = "28")]
	public override void NetworkInitialize__Late()
	{
	}

	[Token(Token = "0x600070D")]
	[Address(RVA = "0x4592B0", Offset = "0x457CB0", VA = "0x1804592B0", Slot = "18")]
	public override void NetworkInitializeIfDisabled()
	{
	}

	[Token(Token = "0x600070E")]
	[Address(RVA = "0x4E7B60", Offset = "0x4E6560", VA = "0x1804E7B60")]
	private void RpcWriter___Observers_RefreshTimerUI_3316948804(int _currentMatchTime)
	{
	}

	[Token(Token = "0x600070F")]
	[Address(RVA = "0x4E8110", Offset = "0x4E6B10", VA = "0x1804E8110")]
	public void RpcLogic___RefreshTimerUI_3316948804(int _currentMatchTime)
	{
	}

	[Token(Token = "0x6000710")]
	[Address(RVA = "0x4E84D0", Offset = "0x4E6ED0", VA = "0x1804E84D0")]
	private void RpcReader___Observers_RefreshTimerUI_3316948804(PooledReader PooledReader0, Channel channel)
	{
	}

	[Token(Token = "0x6000711")]
	[Address(RVA = "0x4E7CF0", Offset = "0x4E66F0", VA = "0x1804E7CF0")]
	private void RpcWriter___Observers_ClientSetTimerActive_1140765316(bool active)
	{
	}

	[Token(Token = "0x6000712")]
	[Address(RVA = "0x4E8530", Offset = "0x4E6F30", VA = "0x1804E8530")]
	public void RpcLogic___ClientSetTimerActive_1140765316(bool active)
	{
	}

	[Token(Token = "0x6000713")]
	[Address(RVA = "0x4E8570", Offset = "0x4E6F70", VA = "0x1804E8570")]
	private void RpcReader___Observers_ClientSetTimerActive_1140765316(PooledReader PooledReader0, Channel channel)
	{
	}

	[Token(Token = "0x6000714")]
	[Address(RVA = "0x4E7E70", Offset = "0x4E6870", VA = "0x1804E7E70")]
	private void RpcWriter___Target_LateClientSetTimerActive_328543758(NetworkConnection target)
	{
	}

	[Token(Token = "0x6000715")]
	[Address(RVA = "0x4E85F0", Offset = "0x4E6FF0", VA = "0x1804E85F0")]
	public void RpcLogic___LateClientSetTimerActive_328543758(NetworkConnection target)
	{
	}

	[Token(Token = "0x6000716")]
	[Address(RVA = "0x4E8630", Offset = "0x4E7030", VA = "0x1804E8630")]
	private void RpcReader___Target_LateClientSetTimerActive_328543758(PooledReader PooledReader0, Channel channel)
	{
	}

	[Token(Token = "0x6000717")]
	[Address(RVA = "0x4592B0", Offset = "0x457CB0", VA = "0x1804592B0", Slot = "29")]
	public override void Awake()
	{
	}
}

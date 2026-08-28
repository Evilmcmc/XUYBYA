using System.Collections;
using System.Runtime.CompilerServices;
using FishNet.Connection;
using FishNet.Object;
using FishNet.Object.Synchronizing;
using FishNet.Serializing;
using FishNet.Transporting;
using Il2CppDummyDll;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

[Token(Token = "0x2000087")]
public class Health : NetworkBehaviour
{
	[Token(Token = "0x4000270")]
	[FieldOffset(Offset = "0xF8")]
	[SerializeField]
	public int maxHealth;

	[Token(Token = "0x4000271")]
	[FieldOffset(Offset = "0x100")]
	[HideInInspector]
	public readonly SyncVar<int> currentHealth;

	[Token(Token = "0x4000272")]
	[FieldOffset(Offset = "0x108")]
	[Header("Health Basr")]
	[SerializeField]
	private TMP_Text myUIHealthText;

	[Token(Token = "0x4000273")]
	[FieldOffset(Offset = "0x110")]
	[SerializeField]
	private Transform displayedUIHealthBar;

	[Token(Token = "0x4000274")]
	[FieldOffset(Offset = "0x118")]
	[SerializeField]
	private Volume damgedVolume;

	[Token(Token = "0x4000275")]
	[FieldOffset(Offset = "0x120")]
	[SerializeField]
	private AudioSource heartbeatAudio;

	[Token(Token = "0x4000276")]
	[FieldOffset(Offset = "0x128")]
	private float healthRatio;

	[Token(Token = "0x4000277")]
	[FieldOffset(Offset = "0x12C")]
	[Header("TDM")]
	[SerializeField]
	public Color redTeamHealthBarColor;

	[Token(Token = "0x4000278")]
	[FieldOffset(Offset = "0x13C")]
	[SerializeField]
	public Color blueTeamHealthBarColor;

	[Token(Token = "0x4000279")]
	[FieldOffset(Offset = "0x150")]
	[SerializeField]
	public Image displayedHealthBarColor;

	[Token(Token = "0x400027A")]
	[FieldOffset(Offset = "0x158")]
	private Image displayedHealthBarImage;

	[Token(Token = "0x400027B")]
	[FieldOffset(Offset = "0x160")]
	[Header("Effects")]
	[SerializeField]
	private GameObject HUD;

	[Token(Token = "0x400027C")]
	[FieldOffset(Offset = "0x168")]
	private bool NetworkInitialize___EarlyHealthAssembly_002DCSharp_002Edll_Excuted;

	[Token(Token = "0x400027D")]
	[FieldOffset(Offset = "0x169")]
	private bool NetworkInitialize__LateHealthAssembly_002DCSharp_002Edll_Excuted;

	[Token(Token = "0x600037F")]
	[Address(RVA = "0x4A1DB0", Offset = "0x4A07B0", VA = "0x1804A1DB0", Slot = "7")]
	public override void OnStartNetwork()
	{
	}

	[Token(Token = "0x6000380")]
	[Address(RVA = "0x4A1E60", Offset = "0x4A0860", VA = "0x1804A1E60", Slot = "9")]
	public override void OnStopNetwork()
	{
	}

	[Token(Token = "0x6000381")]
	[Address(RVA = "0x4A1F10", Offset = "0x4A0910", VA = "0x1804A1F10", Slot = "10")]
	public override void OnStartServer()
	{
	}

	[Token(Token = "0x6000382")]
	[Address(RVA = "0x4A1FC0", Offset = "0x4A09C0", VA = "0x1804A1FC0", Slot = "11")]
	public override void OnStopServer()
	{
	}

	[Token(Token = "0x6000383")]
	[Address(RVA = "0x4A2070", Offset = "0x4A0A70", VA = "0x1804A2070")]
	[Server]
	private void ServerUpdateHealthBar(NetworkConnection connnection, bool asServer)
	{
	}

	[Token(Token = "0x6000384")]
	[Address(RVA = "0x4A2260", Offset = "0x4A0C60", VA = "0x1804A2260")]
	[TargetRpc]
	private void RPCUpdateHealthBar(NetworkConnection target, int health)
	{
	}

	[Token(Token = "0x6000385")]
	[Address(RVA = "0x4A23F0", Offset = "0x4A0DF0", VA = "0x1804A23F0", Slot = "15")]
	public override void OnStartClient()
	{
	}

	[Token(Token = "0x6000386")]
	[Address(RVA = "0x4A2570", Offset = "0x4A0F70", VA = "0x1804A2570")]
	[TargetRpc]
	public void RefreshHealthBarColor(NetworkConnection target)
	{
	}

	[Token(Token = "0x6000387")]
	[Address(RVA = "0x4A26E0", Offset = "0x4A10E0", VA = "0x1804A26E0")]
	[IteratorStateMachine(typeof(_003CSetUpHealthBarColor_003Ed__20))]
	private IEnumerator SetUpHealthBarColor()
	{
		return null;
	}

	[Token(Token = "0x6000388")]
	[Address(RVA = "0x4A2780", Offset = "0x4A1180", VA = "0x1804A2780")]
	[ServerRpc]
	private void CMDChangeCurrentHealth(int health)
	{
	}

	[Token(Token = "0x6000389")]
	[Address(RVA = "0x4A2790", Offset = "0x4A1190", VA = "0x1804A2790")]
	[Server]
	public void ServerChangeCurrentHealth(int health)
	{
	}

	[Token(Token = "0x600038A")]
	[Address(RVA = "0x4A2850", Offset = "0x4A1250", VA = "0x1804A2850")]
	public void ChangeCurrentHealth(int oldValue, int newValue, bool asServer)
	{
	}

	[Token(Token = "0x600038B")]
	[Address(RVA = "0x4A2CD0", Offset = "0x4A16D0", VA = "0x1804A2CD0")]
	public bool IsDead()
	{
		return default(bool);
	}

	[Token(Token = "0x600038C")]
	[Address(RVA = "0x4A2D20", Offset = "0x4A1720", VA = "0x1804A2D20")]
	public int GetCurrentHealth()
	{
		return default(int);
	}

	[Token(Token = "0x600038D")]
	[Address(RVA = "0x4A2D70", Offset = "0x4A1770", VA = "0x1804A2D70")]
	public Health()
	{
	}

	[Token(Token = "0x600038E")]
	[Address(RVA = "0x4A2E70", Offset = "0x4A1870", VA = "0x1804A2E70", Slot = "27")]
	public override void NetworkInitialize___Early()
	{
	}

	[Token(Token = "0x600038F")]
	[Address(RVA = "0x4A2FE0", Offset = "0x4A19E0", VA = "0x1804A2FE0", Slot = "28")]
	public override void NetworkInitialize__Late()
	{
	}

	[Token(Token = "0x6000390")]
	[Address(RVA = "0x4592B0", Offset = "0x457CB0", VA = "0x1804592B0", Slot = "18")]
	public override void NetworkInitializeIfDisabled()
	{
	}

	[Token(Token = "0x6000391")]
	[Address(RVA = "0x4A2260", Offset = "0x4A0C60", VA = "0x1804A2260")]
	private void RpcWriter___Target_RPCUpdateHealthBar_2681120339(NetworkConnection target, int health)
	{
	}

	[Token(Token = "0x6000392")]
	[Address(RVA = "0x4A3020", Offset = "0x4A1A20", VA = "0x1804A3020")]
	private void RpcLogic___RPCUpdateHealthBar_2681120339(NetworkConnection target, int health)
	{
	}

	[Token(Token = "0x6000393")]
	[Address(RVA = "0x4A3170", Offset = "0x4A1B70", VA = "0x1804A3170")]
	private void RpcReader___Target_RPCUpdateHealthBar_2681120339(PooledReader PooledReader0, Channel channel)
	{
	}

	[Token(Token = "0x6000394")]
	[Address(RVA = "0x4A2570", Offset = "0x4A0F70", VA = "0x1804A2570")]
	private void RpcWriter___Target_RefreshHealthBarColor_328543758(NetworkConnection target)
	{
	}

	[Token(Token = "0x6000395")]
	[Address(RVA = "0x4A3310", Offset = "0x4A1D10", VA = "0x1804A3310")]
	public void RpcLogic___RefreshHealthBarColor_328543758(NetworkConnection target)
	{
	}

	[Token(Token = "0x6000396")]
	[Address(RVA = "0x4A3340", Offset = "0x4A1D40", VA = "0x1804A3340")]
	private void RpcReader___Target_RefreshHealthBarColor_328543758(PooledReader PooledReader0, Channel channel)
	{
	}

	[Token(Token = "0x6000397")]
	[Address(RVA = "0x4A3390", Offset = "0x4A1D90", VA = "0x1804A3390")]
	private void RpcWriter___Server_CMDChangeCurrentHealth_3316948804(int health)
	{
	}

	[Token(Token = "0x6000398")]
	[Address(RVA = "0x4A3560", Offset = "0x4A1F60", VA = "0x1804A3560")]
	private void RpcLogic___CMDChangeCurrentHealth_3316948804(int health)
	{
	}

	[Token(Token = "0x6000399")]
	[Address(RVA = "0x4A35D0", Offset = "0x4A1FD0", VA = "0x1804A35D0")]
	private void RpcReader___Server_CMDChangeCurrentHealth_3316948804(PooledReader PooledReader0, Channel channel, NetworkConnection conn)
	{
	}

	[Token(Token = "0x600039A")]
	[Address(RVA = "0x4592B0", Offset = "0x457CB0", VA = "0x1804592B0", Slot = "29")]
	public override void Awake()
	{
	}
}

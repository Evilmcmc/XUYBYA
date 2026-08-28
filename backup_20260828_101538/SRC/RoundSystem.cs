using System.Collections.Generic;
using System.Runtime.CompilerServices;
using FishNet.Object;
using Il2CppDummyDll;
using TMPro;
using UnityEngine;
using UnityEngine.Localization;

[Token(Token = "0x2000070")]
public class RoundSystem : NetworkBehaviour
{
	[Token(Token = "0x40001D6")]
	[FieldOffset(Offset = "0xF8")]
	public int matchLength;

	[Token(Token = "0x40001D7")]
	[FieldOffset(Offset = "0x100")]
	[SerializeField]
	private TMP_Text uiTimer;

	[Token(Token = "0x40001D8")]
	[FieldOffset(Offset = "0x108")]
	[SerializeField]
	private Transform uiLeaderBoard;

	[Token(Token = "0x40001D9")]
	[FieldOffset(Offset = "0x110")]
	[SerializeField]
	private Transform uiEndgame;

	[Token(Token = "0x40001DA")]
	[FieldOffset(Offset = "0x118")]
	[Header("Countdown")]
	[SerializeField]
	private int duration;

	[Token(Token = "0x40001DB")]
	[FieldOffset(Offset = "0x11C")]
	[SerializeField]
	private float tweenTime;

	[Token(Token = "0x40001DC")]
	[FieldOffset(Offset = "0x120")]
	[SerializeField]
	private TMP_Text countdownText;

	[Token(Token = "0x40001DD")]
	[FieldOffset(Offset = "0x128")]
	[SerializeField]
	private LocalizedString fightText;

	[Token(Token = "0x40001DE")]
	[FieldOffset(Offset = "0x130")]
	private int currentMatchTime;

	[Token(Token = "0x40001DF")]
	[FieldOffset(Offset = "0x134")]
	[HideInInspector]
	public int myPlayerArrayIndex;

	[Token(Token = "0x40001E0")]
	[FieldOffset(Offset = "0x138")]
	[HideInInspector]
	public List<GameObject> playerGameObjectList;

	[Token(Token = "0x40001E1")]
	[FieldOffset(Offset = "0x140")]
	[Header("KillFeed")]
	public GameObject KillPopUpPrefab;

	[Token(Token = "0x40001E2")]
	[FieldOffset(Offset = "0x148")]
	public RectTransform KillFeed;

	[Token(Token = "0x40001E3")]
	[FieldOffset(Offset = "0x150")]
	[Header("Effects")]
	[SerializeField]
	private AudioSource CDnumberAudio;

	[Token(Token = "0x40001E4")]
	[FieldOffset(Offset = "0x158")]
	[SerializeField]
	private AudioSource CDtextAudio;

	[Token(Token = "0x40001E5")]
	[FieldOffset(Offset = "0x160")]
	private bool NetworkInitialize___EarlyRoundSystemAssembly_002DCSharp_002Edll_Excuted;

	[Token(Token = "0x40001E6")]
	[FieldOffset(Offset = "0x161")]
	private bool NetworkInitialize__LateRoundSystemAssembly_002DCSharp_002Edll_Excuted;

	[Token(Token = "0x17000051")]
	public static RoundSystem Instance
	{
		[Token(Token = "0x60002CE")]
		[Address(RVA = "0x48F130", Offset = "0x48DB30", VA = "0x18048F130")]
		[CompilerGenerated]
		get
		{
			return null;
		}
		[Token(Token = "0x60002CF")]
		[Address(RVA = "0x48F170", Offset = "0x48DB70", VA = "0x18048F170")]
		[CompilerGenerated]
		private set
		{
		}
	}

	[Token(Token = "0x60002D0")]
	[Address(RVA = "0x48F210", Offset = "0x48DC10", VA = "0x18048F210", Slot = "27")]
	public override void Awake()
	{
	}

	[Token(Token = "0x60002D1")]
	[Address(RVA = "0x464E10", Offset = "0x463810", VA = "0x180464E10")]
	public RoundSystem()
	{
	}

	[Token(Token = "0x60002D2")]
	[Address(RVA = "0x48F250", Offset = "0x48DC50", VA = "0x18048F250", Slot = "28")]
	public override void NetworkInitialize___Early()
	{
	}

	[Token(Token = "0x60002D3")]
	[Address(RVA = "0x48F270", Offset = "0x48DC70", VA = "0x18048F270", Slot = "29")]
	public override void NetworkInitialize__Late()
	{
	}

	[Token(Token = "0x60002D4")]
	[Address(RVA = "0x469C90", Offset = "0x468690", VA = "0x180469C90", Slot = "18")]
	public override void NetworkInitializeIfDisabled()
	{
	}

	[Token(Token = "0x60002D5")]
	[Address(RVA = "0x48F290", Offset = "0x48DC90", VA = "0x18048F290")]
	private void Awake_UserLogic_RoundSystem_Assembly_002DCSharp_002Edll()
	{
	}
}

using System.Collections;
using System.Runtime.CompilerServices;
using FishNet.Object;
using Il2CppDummyDll;
using TMPro;
using UnityEngine;
using UnityEngine.Localization;

[Token(Token = "0x2000041")]
public class PlayerKillPopUp : NetworkBehaviour
{
	[Token(Token = "0x40000C7")]
	[FieldOffset(Offset = "0xF8")]
	[SerializeField]
	private GameObject killPopUp;

	[Token(Token = "0x40000C8")]
	[FieldOffset(Offset = "0x100")]
	[SerializeField]
	private GameObject pointPopUp;

	[Token(Token = "0x40000C9")]
	[FieldOffset(Offset = "0x108")]
	private GameObject popUpRoot;

	[Token(Token = "0x40000CA")]
	[FieldOffset(Offset = "0x110")]
	[SerializeField]
	private LocalizedString[] killPopupTexts;

	[Token(Token = "0x40000CB")]
	[FieldOffset(Offset = "0x118")]
	[SerializeField]
	private LocalizedString assistPopupText;

	[Token(Token = "0x40000CC")]
	[FieldOffset(Offset = "0x120")]
	[SerializeField]
	private LocalizedString bountyCollectedText;

	[Token(Token = "0x40000CD")]
	[FieldOffset(Offset = "0x128")]
	[SerializeField]
	private AudioSource BountySFX;

	[Token(Token = "0x40000CE")]
	[FieldOffset(Offset = "0x130")]
	[SerializeField]
	private AudioSource PopUpSFX;

	[Token(Token = "0x40000CF")]
	[FieldOffset(Offset = "0x138")]
	[SerializeField]
	private float popUpDuration;

	[Token(Token = "0x40000D0")]
	[FieldOffset(Offset = "0x140")]
	private TMP_Text killText;

	[Token(Token = "0x40000D1")]
	[FieldOffset(Offset = "0x148")]
	private TMP_Text pointText;

	[Token(Token = "0x40000D2")]
	[FieldOffset(Offset = "0x150")]
	private bool NetworkInitialize___EarlyPlayerKillPopUpAssembly_002DCSharp_002Edll_Excuted;

	[Token(Token = "0x40000D3")]
	[FieldOffset(Offset = "0x151")]
	private bool NetworkInitialize__LatePlayerKillPopUpAssembly_002DCSharp_002Edll_Excuted;

	[Token(Token = "0x6000168")]
	[Address(RVA = "0x46EA70", Offset = "0x46D470", VA = "0x18046EA70", Slot = "15")]
	public override void OnStartClient()
	{
	}

	[Token(Token = "0x6000169")]
	[Address(RVA = "0x46EC60", Offset = "0x46D660", VA = "0x18046EC60")]
	public void PopUp(bool isAssist, string usernameOfKilled, int bounty)
	{
	}

	[Token(Token = "0x600016A")]
	[Address(RVA = "0x46FFB0", Offset = "0x46E9B0", VA = "0x18046FFB0")]
	private void TryCameraShake()
	{
	}

	[Token(Token = "0x600016B")]
	[Address(RVA = "0x470160", Offset = "0x46EB60", VA = "0x180470160")]
	[IteratorStateMachine(typeof(_003CClosePopup_003Ed__14))]
	private IEnumerator ClosePopup()
	{
		return null;
	}

	[Token(Token = "0x600016C")]
	[Address(RVA = "0x464E10", Offset = "0x463810", VA = "0x180464E10")]
	public PlayerKillPopUp()
	{
	}

	[Token(Token = "0x600016D")]
	[Address(RVA = "0x470200", Offset = "0x46EC00", VA = "0x180470200", Slot = "27")]
	public override void NetworkInitialize___Early()
	{
	}

	[Token(Token = "0x600016E")]
	[Address(RVA = "0x470220", Offset = "0x46EC20", VA = "0x180470220", Slot = "28")]
	public override void NetworkInitialize__Late()
	{
	}

	[Token(Token = "0x600016F")]
	[Address(RVA = "0x4592B0", Offset = "0x457CB0", VA = "0x1804592B0", Slot = "18")]
	public override void NetworkInitializeIfDisabled()
	{
	}

	[Token(Token = "0x6000170")]
	[Address(RVA = "0x4592B0", Offset = "0x457CB0", VA = "0x1804592B0", Slot = "29")]
	public override void Awake()
	{
	}
}

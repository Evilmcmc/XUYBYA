using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Il2CppDummyDll;
using TMPro;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.UI;

[Token(Token = "0x20000ED")]
public class HostMatchSettings : MonoBehaviour
{
	[Token(Token = "0x40004D1")]
	[FieldOffset(Offset = "0x20")]
	[Header("Match Length")]
	[SerializeField]
	private List<int> matchLengthOptions;

	[Token(Token = "0x40004D2")]
	[FieldOffset(Offset = "0x28")]
	[SerializeField]
	private int matchLengthIndex;

	[Token(Token = "0x40004D3")]
	[FieldOffset(Offset = "0x30")]
	[SerializeField]
	private TMP_Text matchLengthLabel;

	[Token(Token = "0x40004D4")]
	[FieldOffset(Offset = "0x38")]
	[SerializeField]
	private LocalizedString matchLengthText;

	[Token(Token = "0x40004D5")]
	[FieldOffset(Offset = "0x40")]
	[HideInInspector]
	public int matchLength;

	[Token(Token = "0x40004D6")]
	[FieldOffset(Offset = "0x48")]
	[Header("Game Mode")]
	[SerializeField]
	private TMP_Text gamemodeLabel;

	[Token(Token = "0x40004D7")]
	[FieldOffset(Offset = "0x50")]
	[SerializeField]
	private GameObject gunToggleParent;

	[Token(Token = "0x40004D8")]
	[FieldOffset(Offset = "0x58")]
	[SerializeField]
	private GameObject nextButton;

	[Token(Token = "0x40004D9")]
	[FieldOffset(Offset = "0x60")]
	[SerializeField]
	private GameObject earlyHostButton;

	[Token(Token = "0x40004DA")]
	[FieldOffset(Offset = "0x68")]
	[SerializeField]
	private GameObject matchLengthButton;

	[Token(Token = "0x40004DB")]
	[FieldOffset(Offset = "0x70")]
	[SerializeField]
	private LocalizedString gamemodeText;

	[Token(Token = "0x40004DC")]
	[FieldOffset(Offset = "0x78")]
	[SerializeField]
	private LocalizedString[] gamemodeNames;

	[Token(Token = "0x40004DD")]
	[FieldOffset(Offset = "0x80")]
	public int gameMode;

	[Token(Token = "0x40004DE")]
	[FieldOffset(Offset = "0x88")]
	[Header("Barrels")]
	[SerializeField]
	private TMP_Text barrelsLabel;

	[Token(Token = "0x40004DF")]
	[FieldOffset(Offset = "0x90")]
	[SerializeField]
	private LocalizedString barrelsText;

	[Token(Token = "0x40004E0")]
	[FieldOffset(Offset = "0x98")]
	[SerializeField]
	private LocalizedString noneText;

	[Token(Token = "0x40004E1")]
	[FieldOffset(Offset = "0xA0")]
	[SerializeField]
	private LocalizedString aFewText;

	[Token(Token = "0x40004E2")]
	[FieldOffset(Offset = "0xA8")]
	[SerializeField]
	private LocalizedString aLotText;

	[Token(Token = "0x40004E3")]
	[FieldOffset(Offset = "0xB0")]
	[SerializeField]
	private LocalizedString tooManyText;

	[Token(Token = "0x40004E4")]
	[FieldOffset(Offset = "0xB8")]
	public int barrels;

	[Token(Token = "0x40004E5")]
	[FieldOffset(Offset = "0xC0")]
	[Header("Visibility")]
	[SerializeField]
	private TMP_Text visibilityLabel;

	[Token(Token = "0x40004E6")]
	[FieldOffset(Offset = "0xC8")]
	[SerializeField]
	private LocalizedString visibilityText;

	[Token(Token = "0x40004E7")]
	[FieldOffset(Offset = "0xD0")]
	[SerializeField]
	private LocalizedString privateText;

	[Token(Token = "0x40004E8")]
	[FieldOffset(Offset = "0xD8")]
	[SerializeField]
	private LocalizedString publicText;

	[Token(Token = "0x40004E9")]
	[FieldOffset(Offset = "0xE0")]
	[HideInInspector]
	public bool privateLobby;

	[Token(Token = "0x40004EA")]
	[FieldOffset(Offset = "0xE8")]
	[Header("Weapon Toggles")]
	public Toggle shotgunToggle;

	[Token(Token = "0x40004EB")]
	[FieldOffset(Offset = "0xF0")]
	public Toggle pistolToggle;

	[Token(Token = "0x40004EC")]
	[FieldOffset(Offset = "0xF8")]
	public Toggle minigunToggle;

	[Token(Token = "0x40004ED")]
	[FieldOffset(Offset = "0x100")]
	public Toggle rpgToggle;

	[Token(Token = "0x40004EE")]
	[FieldOffset(Offset = "0x108")]
	public Toggle crossbowToggle;

	[Token(Token = "0x40004EF")]
	[FieldOffset(Offset = "0x110")]
	public Toggle macheteToggle;

	[Token(Token = "0x40004F0")]
	[FieldOffset(Offset = "0x118")]
	public Toggle railgunToggle;

	[Token(Token = "0x40004F1")]
	[FieldOffset(Offset = "0x120")]
	public Toggle burstToggle;

	[Token(Token = "0x40004F2")]
	[FieldOffset(Offset = "0x128")]
	public Toggle sniperToggle;

	[Token(Token = "0x40004F3")]
	[FieldOffset(Offset = "0x130")]
	[Header("Map Pool")]
	[SerializeField]
	private Transform mapPoolParent;

	[Token(Token = "0x40004F4")]
	[FieldOffset(Offset = "0x138")]
	[SerializeField]
	private Transform workshopMapPoolParent;

	[Token(Token = "0x40004F5")]
	[FieldOffset(Offset = "0x140")]
	[SerializeField]
	private Transform workshopMapPoolParent2;

	[Token(Token = "0x1700009D")]
	public static HostMatchSettings Instance
	{
		[Token(Token = "0x6000724")]
		[Address(RVA = "0x4E8BF0", Offset = "0x4E75F0", VA = "0x1804E8BF0")]
		[CompilerGenerated]
		get
		{
			return null;
		}
		[Token(Token = "0x6000725")]
		[Address(RVA = "0x4E8C30", Offset = "0x4E7630", VA = "0x1804E8C30")]
		[CompilerGenerated]
		private set
		{
		}
	}

	[Token(Token = "0x6000726")]
	[Address(RVA = "0x4E8CD0", Offset = "0x4E76D0", VA = "0x1804E8CD0")]
	private void Awake()
	{
	}

	[Token(Token = "0x6000727")]
	[Address(RVA = "0x4E8FD0", Offset = "0x4E79D0", VA = "0x1804E8FD0")]
	public void GetMatchSettings()
	{
	}

	[Token(Token = "0x6000728")]
	[Address(RVA = "0x4E9360", Offset = "0x4E7D60", VA = "0x1804E9360")]
	public List<MapData> GetMapPool()
	{
		return null;
	}

	[Token(Token = "0x6000729")]
	[Address(RVA = "0x4E9AD0", Offset = "0x4E84D0", VA = "0x1804E9AD0")]
	public List<int> GetSpawnableWeapons()
	{
		return null;
	}

	[Token(Token = "0x600072A")]
	[Address(RVA = "0x4E9F80", Offset = "0x4E8980", VA = "0x1804E9F80")]
	public void NextMatchLength()
	{
	}

	[Token(Token = "0x600072B")]
	[Address(RVA = "0x4EA0A0", Offset = "0x4E8AA0", VA = "0x1804EA0A0")]
	public void PreviousGameMode()
	{
	}

	[Token(Token = "0x600072C")]
	[Address(RVA = "0x4EA350", Offset = "0x4E8D50", VA = "0x1804EA350")]
	public void NextGameMode()
	{
	}

	[Token(Token = "0x600072D")]
	[Address(RVA = "0x4EA620", Offset = "0x4E9020", VA = "0x1804EA620")]
	public void NextBarrelsType()
	{
	}

	[Token(Token = "0x600072E")]
	[Address(RVA = "0x4EA8B0", Offset = "0x4E92B0", VA = "0x1804EA8B0")]
	public void NextVisibility()
	{
	}

	[Token(Token = "0x600072F")]
	[Address(RVA = "0x457FB0", Offset = "0x4569B0", VA = "0x180457FB0")]
	public HostMatchSettings()
	{
	}
}

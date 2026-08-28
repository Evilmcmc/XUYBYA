using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Il2CppDummyDll;
using Steamworks;
using TMPro;
using UnityEngine;
using UnityEngine.Localization;

[Token(Token = "0x2000018")]
public class CharacterCustomization : MonoBehaviour
{
	[Serializable]
	[Token(Token = "0x2000019")]
	public struct PlayerColor
	{
		[Token(Token = "0x4000065")]
		[FieldOffset(Offset = "0x0")]
		public Material mat;

		[Token(Token = "0x4000066")]
		[FieldOffset(Offset = "0x8")]
		public LocalizedString colorName;
	}

	[Token(Token = "0x400004F")]
	[FieldOffset(Offset = "0x20")]
	[Header("General Refrences")]
	[SerializeField]
	private List<PlayerColor> playerColors;

	[Token(Token = "0x4000050")]
	[FieldOffset(Offset = "0x28")]
	[SerializeField]
	private CosmeticPack[] cosmeticPacks;

	[Token(Token = "0x4000051")]
	[FieldOffset(Offset = "0x30")]
	[SerializeField]
	private GameObject hatDLCButton;

	[Token(Token = "0x4000052")]
	[FieldOffset(Offset = "0x38")]
	[SerializeField]
	private GameObject bodyDLCButton;

	[Token(Token = "0x4000053")]
	[FieldOffset(Offset = "0x40")]
	[SerializeField]
	private Color ownedDLCTextColor;

	[Token(Token = "0x4000054")]
	[FieldOffset(Offset = "0x50")]
	[SerializeField]
	private Color unownedDLCTextColor;

	[Token(Token = "0x4000055")]
	[FieldOffset(Offset = "0x60")]
	[SerializeField]
	private AudioSource buttonSound;

	[Token(Token = "0x4000056")]
	[FieldOffset(Offset = "0x68")]
	[Header("Localized Text")]
	[SerializeField]
	private LocalizedString colorLabelText;

	[Token(Token = "0x4000057")]
	[FieldOffset(Offset = "0x70")]
	[SerializeField]
	private LocalizedString hatLabelText;

	[Token(Token = "0x4000058")]
	[FieldOffset(Offset = "0x78")]
	[SerializeField]
	private LocalizedString bodyLabelText;

	[Token(Token = "0x4000059")]
	[FieldOffset(Offset = "0x80")]
	[Header("Labels")]
	[SerializeField]
	private TMP_Text colorLabel;

	[Token(Token = "0x400005A")]
	[FieldOffset(Offset = "0x88")]
	[SerializeField]
	private TMP_Text hatLabel;

	[Token(Token = "0x400005B")]
	[FieldOffset(Offset = "0x90")]
	[SerializeField]
	private TMP_Text bodyLabel;

	[Token(Token = "0x400005C")]
	[FieldOffset(Offset = "0x98")]
	[Header("Player Stuff")]
	[SerializeField]
	private Transform hatParent;

	[Token(Token = "0x400005D")]
	[FieldOffset(Offset = "0xA0")]
	[SerializeField]
	private SkinnedMeshRenderer bodyMesh;

	[Token(Token = "0x400005E")]
	[FieldOffset(Offset = "0xA8")]
	[SerializeField]
	private MeshRenderer headMesh;

	[Token(Token = "0x400005F")]
	[FieldOffset(Offset = "0xB0")]
	private List<HatCosmetic> hats;

	[Token(Token = "0x4000060")]
	[FieldOffset(Offset = "0xB8")]
	private List<PlayerCosmetic> bodies;

	[Token(Token = "0x4000061")]
	[FieldOffset(Offset = "0xC0")]
	private List<CosmeticPack> owned_DLC;

	[Token(Token = "0x4000062")]
	[FieldOffset(Offset = "0xC8")]
	private int currentMat;

	[Token(Token = "0x4000063")]
	[FieldOffset(Offset = "0xCC")]
	private int currentHat;

	[Token(Token = "0x4000064")]
	[FieldOffset(Offset = "0xD0")]
	private int currentBody;

	[Token(Token = "0x6000079")]
	[Address(RVA = "0x45A0F0", Offset = "0x458AF0", VA = "0x18045A0F0")]
	private void OnEnable()
	{
	}

	[Token(Token = "0x600007A")]
	[Address(RVA = "0x45A170", Offset = "0x458B70", VA = "0x18045A170")]
	private void OnDisable()
	{
	}

	[Token(Token = "0x600007B")]
	[Address(RVA = "0x45A230", Offset = "0x458C30", VA = "0x18045A230")]
	private void OnLocaleChanged(UnityEngine.Localization.Locale newLocale)
	{
	}

	[Token(Token = "0x600007C")]
	[Address(RVA = "0x45A260", Offset = "0x458C60", VA = "0x18045A260")]
	public void Awake()
	{
	}

	[Token(Token = "0x600007D")]
	[Address(RVA = "0x45AB10", Offset = "0x459510", VA = "0x18045AB10")]
	private bool OwnsDLC(int dlcAppID)
	{
		return default(bool);
	}

	[Token(Token = "0x600007E")]
	[Address(RVA = "0x45AB20", Offset = "0x459520", VA = "0x18045AB20")]
	private void InitializeColor()
	{
	}

	[Token(Token = "0x600007F")]
	[Address(RVA = "0x45AB80", Offset = "0x459580", VA = "0x18045AB80")]
	public void NextColor()
	{
	}

	[Token(Token = "0x6000080")]
	[Address(RVA = "0x45AC00", Offset = "0x459600", VA = "0x18045AC00")]
	public void PreviousColor()
	{
	}

	[Token(Token = "0x6000081")]
	[Address(RVA = "0x45AC70", Offset = "0x459670", VA = "0x18045AC70")]
	private void UpdateColor()
	{
	}

	[Token(Token = "0x6000082")]
	[Address(RVA = "0x45B380", Offset = "0x459D80", VA = "0x18045B380")]
	private void InitializeHat()
	{
	}

	[Token(Token = "0x6000083")]
	[Address(RVA = "0x45B550", Offset = "0x459F50", VA = "0x18045B550")]
	public void NextHat()
	{
	}

	[Token(Token = "0x6000084")]
	[Address(RVA = "0x45B5D0", Offset = "0x459FD0", VA = "0x18045B5D0")]
	public void PreviousHat()
	{
	}

	[Token(Token = "0x6000085")]
	[Address(RVA = "0x45B650", Offset = "0x45A050", VA = "0x18045B650")]
	private void UpdateHat()
	{
	}

	[Token(Token = "0x6000086")]
	[Address(RVA = "0x45C2E0", Offset = "0x45ACE0", VA = "0x18045C2E0")]
	public bool OwnsHat()
	{
		return default(bool);
	}

	[Token(Token = "0x6000087")]
	[Address(RVA = "0x45C390", Offset = "0x45AD90", VA = "0x18045C390")]
	private void InitializeBody()
	{
	}

	[Token(Token = "0x6000088")]
	[Address(RVA = "0x45C570", Offset = "0x45AF70", VA = "0x18045C570")]
	public void NextBody()
	{
	}

	[Token(Token = "0x6000089")]
	[Address(RVA = "0x45C600", Offset = "0x45B000", VA = "0x18045C600")]
	public void PreviousBody()
	{
	}

	[Token(Token = "0x600008A")]
	[Address(RVA = "0x45C680", Offset = "0x45B080", VA = "0x18045C680")]
	private void UpdateBody()
	{
	}

	[Token(Token = "0x600008B")]
	[Address(RVA = "0x45CCB0", Offset = "0x45B6B0", VA = "0x18045CCB0")]
	public bool OwnsBody()
	{
		return default(bool);
	}

	[Token(Token = "0x600008C")]
	[Address(RVA = "0x45CD60", Offset = "0x45B760", VA = "0x18045CD60")]
	public void StartTryUpdateOwnedDLC(AppId_t appID)
	{
	}

	[Token(Token = "0x600008D")]
	[Address(RVA = "0x45CEB0", Offset = "0x45B8B0", VA = "0x18045CEB0")]
	[IteratorStateMachine(typeof(_003CTryUpdateOwnedDLC_003Ed__43))]
	private IEnumerator TryUpdateOwnedDLC(AppId_t appID)
	{
		return null;
	}

	[Token(Token = "0x600008E")]
	[Address(RVA = "0x457FB0", Offset = "0x4569B0", VA = "0x180457FB0")]
	public CharacterCustomization()
	{
	}
}

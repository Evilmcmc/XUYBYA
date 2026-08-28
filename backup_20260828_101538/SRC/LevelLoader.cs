using System.Collections;
using System.Runtime.CompilerServices;
using Il2CppDummyDll;
using TMPro;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.UI;

[Token(Token = "0x20000CC")]
public class LevelLoader : MonoBehaviour
{
	[Token(Token = "0x4000441")]
	[FieldOffset(Offset = "0x20")]
	[SerializeField]
	private Image blockLeft;

	[Token(Token = "0x4000442")]
	[FieldOffset(Offset = "0x28")]
	[SerializeField]
	private Image blockRight;

	[Token(Token = "0x4000443")]
	[FieldOffset(Offset = "0x30")]
	[SerializeField]
	private Image centerImage;

	[Token(Token = "0x4000444")]
	[FieldOffset(Offset = "0x38")]
	[SerializeField]
	private Image fadeInPanel;

	[Token(Token = "0x4000445")]
	[FieldOffset(Offset = "0x40")]
	[SerializeField]
	private AudioSource exitSFX;

	[Token(Token = "0x4000446")]
	[FieldOffset(Offset = "0x48")]
	[SerializeField]
	private AudioSource enterSFX;

	[Token(Token = "0x4000447")]
	[FieldOffset(Offset = "0x50")]
	[SerializeField]
	private GameObject loadingScreen;

	[Token(Token = "0x4000448")]
	[FieldOffset(Offset = "0x58")]
	[SerializeField]
	private GameObject loadingWheel;

	[Token(Token = "0x4000449")]
	[FieldOffset(Offset = "0x60")]
	[SerializeField]
	private TMP_Text loadingScreenText;

	[Token(Token = "0x400044A")]
	[FieldOffset(Offset = "0x68")]
	[SerializeField]
	private TMP_Text loadingScreenInfoText;

	[Token(Token = "0x400044B")]
	[FieldOffset(Offset = "0x70")]
	[SerializeField]
	private LocalizedString defaultLoadingInfoText;

	[Token(Token = "0x400044C")]
	[FieldOffset(Offset = "0x78")]
	[SerializeField]
	private LocalizedString downloadingLoadingInfoText;

	[Token(Token = "0x1700007D")]
	public static LevelLoader instance
	{
		[Token(Token = "0x600062A")]
		[Address(RVA = "0x4D8430", Offset = "0x4D6E30", VA = "0x1804D8430")]
		[CompilerGenerated]
		get
		{
			return null;
		}
		[Token(Token = "0x600062B")]
		[Address(RVA = "0x4D8470", Offset = "0x4D6E70", VA = "0x1804D8470")]
		[CompilerGenerated]
		private set
		{
		}
	}

	[Token(Token = "0x600062C")]
	[Address(RVA = "0x4D8510", Offset = "0x4D6F10", VA = "0x1804D8510")]
	private void Awake()
	{
	}

	[Token(Token = "0x600062D")]
	[Address(RVA = "0x4D8820", Offset = "0x4D7220", VA = "0x1804D8820")]
	public void InitLoadingTextForDownload()
	{
	}

	[Token(Token = "0x600062E")]
	[Address(RVA = "0x4D8870", Offset = "0x4D7270", VA = "0x1804D8870")]
	public void InitLoadingTextDefault()
	{
	}

	[Token(Token = "0x600062F")]
	[Address(RVA = "0x4D88C0", Offset = "0x4D72C0", VA = "0x1804D88C0")]
	public void Disconnect()
	{
	}

	[Token(Token = "0x6000630")]
	[Address(RVA = "0x4D8A80", Offset = "0x4D7480", VA = "0x1804D8A80")]
	[IteratorStateMachine(typeof(_003COpenBlocks_003Ed__20))]
	public IEnumerator OpenBlocks()
	{
		return null;
	}

	[Token(Token = "0x6000631")]
	[Address(RVA = "0x4D8B20", Offset = "0x4D7520", VA = "0x1804D8B20")]
	[IteratorStateMachine(typeof(_003CCloseBlocks_003Ed__21))]
	public IEnumerator CloseBlocks()
	{
		return null;
	}

	[Token(Token = "0x6000632")]
	[Address(RVA = "0x457FB0", Offset = "0x4569B0", VA = "0x180457FB0")]
	public LevelLoader()
	{
	}
}

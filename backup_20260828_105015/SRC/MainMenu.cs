using System.Runtime.CompilerServices;
using Il2CppDummyDll;
using UnityEngine;
using UnityEngine.InputSystem;

[Token(Token = "0x20000D2")]
public class MainMenu : MonoBehaviour
{
	[Token(Token = "0x400045E")]
	[FieldOffset(Offset = "0x8")]
	public static EnterMenuReason enterMenuReason;

	[Token(Token = "0x400045F")]
	[FieldOffset(Offset = "0x20")]
	[Header("Tabs Parent")]
	public Transform tabsParent;

	[Token(Token = "0x4000460")]
	[FieldOffset(Offset = "0x28")]
	public Tutorial tutorial;

	[Token(Token = "0x4000461")]
	[FieldOffset(Offset = "0x30")]
	[Header("Audio")]
	[SerializeField]
	private AudioSource click;

	[Token(Token = "0x4000462")]
	[FieldOffset(Offset = "0x38")]
	[SerializeField]
	private AudioSource error;

	[Token(Token = "0x4000463")]
	[FieldOffset(Offset = "0x40")]
	[Header("Backdrops")]
	[SerializeField]
	private GameObject backDropMain;

	[Token(Token = "0x4000464")]
	[FieldOffset(Offset = "0x48")]
	[SerializeField]
	private GameObject backDropOther;

	[Token(Token = "0x4000465")]
	[FieldOffset(Offset = "0x50")]
	[SerializeField]
	private InputAction escape;

	[Token(Token = "0x17000084")]
	public static MainMenu Instance
	{
		[Token(Token = "0x6000649")]
		[Address(RVA = "0x4D9BF0", Offset = "0x4D85F0", VA = "0x1804D9BF0")]
		[CompilerGenerated]
		get
		{
			return null;
		}
		[Token(Token = "0x600064A")]
		[Address(RVA = "0x4D9C50", Offset = "0x4D8650", VA = "0x1804D9C50")]
		[CompilerGenerated]
		private set
		{
		}
	}

	[Token(Token = "0x600064B")]
	[Address(RVA = "0x4D9D00", Offset = "0x4D8700", VA = "0x1804D9D00")]
	private void OnEnable()
	{
	}

	[Token(Token = "0x600064C")]
	[Address(RVA = "0x4D9DD0", Offset = "0x4D87D0", VA = "0x1804D9DD0")]
	private void OnDisable()
	{
	}

	[Token(Token = "0x600064D")]
	[Address(RVA = "0x4D9EA0", Offset = "0x4D88A0", VA = "0x1804D9EA0")]
	private void OnEscapeClick(InputAction.CallbackContext context)
	{
	}

	[Token(Token = "0x600064E")]
	[Address(RVA = "0x4DA230", Offset = "0x4D8C30", VA = "0x1804DA230")]
	private void Awake()
	{
	}

	[Token(Token = "0x600064F")]
	[Address(RVA = "0x4DAA50", Offset = "0x4D9450", VA = "0x1804DAA50")]
	public void QuitGame()
	{
	}

	[Token(Token = "0x6000650")]
	[Address(RVA = "0x4DAAA0", Offset = "0x4D94A0", VA = "0x1804DAAA0")]
	public void CheckCosmeticsAndOpenTab(GameObject tab)
	{
	}

	[Token(Token = "0x6000651")]
	[Address(RVA = "0x4DAD10", Offset = "0x4D9710", VA = "0x1804DAD10")]
	public void OpenTab(GameObject tab)
	{
	}

	[Token(Token = "0x6000652")]
	[Address(RVA = "0x4DAED0", Offset = "0x4D98D0", VA = "0x1804DAED0")]
	public void TabCloseAll()
	{
	}

	[Token(Token = "0x6000653")]
	[Address(RVA = "0x457FB0", Offset = "0x4569B0", VA = "0x180457FB0")]
	public MainMenu()
	{
	}
}

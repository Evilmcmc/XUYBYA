using System.Collections;
using System.Runtime.CompilerServices;
using Il2CppDummyDll;
using UnityEngine;
using UnityEngine.Audio;

[Token(Token = "0x20000B9")]
public class SettingsLoader : MonoBehaviour
{
	[Token(Token = "0x40003F3")]
	[FieldOffset(Offset = "0x20")]
	[SerializeField]
	private AudioMixer audioMixer;

	[Token(Token = "0x40003F4")]
	[FieldOffset(Offset = "0x28")]
	[SerializeField]
	private LocaleSelector localeSelector;

	[Token(Token = "0x40003F5")]
	[FieldOffset(Offset = "0x30")]
	[SerializeField]
	private MainMenu mainMenu;

	[Token(Token = "0x60005C5")]
	[Address(RVA = "0x4D1880", Offset = "0x4D0280", VA = "0x1804D1880")]
	private void Start()
	{
	}

	[Token(Token = "0x60005C6")]
	[Address(RVA = "0x4D1EB0", Offset = "0x4D08B0", VA = "0x1804D1EB0")]
	[IteratorStateMachine(typeof(_003CSetLocale_003Ed__4))]
	public IEnumerator SetLocale(int _localeIDD)
	{
		return null;
	}

	[Token(Token = "0x60005C7")]
	[Address(RVA = "0x457FB0", Offset = "0x4569B0", VA = "0x180457FB0")]
	public SettingsLoader()
	{
	}
}

using System.Collections;
using System.Runtime.CompilerServices;
using Il2CppDummyDll;
using UnityEngine;

[Token(Token = "0x20000CF")]
public class LocaleSelector : MonoBehaviour
{
	[Token(Token = "0x4000453")]
	[FieldOffset(Offset = "0x20")]
	[SerializeField]
	private SettingsLoader settingsLoader;

	[Token(Token = "0x600063F")]
	[Address(RVA = "0x4D98B0", Offset = "0x4D82B0", VA = "0x1804D98B0")]
	public void ChangeLocale(int localeID)
	{
	}

	[Token(Token = "0x6000640")]
	[Address(RVA = "0x4D9920", Offset = "0x4D8320", VA = "0x1804D9920")]
	public void ChangeLocaleInGame(int localeID)
	{
	}

	[Token(Token = "0x6000641")]
	[Address(RVA = "0x4D9980", Offset = "0x4D8380", VA = "0x1804D9980")]
	[IteratorStateMachine(typeof(_003CSetLocale_003Ed__3))]
	public IEnumerator SetLocale(int _localeIDD)
	{
		return null;
	}

	[Token(Token = "0x6000642")]
	[Address(RVA = "0x457FB0", Offset = "0x4569B0", VA = "0x180457FB0")]
	public LocaleSelector()
	{
	}
}

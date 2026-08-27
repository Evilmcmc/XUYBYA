using System.Collections;
using System.Runtime.CompilerServices;
using Il2CppDummyDll;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.UI;

[Token(Token = "0x200010C")]
public class RebuildLayout : MonoBehaviour
{
	[Token(Token = "0x400059E")]
	[FieldOffset(Offset = "0x20")]
	[SerializeField]
	private HorizontalLayoutGroup horizontalLayoutGroup;

	[Token(Token = "0x6000812")]
	[Address(RVA = "0x4FAC50", Offset = "0x4F9650", VA = "0x1804FAC50")]
	private void OnEnable()
	{
	}

	[Token(Token = "0x6000813")]
	[Address(RVA = "0x4FACD0", Offset = "0x4F96D0", VA = "0x1804FACD0")]
	private void OnDisable()
	{
	}

	[Token(Token = "0x6000814")]
	[Address(RVA = "0x4FAD90", Offset = "0x4F9790", VA = "0x1804FAD90")]
	private void OnLocaleChanged(UnityEngine.Localization.Locale newLocale)
	{
	}

	[Token(Token = "0x6000815")]
	[Address(RVA = "0x4FAE40", Offset = "0x4F9840", VA = "0x1804FAE40")]
	[IteratorStateMachine(typeof(_003CWaitThenRebuild_003Ed__4))]
	private IEnumerator WaitThenRebuild()
	{
		return null;
	}

	[Token(Token = "0x6000816")]
	[Address(RVA = "0x457FB0", Offset = "0x4569B0", VA = "0x180457FB0")]
	public RebuildLayout()
	{
	}
}

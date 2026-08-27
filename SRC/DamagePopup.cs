using System.Collections;
using System.Runtime.CompilerServices;
using Il2CppDummyDll;
using TMPro;
using UnityEngine;

[Token(Token = "0x200007F")]
public class DamagePopup : MonoBehaviour
{
	[Token(Token = "0x400021C")]
	[FieldOffset(Offset = "0x20")]
	[SerializeField]
	private TMP_Text damagePopupText;

	[Token(Token = "0x6000315")]
	[Address(RVA = "0x493C20", Offset = "0x492620", VA = "0x180493C20")]
	public void _DamagePopup(int _damage, Vector3 hitPos)
	{
	}

	[Token(Token = "0x6000316")]
	[Address(RVA = "0x493D70", Offset = "0x492770", VA = "0x180493D70")]
	[IteratorStateMachine(typeof(_003C_CourotineDamagePopup_003Ed__2))]
	private IEnumerator _CourotineDamagePopup(int _damage, Vector3 hitPos)
	{
		return null;
	}

	[Token(Token = "0x6000317")]
	[Address(RVA = "0x457FB0", Offset = "0x4569B0", VA = "0x180457FB0")]
	public DamagePopup()
	{
	}
}

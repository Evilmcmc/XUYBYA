using Il2CppDummyDll;
using UnityEngine;

[Token(Token = "0x2000060")]
public class LethalCollisionDetection : MonoBehaviour
{
	[Token(Token = "0x400017F")]
	[FieldOffset(Offset = "0x20")]
	[SerializeField]
	private int lethalLayer;

	[Token(Token = "0x6000277")]
	[Address(RVA = "0x489E50", Offset = "0x488850", VA = "0x180489E50")]
	private void OnCollisionEnter(Collision collision)
	{
	}

	[Token(Token = "0x6000278")]
	[Address(RVA = "0x457FB0", Offset = "0x4569B0", VA = "0x180457FB0")]
	public LethalCollisionDetection()
	{
	}
}

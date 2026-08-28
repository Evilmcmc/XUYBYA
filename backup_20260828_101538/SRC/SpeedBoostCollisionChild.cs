using Il2CppDummyDll;
using UnityEngine;

[Token(Token = "0x20000BE")]
public class SpeedBoostCollisionChild : MonoBehaviour
{
	[Token(Token = "0x4000403")]
	[FieldOffset(Offset = "0x20")]
	[SerializeField]
	private int speedBoostLayer;

	[Token(Token = "0x60005E3")]
	[Address(RVA = "0x4D29A0", Offset = "0x4D13A0", VA = "0x1804D29A0")]
	private void OnTriggerEnter(Collider other)
	{
	}

	[Token(Token = "0x60005E4")]
	[Address(RVA = "0x457FB0", Offset = "0x4569B0", VA = "0x180457FB0")]
	public SpeedBoostCollisionChild()
	{
	}
}

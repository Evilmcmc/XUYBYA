using Il2CppDummyDll;
using UnityEngine;

[Token(Token = "0x20000B2")]
public class RaceEndCollisionChild : MonoBehaviour
{
	[Token(Token = "0x40003DB")]
	[FieldOffset(Offset = "0x20")]
	[SerializeField]
	private int endBoxLayer;

	[Token(Token = "0x40003DC")]
	[FieldOffset(Offset = "0x24")]
	private bool hasCollided;

	[Token(Token = "0x60005A2")]
	[Address(RVA = "0x4CE490", Offset = "0x4CCE90", VA = "0x1804CE490")]
	private void OnTriggerEnter(Collider other)
	{
	}

	[Token(Token = "0x60005A3")]
	[Address(RVA = "0x4CE5E0", Offset = "0x4CCFE0", VA = "0x1804CE5E0")]
	private void OnTriggerStay(Collider other)
	{
	}

	[Token(Token = "0x60005A4")]
	[Address(RVA = "0x457FB0", Offset = "0x4569B0", VA = "0x180457FB0")]
	public RaceEndCollisionChild()
	{
	}
}

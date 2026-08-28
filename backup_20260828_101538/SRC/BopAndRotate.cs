using Il2CppDummyDll;
using UnityEngine;

[Token(Token = "0x2000011")]
public class BopAndRotate : MonoBehaviour
{
	[Token(Token = "0x400002E")]
	[FieldOffset(Offset = "0x20")]
	[SerializeField]
	private float speed;

	[Token(Token = "0x400002F")]
	[FieldOffset(Offset = "0x24")]
	[SerializeField]
	private float magnitude;

	[Token(Token = "0x4000030")]
	[FieldOffset(Offset = "0x28")]
	[SerializeField]
	private float rotationSpeed;

	[Token(Token = "0x4000031")]
	[FieldOffset(Offset = "0x2C")]
	[SerializeField]
	private float defaultHeight;

	[Token(Token = "0x6000058")]
	[Address(RVA = "0x457C60", Offset = "0x456660", VA = "0x180457C60")]
	private void Update()
	{
	}

	[Token(Token = "0x6000059")]
	[Address(RVA = "0x457FB0", Offset = "0x4569B0", VA = "0x180457FB0")]
	public BopAndRotate()
	{
	}
}

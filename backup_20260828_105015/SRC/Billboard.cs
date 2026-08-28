using Il2CppDummyDll;
using UnityEngine;

[Token(Token = "0x200007C")]
public class Billboard : MonoBehaviour
{
	[Token(Token = "0x4000209")]
	[FieldOffset(Offset = "0x20")]
	public float AverageSize;

	[Token(Token = "0x400020A")]
	[FieldOffset(Offset = "0x24")]
	public float MinSize;

	[Token(Token = "0x400020B")]
	[FieldOffset(Offset = "0x28")]
	public float MaxSize;

	[Token(Token = "0x400020C")]
	[FieldOffset(Offset = "0x30")]
	private Camera cam;

	[Token(Token = "0x400020D")]
	[FieldOffset(Offset = "0x38")]
	public bool flip;

	[Token(Token = "0x6000302")]
	[Address(RVA = "0x491FB0", Offset = "0x4909B0", VA = "0x180491FB0")]
	private void Start()
	{
	}

	[Token(Token = "0x6000303")]
	[Address(RVA = "0x491FC0", Offset = "0x4909C0", VA = "0x180491FC0")]
	private void GetCamera()
	{
	}

	[Token(Token = "0x6000304")]
	[Address(RVA = "0x492380", Offset = "0x490D80", VA = "0x180492380")]
	private void LateUpdate()
	{
	}

	[Token(Token = "0x6000305")]
	[Address(RVA = "0x457FB0", Offset = "0x4569B0", VA = "0x180457FB0")]
	public Billboard()
	{
	}
}

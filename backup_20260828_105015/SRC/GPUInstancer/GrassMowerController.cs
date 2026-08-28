using Il2CppDummyDll;
using UnityEngine;

namespace GPUInstancer;

[Token(Token = "0x2000152")]
public class GrassMowerController : MonoBehaviour
{
	[Token(Token = "0x4000816")]
	[FieldOffset(Offset = "0x20")]
	public float engineTorque;

	[Token(Token = "0x4000817")]
	[FieldOffset(Offset = "0x24")]
	public float enginePower;

	[Token(Token = "0x4000818")]
	[FieldOffset(Offset = "0x28")]
	private Rigidbody grassMowerRigidbody;

	[Token(Token = "0x4000819")]
	[FieldOffset(Offset = "0x30")]
	private float thrustInput;

	[Token(Token = "0x400081A")]
	[FieldOffset(Offset = "0x34")]
	private float yawInput;

	[Token(Token = "0x6000C42")]
	[Address(RVA = "0x559D70", Offset = "0x558770", VA = "0x180559D70")]
	private void Awake()
	{
	}

	[Token(Token = "0x6000C43")]
	[Address(RVA = "0x559E00", Offset = "0x558800", VA = "0x180559E00")]
	private void FixedUpdate()
	{
	}

	[Token(Token = "0x6000C44")]
	[Address(RVA = "0x559E70", Offset = "0x558870", VA = "0x180559E70")]
	private void GetInputs()
	{
	}

	[Token(Token = "0x6000C45")]
	[Address(RVA = "0x559EE0", Offset = "0x5588E0", VA = "0x180559EE0")]
	private void Move()
	{
	}

	[Token(Token = "0x6000C46")]
	[Address(RVA = "0x55A1F0", Offset = "0x558BF0", VA = "0x18055A1F0")]
	public GrassMowerController()
	{
	}
}

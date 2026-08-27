using Il2CppDummyDll;
using UnityEngine;

[Token(Token = "0x200010E")]
public class StabilizeCharacterAndLerp : MonoBehaviour
{
	[Token(Token = "0x40005A2")]
	[FieldOffset(Offset = "0x20")]
	[SerializeField]
	private MenuRigidbodyMover mover;

	[Token(Token = "0x40005A3")]
	[FieldOffset(Offset = "0x28")]
	[SerializeField]
	private float moveForce;

	[Token(Token = "0x40005A4")]
	[FieldOffset(Offset = "0x2C")]
	[SerializeField]
	private float rotationForce;

	[Token(Token = "0x40005A5")]
	[FieldOffset(Offset = "0x30")]
	[SerializeField]
	private float maxSpeed;

	[Token(Token = "0x40005A6")]
	[FieldOffset(Offset = "0x34")]
	[SerializeField]
	private float maxAngularVelocity;

	[Token(Token = "0x40005A7")]
	[FieldOffset(Offset = "0x38")]
	[SerializeField]
	public float maxDistance;

	[Token(Token = "0x40005A8")]
	[FieldOffset(Offset = "0x3C")]
	[HideInInspector]
	public Vector3 targetPosition;

	[Token(Token = "0x40005A9")]
	[FieldOffset(Offset = "0x48")]
	private Quaternion targetRotation;

	[Token(Token = "0x600081D")]
	[Address(RVA = "0x4FB0B0", Offset = "0x4F9AB0", VA = "0x1804FB0B0")]
	private void Start()
	{
	}

	[Token(Token = "0x600081E")]
	[Address(RVA = "0x4FB230", Offset = "0x4F9C30", VA = "0x1804FB230")]
	private void FixedUpdate()
	{
	}

	[Token(Token = "0x600081F")]
	[Address(RVA = "0x4FBCB0", Offset = "0x4FA6B0", VA = "0x1804FBCB0")]
	public StabilizeCharacterAndLerp()
	{
	}
}

using Il2CppDummyDll;
using UnityEngine;

namespace GPUInstancer;

[Token(Token = "0x2000154")]
public class SpaceshipCameraRig : MonoBehaviour
{
	[Token(Token = "0x400081D")]
	[FieldOffset(Offset = "0x20")]
	public Transform m_Target;

	[Token(Token = "0x400081E")]
	[FieldOffset(Offset = "0x28")]
	public float m_MoveSpeed;

	[Token(Token = "0x400081F")]
	[FieldOffset(Offset = "0x2C")]
	public float m_TurnSpeed;

	[Token(Token = "0x4000820")]
	[FieldOffset(Offset = "0x30")]
	public float m_RollSpeed;

	[Token(Token = "0x4000821")]
	[FieldOffset(Offset = "0x34")]
	public bool m_FollowVelocity;

	[Token(Token = "0x4000822")]
	[FieldOffset(Offset = "0x35")]
	public bool m_FollowTilt;

	[Token(Token = "0x4000823")]
	[FieldOffset(Offset = "0x38")]
	public float m_SpinTurnLimit;

	[Token(Token = "0x4000824")]
	[FieldOffset(Offset = "0x3C")]
	public float m_TargetVelocityLowerLimit;

	[Token(Token = "0x4000825")]
	[FieldOffset(Offset = "0x40")]
	public float m_SmoothTurnTime;

	[Token(Token = "0x4000826")]
	[FieldOffset(Offset = "0x44")]
	private Vector3 m_LastTargetPosition;

	[Token(Token = "0x4000827")]
	[FieldOffset(Offset = "0x50")]
	private Rigidbody targetRigidbody;

	[Token(Token = "0x4000828")]
	[FieldOffset(Offset = "0x58")]
	private float m_LastFlatAngle;

	[Token(Token = "0x4000829")]
	[FieldOffset(Offset = "0x5C")]
	private float m_CurrentTurnAmount;

	[Token(Token = "0x400082A")]
	[FieldOffset(Offset = "0x60")]
	private float m_TurnSpeedVelocityChange;

	[Token(Token = "0x400082B")]
	[FieldOffset(Offset = "0x64")]
	private Vector3 m_RollUp;

	[Token(Token = "0x6000C4B")]
	[Address(RVA = "0x55A790", Offset = "0x559190", VA = "0x18055A790")]
	private void Start()
	{
	}

	[Token(Token = "0x6000C4C")]
	[Address(RVA = "0x55A8E0", Offset = "0x5592E0", VA = "0x18055A8E0")]
	private void FixedUpdate()
	{
	}

	[Token(Token = "0x6000C4D")]
	[Address(RVA = "0x55A940", Offset = "0x559340", VA = "0x18055A940")]
	private void FollowTarget(float deltaTime)
	{
	}

	[Token(Token = "0x6000C4E")]
	[Address(RVA = "0x55B430", Offset = "0x559E30", VA = "0x18055B430")]
	public SpaceshipCameraRig()
	{
	}
}

using Il2CppDummyDll;
using UnityEngine;

namespace GPUInstancer;

[Token(Token = "0x2000155")]
public class SpaceshipController : MonoBehaviour
{
	[Token(Token = "0x400082C")]
	[FieldOffset(Offset = "0x20")]
	public float engineTorque;

	[Token(Token = "0x400082D")]
	[FieldOffset(Offset = "0x24")]
	public float enginePower;

	[Token(Token = "0x400082E")]
	[FieldOffset(Offset = "0x28")]
	private Rigidbody shipRigidbody;

	[Token(Token = "0x400082F")]
	[FieldOffset(Offset = "0x30")]
	private float rollInput;

	[Token(Token = "0x4000830")]
	[FieldOffset(Offset = "0x34")]
	private float thrustInput;

	[Token(Token = "0x4000831")]
	[FieldOffset(Offset = "0x38")]
	private float pitchInput;

	[Token(Token = "0x4000832")]
	[FieldOffset(Offset = "0x3C")]
	private float yawInput;

	[Token(Token = "0x4000833")]
	[FieldOffset(Offset = "0x40")]
	private ParticleSystem.EmissionModule engineThrusterEmission;

	[Token(Token = "0x4000834")]
	[FieldOffset(Offset = "0x48")]
	private ParticleSystem.EmissionModule engineGlowEmission;

	[Token(Token = "0x4000835")]
	[FieldOffset(Offset = "0x50")]
	private Light engineGlowLight;

	[Token(Token = "0x4000836")]
	[FieldOffset(Offset = "0x58")]
	private float originalThrusterEmissionRate;

	[Token(Token = "0x4000837")]
	[FieldOffset(Offset = "0x5C")]
	private float originalGlowEmissionRate;

	[Token(Token = "0x6000C4F")]
	[Address(RVA = "0x55B4F0", Offset = "0x559EF0", VA = "0x18055B4F0")]
	private void Awake()
	{
	}

	[Token(Token = "0x6000C50")]
	[Address(RVA = "0x55B980", Offset = "0x55A380", VA = "0x18055B980")]
	private void FixedUpdate()
	{
	}

	[Token(Token = "0x6000C51")]
	[Address(RVA = "0x55BAD0", Offset = "0x55A4D0", VA = "0x18055BAD0")]
	private void GetInputs()
	{
	}

	[Token(Token = "0x6000C52")]
	[Address(RVA = "0x55BC20", Offset = "0x55A620", VA = "0x18055BC20")]
	private void Move()
	{
	}

	[Token(Token = "0x6000C53")]
	[Address(RVA = "0x55C1D0", Offset = "0x55ABD0", VA = "0x18055C1D0")]
	private void AdjustThrusterEffects()
	{
	}

	[Token(Token = "0x6000C54")]
	[Address(RVA = "0x551610", Offset = "0x550010", VA = "0x180551610")]
	public SpaceshipController()
	{
	}
}

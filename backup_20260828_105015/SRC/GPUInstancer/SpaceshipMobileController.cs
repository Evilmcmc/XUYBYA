using Il2CppDummyDll;
using UnityEngine;

namespace GPUInstancer;

[Token(Token = "0x2000144")]
public class SpaceshipMobileController : MonoBehaviour
{
	[Token(Token = "0x40007AB")]
	[FieldOffset(Offset = "0x20")]
	public float engineTorque;

	[Token(Token = "0x40007AC")]
	[FieldOffset(Offset = "0x24")]
	public float enginePower;

	[Token(Token = "0x40007AD")]
	[FieldOffset(Offset = "0x28")]
	public SpaceshipMobileJoystick spaceShipJoystick;

	[Token(Token = "0x40007AE")]
	[FieldOffset(Offset = "0x30")]
	private Rigidbody shipRigidbody;

	[Token(Token = "0x40007AF")]
	[FieldOffset(Offset = "0x38")]
	private float rollInput;

	[Token(Token = "0x40007B0")]
	[FieldOffset(Offset = "0x3C")]
	private float thrustInput;

	[Token(Token = "0x40007B1")]
	[FieldOffset(Offset = "0x40")]
	private float pitchInput;

	[Token(Token = "0x40007B2")]
	[FieldOffset(Offset = "0x44")]
	private float yawInput;

	[Token(Token = "0x40007B3")]
	[FieldOffset(Offset = "0x48")]
	private ParticleSystem.EmissionModule engineThrusterEmission;

	[Token(Token = "0x40007B4")]
	[FieldOffset(Offset = "0x50")]
	private ParticleSystem.EmissionModule engineGlowEmission;

	[Token(Token = "0x40007B5")]
	[FieldOffset(Offset = "0x58")]
	private Light engineGlowLight;

	[Token(Token = "0x40007B6")]
	[FieldOffset(Offset = "0x60")]
	private float originalThrusterEmissionRate;

	[Token(Token = "0x40007B7")]
	[FieldOffset(Offset = "0x64")]
	private float originalGlowEmissionRate;

	[Token(Token = "0x6000BE4")]
	[Address(RVA = "0x550920", Offset = "0x54F320", VA = "0x180550920")]
	private void Awake()
	{
	}

	[Token(Token = "0x6000BE5")]
	[Address(RVA = "0x550DB0", Offset = "0x54F7B0", VA = "0x180550DB0")]
	private void FixedUpdate()
	{
	}

	[Token(Token = "0x6000BE6")]
	[Address(RVA = "0x550E00", Offset = "0x54F800", VA = "0x180550E00")]
	private void GetJoystickInput()
	{
	}

	[Token(Token = "0x6000BE7")]
	[Address(RVA = "0x550E30", Offset = "0x54F830", VA = "0x180550E30")]
	public void SetRollInput(float rollInput)
	{
	}

	[Token(Token = "0x6000BE8")]
	[Address(RVA = "0x550E40", Offset = "0x54F840", VA = "0x180550E40")]
	public void SetThrustInput(bool isThrusting)
	{
	}

	[Token(Token = "0x6000BE9")]
	[Address(RVA = "0x550E70", Offset = "0x54F870", VA = "0x180550E70")]
	private void Move()
	{
	}

	[Token(Token = "0x6000BEA")]
	[Address(RVA = "0x551420", Offset = "0x54FE20", VA = "0x180551420")]
	private void AdjustThrusterEffects()
	{
	}

	[Token(Token = "0x6000BEB")]
	[Address(RVA = "0x551610", Offset = "0x550010", VA = "0x180551610")]
	public SpaceshipMobileController()
	{
	}
}

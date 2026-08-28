using Il2CppDummyDll;
using UnityEngine;

[Token(Token = "0x2000116")]
public class LeanSmooth
{
	[Token(Token = "0x6000841")]
	[Address(RVA = "0x4FDFA0", Offset = "0x4FC9A0", VA = "0x1804FDFA0")]
	public static float damp(float current, float target, ref float currentVelocity, float smoothTime, float maxSpeed = -1f, float deltaTime = -1f)
	{
		return default(float);
	}

	[Token(Token = "0x6000842")]
	[Address(RVA = "0x4FE170", Offset = "0x4FCB70", VA = "0x1804FE170")]
	public static Vector3 damp(Vector3 current, Vector3 target, ref Vector3 currentVelocity, float smoothTime, float maxSpeed = -1f, float deltaTime = -1f)
	{
		return default(Vector3);
	}

	[Token(Token = "0x6000843")]
	[Address(RVA = "0x4FE2A0", Offset = "0x4FCCA0", VA = "0x1804FE2A0")]
	public static Color damp(Color current, Color target, ref Color currentVelocity, float smoothTime, float maxSpeed = -1f, float deltaTime = -1f)
	{
		return default(Color);
	}

	[Token(Token = "0x6000844")]
	[Address(RVA = "0x4FE410", Offset = "0x4FCE10", VA = "0x1804FE410")]
	public static float spring(float current, float target, ref float currentVelocity, float smoothTime, float maxSpeed = -1f, float deltaTime = -1f, float friction = 2f, float accelRate = 0.5f)
	{
		return default(float);
	}

	[Token(Token = "0x6000845")]
	[Address(RVA = "0x4FE520", Offset = "0x4FCF20", VA = "0x1804FE520")]
	public static Vector3 spring(Vector3 current, Vector3 target, ref Vector3 currentVelocity, float smoothTime, float maxSpeed = -1f, float deltaTime = -1f, float friction = 2f, float accelRate = 0.5f)
	{
		return default(Vector3);
	}

	[Token(Token = "0x6000846")]
	[Address(RVA = "0x4FE6A0", Offset = "0x4FD0A0", VA = "0x1804FE6A0")]
	public static Color spring(Color current, Color target, ref Color currentVelocity, float smoothTime, float maxSpeed = -1f, float deltaTime = -1f, float friction = 2f, float accelRate = 0.5f)
	{
		return default(Color);
	}

	[Token(Token = "0x6000847")]
	[Address(RVA = "0x4FE870", Offset = "0x4FD270", VA = "0x1804FE870")]
	public static float linear(float current, float target, float moveSpeed, float deltaTime = -1f)
	{
		return default(float);
	}

	[Token(Token = "0x6000848")]
	[Address(RVA = "0x4FE940", Offset = "0x4FD340", VA = "0x1804FE940")]
	public static Vector3 linear(Vector3 current, Vector3 target, float moveSpeed, float deltaTime = -1f)
	{
		return default(Vector3);
	}

	[Token(Token = "0x6000849")]
	[Address(RVA = "0x4FEA20", Offset = "0x4FD420", VA = "0x1804FEA20")]
	public static Color linear(Color current, Color target, float moveSpeed)
	{
		return default(Color);
	}

	[Token(Token = "0x600084A")]
	[Address(RVA = "0x4FEB30", Offset = "0x4FD530", VA = "0x1804FEB30")]
	public static float bounceOut(float current, float target, ref float currentVelocity, float smoothTime, float maxSpeed = -1f, float deltaTime = -1f, float friction = 2f, float accelRate = 0.5f, float hitDamping = 0.9f)
	{
		return default(float);
	}

	[Token(Token = "0x600084B")]
	[Address(RVA = "0x4FEC80", Offset = "0x4FD680", VA = "0x1804FEC80")]
	public static Vector3 bounceOut(Vector3 current, Vector3 target, ref Vector3 currentVelocity, float smoothTime, float maxSpeed = -1f, float deltaTime = -1f, float friction = 2f, float accelRate = 0.5f, float hitDamping = 0.9f)
	{
		return default(Vector3);
	}

	[Token(Token = "0x600084C")]
	[Address(RVA = "0x4FEE20", Offset = "0x4FD820", VA = "0x1804FEE20")]
	public static Color bounceOut(Color current, Color target, ref Color currentVelocity, float smoothTime, float maxSpeed = -1f, float deltaTime = -1f, float friction = 2f, float accelRate = 0.5f, float hitDamping = 0.9f)
	{
		return default(Color);
	}

	[Token(Token = "0x600084D")]
	[Address(RVA = "0x4576C0", Offset = "0x4560C0", VA = "0x1804576C0")]
	public LeanSmooth()
	{
	}
}

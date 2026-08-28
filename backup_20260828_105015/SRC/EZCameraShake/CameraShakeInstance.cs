using Il2CppDummyDll;
using UnityEngine;

namespace EZCameraShake;

[Token(Token = "0x20001BB")]
public class CameraShakeInstance
{
	[Token(Token = "0x40008FE")]
	[FieldOffset(Offset = "0x10")]
	public float Magnitude;

	[Token(Token = "0x40008FF")]
	[FieldOffset(Offset = "0x14")]
	public float Roughness;

	[Token(Token = "0x4000900")]
	[FieldOffset(Offset = "0x18")]
	public Vector3 PositionInfluence;

	[Token(Token = "0x4000901")]
	[FieldOffset(Offset = "0x24")]
	public Vector3 RotationInfluence;

	[Token(Token = "0x4000902")]
	[FieldOffset(Offset = "0x30")]
	public bool DeleteOnInactive;

	[Token(Token = "0x4000903")]
	[FieldOffset(Offset = "0x34")]
	private float roughMod;

	[Token(Token = "0x4000904")]
	[FieldOffset(Offset = "0x38")]
	private float magnMod;

	[Token(Token = "0x4000905")]
	[FieldOffset(Offset = "0x3C")]
	private float fadeOutDuration;

	[Token(Token = "0x4000906")]
	[FieldOffset(Offset = "0x40")]
	private float fadeInDuration;

	[Token(Token = "0x4000907")]
	[FieldOffset(Offset = "0x44")]
	private bool sustain;

	[Token(Token = "0x4000908")]
	[FieldOffset(Offset = "0x48")]
	private float currentFadeTime;

	[Token(Token = "0x4000909")]
	[FieldOffset(Offset = "0x4C")]
	private float tick;

	[Token(Token = "0x400090A")]
	[FieldOffset(Offset = "0x50")]
	private Vector3 amt;

	[Token(Token = "0x170000FB")]
	public float ScaleRoughness
	{
		[Token(Token = "0x6000E23")]
		[Address(RVA = "0x455040", Offset = "0x453A40", VA = "0x180455040")]
		get
		{
			return default(float);
		}
		[Token(Token = "0x6000E24")]
		[Address(RVA = "0x577840", Offset = "0x576240", VA = "0x180577840")]
		set
		{
		}
	}

	[Token(Token = "0x170000FC")]
	public float ScaleMagnitude
	{
		[Token(Token = "0x6000E25")]
		[Address(RVA = "0x577850", Offset = "0x576250", VA = "0x180577850")]
		get
		{
			return default(float);
		}
		[Token(Token = "0x6000E26")]
		[Address(RVA = "0x550E30", Offset = "0x54F830", VA = "0x180550E30")]
		set
		{
		}
	}

	[Token(Token = "0x170000FD")]
	public float NormalizedFadeTime
	{
		[Token(Token = "0x6000E27")]
		[Address(RVA = "0x577860", Offset = "0x576260", VA = "0x180577860")]
		get
		{
			return default(float);
		}
	}

	[Token(Token = "0x170000FE")]
	private bool IsShaking
	{
		[Token(Token = "0x6000E28")]
		[Address(RVA = "0x577870", Offset = "0x576270", VA = "0x180577870")]
		get
		{
			return default(bool);
		}
	}

	[Token(Token = "0x170000FF")]
	private bool IsFadingOut
	{
		[Token(Token = "0x6000E29")]
		[Address(RVA = "0x577890", Offset = "0x576290", VA = "0x180577890")]
		get
		{
			return default(bool);
		}
	}

	[Token(Token = "0x17000100")]
	private bool IsFadingIn
	{
		[Token(Token = "0x6000E2A")]
		[Address(RVA = "0x5778B0", Offset = "0x5762B0", VA = "0x1805778B0")]
		get
		{
			return default(bool);
		}
	}

	[Token(Token = "0x17000101")]
	public CameraShakeState CurrentState
	{
		[Token(Token = "0x6000E2B")]
		[Address(RVA = "0x5778E0", Offset = "0x5762E0", VA = "0x1805778E0")]
		get
		{
			return default(CameraShakeState);
		}
	}

	[Token(Token = "0x6000E1E")]
	[Address(RVA = "0x577400", Offset = "0x575E00", VA = "0x180577400")]
	public CameraShakeInstance(float magnitude, float roughness, float fadeInTime, float fadeOutTime)
	{
	}

	[Token(Token = "0x6000E1F")]
	[Address(RVA = "0x5774B0", Offset = "0x575EB0", VA = "0x1805774B0")]
	public CameraShakeInstance(float magnitude, float roughness)
	{
	}

	[Token(Token = "0x6000E20")]
	[Address(RVA = "0x577540", Offset = "0x575F40", VA = "0x180577540")]
	public Vector3 UpdateShake()
	{
		return default(Vector3);
	}

	[Token(Token = "0x6000E21")]
	[Address(RVA = "0x5777F0", Offset = "0x5761F0", VA = "0x1805777F0")]
	public void StartFadeOut(float fadeOutTime)
	{
	}

	[Token(Token = "0x6000E22")]
	[Address(RVA = "0x577810", Offset = "0x576210", VA = "0x180577810")]
	public void StartFadeIn(float fadeInTime)
	{
	}
}

using Il2CppDummyDll;

[Token(Token = "0x200008F")]
public class Spring
{
	[Token(Token = "0x4000302")]
	[FieldOffset(Offset = "0x10")]
	private float strength;

	[Token(Token = "0x4000303")]
	[FieldOffset(Offset = "0x14")]
	private float damper;

	[Token(Token = "0x4000304")]
	[FieldOffset(Offset = "0x18")]
	private float target;

	[Token(Token = "0x4000305")]
	[FieldOffset(Offset = "0x1C")]
	private float velocity;

	[Token(Token = "0x4000306")]
	[FieldOffset(Offset = "0x20")]
	private float value;

	[Token(Token = "0x1700005E")]
	public float Value
	{
		[Token(Token = "0x6000401")]
		[Address(RVA = "0x4ADE10", Offset = "0x4AC810", VA = "0x1804ADE10")]
		get
		{
			return default(float);
		}
	}

	[Token(Token = "0x60003FA")]
	[Address(RVA = "0x4ADD40", Offset = "0x4AC740", VA = "0x1804ADD40")]
	public void Update(float deltaTime)
	{
	}

	[Token(Token = "0x60003FB")]
	[Address(RVA = "0x4ADDB0", Offset = "0x4AC7B0", VA = "0x1804ADDB0")]
	public void Reset()
	{
	}

	[Token(Token = "0x60003FC")]
	[Address(RVA = "0x4ADDC0", Offset = "0x4AC7C0", VA = "0x1804ADDC0")]
	public void SetValue(float value)
	{
	}

	[Token(Token = "0x60003FD")]
	[Address(RVA = "0x4ADDD0", Offset = "0x4AC7D0", VA = "0x1804ADDD0")]
	public void SetTarget(float target)
	{
	}

	[Token(Token = "0x60003FE")]
	[Address(RVA = "0x4ADDE0", Offset = "0x4AC7E0", VA = "0x1804ADDE0")]
	public void SetDamper(float damper)
	{
	}

	[Token(Token = "0x60003FF")]
	[Address(RVA = "0x4ADDF0", Offset = "0x4AC7F0", VA = "0x1804ADDF0")]
	public void SetStrength(float strength)
	{
	}

	[Token(Token = "0x6000400")]
	[Address(RVA = "0x4ADE00", Offset = "0x4AC800", VA = "0x1804ADE00")]
	public void SetVelocity(float velocity)
	{
	}

	[Token(Token = "0x6000402")]
	[Address(RVA = "0x4576C0", Offset = "0x4560C0", VA = "0x1804576C0")]
	public Spring()
	{
	}
}

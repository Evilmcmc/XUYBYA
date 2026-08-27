using Il2CppDummyDll;

[Token(Token = "0x2000127")]
public class LTEvent
{
	[Token(Token = "0x4000691")]
	[FieldOffset(Offset = "0x10")]
	public int id;

	[Token(Token = "0x4000692")]
	[FieldOffset(Offset = "0x18")]
	public object data;

	[Token(Token = "0x6000982")]
	[Address(RVA = "0x51F8E0", Offset = "0x51E2E0", VA = "0x18051F8E0")]
	public LTEvent(int id, object data)
	{
	}
}

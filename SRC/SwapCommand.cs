using Il2CppDummyDll;

[Token(Token = "0x200001E")]
public class SwapCommand : Command
{
	[Token(Token = "0x17000020")]
	public override string descText
	{
		[Token(Token = "0x60000A4")]
		[Address(RVA = "0x45E7A0", Offset = "0x45D1A0", VA = "0x18045E7A0", Slot = "4")]
		get
		{
			return null;
		}
	}

	[Token(Token = "0x17000021")]
	public override string helpText
	{
		[Token(Token = "0x60000A5")]
		[Address(RVA = "0x45E8F0", Offset = "0x45D2F0", VA = "0x18045E8F0", Slot = "5")]
		get
		{
			return null;
		}
	}

	[Token(Token = "0x60000A6")]
	[Address(RVA = "0x45EBB0", Offset = "0x45D5B0", VA = "0x18045EBB0", Slot = "6")]
	public override void Execute(string[] parameters)
	{
	}

	[Token(Token = "0x60000A7")]
	[Address(RVA = "0x4576C0", Offset = "0x4560C0", VA = "0x1804576C0")]
	public SwapCommand()
	{
	}
}

using Il2CppDummyDll;

[Token(Token = "0x2000023")]
public class UnMuteAllCommand : Command
{
	[Token(Token = "0x1700002A")]
	public override string descText
	{
		[Token(Token = "0x60000B8")]
		[Address(RVA = "0x461CC0", Offset = "0x4606C0", VA = "0x180461CC0", Slot = "4")]
		get
		{
			return null;
		}
	}

	[Token(Token = "0x1700002B")]
	public override string helpText
	{
		[Token(Token = "0x60000B9")]
		[Address(RVA = "0x461E10", Offset = "0x460810", VA = "0x180461E10", Slot = "5")]
		get
		{
			return null;
		}
	}

	[Token(Token = "0x60000BA")]
	[Address(RVA = "0x4620D0", Offset = "0x460AD0", VA = "0x1804620D0", Slot = "6")]
	public override void Execute(string[] parameters)
	{
	}

	[Token(Token = "0x60000BB")]
	[Address(RVA = "0x4576C0", Offset = "0x4560C0", VA = "0x1804576C0")]
	public UnMuteAllCommand()
	{
	}
}

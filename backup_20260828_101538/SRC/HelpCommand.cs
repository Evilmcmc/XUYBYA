using Il2CppDummyDll;

[Token(Token = "0x200001F")]
public class HelpCommand : Command
{
	[Token(Token = "0x17000022")]
	public override string descText
	{
		[Token(Token = "0x60000A8")]
		[Address(RVA = "0x45F080", Offset = "0x45DA80", VA = "0x18045F080", Slot = "4")]
		get
		{
			return null;
		}
	}

	[Token(Token = "0x17000023")]
	public override string helpText
	{
		[Token(Token = "0x60000A9")]
		[Address(RVA = "0x45F1D0", Offset = "0x45DBD0", VA = "0x18045F1D0", Slot = "5")]
		get
		{
			return null;
		}
	}

	[Token(Token = "0x60000AA")]
	[Address(RVA = "0x45F490", Offset = "0x45DE90", VA = "0x18045F490", Slot = "6")]
	public override void Execute(string[] parameters)
	{
	}

	[Token(Token = "0x60000AB")]
	[Address(RVA = "0x4576C0", Offset = "0x4560C0", VA = "0x1804576C0")]
	public HelpCommand()
	{
	}
}

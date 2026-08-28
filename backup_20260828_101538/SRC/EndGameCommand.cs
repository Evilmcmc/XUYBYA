using Il2CppDummyDll;

[Token(Token = "0x2000026")]
public class EndGameCommand : Command
{
	[Token(Token = "0x17000030")]
	public override string descText
	{
		[Token(Token = "0x60000C4")]
		[Address(RVA = "0x463E20", Offset = "0x462820", VA = "0x180463E20", Slot = "4")]
		get
		{
			return null;
		}
	}

	[Token(Token = "0x17000031")]
	public override string helpText
	{
		[Token(Token = "0x60000C5")]
		[Address(RVA = "0x463F70", Offset = "0x462970", VA = "0x180463F70", Slot = "5")]
		get
		{
			return null;
		}
	}

	[Token(Token = "0x60000C6")]
	[Address(RVA = "0x464230", Offset = "0x462C30", VA = "0x180464230", Slot = "6")]
	public override void Execute(string[] parameters)
	{
	}

	[Token(Token = "0x60000C7")]
	[Address(RVA = "0x4576C0", Offset = "0x4560C0", VA = "0x1804576C0")]
	public EndGameCommand()
	{
	}
}

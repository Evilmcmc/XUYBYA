using Il2CppDummyDll;

[Token(Token = "0x2000021")]
public class UnmuteCommand : Command
{
	[Token(Token = "0x17000026")]
	public override string descText
	{
		[Token(Token = "0x60000B0")]
		[Address(RVA = "0x460710", Offset = "0x45F110", VA = "0x180460710", Slot = "4")]
		get
		{
			return null;
		}
	}

	[Token(Token = "0x17000027")]
	public override string helpText
	{
		[Token(Token = "0x60000B1")]
		[Address(RVA = "0x460860", Offset = "0x45F260", VA = "0x180460860", Slot = "5")]
		get
		{
			return null;
		}
	}

	[Token(Token = "0x60000B2")]
	[Address(RVA = "0x460B20", Offset = "0x45F520", VA = "0x180460B20", Slot = "6")]
	public override void Execute(string[] parameters)
	{
	}

	[Token(Token = "0x60000B3")]
	[Address(RVA = "0x4576C0", Offset = "0x4560C0", VA = "0x1804576C0")]
	public UnmuteCommand()
	{
	}
}

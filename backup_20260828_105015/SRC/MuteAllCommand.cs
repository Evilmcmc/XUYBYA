using Il2CppDummyDll;

[Token(Token = "0x2000022")]
public class MuteAllCommand : Command
{
	[Token(Token = "0x17000028")]
	public override string descText
	{
		[Token(Token = "0x60000B4")]
		[Address(RVA = "0x461620", Offset = "0x460020", VA = "0x180461620", Slot = "4")]
		get
		{
			return null;
		}
	}

	[Token(Token = "0x17000029")]
	public override string helpText
	{
		[Token(Token = "0x60000B5")]
		[Address(RVA = "0x461770", Offset = "0x460170", VA = "0x180461770", Slot = "5")]
		get
		{
			return null;
		}
	}

	[Token(Token = "0x60000B6")]
	[Address(RVA = "0x461A30", Offset = "0x460430", VA = "0x180461A30", Slot = "6")]
	public override void Execute(string[] parameters)
	{
	}

	[Token(Token = "0x60000B7")]
	[Address(RVA = "0x4576C0", Offset = "0x4560C0", VA = "0x1804576C0")]
	public MuteAllCommand()
	{
	}
}

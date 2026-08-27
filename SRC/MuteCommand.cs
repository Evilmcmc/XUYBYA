using Il2CppDummyDll;

[Token(Token = "0x2000020")]
public class MuteCommand : Command
{
	[Token(Token = "0x17000024")]
	public override string descText
	{
		[Token(Token = "0x60000AC")]
		[Address(RVA = "0x45F990", Offset = "0x45E390", VA = "0x18045F990", Slot = "4")]
		get
		{
			return null;
		}
	}

	[Token(Token = "0x17000025")]
	public override string helpText
	{
		[Token(Token = "0x60000AD")]
		[Address(RVA = "0x45FAE0", Offset = "0x45E4E0", VA = "0x18045FAE0", Slot = "5")]
		get
		{
			return null;
		}
	}

	[Token(Token = "0x60000AE")]
	[Address(RVA = "0x45FDA0", Offset = "0x45E7A0", VA = "0x18045FDA0", Slot = "6")]
	public override void Execute(string[] parameters)
	{
	}

	[Token(Token = "0x60000AF")]
	[Address(RVA = "0x4576C0", Offset = "0x4560C0", VA = "0x1804576C0")]
	public MuteCommand()
	{
	}
}

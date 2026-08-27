using Il2CppDummyDll;

[Token(Token = "0x2000024")]
public class BanCommand : Command
{
	[Token(Token = "0x1700002C")]
	public override string descText
	{
		[Token(Token = "0x60000BC")]
		[Address(RVA = "0x4623B0", Offset = "0x460DB0", VA = "0x1804623B0", Slot = "4")]
		get
		{
			return null;
		}
	}

	[Token(Token = "0x1700002D")]
	public override string helpText
	{
		[Token(Token = "0x60000BD")]
		[Address(RVA = "0x462500", Offset = "0x460F00", VA = "0x180462500", Slot = "5")]
		get
		{
			return null;
		}
	}

	[Token(Token = "0x60000BE")]
	[Address(RVA = "0x4627C0", Offset = "0x4611C0", VA = "0x1804627C0", Slot = "6")]
	public override void Execute(string[] parameters)
	{
	}

	[Token(Token = "0x60000BF")]
	[Address(RVA = "0x4576C0", Offset = "0x4560C0", VA = "0x1804576C0")]
	public BanCommand()
	{
	}
}

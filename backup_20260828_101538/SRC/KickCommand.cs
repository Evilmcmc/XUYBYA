using Il2CppDummyDll;

[Token(Token = "0x2000025")]
public class KickCommand : Command
{
	[Token(Token = "0x1700002E")]
	public override string descText
	{
		[Token(Token = "0x60000C0")]
		[Address(RVA = "0x463090", Offset = "0x461A90", VA = "0x180463090", Slot = "4")]
		get
		{
			return null;
		}
	}

	[Token(Token = "0x1700002F")]
	public override string helpText
	{
		[Token(Token = "0x60000C1")]
		[Address(RVA = "0x4631E0", Offset = "0x461BE0", VA = "0x1804631E0", Slot = "5")]
		get
		{
			return null;
		}
	}

	[Token(Token = "0x60000C2")]
	[Address(RVA = "0x4634A0", Offset = "0x461EA0", VA = "0x1804634A0", Slot = "6")]
	public override void Execute(string[] parameters)
	{
	}

	[Token(Token = "0x60000C3")]
	[Address(RVA = "0x4576C0", Offset = "0x4560C0", VA = "0x1804576C0")]
	public KickCommand()
	{
	}
}

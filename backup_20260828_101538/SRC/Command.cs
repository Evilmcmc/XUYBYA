using Il2CppDummyDll;

[Token(Token = "0x200001D")]
public abstract class Command
{
	[Token(Token = "0x1700001E")]
	public abstract string descText
	{
		[Token(Token = "0x60000A0")]
		get;
	}

	[Token(Token = "0x1700001F")]
	public abstract string helpText
	{
		[Token(Token = "0x60000A1")]
		get;
	}

	[Token(Token = "0x60000A2")]
	public abstract void Execute(string[] parameters);

	[Token(Token = "0x60000A3")]
	[Address(RVA = "0x4576C0", Offset = "0x4560C0", VA = "0x1804576C0")]
	protected Command()
	{
	}
}

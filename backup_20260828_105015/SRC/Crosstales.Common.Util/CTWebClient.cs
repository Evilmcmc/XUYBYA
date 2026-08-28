using System;
using System.Net;
using System.Runtime.CompilerServices;
using Il2CppDummyDll;

namespace Crosstales.Common.Util;

[Token(Token = "0x20001D4")]
public class CTWebClient : WebClient
{
	[Token(Token = "0x17000131")]
	public int Timeout
	{
		[Token(Token = "0x6000F46")]
		[Address(RVA = "0x58E0C0", Offset = "0x58CAC0", VA = "0x18058E0C0")]
		[CompilerGenerated]
		get
		{
			return default(int);
		}
		[Token(Token = "0x6000F47")]
		[Address(RVA = "0x58E0D0", Offset = "0x58CAD0", VA = "0x18058E0D0")]
		[CompilerGenerated]
		set
		{
		}
	}

	[Token(Token = "0x17000132")]
	public int ConnectionLimit
	{
		[Token(Token = "0x6000F48")]
		[Address(RVA = "0x58E0E0", Offset = "0x58CAE0", VA = "0x18058E0E0")]
		[CompilerGenerated]
		get
		{
			return default(int);
		}
		[Token(Token = "0x6000F49")]
		[Address(RVA = "0x58E0F0", Offset = "0x58CAF0", VA = "0x18058E0F0")]
		[CompilerGenerated]
		set
		{
		}
	}

	[Token(Token = "0x6000F4A")]
	[Address(RVA = "0x58E100", Offset = "0x58CB00", VA = "0x18058E100")]
	public CTWebClient()
	{
	}

	[Token(Token = "0x6000F4B")]
	[Address(RVA = "0x58E2A0", Offset = "0x58CCA0", VA = "0x18058E2A0")]
	public CTWebClient(int timeout, int connectionLimit = 20)
	{
	}

	[Token(Token = "0x6000F4C")]
	[Address(RVA = "0x58E440", Offset = "0x58CE40", VA = "0x18058E440")]
	public WebRequest CTGetWebRequest(string uri)
	{
		return null;
	}

	[Token(Token = "0x6000F4D")]
	[Address(RVA = "0x58E4C0", Offset = "0x58CEC0", VA = "0x18058E4C0", Slot = "12")]
	protected override WebRequest GetWebRequest(Uri uri)
	{
		return null;
	}
}

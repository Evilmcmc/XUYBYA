using System;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using Il2CppDummyDll;

namespace Crosstales.Common.Util;

[Token(Token = "0x20001D8")]
public abstract class NetworkHelper
{
	[Token(Token = "0x40009C0")]
	protected const string FILE_PREFIX = "file://";

	[Token(Token = "0x1700013E")]
	public static bool isInternetAvailable
	{
		[Token(Token = "0x6000F98")]
		[Address(RVA = "0x5966E0", Offset = "0x5950E0", VA = "0x1805966E0")]
		get
		{
			return default(bool);
		}
	}

	[Token(Token = "0x6000F99")]
	[Address(RVA = "0x596770", Offset = "0x595170", VA = "0x180596770")]
	public static bool OpenURL(string url)
	{
		return default(bool);
	}

	[Token(Token = "0x6000F9A")]
	[Address(RVA = "0x596840", Offset = "0x595240", VA = "0x180596840")]
	public static bool RemoteCertificateValidationCallback(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
	{
		return default(bool);
	}

	[Token(Token = "0x6000F9B")]
	[Address(RVA = "0x596EC0", Offset = "0x5958C0", VA = "0x180596EC0")]
	public static string GetURLFromFile(string path)
	{
		return null;
	}

	[Token(Token = "0x6000F9C")]
	[Address(RVA = "0x5970C0", Offset = "0x595AC0", VA = "0x1805970C0")]
	public static string ValidateURL(string url, bool removeProtocol = false, bool removeWWW = true, bool removeSlash = true)
	{
		return null;
	}

	[Token(Token = "0x6000F9D")]
	[Address(RVA = "0x5976C0", Offset = "0x5960C0", VA = "0x1805976C0")]
	public static bool isURL(string url)
	{
		return default(bool);
	}

	[Token(Token = "0x6000F9E")]
	[Address(RVA = "0x597A10", Offset = "0x596410", VA = "0x180597A10")]
	public static bool isIPv4(string ip)
	{
		return default(bool);
	}

	[Token(Token = "0x6000F9F")]
	[Address(RVA = "0x597D00", Offset = "0x596700", VA = "0x180597D00")]
	public static string GetIP(string host)
	{
		return null;
	}

	[Token(Token = "0x6000FA0")]
	[Address(RVA = "0x597EB0", Offset = "0x5968B0", VA = "0x180597EB0")]
	[Obsolete("Please use 'GetURLFromFile' instead.")]
	public static string ValidURLFromFilePath(string path)
	{
		return null;
	}

	[Token(Token = "0x6000FA1")]
	[Address(RVA = "0x597EC0", Offset = "0x5968C0", VA = "0x180597EC0")]
	[Obsolete("Please use 'ValidateURL' instead.")]
	public static string CleanUrl(string url, bool removeProtocol = true, bool removeWWW = true, bool removeSlash = true)
	{
		return null;
	}

	[Token(Token = "0x6000FA2")]
	[Address(RVA = "0x58F380", Offset = "0x58DD80", VA = "0x18058F380")]
	[Obsolete("Please use 'isURL' instead.")]
	public static bool isValidURL(string url)
	{
		return default(bool);
	}

	[Token(Token = "0x6000FA3")]
	[Address(RVA = "0x597ED0", Offset = "0x5968D0", VA = "0x180597ED0")]
	private static void openURL(string url)
	{
	}

	[Token(Token = "0x6000FA4")]
	[Address(RVA = "0x4576C0", Offset = "0x4560C0", VA = "0x1804576C0")]
	protected NetworkHelper()
	{
	}
}

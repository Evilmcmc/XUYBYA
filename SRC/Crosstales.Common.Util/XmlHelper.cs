using Il2CppDummyDll;

namespace Crosstales.Common.Util;

[Token(Token = "0x20001DC")]
public abstract class XmlHelper
{
	[Token(Token = "0x6000FBA")]
	public static void SerializeToFile<T>(T obj, string filename)
	{
	}

	[Token(Token = "0x6000FBB")]
	public static string SerializeToString<T>(T obj)
	{
		return null;
	}

	[Token(Token = "0x6000FBC")]
	public static byte[] SerializeToByteArray<T>(T obj)
	{
		return null;
	}

	[Token(Token = "0x6000FBD")]
	public static T DeserializeFromFile<T>(string filename, bool skipBOM = false)
	{
		return (T)null;
	}

	[Token(Token = "0x6000FBE")]
	public static T DeserializeFromString<T>(string xmlAsString, bool skipBOM = true)
	{
		return (T)null;
	}

	[Token(Token = "0x6000FBF")]
	public static T DeserializeFromByteArray<T>(byte[] data)
	{
		return (T)null;
	}

	[Token(Token = "0x6000FC0")]
	public static T DeserializeFromResource<T>(string resourceName, bool skipBOM = true)
	{
		return (T)null;
	}

	[Token(Token = "0x6000FC1")]
	[Address(RVA = "0x4576C0", Offset = "0x4560C0", VA = "0x1804576C0")]
	protected XmlHelper()
	{
	}
}

using Il2CppDummyDll;
using UnityEngine;

[Token(Token = "0x2000030")]
public class DataPacker
{
	[Token(Token = "0x60000E5")]
	[Address(RVA = "0x465940", Offset = "0x464340", VA = "0x180465940")]
	public static short[] PackVector3(Vector3 source)
	{
		return null;
	}

	[Token(Token = "0x60000E6")]
	[Address(RVA = "0x465A10", Offset = "0x464410", VA = "0x180465A10")]
	public static short[] PackDirection(Vector3 source)
	{
		return null;
	}

	[Token(Token = "0x60000E7")]
	[Address(RVA = "0x465AF0", Offset = "0x4644F0", VA = "0x180465AF0")]
	public static Vector3 UnpackShort(short[] source)
	{
		return default(Vector3);
	}

	[Token(Token = "0x60000E8")]
	[Address(RVA = "0x465B50", Offset = "0x464550", VA = "0x180465B50")]
	public static Vector3 UnpackDirection(short[] source)
	{
		return default(Vector3);
	}

	[Token(Token = "0x60000E9")]
	[Address(RVA = "0x4576C0", Offset = "0x4560C0", VA = "0x1804576C0")]
	public DataPacker()
	{
	}
}

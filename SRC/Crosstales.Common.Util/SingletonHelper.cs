using System.Runtime.CompilerServices;
using Il2CppDummyDll;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Crosstales.Common.Util;

[Token(Token = "0x20001DB")]
public class SingletonHelper
{
	[Token(Token = "0x40009C9")]
	[FieldOffset(Offset = "0x1")]
	private static bool isInitialized;

	[Token(Token = "0x17000141")]
	public static bool isQuitting
	{
		[Token(Token = "0x6000FB3")]
		[Address(RVA = "0x597FD0", Offset = "0x5969D0", VA = "0x180597FD0")]
		[CompilerGenerated]
		get
		{
			return default(bool);
		}
		[Token(Token = "0x6000FB4")]
		[Address(RVA = "0x598030", Offset = "0x596A30", VA = "0x180598030")]
		[CompilerGenerated]
		set
		{
		}
	}

	[Token(Token = "0x6000FB5")]
	[Address(RVA = "0x598090", Offset = "0x596A90", VA = "0x180598090")]
	static SingletonHelper()
	{
	}

	[Token(Token = "0x6000FB6")]
	[Address(RVA = "0x5981E0", Offset = "0x596BE0", VA = "0x1805981E0")]
	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
	private static void initialize()
	{
	}

	[Token(Token = "0x6000FB7")]
	[Address(RVA = "0x5985C0", Offset = "0x596FC0", VA = "0x1805985C0")]
	private static void onSceneLoaded(Scene scene, LoadSceneMode mode)
	{
	}

	[Token(Token = "0x6000FB8")]
	[Address(RVA = "0x5987C0", Offset = "0x5971C0", VA = "0x1805987C0")]
	private static void onQuitting()
	{
	}

	[Token(Token = "0x6000FB9")]
	[Address(RVA = "0x4576C0", Offset = "0x4560C0", VA = "0x1804576C0")]
	public SingletonHelper()
	{
	}
}

using System;
using System.Collections.Generic;
using System.Globalization;
using Crosstales.Common.Model.Enum;
using Il2CppDummyDll;
using UnityEngine;

namespace Crosstales.Common.Util;

[Token(Token = "0x20001D1")]
public abstract class BaseHelper
{
	[Token(Token = "0x40009AA")]
	[FieldOffset(Offset = "0x0")]
	public static bool ApplicationIsPlaying;

	[Token(Token = "0x40009AB")]
	[FieldOffset(Offset = "0x8")]
	protected static readonly System.Random _rnd;

	[Token(Token = "0x40009AC")]
	[FieldOffset(Offset = "0x10")]
	private static string[] _args;

	[Token(Token = "0x40009AD")]
	[FieldOffset(Offset = "0x18")]
	private static int _androidAPILevel;

	[Token(Token = "0x17000117")]
	public static CultureInfo BaseCulture
	{
		[Token(Token = "0x6000EFF")]
		[Address(RVA = "0x588780", Offset = "0x587180", VA = "0x180588780")]
		get
		{
			return null;
		}
	}

	[Token(Token = "0x17000118")]
	public static bool isEditorMode
	{
		[Token(Token = "0x6000F00")]
		[Address(RVA = "0x5888B0", Offset = "0x5872B0", VA = "0x1805888B0")]
		get
		{
			return default(bool);
		}
	}

	[Token(Token = "0x17000119")]
	public static bool isIL2CPP
	{
		[Token(Token = "0x6000F01")]
		[Address(RVA = "0x588930", Offset = "0x587330", VA = "0x180588930")]
		get
		{
			return default(bool);
		}
	}

	[Token(Token = "0x1700011A")]
	public static Platform CurrentPlatform
	{
		[Token(Token = "0x6000F02")]
		[Address(RVA = "0x588940", Offset = "0x587340", VA = "0x180588940")]
		get
		{
			return default(Platform);
		}
	}

	[Token(Token = "0x1700011B")]
	public static int AndroidAPILevel
	{
		[Token(Token = "0x6000F03")]
		[Address(RVA = "0x588990", Offset = "0x587390", VA = "0x180588990")]
		get
		{
			return default(int);
		}
	}

	[Token(Token = "0x1700011C")]
	public static bool isWindowsPlatform
	{
		[Token(Token = "0x6000F04")]
		[Address(RVA = "0x588930", Offset = "0x587330", VA = "0x180588930")]
		get
		{
			return default(bool);
		}
	}

	[Token(Token = "0x1700011D")]
	public static bool isMacOSPlatform
	{
		[Token(Token = "0x6000F05")]
		[Address(RVA = "0x5889F0", Offset = "0x5873F0", VA = "0x1805889F0")]
		get
		{
			return default(bool);
		}
	}

	[Token(Token = "0x1700011E")]
	public static bool isLinuxPlatform
	{
		[Token(Token = "0x6000F06")]
		[Address(RVA = "0x5889F0", Offset = "0x5873F0", VA = "0x1805889F0")]
		get
		{
			return default(bool);
		}
	}

	[Token(Token = "0x1700011F")]
	public static bool isStandalonePlatform
	{
		[Token(Token = "0x6000F07")]
		[Address(RVA = "0x588A00", Offset = "0x587400", VA = "0x180588A00")]
		get
		{
			return default(bool);
		}
	}

	[Token(Token = "0x17000120")]
	public static bool isAndroidPlatform
	{
		[Token(Token = "0x6000F08")]
		[Address(RVA = "0x5889F0", Offset = "0x5873F0", VA = "0x1805889F0")]
		get
		{
			return default(bool);
		}
	}

	[Token(Token = "0x17000121")]
	public static bool isIOSPlatform
	{
		[Token(Token = "0x6000F09")]
		[Address(RVA = "0x5889F0", Offset = "0x5873F0", VA = "0x1805889F0")]
		get
		{
			return default(bool);
		}
	}

	[Token(Token = "0x17000122")]
	public static bool isTvOSPlatform
	{
		[Token(Token = "0x6000F0A")]
		[Address(RVA = "0x5889F0", Offset = "0x5873F0", VA = "0x1805889F0")]
		get
		{
			return default(bool);
		}
	}

	[Token(Token = "0x17000123")]
	public static bool isWSAPlatform
	{
		[Token(Token = "0x6000F0B")]
		[Address(RVA = "0x5889F0", Offset = "0x5873F0", VA = "0x1805889F0")]
		get
		{
			return default(bool);
		}
	}

	[Token(Token = "0x17000124")]
	public static bool isXboxOnePlatform
	{
		[Token(Token = "0x6000F0C")]
		[Address(RVA = "0x5889F0", Offset = "0x5873F0", VA = "0x1805889F0")]
		get
		{
			return default(bool);
		}
	}

	[Token(Token = "0x17000125")]
	public static bool isPS4Platform
	{
		[Token(Token = "0x6000F0D")]
		[Address(RVA = "0x5889F0", Offset = "0x5873F0", VA = "0x1805889F0")]
		get
		{
			return default(bool);
		}
	}

	[Token(Token = "0x17000126")]
	public static bool isWebGLPlatform
	{
		[Token(Token = "0x6000F0E")]
		[Address(RVA = "0x5889F0", Offset = "0x5873F0", VA = "0x1805889F0")]
		get
		{
			return default(bool);
		}
	}

	[Token(Token = "0x17000127")]
	public static bool isWebPlatform
	{
		[Token(Token = "0x6000F0F")]
		[Address(RVA = "0x588A50", Offset = "0x587450", VA = "0x180588A50")]
		get
		{
			return default(bool);
		}
	}

	[Token(Token = "0x17000128")]
	public static bool isWindowsBasedPlatform
	{
		[Token(Token = "0x6000F10")]
		[Address(RVA = "0x588AA0", Offset = "0x5874A0", VA = "0x180588AA0")]
		get
		{
			return default(bool);
		}
	}

	[Token(Token = "0x17000129")]
	public static bool isWSABasedPlatform
	{
		[Token(Token = "0x6000F11")]
		[Address(RVA = "0x588AF0", Offset = "0x5874F0", VA = "0x180588AF0")]
		get
		{
			return default(bool);
		}
	}

	[Token(Token = "0x1700012A")]
	public static bool isAppleBasedPlatform
	{
		[Token(Token = "0x6000F12")]
		[Address(RVA = "0x588B50", Offset = "0x587550", VA = "0x180588B50")]
		get
		{
			return default(bool);
		}
	}

	[Token(Token = "0x1700012B")]
	public static bool isIOSBasedPlatform
	{
		[Token(Token = "0x6000F13")]
		[Address(RVA = "0x588BC0", Offset = "0x5875C0", VA = "0x180588BC0")]
		get
		{
			return default(bool);
		}
	}

	[Token(Token = "0x1700012C")]
	public static bool isMobilePlatform
	{
		[Token(Token = "0x6000F14")]
		[Address(RVA = "0x588C20", Offset = "0x587620", VA = "0x180588C20")]
		get
		{
			return default(bool);
		}
	}

	[Token(Token = "0x1700012D")]
	public static bool isEditor
	{
		[Token(Token = "0x6000F15")]
		[Address(RVA = "0x588CD0", Offset = "0x5876D0", VA = "0x180588CD0")]
		get
		{
			return default(bool);
		}
	}

	[Token(Token = "0x1700012E")]
	public static bool isWindowsEditor
	{
		[Token(Token = "0x6000F16")]
		[Address(RVA = "0x5889F0", Offset = "0x5873F0", VA = "0x1805889F0")]
		get
		{
			return default(bool);
		}
	}

	[Token(Token = "0x1700012F")]
	public static bool isMacOSEditor
	{
		[Token(Token = "0x6000F17")]
		[Address(RVA = "0x5889F0", Offset = "0x5873F0", VA = "0x1805889F0")]
		get
		{
			return default(bool);
		}
	}

	[Token(Token = "0x17000130")]
	public static bool isLinuxEditor
	{
		[Token(Token = "0x6000F18")]
		[Address(RVA = "0x5889F0", Offset = "0x5873F0", VA = "0x1805889F0")]
		get
		{
			return default(bool);
		}
	}

	[Token(Token = "0x6000F19")]
	[Address(RVA = "0x588D40", Offset = "0x587740", VA = "0x180588D40")]
	[RuntimeInitializeOnLoadMethod]
	private static void initialize()
	{
	}

	[Token(Token = "0x6000F1A")]
	[Address(RVA = "0x588E00", Offset = "0x587800", VA = "0x180588E00")]
	public static string CreateString(string generateChars, int stringLength)
	{
		return null;
	}

	[Token(Token = "0x6000F1B")]
	[Address(RVA = "0x589000", Offset = "0x587A00", VA = "0x180589000")]
	public static List<string> SplitStringToLines(string text, bool ignoreCommentedLines = true, int skipHeaderLines = 0, int skipFooterLines = 0)
	{
		return null;
	}

	[Token(Token = "0x6000F1C")]
	[Address(RVA = "0x5893E0", Offset = "0x587DE0", VA = "0x1805893E0")]
	public static string FormatBytesToHRF(long bytes, bool useSI = false)
	{
		return null;
	}

	[Token(Token = "0x6000F1D")]
	[Address(RVA = "0x5896C0", Offset = "0x5880C0", VA = "0x1805896C0")]
	public static string FormatSecondsToHRF(double seconds)
	{
		return null;
	}

	[Token(Token = "0x6000F1E")]
	[Address(RVA = "0x589DA0", Offset = "0x5887A0", VA = "0x180589DA0")]
	public static Color HSVToRGB(float h, float s, float v, float a = 1f)
	{
		return default(Color);
	}

	[Token(Token = "0x6000F1F")]
	[Address(RVA = "0x589EF0", Offset = "0x5888F0", VA = "0x180589EF0")]
	public static string GenerateLoremIpsum(int length, int minSentences = 1, int maxSentences = 2147483647, int minWords = 1, int maxWords = 15)
	{
		return null;
	}

	[Token(Token = "0x6000F20")]
	[Address(RVA = "0x58A550", Offset = "0x588F50", VA = "0x18058A550")]
	public static string LanguageToISO639(SystemLanguage language)
	{
		return null;
	}

	[Token(Token = "0x6000F21")]
	[Address(RVA = "0x58AAD0", Offset = "0x5894D0", VA = "0x18058AAD0")]
	public static SystemLanguage ISO639ToLanguage(string isoCode)
	{
		return default(SystemLanguage);
	}

	[Token(Token = "0x6000F22")]
	[Address(RVA = "0x58BCA0", Offset = "0x58A6A0", VA = "0x18058BCA0")]
	public static object InvokeMethod(string className, string methodName, params object[] parameters)
	{
		return null;
	}

	[Token(Token = "0x6000F23")]
	[Address(RVA = "0x58C150", Offset = "0x58AB50", VA = "0x18058C150")]
	public static string GetArgument(string name)
	{
		return null;
	}

	[Token(Token = "0x6000F24")]
	[Address(RVA = "0x58C400", Offset = "0x58AE00", VA = "0x18058C400")]
	public static string[] GetArguments()
	{
		return null;
	}

	[Token(Token = "0x6000F25")]
	[Address(RVA = "0x58C520", Offset = "0x58AF20", VA = "0x18058C520")]
	private static string addLeadingZero(int value)
	{
		return null;
	}

	[Token(Token = "0x6000F26")]
	[Address(RVA = "0x4576C0", Offset = "0x4560C0", VA = "0x1804576C0")]
	protected BaseHelper()
	{
	}
}

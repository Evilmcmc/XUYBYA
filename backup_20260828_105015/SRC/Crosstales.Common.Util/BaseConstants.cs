using System.Text.RegularExpressions;
using Il2CppDummyDll;

namespace Crosstales.Common.Util;

[Token(Token = "0x20001D0")]
public abstract class BaseConstants
{
	[Token(Token = "0x4000964")]
	public const string ASSET_AUTHOR = "crosstales LLC";

	[Token(Token = "0x4000965")]
	public const string ASSET_AUTHOR_URL = "https://www.crosstales.com";

	[Token(Token = "0x4000966")]
	public const string ASSET_CT_URL = "https://assetstore.unity.com/lists/crosstales-42213?aid=1011lNGT";

	[Token(Token = "0x4000967")]
	public const string ASSET_SOCIAL_DISCORD = "https://discord.gg/ZbZ2sh4";

	[Token(Token = "0x4000968")]
	public const string ASSET_SOCIAL_FACEBOOK = "https://www.facebook.com/crosstales/";

	[Token(Token = "0x4000969")]
	public const string ASSET_SOCIAL_TWITTER = "https://twitter.com/crosstales";

	[Token(Token = "0x400096A")]
	public const string ASSET_SOCIAL_YOUTUBE = "https://www.youtube.com/c/Crosstales";

	[Token(Token = "0x400096B")]
	public const string ASSET_SOCIAL_LINKEDIN = "https://www.linkedin.com/company/crosstales";

	[Token(Token = "0x400096C")]
	public const string ASSET_3P_PLAYMAKER = "https://assetstore.unity.com/packages/slug/368?aid=1011lNGT";

	[Token(Token = "0x400096D")]
	public const string ASSET_3P_VOLUMETRIC_AUDIO = "https://assetstore.unity.com/packages/slug/17125?aid=1011lNGT";

	[Token(Token = "0x400096E")]
	public const string ASSET_3P_ROCKTOMATE = "https://assetstore.unity.com/packages/slug/156311?aid=1011lNGT";

	[Token(Token = "0x400096F")]
	public const string ASSET_3P_RTFB = "https://assetstore.unity.com/packages/slug/113006?aid=1011lNGT";

	[Token(Token = "0x4000970")]
	public const string ASSET_BWF = "https://assetstore.unity.com/packages/slug/26255?aid=1011lNGT";

	[Token(Token = "0x4000971")]
	public const string ASSET_DJ = "https://assetstore.unity.com/packages/slug/41993?aid=1011lNGT";

	[Token(Token = "0x4000972")]
	public const string ASSET_FB = "https://assetstore.unity.com/packages/slug/98713?aid=1011lNGT";

	[Token(Token = "0x4000973")]
	public const string ASSET_OC = "https://assetstore.unity.com/packages/slug/74688?aid=1011lNGT";

	[Token(Token = "0x4000974")]
	public const string ASSET_RADIO = "https://assetstore.unity.com/packages/slug/32034?aid=1011lNGT";

	[Token(Token = "0x4000975")]
	public const string ASSET_RTV = "https://assetstore.unity.com/packages/slug/41068?aid=1011lNGT";

	[Token(Token = "0x4000976")]
	public const string ASSET_TB = "https://assetstore.unity.com/packages/slug/98711?aid=1011lNGT";

	[Token(Token = "0x4000977")]
	public const string ASSET_TPB = "https://assetstore.unity.com/packages/slug/98714?aid=1011lNGT";

	[Token(Token = "0x4000978")]
	public const string ASSET_TPS = "https://assetstore.unity.com/packages/slug/60040?aid=1011lNGT";

	[Token(Token = "0x4000979")]
	public const string ASSET_TR = "https://assetstore.unity.com/packages/slug/61617?aid=1011lNGT";

	[Token(Token = "0x400097A")]
	public const int FACTOR_KB = 1024;

	[Token(Token = "0x400097B")]
	public const int FACTOR_MB = 1048576;

	[Token(Token = "0x400097C")]
	public const int FACTOR_GB = 1073741824;

	[Token(Token = "0x400097D")]
	public const float FLOAT_32768 = 32768f;

	[Token(Token = "0x400097E")]
	public const float FLOAT_TOLERANCE = 0.0001f;

	[Token(Token = "0x400097F")]
	public const string FORMAT_TWO_DECIMAL_PLACES = "0.00";

	[Token(Token = "0x4000980")]
	public const string FORMAT_NO_DECIMAL_PLACES = "0";

	[Token(Token = "0x4000981")]
	public const string FORMAT_PERCENT = "0%";

	[Token(Token = "0x4000982")]
	public const bool DEFAULT_DEBUG = false;

	[Token(Token = "0x4000983")]
	public const string PATH_DELIMITER_WINDOWS = "\\";

	[Token(Token = "0x4000984")]
	public const string PATH_DELIMITER_UNIX = "/";

	[Token(Token = "0x4000985")]
	[FieldOffset(Offset = "0x0")]
	private static Regex _regexLineEndings;

	[Token(Token = "0x4000986")]
	[FieldOffset(Offset = "0x8")]
	private static Regex _regexEmail;

	[Token(Token = "0x4000987")]
	[FieldOffset(Offset = "0x10")]
	private static Regex _regexCreditCard;

	[Token(Token = "0x4000988")]
	[FieldOffset(Offset = "0x18")]
	private static Regex _regexUrlWeb;

	[Token(Token = "0x4000989")]
	[FieldOffset(Offset = "0x20")]
	private static Regex _regexIPAddress;

	[Token(Token = "0x400098A")]
	[FieldOffset(Offset = "0x28")]
	private static Regex _regexInvalidChars;

	[Token(Token = "0x400098B")]
	[FieldOffset(Offset = "0x30")]
	private static Regex _regexAlpha;

	[Token(Token = "0x400098C")]
	[FieldOffset(Offset = "0x38")]
	private static Regex _regexCleanSpace;

	[Token(Token = "0x400098D")]
	[FieldOffset(Offset = "0x40")]
	private static Regex _regexCleanTags;

	[Token(Token = "0x400098E")]
	[FieldOffset(Offset = "0x48")]
	private static Regex _regexDriveLetters;

	[Token(Token = "0x400098F")]
	[FieldOffset(Offset = "0x50")]
	private static Regex _regexFile;

	[Token(Token = "0x4000990")]
	public const string ALPHABET_LATIN_UPPERCASE = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

	[Token(Token = "0x4000991")]
	public const string ALPHABET_LATIN_LOWERCASE = "abcdefghijklmnopqrstuvwxyz";

	[Token(Token = "0x4000992")]
	public const string ALPHABET_EXT_UPPERCASE = "ÀÂÄÆÇÈÉÊËÎÏÔŒÙÛÜ";

	[Token(Token = "0x4000993")]
	public const string ALPHABET_EXT_LOWERCASE = "àâäæçèéêëîïôœùûü";

	[Token(Token = "0x4000994")]
	[FieldOffset(Offset = "0x58")]
	public static readonly string ALPHABET_LATIN;

	[Token(Token = "0x4000995")]
	public const string NUMBERS = "0123456789";

	[Token(Token = "0x4000996")]
	[FieldOffset(Offset = "0x60")]
	public static readonly string SIGNS;

	[Token(Token = "0x4000997")]
	[FieldOffset(Offset = "0x68")]
	public static bool DEV_DEBUG;

	[Token(Token = "0x4000998")]
	[FieldOffset(Offset = "0x70")]
	public static string TEXT_TOSTRING_START;

	[Token(Token = "0x4000999")]
	[FieldOffset(Offset = "0x78")]
	public static string TEXT_TOSTRING_END;

	[Token(Token = "0x400099A")]
	[FieldOffset(Offset = "0x80")]
	public static string TEXT_TOSTRING_DELIMITER;

	[Token(Token = "0x400099B")]
	[FieldOffset(Offset = "0x88")]
	public static string TEXT_TOSTRING_DELIMITER_END;

	[Token(Token = "0x400099C")]
	public const string PREFIX_HTTP = "http://";

	[Token(Token = "0x400099D")]
	public const string PREFIX_HTTPS = "https://";

	[Token(Token = "0x400099E")]
	[FieldOffset(Offset = "0x90")]
	public static int PROCESS_KILL_TIME;

	[Token(Token = "0x400099F")]
	[FieldOffset(Offset = "0x98")]
	public static string CMD_WINDOWS_PATH;

	[Token(Token = "0x40009A0")]
	[FieldOffset(Offset = "0xA0")]
	public static bool SHOW_BWF_BANNER;

	[Token(Token = "0x40009A1")]
	[FieldOffset(Offset = "0xA1")]
	public static bool SHOW_DJ_BANNER;

	[Token(Token = "0x40009A2")]
	[FieldOffset(Offset = "0xA2")]
	public static bool SHOW_FB_BANNER;

	[Token(Token = "0x40009A3")]
	[FieldOffset(Offset = "0xA3")]
	public static bool SHOW_OC_BANNER;

	[Token(Token = "0x40009A4")]
	[FieldOffset(Offset = "0xA4")]
	public static bool SHOW_RADIO_BANNER;

	[Token(Token = "0x40009A5")]
	[FieldOffset(Offset = "0xA5")]
	public static bool SHOW_RTV_BANNER;

	[Token(Token = "0x40009A6")]
	[FieldOffset(Offset = "0xA6")]
	public static bool SHOW_TB_BANNER;

	[Token(Token = "0x40009A7")]
	[FieldOffset(Offset = "0xA7")]
	public static bool SHOW_TPB_BANNER;

	[Token(Token = "0x40009A8")]
	[FieldOffset(Offset = "0xA8")]
	public static bool SHOW_TPS_BANNER;

	[Token(Token = "0x40009A9")]
	[FieldOffset(Offset = "0xA9")]
	public static bool SHOW_TR_BANNER;

	[Token(Token = "0x1700010A")]
	public static Regex REGEX_LINEENDINGS
	{
		[Token(Token = "0x6000EF0")]
		[Address(RVA = "0x5873F0", Offset = "0x585DF0", VA = "0x1805873F0")]
		get
		{
			return null;
		}
	}

	[Token(Token = "0x1700010B")]
	public static Regex REGEX_EMAIL
	{
		[Token(Token = "0x6000EF1")]
		[Address(RVA = "0x587520", Offset = "0x585F20", VA = "0x180587520")]
		get
		{
			return null;
		}
	}

	[Token(Token = "0x1700010C")]
	public static Regex REGEX_CREDITCARD
	{
		[Token(Token = "0x6000EF2")]
		[Address(RVA = "0x587650", Offset = "0x586050", VA = "0x180587650")]
		get
		{
			return null;
		}
	}

	[Token(Token = "0x1700010D")]
	public static Regex REGEX_URL_WEB
	{
		[Token(Token = "0x6000EF3")]
		[Address(RVA = "0x587780", Offset = "0x586180", VA = "0x180587780")]
		get
		{
			return null;
		}
	}

	[Token(Token = "0x1700010E")]
	public static Regex REGEX_IP_ADDRESS
	{
		[Token(Token = "0x6000EF4")]
		[Address(RVA = "0x5878B0", Offset = "0x5862B0", VA = "0x1805878B0")]
		get
		{
			return null;
		}
	}

	[Token(Token = "0x1700010F")]
	public static Regex REGEX_INVALID_CHARS
	{
		[Token(Token = "0x6000EF5")]
		[Address(RVA = "0x5879E0", Offset = "0x5863E0", VA = "0x1805879E0")]
		get
		{
			return null;
		}
	}

	[Token(Token = "0x17000110")]
	public static Regex REGEX_ALPHANUMERIC
	{
		[Token(Token = "0x6000EF6")]
		[Address(RVA = "0x587B10", Offset = "0x586510", VA = "0x180587B10")]
		get
		{
			return null;
		}
	}

	[Token(Token = "0x17000111")]
	public static Regex REGEX_CLEAN_SPACES
	{
		[Token(Token = "0x6000EF7")]
		[Address(RVA = "0x587C40", Offset = "0x586640", VA = "0x180587C40")]
		get
		{
			return null;
		}
	}

	[Token(Token = "0x17000112")]
	public static Regex REGEX_CLEAN_TAGS
	{
		[Token(Token = "0x6000EF8")]
		[Address(RVA = "0x587D70", Offset = "0x586770", VA = "0x180587D70")]
		get
		{
			return null;
		}
	}

	[Token(Token = "0x17000113")]
	public static Regex REGEX_DRIVE_LETTERS
	{
		[Token(Token = "0x6000EF9")]
		[Address(RVA = "0x587EA0", Offset = "0x5868A0", VA = "0x180587EA0")]
		get
		{
			return null;
		}
	}

	[Token(Token = "0x17000114")]
	public static Regex REGEX_FILE
	{
		[Token(Token = "0x6000EFA")]
		[Address(RVA = "0x587FD0", Offset = "0x5869D0", VA = "0x180587FD0")]
		get
		{
			return null;
		}
	}

	[Token(Token = "0x17000115")]
	public static string PREFIX_FILE
	{
		[Token(Token = "0x6000EFB")]
		[Address(RVA = "0x588100", Offset = "0x586B00", VA = "0x180588100")]
		get
		{
			return null;
		}
	}

	[Token(Token = "0x17000116")]
	public static string APPLICATION_PATH
	{
		[Token(Token = "0x6000EFC")]
		[Address(RVA = "0x5881D0", Offset = "0x586BD0", VA = "0x1805881D0")]
		get
		{
			return null;
		}
	}

	[Token(Token = "0x6000EFD")]
	[Address(RVA = "0x4576C0", Offset = "0x4560C0", VA = "0x1804576C0")]
	protected BaseConstants()
	{
	}
}

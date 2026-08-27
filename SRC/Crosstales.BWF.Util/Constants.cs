using System;
using Crosstales.Common.Util;
using Il2CppDummyDll;

namespace Crosstales.BWF.Util;

[Token(Token = "0x20001EF")]
public abstract class Constants : BaseConstants
{
	[Token(Token = "0x4000A08")]
	public const string ASSET_NAME = "Bad Word Filter PRO";

	[Token(Token = "0x4000A09")]
	public const string ASSET_NAME_SHORT = "BWF PRO";

	[Token(Token = "0x4000A0A")]
	public const string ASSET_VERSION = "2023.2.3";

	[Token(Token = "0x4000A0B")]
	public const int ASSET_BUILD = 20230720;

	[Token(Token = "0x4000A0C")]
	[FieldOffset(Offset = "0x0")]
	public static readonly DateTime ASSET_CREATED;

	[Token(Token = "0x4000A0D")]
	[FieldOffset(Offset = "0x8")]
	public static readonly DateTime ASSET_CHANGED;

	[Token(Token = "0x4000A0E")]
	public const string ASSET_PRO_URL = "https://assetstore.unity.com/packages/slug/26255?aid=1011lNGT";

	[Token(Token = "0x4000A0F")]
	public const string ASSET_UPDATE_CHECK_URL = "https://www.crosstales.com/media/assets/bwf_versions.txt";

	[Token(Token = "0x4000A10")]
	public const string ASSET_CONTACT = "bwf@crosstales.com";

	[Token(Token = "0x4000A11")]
	public const string ASSET_MANUAL_URL = "https://www.crosstales.com/media/data/assets/badwordfilter/BadWordFilter-doc.pdf";

	[Token(Token = "0x4000A12")]
	public const string ASSET_API_URL = "https://www.crosstales.com/en/assets/badwordfilter/api";

	[Token(Token = "0x4000A13")]
	public const string ASSET_FORUM_URL = "https://forum.unity.com/threads/bad-word-filter-pro-solution-against-profanity-and-obscenity.289960/";

	[Token(Token = "0x4000A14")]
	public const string ASSET_WEB_URL = "https://www.crosstales.com/en/portfolio//badwordfilter/";

	[Token(Token = "0x4000A15")]
	public const string ASSET_VIDEO_PROMO = "https://youtu.be/pXICeRKaRPM?list=PLgtonIOr6Tb41XTMeeZ836tjHlKgOO84S";

	[Token(Token = "0x4000A16")]
	public const string ASSET_VIDEO_TUTORIAL = "https://youtu.be/W8FxFlIObWM?list=PLgtonIOr6Tb41XTMeeZ836tjHlKgOO84S";

	[Token(Token = "0x4000A17")]
	public const string KEY_PREFIX = "BWF_CFG_";

	[Token(Token = "0x4000A18")]
	public const string KEY_DEBUG = "BWF_CFG_DEBUG";

	[Token(Token = "0x4000A19")]
	public const string KEY_DEBUG_BADWORDS = "BWF_CFG_DEBUG_BADWORDS";

	[Token(Token = "0x4000A1A")]
	public const string KEY_DEBUG_DOMAINS = "BWF_CFG_DEBUG_DOMAINS";

	[Token(Token = "0x4000A1B")]
	public const bool DEFAULT_DEBUG_BADWORDS = false;

	[Token(Token = "0x4000A1C")]
	public const bool DEFAULT_DEBUG_DOMAINS = false;

	[Token(Token = "0x4000A1D")]
	public const string MANAGER_SCENE_OBJECT_NAME = "BWF";

	[Token(Token = "0x4000A1E")]
	[FieldOffset(Offset = "0x10")]
	public static int WWW_TIMEOUT;

	[Token(Token = "0x600101B")]
	[Address(RVA = "0x59DAC0", Offset = "0x59C4C0", VA = "0x18059DAC0")]
	protected Constants()
	{
	}
}

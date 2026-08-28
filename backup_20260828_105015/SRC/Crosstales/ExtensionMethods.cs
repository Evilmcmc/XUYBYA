using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using Il2CppDummyDll;
using UnityEngine;

namespace Crosstales;

[Token(Token = "0x20001BF")]
public static class ExtensionMethods
{
	[Token(Token = "0x4000914")]
	[Il2CppDummyDll.FieldOffset(Offset = "0x0")]
	private static readonly Vector3 FLAT_VECTOR;

	[Token(Token = "0x6000E42")]
	[Address(RVA = "0x578F30", Offset = "0x577930", VA = "0x180578F30")]
	public static string CTToTitleCase(this string str)
	{
		return null;
	}

	[Token(Token = "0x6000E43")]
	[Address(RVA = "0x579010", Offset = "0x577A10", VA = "0x180579010")]
	public static string CTReverse(this string str)
	{
		return null;
	}

	[Token(Token = "0x6000E44")]
	[Address(RVA = "0x5790E0", Offset = "0x577AE0", VA = "0x1805790E0")]
	public static string CTReplace(this string str, string oldString, string newString, StringComparison comp = StringComparison.OrdinalIgnoreCase)
	{
		return null;
	}

	[Token(Token = "0x6000E45")]
	[Address(RVA = "0x5791C0", Offset = "0x577BC0", VA = "0x1805791C0")]
	public static string CTRemoveChars(this string str, params char[] removeChars)
	{
		return null;
	}

	[Token(Token = "0x6000E46")]
	[Address(RVA = "0x579320", Offset = "0x577D20", VA = "0x180579320")]
	public static bool CTEquals(this string str, string toCheck, StringComparison comp = StringComparison.OrdinalIgnoreCase)
	{
		return default(bool);
	}

	[Token(Token = "0x6000E47")]
	[Address(RVA = "0x579330", Offset = "0x577D30", VA = "0x180579330")]
	public static bool CTContains(this string str, string toCheck, StringComparison comp = StringComparison.OrdinalIgnoreCase)
	{
		return default(bool);
	}

	[Token(Token = "0x6000E48")]
	[Address(RVA = "0x579370", Offset = "0x577D70", VA = "0x180579370")]
	public static bool CTContainsAny(this string str, string searchTerms, char splitChar = ' ')
	{
		return default(bool);
	}

	[Token(Token = "0x6000E49")]
	[Address(RVA = "0x579510", Offset = "0x577F10", VA = "0x180579510")]
	public static bool CTContainsAll(this string str, string searchTerms, char splitChar = ' ')
	{
		return default(bool);
	}

	[Token(Token = "0x6000E4A")]
	[Address(RVA = "0x5796B0", Offset = "0x5780B0", VA = "0x1805796B0")]
	public static string CTRemoveNewLines(this string str, string replacement = "#nl#", [Optional] string newLine)
	{
		return null;
	}

	[Token(Token = "0x6000E4B")]
	[Address(RVA = "0x579710", Offset = "0x578110", VA = "0x180579710")]
	public static string CTAddNewLines(this string str, string replacement = "#nl#", [Optional] string newLine)
	{
		return null;
	}

	[Token(Token = "0x6000E4C")]
	[Address(RVA = "0x579960", Offset = "0x578360", VA = "0x180579960")]
	[Obsolete("Please use 'CTIsNumeric' instead.")]
	public static bool CTisNumeric(this string str)
	{
		return default(bool);
	}

	[Token(Token = "0x6000E4D")]
	[Address(RVA = "0x579A30", Offset = "0x578430", VA = "0x180579A30")]
	public static bool CTIsNumeric(this string str)
	{
		return default(bool);
	}

	[Token(Token = "0x6000E4E")]
	[Address(RVA = "0x579AC0", Offset = "0x5784C0", VA = "0x180579AC0")]
	[Obsolete("Please use 'CTIsInteger' instead.")]
	public static bool CTisInteger(this string str)
	{
		return default(bool);
	}

	[Token(Token = "0x6000E4F")]
	[Address(RVA = "0x579B70", Offset = "0x578570", VA = "0x180579B70")]
	public static bool CTIsInteger(this string str)
	{
		return default(bool);
	}

	[Token(Token = "0x6000E50")]
	[Address(RVA = "0x579BE0", Offset = "0x5785E0", VA = "0x180579BE0")]
	[Obsolete("Please use 'CTIsEmail' instead.")]
	public static bool CTisEmail(this string str)
	{
		return default(bool);
	}

	[Token(Token = "0x6000E51")]
	[Address(RVA = "0x579C30", Offset = "0x578630", VA = "0x180579C30")]
	public static bool CTIsEmail(this string str)
	{
		return default(bool);
	}

	[Token(Token = "0x6000E52")]
	[Address(RVA = "0x579DF0", Offset = "0x5787F0", VA = "0x180579DF0")]
	[Obsolete("Please use 'CTIsWebsite' instead.")]
	public static bool CTisWebsite(this string str)
	{
		return default(bool);
	}

	[Token(Token = "0x6000E53")]
	[Address(RVA = "0x579E40", Offset = "0x578840", VA = "0x180579E40")]
	public static bool CTIsWebsite(this string str)
	{
		return default(bool);
	}

	[Token(Token = "0x6000E54")]
	[Address(RVA = "0x57A000", Offset = "0x578A00", VA = "0x18057A000")]
	[Obsolete("Please use 'CTIsCreditcard' instead.")]
	public static bool CTisCreditcard(this string str)
	{
		return default(bool);
	}

	[Token(Token = "0x6000E55")]
	[Address(RVA = "0x57A050", Offset = "0x578A50", VA = "0x18057A050")]
	public static bool CTIsCreditcard(this string str)
	{
		return default(bool);
	}

	[Token(Token = "0x6000E56")]
	[Address(RVA = "0x57A210", Offset = "0x578C10", VA = "0x18057A210")]
	[Obsolete("Please use 'CTIsIPv4' instead.")]
	public static bool CTisIPv4(this string str)
	{
		return default(bool);
	}

	[Token(Token = "0x6000E57")]
	[Address(RVA = "0x57A270", Offset = "0x578C70", VA = "0x18057A270")]
	public static bool CTIsIPv4(this string str)
	{
		return default(bool);
	}

	[Token(Token = "0x6000E58")]
	[Address(RVA = "0x57A280", Offset = "0x578C80", VA = "0x18057A280")]
	[Obsolete("Please use 'CTIsAlphanumeric' instead.")]
	public static bool CTisAlphanumeric(this string str)
	{
		return default(bool);
	}

	[Token(Token = "0x6000E59")]
	[Address(RVA = "0x57A2D0", Offset = "0x578CD0", VA = "0x18057A2D0")]
	public static bool CTIsAlphanumeric(this string str)
	{
		return default(bool);
	}

	[Token(Token = "0x6000E5A")]
	[Address(RVA = "0x57A490", Offset = "0x578E90", VA = "0x18057A490")]
	[Obsolete("Please use 'CTHasLineEndings' instead.")]
	public static bool CThasLineEndings(this string str)
	{
		return default(bool);
	}

	[Token(Token = "0x6000E5B")]
	[Address(RVA = "0x57A570", Offset = "0x578F70", VA = "0x18057A570")]
	public static bool CTHasLineEndings(this string str)
	{
		return default(bool);
	}

	[Token(Token = "0x6000E5C")]
	[Address(RVA = "0x57A620", Offset = "0x579020", VA = "0x18057A620")]
	[Obsolete("Please use 'CTHasInvalidChars' instead.")]
	public static bool CThasInvalidChars(this string str)
	{
		return default(bool);
	}

	[Token(Token = "0x6000E5D")]
	[Address(RVA = "0x57A670", Offset = "0x579070", VA = "0x18057A670")]
	public static bool CTHasInvalidChars(this string str)
	{
		return default(bool);
	}

	[Token(Token = "0x6000E5E")]
	[Address(RVA = "0x57A830", Offset = "0x579230", VA = "0x18057A830")]
	public static bool CTStartsWith(this string str, string toCheck, StringComparison comp = StringComparison.OrdinalIgnoreCase)
	{
		return default(bool);
	}

	[Token(Token = "0x6000E5F")]
	[Address(RVA = "0x57A850", Offset = "0x579250", VA = "0x18057A850")]
	public static bool CTEndsWith(this string str, string toCheck, StringComparison comp = StringComparison.OrdinalIgnoreCase)
	{
		return default(bool);
	}

	[Token(Token = "0x6000E60")]
	[Address(RVA = "0x57A870", Offset = "0x579270", VA = "0x18057A870")]
	public static int CTLastIndexOf(this string str, string toCheck, StringComparison comp = StringComparison.OrdinalIgnoreCase)
	{
		return default(int);
	}

	[Token(Token = "0x6000E61")]
	[Address(RVA = "0x57A910", Offset = "0x579310", VA = "0x18057A910")]
	public static int CTIndexOf(this string str, string toCheck, StringComparison comp = StringComparison.OrdinalIgnoreCase)
	{
		return default(int);
	}

	[Token(Token = "0x6000E62")]
	[Address(RVA = "0x57A9A0", Offset = "0x5793A0", VA = "0x18057A9A0")]
	public static int CTIndexOf(this string str, string toCheck, int startIndex, StringComparison comp = StringComparison.OrdinalIgnoreCase)
	{
		return default(int);
	}

	[Token(Token = "0x6000E63")]
	[Address(RVA = "0x57AA30", Offset = "0x579430", VA = "0x18057AA30")]
	public static string CTToBase64(this string str, [Optional] Encoding encoding)
	{
		return null;
	}

	[Token(Token = "0x6000E64")]
	[Address(RVA = "0x57AB90", Offset = "0x579590", VA = "0x18057AB90")]
	public static string CTFromBase64(this string str, [Optional] Encoding encoding)
	{
		return null;
	}

	[Token(Token = "0x6000E65")]
	[Address(RVA = "0x57ACC0", Offset = "0x5796C0", VA = "0x18057ACC0")]
	public static byte[] CTFromBase64ToByteArray(this string str)
	{
		return null;
	}

	[Token(Token = "0x6000E66")]
	[Address(RVA = "0x57AD70", Offset = "0x579770", VA = "0x18057AD70")]
	public static string CTToHex(this string str, bool addPrefix = false)
	{
		return null;
	}

	[Token(Token = "0x6000E67")]
	[Address(RVA = "0x57AF90", Offset = "0x579990", VA = "0x18057AF90")]
	public static string CTHexToString(this string hexString)
	{
		return null;
	}

	[Token(Token = "0x6000E68")]
	[Address(RVA = "0x57B160", Offset = "0x579B60", VA = "0x18057B160")]
	public static Color32 CTHexToColor32(this string hexString)
	{
		return default(Color32);
	}

	[Token(Token = "0x6000E69")]
	[Address(RVA = "0x57B6D0", Offset = "0x57A0D0", VA = "0x18057B6D0")]
	public static Color CTHexToColor(this string hexString)
	{
		return default(Color);
	}

	[Token(Token = "0x6000E6A")]
	[Address(RVA = "0x57B7A0", Offset = "0x57A1A0", VA = "0x18057B7A0")]
	public static byte[] CTToByteArray(this string str, [Optional] Encoding encoding)
	{
		return null;
	}

	[Token(Token = "0x6000E6B")]
	[Address(RVA = "0x57B800", Offset = "0x57A200", VA = "0x18057B800")]
	public static string CTClearTags(this string str)
	{
		return null;
	}

	[Token(Token = "0x6000E6C")]
	[Address(RVA = "0x57B9D0", Offset = "0x57A3D0", VA = "0x18057B9D0")]
	public static string CTClearSpaces(this string str)
	{
		return null;
	}

	[Token(Token = "0x6000E6D")]
	[Address(RVA = "0x57BBB0", Offset = "0x57A5B0", VA = "0x18057BBB0")]
	public static string CTClearLineEndings(this string str)
	{
		return null;
	}

	[Token(Token = "0x6000E6E")]
	public static void CTShuffle<T>(this T[] array, int seed = 0)
	{
	}

	[Token(Token = "0x6000E6F")]
	public static string CTDump<T>(this T[] array, string prefix = "", string postfix = "", bool appendNewLine = true, string delimiter = "; ")
	{
		return null;
	}

	[Token(Token = "0x6000E70")]
	[Address(RVA = "0x57BC70", Offset = "0x57A670", VA = "0x18057BC70")]
	public static string CTDump(this Quaternion[] array)
	{
		return null;
	}

	[Token(Token = "0x6000E71")]
	[Address(RVA = "0x57BDF0", Offset = "0x57A7F0", VA = "0x18057BDF0")]
	public static string CTDump(this Vector2[] array)
	{
		return null;
	}

	[Token(Token = "0x6000E72")]
	[Address(RVA = "0x57BF30", Offset = "0x57A930", VA = "0x18057BF30")]
	public static string CTDump(this Vector3[] array)
	{
		return null;
	}

	[Token(Token = "0x6000E73")]
	[Address(RVA = "0x57C0A0", Offset = "0x57AAA0", VA = "0x18057C0A0")]
	public static string CTDump(this Vector4[] array)
	{
		return null;
	}

	[Token(Token = "0x6000E74")]
	public static string[] CTToStringArray<T>(this T[] array)
	{
		return null;
	}

	[Token(Token = "0x6000E75")]
	[Address(RVA = "0x57C220", Offset = "0x57AC20", VA = "0x18057C220")]
	public static float[] CTToFloatArray(this byte[] array, int count = 0)
	{
		return null;
	}

	[Token(Token = "0x6000E76")]
	[Address(RVA = "0x57C3C0", Offset = "0x57ADC0", VA = "0x18057C3C0")]
	public static byte[] CTToByteArray(this float[] array, int count = 0)
	{
		return null;
	}

	[Token(Token = "0x6000E77")]
	[Address(RVA = "0x57C4E0", Offset = "0x57AEE0", VA = "0x18057C4E0")]
	public static Texture2D CTToTexture(this byte[] data, [Optional] Texture2D supportTexture)
	{
		return null;
	}

	[Token(Token = "0x6000E78")]
	[Address(RVA = "0x57C640", Offset = "0x57B040", VA = "0x18057C640")]
	public static Sprite CTToSprite(this byte[] data, [Optional] Texture2D supportTexture)
	{
		return null;
	}

	[Token(Token = "0x6000E79")]
	[Address(RVA = "0x57C8E0", Offset = "0x57B2E0", VA = "0x18057C8E0")]
	public static string CTToString(this byte[] data, [Optional] Encoding encoding)
	{
		return null;
	}

	[Token(Token = "0x6000E7A")]
	[Address(RVA = "0x57C940", Offset = "0x57B340", VA = "0x18057C940")]
	public static string CTToBase64(this byte[] data)
	{
		return null;
	}

	[Token(Token = "0x6000E7B")]
	public static T[] GetColumn<T>(this T[,] matrix, int columnNumber)
	{
		return null;
	}

	[Token(Token = "0x6000E7C")]
	public static T[] GetRow<T>(this T[,] matrix, int rowNumber)
	{
		return null;
	}

	[Token(Token = "0x6000E7D")]
	public static void CTShuffle<T>(this IList<T> list, int seed = 0)
	{
	}

	[Token(Token = "0x6000E7E")]
	public static string CTDump<T>(this IList<T> list, string prefix = "", string postfix = "", bool appendNewLine = true, string delimiter = "; ")
	{
		return null;
	}

	[Token(Token = "0x6000E7F")]
	[Address(RVA = "0x57CA10", Offset = "0x57B410", VA = "0x18057CA10")]
	public static string CTDump(this IList<Quaternion> list)
	{
		return null;
	}

	[Token(Token = "0x6000E80")]
	[Address(RVA = "0x57CCF0", Offset = "0x57B6F0", VA = "0x18057CCF0")]
	public static string CTDump(this IList<Vector2> list)
	{
		return null;
	}

	[Token(Token = "0x6000E81")]
	[Address(RVA = "0x57CF90", Offset = "0x57B990", VA = "0x18057CF90")]
	public static string CTDump(this IList<Vector3> list)
	{
		return null;
	}

	[Token(Token = "0x6000E82")]
	[Address(RVA = "0x57D260", Offset = "0x57BC60", VA = "0x18057D260")]
	public static string CTDump(this IList<Vector4> list)
	{
		return null;
	}

	[Token(Token = "0x6000E83")]
	public static List<string> CTToString<T>(this IList<T> list)
	{
		return null;
	}

	[Token(Token = "0x6000E84")]
	public static string CTDump<K, V>(this IDictionary<K, V> dict, string prefix = "", string postfix = "", bool appendNewLine = true, string delimiter = "; ")
	{
		return null;
	}

	[Token(Token = "0x6000E85")]
	public static void CTAddRange<K, V>(this IDictionary<K, V> dict, IDictionary<K, V> collection)
	{
	}

	[Token(Token = "0x6000E86")]
	[Address(RVA = "0x57D540", Offset = "0x57BF40", VA = "0x18057D540")]
	public static byte[] CTReadFully(this Stream input)
	{
		return null;
	}

	[Token(Token = "0x6000E87")]
	[Address(RVA = "0x57D6C0", Offset = "0x57C0C0", VA = "0x18057D6C0")]
	public static string CTToHexRGB(this Color32 input)
	{
		return null;
	}

	[Token(Token = "0x6000E88")]
	[Address(RVA = "0x57D780", Offset = "0x57C180", VA = "0x18057D780")]
	public static string CTToHexRGB(this Color input)
	{
		return null;
	}

	[Token(Token = "0x6000E89")]
	[Address(RVA = "0x57D7A0", Offset = "0x57C1A0", VA = "0x18057D7A0")]
	public static string CTToHexRGBA(this Color32 input)
	{
		return null;
	}

	[Token(Token = "0x6000E8A")]
	[Address(RVA = "0x57D860", Offset = "0x57C260", VA = "0x18057D860")]
	public static string CTToHexRGBA(this Color input)
	{
		return null;
	}

	[Token(Token = "0x6000E8B")]
	[Address(RVA = "0x57D880", Offset = "0x57C280", VA = "0x18057D880")]
	public static Vector3 CTVector3(this Color32 color)
	{
		return default(Vector3);
	}

	[Token(Token = "0x6000E8C")]
	[Address(RVA = "0x57D940", Offset = "0x57C340", VA = "0x18057D940")]
	public static Vector3 CTVector3(this Color color)
	{
		return default(Vector3);
	}

	[Token(Token = "0x6000E8D")]
	[Address(RVA = "0x57D960", Offset = "0x57C360", VA = "0x18057D960")]
	public static Vector4 CTVector4(this Color32 color)
	{
		return default(Vector4);
	}

	[Token(Token = "0x6000E8E")]
	[Address(RVA = "0x57DA60", Offset = "0x57C460", VA = "0x18057DA60")]
	public static Vector4 CTVector4(this Color color)
	{
		return default(Vector4);
	}

	[Token(Token = "0x6000E8F")]
	[Address(RVA = "0x57DA80", Offset = "0x57C480", VA = "0x18057DA80")]
	public static Vector2 CTMultiply(this Vector2 a, Vector2 b)
	{
		return default(Vector2);
	}

	[Token(Token = "0x6000E90")]
	[Address(RVA = "0x57DAC0", Offset = "0x57C4C0", VA = "0x18057DAC0")]
	public static Vector3 CTMultiply(this Vector3 a, Vector3 b)
	{
		return default(Vector3);
	}

	[Token(Token = "0x6000E91")]
	[Address(RVA = "0x57DB00", Offset = "0x57C500", VA = "0x18057DB00")]
	public static Vector3 CTFlatten(this Vector3 a)
	{
		return default(Vector3);
	}

	[Token(Token = "0x6000E92")]
	[Address(RVA = "0x57DBA0", Offset = "0x57C5A0", VA = "0x18057DBA0")]
	public static Quaternion CTQuaternion(this Vector3 eulerAngle)
	{
		return default(Quaternion);
	}

	[Token(Token = "0x6000E93")]
	[Address(RVA = "0x57DC50", Offset = "0x57C650", VA = "0x18057DC50")]
	public static Color CTColorRGB(this Vector3 rgb, float alpha = 1f)
	{
		return default(Color);
	}

	[Token(Token = "0x6000E94")]
	[Address(RVA = "0x57DCD0", Offset = "0x57C6D0", VA = "0x18057DCD0")]
	public static Vector4 CTMultiply(this Vector4 a, Vector4 b)
	{
		return default(Vector4);
	}

	[Token(Token = "0x6000E95")]
	[Address(RVA = "0x57DA60", Offset = "0x57C460", VA = "0x18057DA60")]
	public static Quaternion CTQuaternion(this Vector4 angle)
	{
		return default(Quaternion);
	}

	[Token(Token = "0x6000E96")]
	[Address(RVA = "0x57DD20", Offset = "0x57C720", VA = "0x18057DD20")]
	public static Color CTColorRGBA(this Vector4 rgba)
	{
		return default(Color);
	}

	[Token(Token = "0x6000E97")]
	[Address(RVA = "0x57DDA0", Offset = "0x57C7A0", VA = "0x18057DDA0")]
	public static Vector3 CTVector3(this Quaternion angle)
	{
		return default(Vector3);
	}

	[Token(Token = "0x6000E98")]
	[Address(RVA = "0x57DA60", Offset = "0x57C460", VA = "0x18057DA60")]
	public static Vector4 CTVector4(this Quaternion angle)
	{
		return default(Vector4);
	}

	[Token(Token = "0x6000E99")]
	[Address(RVA = "0x57DDD0", Offset = "0x57C7D0", VA = "0x18057DDD0")]
	public static Vector3 CTCorrectLossyScale(this Canvas canvas)
	{
		return default(Vector3);
	}

	[Token(Token = "0x6000E9A")]
	[Address(RVA = "0x57E1F0", Offset = "0x57CBF0", VA = "0x18057E1F0")]
	public static void CTGetLocalCorners(this RectTransform transform, Vector3[] fourCornersArray, Canvas canvas, float inset = 0f, bool corrected = false)
	{
	}

	[Token(Token = "0x6000E9B")]
	[Address(RVA = "0x57E660", Offset = "0x57D060", VA = "0x18057E660")]
	public static Vector3[] CTGetLocalCorners(this RectTransform transform, Canvas canvas, float inset = 0f, bool corrected = false)
	{
		return null;
	}

	[Token(Token = "0x6000E9C")]
	[Address(RVA = "0x57E720", Offset = "0x57D120", VA = "0x18057E720")]
	public static void CTGetScreenCorners(this RectTransform transform, Vector3[] fourCornersArray, Canvas canvas, float inset = 0f, bool corrected = false)
	{
	}

	[Token(Token = "0x6000E9D")]
	[Address(RVA = "0x57ECF0", Offset = "0x57D6F0", VA = "0x18057ECF0")]
	public static Vector3[] CTGetScreenCorners(this RectTransform transform, Canvas canvas, float inset = 0f, bool corrected = false)
	{
		return null;
	}

	[Token(Token = "0x6000E9E")]
	[Address(RVA = "0x57EDB0", Offset = "0x57D7B0", VA = "0x18057EDB0")]
	public static Bounds CTGetBounds(this RectTransform transform, float uiScaleFactor = 1f)
	{
		return default(Bounds);
	}

	[Token(Token = "0x6000E9F")]
	[Address(RVA = "0x57F4D0", Offset = "0x57DED0", VA = "0x18057F4D0")]
	public static void CTSetLeft(this RectTransform transform, float value)
	{
	}

	[Token(Token = "0x6000EA0")]
	[Address(RVA = "0x57F610", Offset = "0x57E010", VA = "0x18057F610")]
	public static void CTSetRight(this RectTransform transform, float value)
	{
	}

	[Token(Token = "0x6000EA1")]
	[Address(RVA = "0x57F750", Offset = "0x57E150", VA = "0x18057F750")]
	public static void CTSetTop(this RectTransform transform, float value)
	{
	}

	[Token(Token = "0x6000EA2")]
	[Address(RVA = "0x57F890", Offset = "0x57E290", VA = "0x18057F890")]
	public static void CTSetBottom(this RectTransform transform, float value)
	{
	}

	[Token(Token = "0x6000EA3")]
	[Address(RVA = "0x57F9D0", Offset = "0x57E3D0", VA = "0x18057F9D0")]
	public static float CTGetLeft(this RectTransform transform)
	{
		return default(float);
	}

	[Token(Token = "0x6000EA4")]
	[Address(RVA = "0x57FAF0", Offset = "0x57E4F0", VA = "0x18057FAF0")]
	public static float CTGetRight(this RectTransform transform)
	{
		return default(float);
	}

	[Token(Token = "0x6000EA5")]
	[Address(RVA = "0x57FC10", Offset = "0x57E610", VA = "0x18057FC10")]
	public static float CTGetTop(this RectTransform transform)
	{
		return default(float);
	}

	[Token(Token = "0x6000EA6")]
	[Address(RVA = "0x57FD30", Offset = "0x57E730", VA = "0x18057FD30")]
	public static float CTGetBottom(this RectTransform transform)
	{
		return default(float);
	}

	[Token(Token = "0x6000EA7")]
	[Address(RVA = "0x57FE50", Offset = "0x57E850", VA = "0x18057FE50")]
	public static Vector4 CTGetLRTB(this RectTransform transform)
	{
		return default(Vector4);
	}

	[Token(Token = "0x6000EA8")]
	[Address(RVA = "0x57FFD0", Offset = "0x57E9D0", VA = "0x18057FFD0")]
	public static void CTSetLRTB(this RectTransform transform, Vector4 lrtb)
	{
	}

	[Token(Token = "0x6000EA9")]
	[Address(RVA = "0x580120", Offset = "0x57EB20", VA = "0x180580120")]
	public static List<GameObject> CTFindAll(this Component component, string name, int maxDepth = 0)
	{
		return null;
	}

	[Token(Token = "0x6000EAA")]
	public static List<T> CTFindAll<T>(this Component component, string name) where T : Component
	{
		return null;
	}

	[Token(Token = "0x6000EAB")]
	[Address(RVA = "0x580680", Offset = "0x57F080", VA = "0x180580680")]
	public static GameObject CTFind(this MonoBehaviour mb, string name)
	{
		return null;
	}

	[Token(Token = "0x6000EAC")]
	public static T CTFind<T>(this MonoBehaviour mb, string name)
	{
		return (T)null;
	}

	[Token(Token = "0x6000EAD")]
	[Address(RVA = "0x5807F0", Offset = "0x57F1F0", VA = "0x1805807F0")]
	public static GameObject CTFind(this GameObject go, string name)
	{
		return null;
	}

	[Token(Token = "0x6000EAE")]
	public static T CTFind<T>(this GameObject go, string name)
	{
		return (T)null;
	}

	[Token(Token = "0x6000EAF")]
	[Address(RVA = "0x580960", Offset = "0x57F360", VA = "0x180580960")]
	public static Bounds CTGetBounds(this GameObject go)
	{
		return default(Bounds);
	}

	[Token(Token = "0x6000EB0")]
	[Address(RVA = "0x581060", Offset = "0x57FA60", VA = "0x180581060")]
	public static Transform CTFind(this Transform transform, string name)
	{
		return null;
	}

	[Token(Token = "0x6000EB1")]
	public static T CTFind<T>(this Transform transform, string name)
	{
		return (T)null;
	}

	[Token(Token = "0x6000EB2")]
	[Address(RVA = "0x581200", Offset = "0x57FC00", VA = "0x180581200")]
	public static byte[] CTToPNG(this Sprite sprite)
	{
		return null;
	}

	[Token(Token = "0x6000EB3")]
	[Address(RVA = "0x581450", Offset = "0x57FE50", VA = "0x180581450")]
	public static byte[] CTToJPG(this Sprite sprite)
	{
		return null;
	}

	[Token(Token = "0x6000EB4")]
	[Address(RVA = "0x5816A0", Offset = "0x5800A0", VA = "0x1805816A0")]
	public static byte[] CTToTGA(this Sprite sprite)
	{
		return null;
	}

	[Token(Token = "0x6000EB5")]
	[Address(RVA = "0x5818F0", Offset = "0x5802F0", VA = "0x1805818F0")]
	public static byte[] CTToEXR(this Sprite sprite)
	{
		return null;
	}

	[Token(Token = "0x6000EB6")]
	[Address(RVA = "0x581B40", Offset = "0x580540", VA = "0x180581B40")]
	public static byte[] CTToPNG(this Texture2D texture)
	{
		return null;
	}

	[Token(Token = "0x6000EB7")]
	[Address(RVA = "0x581C50", Offset = "0x580650", VA = "0x180581C50")]
	public static byte[] CTToJPG(this Texture2D texture)
	{
		return null;
	}

	[Token(Token = "0x6000EB8")]
	[Address(RVA = "0x581D70", Offset = "0x580770", VA = "0x180581D70")]
	public static byte[] CTToTGA(this Texture2D texture)
	{
		return null;
	}

	[Token(Token = "0x6000EB9")]
	[Address(RVA = "0x581E80", Offset = "0x580880", VA = "0x180581E80")]
	public static byte[] CTToEXR(this Texture2D texture)
	{
		return null;
	}

	[Token(Token = "0x6000EBA")]
	[Address(RVA = "0x581FA0", Offset = "0x5809A0", VA = "0x180581FA0")]
	public static Sprite CTToSprite(this Texture2D texture, float pixelsPerUnit = 100f)
	{
		return null;
	}

	[Token(Token = "0x6000EBB")]
	[Address(RVA = "0x582170", Offset = "0x580B70", VA = "0x180582170")]
	public static Texture2D CTRotate90(this Texture2D texture)
	{
		return null;
	}

	[Token(Token = "0x6000EBC")]
	[Address(RVA = "0x5825E0", Offset = "0x580FE0", VA = "0x1805825E0")]
	public static Texture2D CTRotate180(this Texture2D texture)
	{
		return null;
	}

	[Token(Token = "0x6000EBD")]
	[Address(RVA = "0x582950", Offset = "0x581350", VA = "0x180582950")]
	public static Texture2D CTRotate270(this Texture2D texture)
	{
		return null;
	}

	[Token(Token = "0x6000EBE")]
	[Address(RVA = "0x582D40", Offset = "0x581740", VA = "0x180582D40")]
	public static Texture2D CTToTexture2D(this Texture texture)
	{
		return null;
	}

	[Token(Token = "0x6000EBF")]
	[Address(RVA = "0x583030", Offset = "0x581A30", VA = "0x180583030")]
	public static Texture2D CTFlipHorizontal(this Texture2D texture)
	{
		return null;
	}

	[Token(Token = "0x6000EC0")]
	[Address(RVA = "0x5831D0", Offset = "0x581BD0", VA = "0x1805831D0")]
	public static Texture2D CTFlipVertical(this Texture2D texture)
	{
		return null;
	}

	[Token(Token = "0x6000EC1")]
	[Address(RVA = "0x583370", Offset = "0x581D70", VA = "0x180583370")]
	public static bool CTHasActiveClip(this AudioSource source)
	{
		return default(bool);
	}

	[Token(Token = "0x6000EC2")]
	[Address(RVA = "0x583630", Offset = "0x582030", VA = "0x180583630")]
	public static void CTAbort(this Thread thread, bool silent = true)
	{
	}

	[Token(Token = "0x6000EC3")]
	[Address(RVA = "0x583710", Offset = "0x582110", VA = "0x180583710")]
	public static bool CTIsVisibleFrom(this Renderer renderer, Camera camera)
	{
		return default(bool);
	}

	[Token(Token = "0x6000EC4")]
	[Address(RVA = "0x583A10", Offset = "0x582410", VA = "0x180583A10")]
	private static Transform deepSearch(Transform parent, string name)
	{
		return null;
	}

	[Token(Token = "0x6000EC5")]
	[Address(RVA = "0x583DC0", Offset = "0x5827C0", VA = "0x180583DC0")]
	private static List<Transform> getAllChildren(this Transform parent, int maxDepth = 0, [Optional] List<Transform> transformList, int depth = 0)
	{
		return null;
	}

	[Token(Token = "0x6000EC6")]
	[Address(RVA = "0x584120", Offset = "0x582B20", VA = "0x180584120")]
	private static float bytesToFloat(byte firstByte, byte secondByte)
	{
		return default(float);
	}
}

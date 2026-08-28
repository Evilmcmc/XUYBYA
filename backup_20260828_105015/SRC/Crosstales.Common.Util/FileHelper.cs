using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using Il2CppDummyDll;
using UnityEngine;

namespace Crosstales.Common.Util;

[Token(Token = "0x20001D5")]
public static class FileHelper
{
	[Token(Token = "0x40009B2")]
	[Il2CppDummyDll.FieldOffset(Offset = "0x0")]
	private static string _applicationDataPath;

	[Token(Token = "0x40009B3")]
	[Il2CppDummyDll.FieldOffset(Offset = "0x8")]
	private static string _applicationTempPath;

	[Token(Token = "0x40009B4")]
	[Il2CppDummyDll.FieldOffset(Offset = "0x10")]
	private static string _applicationPersistentPath;

	[Token(Token = "0x40009B5")]
	[Il2CppDummyDll.FieldOffset(Offset = "0x18")]
	private static char[] _invalidFilenameChars;

	[Token(Token = "0x40009B6")]
	[Il2CppDummyDll.FieldOffset(Offset = "0x20")]
	private static char[] _invalidPathChars;

	[Token(Token = "0x17000133")]
	public static string StreamingAssetsPath
	{
		[Token(Token = "0x6000F4E")]
		[Address(RVA = "0x58E6A0", Offset = "0x58D0A0", VA = "0x18058E6A0")]
		get
		{
			return null;
		}
	}

	[Token(Token = "0x17000134")]
	public static string ApplicationDataPath
	{
		[Token(Token = "0x6000F4F")]
		[Address(RVA = "0x58E7D0", Offset = "0x58D1D0", VA = "0x18058E7D0")]
		get
		{
			return null;
		}
	}

	[Token(Token = "0x17000135")]
	public static string ApplicationTempPath
	{
		[Token(Token = "0x6000F50")]
		[Address(RVA = "0x58E810", Offset = "0x58D210", VA = "0x18058E810")]
		get
		{
			return null;
		}
	}

	[Token(Token = "0x17000136")]
	public static string ApplicationPersistentPath
	{
		[Token(Token = "0x6000F51")]
		[Address(RVA = "0x58E850", Offset = "0x58D250", VA = "0x18058E850")]
		get
		{
			return null;
		}
	}

	[Token(Token = "0x17000137")]
	public static string TempFile
	{
		[Token(Token = "0x6000F52")]
		[Address(RVA = "0x58E890", Offset = "0x58D290", VA = "0x18058E890")]
		get
		{
			return null;
		}
	}

	[Token(Token = "0x17000138")]
	public static string TempPath
	{
		[Token(Token = "0x6000F53")]
		[Address(RVA = "0x58E8E0", Offset = "0x58D2E0", VA = "0x18058E8E0")]
		get
		{
			return null;
		}
	}

	[Token(Token = "0x6000F54")]
	[Address(RVA = "0x58E930", Offset = "0x58D330", VA = "0x18058E930")]
	[RuntimeInitializeOnLoadMethod]
	private static void initialize()
	{
	}

	[Token(Token = "0x6000F55")]
	[Address(RVA = "0x58F0F0", Offset = "0x58DAF0", VA = "0x18058F0F0")]
	public static bool isUnixPath(string path)
	{
		return default(bool);
	}

	[Token(Token = "0x6000F56")]
	[Address(RVA = "0x58F150", Offset = "0x58DB50", VA = "0x18058F150")]
	public static bool isWindowsPath(string path)
	{
		return default(bool);
	}

	[Token(Token = "0x6000F57")]
	[Address(RVA = "0x58F320", Offset = "0x58DD20", VA = "0x18058F320")]
	public static bool isUNCPath(string path)
	{
		return default(bool);
	}

	[Token(Token = "0x6000F58")]
	[Address(RVA = "0x58F380", Offset = "0x58DD80", VA = "0x18058F380")]
	public static bool isURL(string path)
	{
		return default(bool);
	}

	[Token(Token = "0x6000F59")]
	[Address(RVA = "0x58F390", Offset = "0x58DD90", VA = "0x18058F390")]
	public static string ValidatePath(string path, bool addEndDelimiter = true, bool preserveFile = true, bool removeInvalidChars = true)
	{
		return null;
	}

	[Token(Token = "0x6000F5A")]
	[Address(RVA = "0x58F6A0", Offset = "0x58E0A0", VA = "0x18058F6A0")]
	public static string ValidateFile(string path, bool removeInvalidChars = true)
	{
		return null;
	}

	[Token(Token = "0x6000F5B")]
	[Address(RVA = "0x58FD60", Offset = "0x58E760", VA = "0x18058FD60")]
	public static bool HasPathInvalidChars(string path, bool ignoreNullOrEmpty = true)
	{
		return default(bool);
	}

	[Token(Token = "0x6000F5C")]
	[Address(RVA = "0x58FDF0", Offset = "0x58E7F0", VA = "0x18058FDF0")]
	public static bool HasFileInvalidChars(string file, bool ignoreNullOrEmpty = true)
	{
		return default(bool);
	}

	[Token(Token = "0x6000F5D")]
	[Address(RVA = "0x58FEC0", Offset = "0x58E8C0", VA = "0x18058FEC0")]
	public static string[] GetFilesForName(string path, bool isRecursive = false, params string[] filenames)
	{
		return null;
	}

	[Token(Token = "0x6000F5E")]
	[Address(RVA = "0x5904D0", Offset = "0x58EED0", VA = "0x1805904D0")]
	public static string[] GetFiles(string path, bool isRecursive = false, params string[] extensions)
	{
		return null;
	}

	[Token(Token = "0x6000F5F")]
	[Address(RVA = "0x5906E0", Offset = "0x58F0E0", VA = "0x1805906E0")]
	public static string[] GetDirectories(string path, bool isRecursive = false)
	{
		return null;
	}

	[Token(Token = "0x6000F60")]
	[Address(RVA = "0x590960", Offset = "0x58F360", VA = "0x180590960")]
	public static string[] GetDrives()
	{
		return null;
	}

	[Token(Token = "0x6000F61")]
	[Address(RVA = "0x590AE0", Offset = "0x58F4E0", VA = "0x180590AE0")]
	public static bool CopyDirectory(string sourceDir, string destDir, bool move = false)
	{
		return default(bool);
	}

	[Token(Token = "0x6000F62")]
	[Address(RVA = "0x590F10", Offset = "0x58F910", VA = "0x180590F10")]
	public static bool CopyFile(string sourceFile, string destFile, bool move = false)
	{
		return default(bool);
	}

	[Token(Token = "0x6000F63")]
	[Address(RVA = "0x5912D0", Offset = "0x58FCD0", VA = "0x1805912D0")]
	public static bool MoveDirectory(string sourceDir, string destDir)
	{
		return default(bool);
	}

	[Token(Token = "0x6000F64")]
	[Address(RVA = "0x5912E0", Offset = "0x58FCE0", VA = "0x1805912E0")]
	public static bool MoveFile(string sourceFile, string destFile)
	{
		return default(bool);
	}

	[Token(Token = "0x6000F65")]
	[Address(RVA = "0x5912F0", Offset = "0x58FCF0", VA = "0x1805912F0")]
	public static string RenameDirectory(string path, string newName)
	{
		return null;
	}

	[Token(Token = "0x6000F66")]
	[Address(RVA = "0x591560", Offset = "0x58FF60", VA = "0x180591560")]
	public static string RenameFile(string path, string newName)
	{
		return null;
	}

	[Token(Token = "0x6000F67")]
	[Address(RVA = "0x591760", Offset = "0x590160", VA = "0x180591760")]
	public static bool DeleteFile(string file)
	{
		return default(bool);
	}

	[Token(Token = "0x6000F68")]
	[Address(RVA = "0x591940", Offset = "0x590340", VA = "0x180591940")]
	public static bool DeleteDirectory(string dir)
	{
		return default(bool);
	}

	[Token(Token = "0x6000F69")]
	[Address(RVA = "0x591C40", Offset = "0x590640", VA = "0x180591C40")]
	public static bool ExistsFile(string file)
	{
		return default(bool);
	}

	[Token(Token = "0x6000F6A")]
	[Address(RVA = "0x591D50", Offset = "0x590750", VA = "0x180591D50")]
	public static bool ExistsDirectory(string path)
	{
		return default(bool);
	}

	[Token(Token = "0x6000F6B")]
	[Address(RVA = "0x591E60", Offset = "0x590860", VA = "0x180591E60")]
	public static string CreateDirectory(string path, string folderName)
	{
		return null;
	}

	[Token(Token = "0x6000F6C")]
	[Address(RVA = "0x5920A0", Offset = "0x590AA0", VA = "0x1805920A0")]
	public static bool CreateDirectory(string path)
	{
		return default(bool);
	}

	[Token(Token = "0x6000F6D")]
	[Address(RVA = "0x592240", Offset = "0x590C40", VA = "0x180592240")]
	public static string CreateFile(string path, string fileName)
	{
		return null;
	}

	[Token(Token = "0x6000F6E")]
	[Address(RVA = "0x592500", Offset = "0x590F00", VA = "0x180592500")]
	public static bool CreateFile(string path)
	{
		return default(bool);
	}

	[Token(Token = "0x6000F6F")]
	[Address(RVA = "0x5926F0", Offset = "0x5910F0", VA = "0x1805926F0")]
	public static bool isDirectory(string path, bool checkForExtensions = true)
	{
		return default(bool);
	}

	[Token(Token = "0x6000F70")]
	[Address(RVA = "0x592860", Offset = "0x591260", VA = "0x180592860")]
	public static bool isFile(string path, bool checkForExtensions = true)
	{
		return default(bool);
	}

	[Token(Token = "0x6000F71")]
	[Address(RVA = "0x592890", Offset = "0x591290", VA = "0x180592890")]
	public static string GetFileName(string path, bool removeInvalidChars = true)
	{
		return null;
	}

	[Token(Token = "0x6000F72")]
	[Address(RVA = "0x592E00", Offset = "0x591800", VA = "0x180592E00")]
	public static string GetCurrentDirectoryName(string path)
	{
		return null;
	}

	[Token(Token = "0x6000F73")]
	[Address(RVA = "0x593370", Offset = "0x591D70", VA = "0x180593370")]
	public static string GetDirectoryName(string path)
	{
		return null;
	}

	[Token(Token = "0x6000F74")]
	[Address(RVA = "0x593800", Offset = "0x592200", VA = "0x180593800")]
	public static long GetFilesize(string path)
	{
		return default(long);
	}

	[Token(Token = "0x6000F75")]
	[Address(RVA = "0x593A40", Offset = "0x592440", VA = "0x180593A40")]
	public static string GetExtension(string path)
	{
		return null;
	}

	[Token(Token = "0x6000F76")]
	[Address(RVA = "0x593C80", Offset = "0x592680", VA = "0x180593C80")]
	public static DateTime GetLastModifiedDate(string path)
	{
		return default(DateTime);
	}

	[Token(Token = "0x6000F77")]
	[Address(RVA = "0x594010", Offset = "0x592A10", VA = "0x180594010")]
	public static string ReadAllText(string sourceFile, [Optional] Encoding encoding)
	{
		return null;
	}

	[Token(Token = "0x6000F78")]
	[Address(RVA = "0x594310", Offset = "0x592D10", VA = "0x180594310")]
	public static string[] ReadAllLines(string sourceFile, [Optional] Encoding encoding)
	{
		return null;
	}

	[Token(Token = "0x6000F79")]
	[Address(RVA = "0x594610", Offset = "0x593010", VA = "0x180594610")]
	public static byte[] ReadAllBytes(string sourceFile)
	{
		return null;
	}

	[Token(Token = "0x6000F7A")]
	[Address(RVA = "0x5947F0", Offset = "0x5931F0", VA = "0x1805947F0")]
	public static bool WriteAllText(string destFile, string text, [Optional] Encoding encoding)
	{
		return default(bool);
	}

	[Token(Token = "0x6000F7B")]
	[Address(RVA = "0x5949C0", Offset = "0x5933C0", VA = "0x1805949C0")]
	public static bool WriteAllLines(string destFile, string[] lines, [Optional] Encoding encoding)
	{
		return default(bool);
	}

	[Token(Token = "0x6000F7C")]
	[Address(RVA = "0x594B80", Offset = "0x593580", VA = "0x180594B80")]
	public static bool WriteAllBytes(string destFile, byte[] data)
	{
		return default(bool);
	}

	[Token(Token = "0x6000F7D")]
	[Address(RVA = "0x594D90", Offset = "0x593790", VA = "0x180594D90")]
	public static bool ShowPath(string path)
	{
		return default(bool);
	}

	[Token(Token = "0x6000F7E")]
	[Address(RVA = "0x594DA0", Offset = "0x5937A0", VA = "0x180594DA0")]
	public static bool ShowFile(string file)
	{
		return default(bool);
	}

	[Token(Token = "0x6000F7F")]
	[Address(RVA = "0x5951A0", Offset = "0x593BA0", VA = "0x1805951A0")]
	public static bool OpenFile(string file)
	{
		return default(bool);
	}

	[Token(Token = "0x6000F80")]
	[Address(RVA = "0x5954B0", Offset = "0x593EB0", VA = "0x1805954B0")]
	[Obsolete("Please use 'HasPathInvalidChars' instead.")]
	public static bool PathHasInvalidChars(string path)
	{
		return default(bool);
	}

	[Token(Token = "0x6000F81")]
	[Address(RVA = "0x595530", Offset = "0x593F30", VA = "0x180595530")]
	[Obsolete("Please use 'HasFileInvalidChars' instead.")]
	public static bool FileHasInvalidChars(string file)
	{
		return default(bool);
	}

	[Token(Token = "0x6000F82")]
	[Address(RVA = "0x5955F0", Offset = "0x593FF0", VA = "0x1805955F0")]
	[Obsolete("Please use 'CopyDirectory' instead.")]
	public static bool CopyPath(string sourceDir, string destDir, bool move = false)
	{
		return default(bool);
	}

	[Token(Token = "0x6000F83")]
	[Address(RVA = "0x5912D0", Offset = "0x58FCD0", VA = "0x1805912D0")]
	[Obsolete("Please use 'MoveDirectory' instead.")]
	public static bool MovePath(string sourceDir, string destDir)
	{
		return default(bool);
	}

	[Token(Token = "0x6000F84")]
	[Address(RVA = "0x595600", Offset = "0x594000", VA = "0x180595600")]
	private static void copyAll(DirectoryInfo source, DirectoryInfo target)
	{
	}
}

using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using Crosstales.BWF.Data;
using Il2CppDummyDll;
using UnityEngine;

namespace Crosstales.BWF.Provider;

[Token(Token = "0x20001F7")]
[ExecuteInEditMode]
public abstract class BaseProvider : MonoBehaviour, IProvider
{
	[Token(Token = "0x4000A35")]
	[FieldOffset(Offset = "0x20")]
	[Header("Regex Options")]
	[Tooltip("Option1 (default: RegexOptions.IgnoreCase).")]
	public RegexOptions RegexOption1;

	[Token(Token = "0x4000A36")]
	[FieldOffset(Offset = "0x24")]
	[Tooltip("Option2 (default: RegexOptions.CultureInvariant).")]
	public RegexOptions RegexOption2;

	[Token(Token = "0x4000A37")]
	[FieldOffset(Offset = "0x28")]
	[Tooltip("Option3 (default: RegexOptions.None).")]
	public RegexOptions RegexOption3;

	[Token(Token = "0x4000A38")]
	[FieldOffset(Offset = "0x2C")]
	[Tooltip("Option4 (default: RegexOptions.None).")]
	public RegexOptions RegexOption4;

	[Token(Token = "0x4000A39")]
	[FieldOffset(Offset = "0x30")]
	[Tooltip("Option5 (default: RegexOptions.None).")]
	public RegexOptions RegexOption5;

	[Token(Token = "0x4000A3A")]
	[FieldOffset(Offset = "0x38")]
	[Header("Sources")]
	[Tooltip("All sources for this provider.")]
	[ContextMenuItem("Create Source", "createSource")]
	public List<Source> Sources;

	[Token(Token = "0x4000A3B")]
	[FieldOffset(Offset = "0x40")]
	[Header("Load Behaviour")]
	[Tooltip("Clears all existing bad words on 'Load' (default: true).")]
	public bool ClearOnLoad;

	[Token(Token = "0x4000A3C")]
	[FieldOffset(Offset = "0x48")]
	protected readonly List<string> coRoutines;

	[Token(Token = "0x4000A3D")]
	[FieldOffset(Offset = "0x50")]
	protected bool _loading;

	[Token(Token = "0x17000152")]
	public int RegexCount
	{
		[Token(Token = "0x6001043")]
		[Address(RVA = "0x5A0FB0", Offset = "0x59F9B0", VA = "0x1805A0FB0")]
		get
		{
			return default(int);
		}
	}

	[Token(Token = "0x17000153")]
	public bool isReady
	{
		[Token(Token = "0x6001044")]
		[Address(RVA = "0x5A1120", Offset = "0x59FB20", VA = "0x1805A1120", Slot = "4")]
		[CompilerGenerated]
		get
		{
			return default(bool);
		}
		[Token(Token = "0x6001045")]
		[Address(RVA = "0x5A1130", Offset = "0x59FB30", VA = "0x1805A1130", Slot = "5")]
		[CompilerGenerated]
		set
		{
		}
	}

	[Token(Token = "0x6001046")]
	public abstract void Load();

	[Token(Token = "0x6001047")]
	public abstract void Save();

	[Token(Token = "0x6001048")]
	[Address(RVA = "0x5A1140", Offset = "0x59FB40", VA = "0x1805A1140", Slot = "8")]
	public List<string> Verify(Source source)
	{
		return null;
	}

	[Token(Token = "0x6001049")]
	protected abstract void init();

	[Token(Token = "0x600104A")]
	[Address(RVA = "0x5A1430", Offset = "0x59FE30", VA = "0x1805A1430")]
	private void Awake()
	{
	}

	[Token(Token = "0x600104B")]
	[Address(RVA = "0x5A1450", Offset = "0x59FE50", VA = "0x1805A1450")]
	protected void logNoResourcesAdded()
	{
	}

	[Token(Token = "0x600104C")]
	[Address(RVA = "0x4576C0", Offset = "0x4560C0", VA = "0x1804576C0")]
	protected void createSource()
	{
	}

	[Token(Token = "0x600104D")]
	[Address(RVA = "0x5A1590", Offset = "0x59FF90", VA = "0x1805A1590")]
	protected BaseProvider()
	{
	}
}

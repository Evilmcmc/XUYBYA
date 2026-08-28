using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using Crosstales.BWF.Data;
using Crosstales.BWF.Filter;
using Crosstales.BWF.Model.Enum;
using Crosstales.BWF.Provider;
using Il2CppDummyDll;
using UnityEngine;
using UnityEngine.Serialization;

namespace Crosstales.BWF.Manager;

[Token(Token = "0x2000203")]
[DisallowMultipleComponent]
[HelpURL("https://www.crosstales.com/media/data/assets/badwordfilter/api/class_crosstales_1_1_b_w_f_1_1_manager_1_1_bad_word_manager.html")]
public class BadWordManager : BaseManager<BadWordManager, BadWordFilter>
{
	[Token(Token = "0x4000A66")]
	[FieldOffset(Offset = "0x50")]
	[FormerlySerializedAs("ReplaceChars")]
	[Header("Specific Settings")]
	[Tooltip("Replace characters for bad words (default: *).")]
	[SerializeField]
	private string replaceChars;

	[Token(Token = "0x4000A67")]
	[FieldOffset(Offset = "0x58")]
	[Tooltip("Replace mode operations on the input string (default: Default).")]
	[SerializeField]
	private ReplaceMode mode;

	[Token(Token = "0x4000A68")]
	[FieldOffset(Offset = "0x5C")]
	[Tooltip("Remove unnecessary spaces between letters in the input string (default: false).")]
	[SerializeField]
	private bool removeSpaces;

	[Token(Token = "0x4000A69")]
	[FieldOffset(Offset = "0x60")]
	[Tooltip("Maximal text length for the space detection (default: 3).")]
	[SerializeField]
	private int maxTextLength;

	[Token(Token = "0x4000A6A")]
	[FieldOffset(Offset = "0x68")]
	public string removeChars;

	[Token(Token = "0x4000A6B")]
	[FieldOffset(Offset = "0x70")]
	[FormerlySerializedAs("SimpleCheck")]
	[Tooltip("Use simple detection algorithm. This is the way to check for Chinese, Japanese, Korean and Thai bad words (default: false).")]
	[SerializeField]
	private bool simpleCheck;

	[Token(Token = "0x4000A6C")]
	[FieldOffset(Offset = "0x78")]
	[FormerlySerializedAs("BadWordProviderLTR")]
	[Header("Bad Word Providers")]
	[Tooltip("List of all left-to-right providers.")]
	[SerializeField]
	private List<BadWordProvider> badWordProviderLTR;

	[Token(Token = "0x4000A6D")]
	[FieldOffset(Offset = "0x80")]
	[FormerlySerializedAs("BadWordProviderRTL")]
	[Tooltip("List of all right-to-left providers.")]
	[SerializeField]
	private List<BadWordProvider> badWordProviderRTL;

	[Token(Token = "0x4000A6E")]
	[FieldOffset(Offset = "0x88")]
	[Header("Events")]
	public OnContainsCompleted OnContainsCompleted;

	[Token(Token = "0x4000A6F")]
	[FieldOffset(Offset = "0x90")]
	public OnGetAllCompleted OnGetAllCompleted;

	[Token(Token = "0x4000A70")]
	[FieldOffset(Offset = "0x98")]
	public OnReplaceAllCompleted OnReplaceAllCompleted;

	[Token(Token = "0x4000A71")]
	[FieldOffset(Offset = "0xA0")]
	private Thread _worker;

	[Token(Token = "0x1700015B")]
	public string ReplaceChars
	{
		[Token(Token = "0x600107C")]
		[Address(RVA = "0x5A5280", Offset = "0x5A3C80", VA = "0x1805A5280")]
		get
		{
			return null;
		}
		[Token(Token = "0x600107D")]
		[Address(RVA = "0x5A52A0", Offset = "0x5A3CA0", VA = "0x1805A52A0")]
		set
		{
		}
	}

	[Token(Token = "0x1700015C")]
	public ReplaceMode Mode
	{
		[Token(Token = "0x600107E")]
		[Address(RVA = "0x5A5370", Offset = "0x5A3D70", VA = "0x1805A5370")]
		get
		{
			return default(ReplaceMode);
		}
		[Token(Token = "0x600107F")]
		[Address(RVA = "0x5A5390", Offset = "0x5A3D90", VA = "0x1805A5390")]
		set
		{
		}
	}

	[Token(Token = "0x1700015D")]
	public bool RemoveSpaces
	{
		[Token(Token = "0x6001080")]
		[Address(RVA = "0x5A53B0", Offset = "0x5A3DB0", VA = "0x1805A53B0")]
		get
		{
			return default(bool);
		}
		[Token(Token = "0x6001081")]
		[Address(RVA = "0x5A53D0", Offset = "0x5A3DD0", VA = "0x1805A53D0")]
		set
		{
		}
	}

	[Token(Token = "0x1700015E")]
	public int MaxTextLength
	{
		[Token(Token = "0x6001082")]
		[Address(RVA = "0x5A53F0", Offset = "0x5A3DF0", VA = "0x1805A53F0")]
		get
		{
			return default(int);
		}
		[Token(Token = "0x6001083")]
		[Address(RVA = "0x5A5410", Offset = "0x5A3E10", VA = "0x1805A5410")]
		set
		{
		}
	}

	[Token(Token = "0x1700015F")]
	public string RemoveChars
	{
		[Token(Token = "0x6001084")]
		[Address(RVA = "0x5A5430", Offset = "0x5A3E30", VA = "0x1805A5430")]
		get
		{
			return null;
		}
		[Token(Token = "0x6001085")]
		[Address(RVA = "0x5A5450", Offset = "0x5A3E50", VA = "0x1805A5450")]
		set
		{
		}
	}

	[Token(Token = "0x17000160")]
	public bool SimpleCheck
	{
		[Token(Token = "0x6001086")]
		[Address(RVA = "0x5A5520", Offset = "0x5A3F20", VA = "0x1805A5520")]
		get
		{
			return default(bool);
		}
		[Token(Token = "0x6001087")]
		[Address(RVA = "0x5A5540", Offset = "0x5A3F40", VA = "0x1805A5540")]
		set
		{
		}
	}

	[Token(Token = "0x17000161")]
	public List<BadWordProvider> BadWordProviderLTR
	{
		[Token(Token = "0x6001088")]
		[Address(RVA = "0x5415D0", Offset = "0x53FFD0", VA = "0x1805415D0")]
		get
		{
			return null;
		}
		[Token(Token = "0x6001089")]
		[Address(RVA = "0x5415E0", Offset = "0x53FFE0", VA = "0x1805415E0")]
		set
		{
		}
	}

	[Token(Token = "0x17000162")]
	public List<BadWordProvider> BadWordProviderRTL
	{
		[Token(Token = "0x600108A")]
		[Address(RVA = "0x49DF40", Offset = "0x49C940", VA = "0x18049DF40")]
		get
		{
			return null;
		}
		[Token(Token = "0x600108B")]
		[Address(RVA = "0x49DF50", Offset = "0x49C950", VA = "0x18049DF50")]
		set
		{
		}
	}

	[Token(Token = "0x17000163")]
	public List<Source> Sources
	{
		[Token(Token = "0x600108C")]
		[Address(RVA = "0x5A5560", Offset = "0x5A3F60", VA = "0x1805A5560")]
		get
		{
			return null;
		}
	}

	[Token(Token = "0x17000164")]
	public int TotalRegexCount
	{
		[Token(Token = "0x600108D")]
		[Address(RVA = "0x5A5580", Offset = "0x5A3F80", VA = "0x1805A5580")]
		get
		{
			return default(int);
		}
	}

	[Token(Token = "0x17000165")]
	protected override OnContainsCompleted onContainsCompleted
	{
		[Token(Token = "0x600108E")]
		[Address(RVA = "0x49DFB0", Offset = "0x49C9B0", VA = "0x18049DFB0", Slot = "7")]
		get
		{
			return null;
		}
	}

	[Token(Token = "0x17000166")]
	protected override OnGetAllCompleted onGetAllCompleted
	{
		[Token(Token = "0x600108F")]
		[Address(RVA = "0x49E020", Offset = "0x49CA20", VA = "0x18049E020", Slot = "8")]
		get
		{
			return null;
		}
	}

	[Token(Token = "0x17000167")]
	protected override OnReplaceAllCompleted onReplaceAllCompleted
	{
		[Token(Token = "0x6001090")]
		[Address(RVA = "0x49E090", Offset = "0x49CA90", VA = "0x18049E090", Slot = "9")]
		get
		{
			return null;
		}
	}

	[Token(Token = "0x6001091")]
	[Address(RVA = "0x5A5730", Offset = "0x5A4130", VA = "0x1805A5730", Slot = "4")]
	protected override void Awake()
	{
	}

	[Token(Token = "0x6001092")]
	[Address(RVA = "0x5A58B0", Offset = "0x5A42B0", VA = "0x1805A58B0")]
	private void OnValidate()
	{
	}

	[Token(Token = "0x6001093")]
	[Address(RVA = "0x5A5B30", Offset = "0x5A4530", VA = "0x1805A5B30", Slot = "6")]
	protected override void OnApplicationQuit()
	{
	}

	[Token(Token = "0x6001094")]
	[Address(RVA = "0x5A5BC0", Offset = "0x5A45C0", VA = "0x1805A5BC0")]
	public static void ResetObject()
	{
	}

	[Token(Token = "0x6001095")]
	[Address(RVA = "0x5A5C20", Offset = "0x5A4620", VA = "0x1805A5C20")]
	public void Load()
	{
	}

	[Token(Token = "0x6001096")]
	[Address(RVA = "0x5A5D90", Offset = "0x5A4790", VA = "0x1805A5D90")]
	public bool Contains(string text, params string[] sourceNames)
	{
		return default(bool);
	}

	[Token(Token = "0x6001097")]
	[Address(RVA = "0x5A5DC0", Offset = "0x5A47C0", VA = "0x1805A5DC0")]
	public void ContainsAsync(string text, params string[] sourceNames)
	{
	}

	[Token(Token = "0x6001098")]
	[Address(RVA = "0x5A5F30", Offset = "0x5A4930", VA = "0x1805A5F30")]
	public List<string> GetAll(string text, params string[] sourceNames)
	{
		return null;
	}

	[Token(Token = "0x6001099")]
	[Address(RVA = "0x5A5FF0", Offset = "0x5A49F0", VA = "0x1805A5FF0")]
	public void GetAllAsync(string text, params string[] sourceNames)
	{
	}

	[Token(Token = "0x600109A")]
	[Address(RVA = "0x5A6160", Offset = "0x5A4B60", VA = "0x1805A6160")]
	public string ReplaceAll(string text, bool markOnly = false, string prefix = "", string postfix = "", params string[] sourceNames)
	{
		return null;
	}

	[Token(Token = "0x600109B")]
	[Address(RVA = "0x5A61B0", Offset = "0x5A4BB0", VA = "0x1805A61B0")]
	public void ReplaceAllAsync(string text, bool markOnly = false, string prefix = "", string postfix = "", params string[] sourceNames)
	{
	}

	[Token(Token = "0x600109C")]
	[Address(RVA = "0x5A61F0", Offset = "0x5A4BF0", VA = "0x1805A61F0")]
	public string Mark(string text, bool replace = false, string prefix = "<b><color=red>", string postfix = "</color></b>", params string[] sourceNames)
	{
		return null;
	}

	[Token(Token = "0x600109D")]
	[Address(RVA = "0x5A6240", Offset = "0x5A4C40", VA = "0x1805A6240")]
	[IteratorStateMachine(typeof(_003CcontainsAsync_003Ed__58))]
	private IEnumerator containsAsync(string text, params string[] sourceNames)
	{
		return null;
	}

	[Token(Token = "0x600109E")]
	[Address(RVA = "0x5A63A0", Offset = "0x5A4DA0", VA = "0x1805A63A0")]
	[IteratorStateMachine(typeof(_003CgetAllAsync_003Ed__59))]
	private IEnumerator getAllAsync(string text, params string[] sourceNames)
	{
		return null;
	}

	[Token(Token = "0x600109F")]
	[Address(RVA = "0x5A6500", Offset = "0x5A4F00", VA = "0x1805A6500")]
	[IteratorStateMachine(typeof(_003CreplaceAllAsync_003Ed__60))]
	private IEnumerator replaceAllAsync(string text, bool markOnly = false, string prefix = "", string postfix = "", params string[] sourceNames)
	{
		return null;
	}

	[Token(Token = "0x60010A0")]
	[Address(RVA = "0x5A6710", Offset = "0x5A5110", VA = "0x1805A6710")]
	public BadWordManager()
	{
	}
}

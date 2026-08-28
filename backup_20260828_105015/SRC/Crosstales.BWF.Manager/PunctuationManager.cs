using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using Crosstales.BWF.Filter;
using Il2CppDummyDll;
using UnityEngine;
using UnityEngine.Serialization;

namespace Crosstales.BWF.Manager;

[Token(Token = "0x200021B")]
[DisallowMultipleComponent]
[HelpURL("https://www.crosstales.com/media/data/assets/badwordfilter/api/class_crosstales_1_1_b_w_f_1_1_manager_1_1_punctuation_manager.html")]
public class PunctuationManager : BaseManager<PunctuationManager, PunctuationFilter>
{
	[Token(Token = "0x4000AEC")]
	[FieldOffset(Offset = "0x50")]
	[FormerlySerializedAs("PunctuationCharsNumber")]
	[Header("Specific Settings")]
	[Tooltip("Defines the number of allowed punctuation letters in a row (default: 3).")]
	[SerializeField]
	private int punctuationCharsNumber;

	[Token(Token = "0x4000AED")]
	[FieldOffset(Offset = "0x58")]
	[Header("Events")]
	public OnContainsCompleted OnContainsCompleted;

	[Token(Token = "0x4000AEE")]
	[FieldOffset(Offset = "0x60")]
	public OnGetAllCompleted OnGetAllCompleted;

	[Token(Token = "0x4000AEF")]
	[FieldOffset(Offset = "0x68")]
	public OnReplaceAllCompleted OnReplaceAllCompleted;

	[Token(Token = "0x4000AF0")]
	[FieldOffset(Offset = "0x70")]
	private Thread _worker;

	[Token(Token = "0x1700018A")]
	public int PunctuationCharsNumber
	{
		[Token(Token = "0x600112F")]
		[Address(RVA = "0x5AB630", Offset = "0x5AA030", VA = "0x1805AB630")]
		get
		{
			return default(int);
		}
		[Token(Token = "0x6001130")]
		[Address(RVA = "0x5AB650", Offset = "0x5AA050", VA = "0x1805AB650")]
		set
		{
		}
	}

	[Token(Token = "0x1700018B")]
	protected override OnContainsCompleted onContainsCompleted
	{
		[Token(Token = "0x6001131")]
		[Address(RVA = "0x5A7900", Offset = "0x5A6300", VA = "0x1805A7900", Slot = "7")]
		get
		{
			return null;
		}
	}

	[Token(Token = "0x1700018C")]
	protected override OnGetAllCompleted onGetAllCompleted
	{
		[Token(Token = "0x6001132")]
		[Address(RVA = "0x59E250", Offset = "0x59CC50", VA = "0x18059E250", Slot = "8")]
		get
		{
			return null;
		}
	}

	[Token(Token = "0x1700018D")]
	protected override OnReplaceAllCompleted onReplaceAllCompleted
	{
		[Token(Token = "0x6001133")]
		[Address(RVA = "0x59E2C0", Offset = "0x59CCC0", VA = "0x18059E2C0", Slot = "9")]
		get
		{
			return null;
		}
	}

	[Token(Token = "0x6001134")]
	[Address(RVA = "0x5AB690", Offset = "0x5AA090", VA = "0x1805AB690", Slot = "4")]
	protected override void Awake()
	{
	}

	[Token(Token = "0x6001135")]
	[Address(RVA = "0x5AB810", Offset = "0x5AA210", VA = "0x1805AB810", Slot = "6")]
	protected override void OnApplicationQuit()
	{
	}

	[Token(Token = "0x6001136")]
	[Address(RVA = "0x5AB890", Offset = "0x5AA290", VA = "0x1805AB890")]
	private void OnValidate()
	{
	}

	[Token(Token = "0x6001137")]
	[Address(RVA = "0x5AB8E0", Offset = "0x5AA2E0", VA = "0x1805AB8E0")]
	public static void ResetObject()
	{
	}

	[Token(Token = "0x6001138")]
	[Address(RVA = "0x5AB940", Offset = "0x5AA340", VA = "0x1805AB940")]
	public void Load()
	{
	}

	[Token(Token = "0x6001139")]
	[Address(RVA = "0x5ABA20", Offset = "0x5AA420", VA = "0x1805ABA20")]
	public bool Contains(string text)
	{
		return default(bool);
	}

	[Token(Token = "0x600113A")]
	[Address(RVA = "0x5ABAB0", Offset = "0x5AA4B0", VA = "0x1805ABAB0")]
	public void ContainsAsync(string text)
	{
	}

	[Token(Token = "0x600113B")]
	[Address(RVA = "0x5ABBC0", Offset = "0x5AA5C0", VA = "0x1805ABBC0")]
	public List<string> GetAll(string text)
	{
		return null;
	}

	[Token(Token = "0x600113C")]
	[Address(RVA = "0x5ABCB0", Offset = "0x5AA6B0", VA = "0x1805ABCB0")]
	public void GetAllAsync(string text)
	{
	}

	[Token(Token = "0x600113D")]
	[Address(RVA = "0x5ABDC0", Offset = "0x5AA7C0", VA = "0x1805ABDC0")]
	public string ReplaceAll(string text, bool markOnly = false, string prefix = "", string postfix = "")
	{
		return null;
	}

	[Token(Token = "0x600113E")]
	[Address(RVA = "0x5ABE70", Offset = "0x5AA870", VA = "0x1805ABE70")]
	public void ReplaceAllAsync(string text, bool markOnly = false, string prefix = "", string postfix = "")
	{
	}

	[Token(Token = "0x600113F")]
	[Address(RVA = "0x5ABEB0", Offset = "0x5AA8B0", VA = "0x1805ABEB0")]
	public string Mark(string text, bool replace = false, string prefix = "<b><color=red>", string postfix = "</color></b>")
	{
		return null;
	}

	[Token(Token = "0x6001140")]
	[Address(RVA = "0x5ABF60", Offset = "0x5AA960", VA = "0x1805ABF60")]
	[IteratorStateMachine(typeof(_003CcontainsAsync_003Ed__26))]
	private IEnumerator containsAsync(string text)
	{
		return null;
	}

	[Token(Token = "0x6001141")]
	[Address(RVA = "0x5AC060", Offset = "0x5AAA60", VA = "0x1805AC060")]
	[IteratorStateMachine(typeof(_003CgetAllAsync_003Ed__27))]
	private IEnumerator getAllAsync(string text)
	{
		return null;
	}

	[Token(Token = "0x6001142")]
	[Address(RVA = "0x5AC160", Offset = "0x5AAB60", VA = "0x1805AC160")]
	[IteratorStateMachine(typeof(_003CreplaceAllAsync_003Ed__28))]
	private IEnumerator replaceAllAsync(string text, bool markOnly = false, string prefix = "", string postfix = "")
	{
		return null;
	}

	[Token(Token = "0x6001143")]
	[Address(RVA = "0x5AC320", Offset = "0x5AAD20", VA = "0x1805AC320")]
	public PunctuationManager()
	{
	}
}
